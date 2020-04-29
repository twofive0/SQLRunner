'
' Created by SharpDevelop.
' User: Devin
' Date: 5/29/2013
' Time: 8:59 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
Imports System.Data.SQLite
Imports System.Data.OleDb
Imports System.Data
Imports SevenZip.SevenZipExtractor


Public Class SQLiteConvert
	
	Public ds As DataSet
	Public sqliteConn As SQLite.SQLiteConnection
	
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		ds = New DataSet
		sqliteConn = New SQLiteConnection
				
	End Sub
	
		Sub BtnSelectSourceClick(sender As Object, e As EventArgs)
		
		Dim fd As New OpenFileDialog
		
		With fd
			.Filter = "Multiset File (*.7z)|*.7z|All files (*.*)|*.*"
			.Multiselect = False
			.ShowDialog
		End With
		
		Me.txtSourceFile.text = fd.FileName
		
	End Sub
	
	
	
	Sub BtnSelectTargetClick(sender As Object, e As EventArgs)
		
		Dim fd As New SaveFileDialog
		
		With fd
			.Filter = "SQLite 3 Database (*.s3db)|*.s3db|All files (*.*)|*.*"
			.ShowDialog
		End With
		
		If fd.FileName.ToString.Length < 1 Then Exit Sub
		
		Me.txtTargetFile.text = fd.FileName
	
		
	End Sub
	
	Sub importData
		
		Me.backgroundWorker1.ReportProgress(0,"Clearing Temp Dir")
		createTempDir
		Me.backgroundWorker1.ReportProgress(0,"Decompressing Files")
		unzipToTemp
		Me.backgroundWorker1.ReportProgress(0,"Importing Data")
		grabTables
		If Not IO.File.Exists(Me.txtTargetFile.text) Then
			Try
				SQLiteConnection.CreateFile(Me.txtTargetFile.Text)
	        Catch ex As Exception
	            Me.backgroundWorker1.ReportProgress(0, "Couldn't create SQLite 3 database" & ex.Message)
	        End Try
		End If
		
		sendToSQLite
		'ds.WriteXml("c:\users\devin\desktop\fart2.xml",XmlWriteMode.WriteSchema)
		cleanUp
		
		Me.backgroundWorker1.ReportProgress(0, "Last save @ " & Now)
		
	End Sub
	
	Sub sendToSQLite
		
		For Each tbl As DataTable In ds.Tables
			CopyToSQLite(tbl, Me.txtTargetFile.text)
		Next
		
		
	End Sub
	
	Private Sub CopyToSQLite(byref source As DataTable, target As string)
		
		Me.backgroundWorker1.ReportProgress(0,"Saving to SQLite")
		
		Dim rowCtr As Integer = 0
			
		Try
			Dim connString As String = "Data Source =" & Me.txtTargetFile.text & ";Version=3;"
		    Dim sqlConnection As New SQLiteConnection(connString)
		    Dim addTblCommand As String = createMakeSQLiteTableCmd(source)
		    Dim sqliteCommand As New SQLiteCommand(addTblCommand, sqlConnection)
		    Dim sqliteCommand2 As New SQLiteCommand("",sqlConnection)
		    sqlConnection.Open
		    sqliteCommand.ExecuteNonQuery
		    For Each dtRow As DataRow In source.Rows
		    	sqliteCommand2.CommandText = createInsertSQLiteDataCmd(source.TableName.ToString, dtRow)
		    	sqliteCommand2.ExecuteNonQuery
		    	Me.backgroundWorker1.ReportProgress((rowCtr/source.Rows.Count)*100, "Saving to SQLite: " & source.TableName.tostring)
		    	rowCtr += 1
		    Next
		    sqlConnection.Close
		Catch ex As Exception
			Me.backgroundWorker1.ReportProgress(0, "Error Saving to SQLite: " & ex.Message) 
	    End Try
	    
    End Sub
	
	Sub grabTables
		
		Dim fNameSchema As String
		Dim fNameData As String
		Dim tName As String
		Dim dt As DataTable
		
		Try
			For Each f As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath & "SQLRunnerTemp","*.xsd")
				tName = System.IO.Path.GetFileNameWithoutExtension(f).Replace(".txt","")
				fNameSchema = f
				fNameData = f.Replace(".xsd", "")
				dt = New DataTable(tName)
				dt.ReadXmlSchema(f)
				readDataIntoTable(dt, fNameData)
				ds.Tables.Add(dt)
				ds.AcceptChanges
			next			
		Catch ex As Exception
			Me.backgroundWorker1.ReportProgress(0, "Error grabbing text files: " & ex.Message)
		End Try

		
		
	End Sub
		
	Sub readDataIntoTable(byref dt As DataTable, fName As String)
		
		Dim sReader As New IO.StreamReader(fName)
		Dim columnsTxt() As String
		Dim drTemp As DataRow
		Dim cnt As Integer = 0
		
		'dump the header
		sReader.ReadLine()
		
		While Not sReader.EndOfStream
			
			'TODO : This line is removing double quotes in strings!!
			'read a line of txt, this line is removing double quotes!!
			columnsTxt = sReader.ReadLine().Replace("""","").Split("¶")
			drTemp = dt.NewRow
			cnt = 0
			'add each column of data to row
			For Each tmp As String In columnsTxt
				If tmp = "" Then
					drTemp.Item(cnt) = DBNull.Value
				Else
					drTemp.Item(cnt) = CTypeDynamic(tmp,dt.Columns(cnt).DataType)					
				End If
				cnt = cnt + 1
			Next
			
			'add row to table
			dt.Rows.Add(drTemp)
			
		End While
		
		
			
	End Sub
		
	
	Sub unzipToTemp
		
		Dim sz As New SevenZip.SevenZipExtractor(Me.txtSourceFile.Text)
		
		sz.ExtractArchive(System.IO.Path.GetTempPath & "\SQLRunnerTemp")
		
	End Sub
	
	Sub createTempDir
		
	 	Try
        	System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath & "\SQLRunnerTemp")
 			For Each foundFile As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath & "SQLRunnerTemp", "*.*")
   				System.IO.File.Delete(foundFile)
			Next
        Catch ex1 As Exception
        	Me.backgroundWorker1.ReportProgress(0, "Unable to write to temp directory!" & ex1.Message)
        	Exit Sub
        End Try
        
	End Sub
	
	Sub BtnGoClick(sender As Object, e As EventArgs)
		
		'MsgBox("not implemented!")
		importData
		'Me.backgroundWorker1.RunWorkerAsync
		
	End Sub
	
	Sub cleanUp
		
		ds.reset
		Try
			For Each foundFile As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath & "SQLRunnerTemp", "*.*")
				System.IO.File.Delete(foundFile)
			Next
		Catch ex As Exception
		End Try
		
		Me.txtStatus.Text = "Last process completed @" & Now
		
	End Sub
	
	Function createMakeSQLiteTableCmd(ByRef dt As DataTable) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "CREATE TABLE [" & dt.TableName.ToString & "] ("
		
		For Each clm As DataColumn In dt.Columns
			tmpCmdString = tmpCmdString & "[" & clm.ColumnName.ToString & "] "
			Select Case clm.DataType.ToString
				Case "System.Integer"
					tmpCmdString = tmpCmdString & "DOUBLE, "
				Case "System.Int32"
					tmpCmdString = tmpCmdString & "DOUBLE, "
				Case "System.Double"
					tmpCmdString = tmpCmdString & "DOUBLE, "
				Case "System.Int16"
					tmpCmdString = tmpCmdString & "INTEGER, "
				Case "System.Int64"
					tmpCmdString = tmpCmdString & "DOUBLE, "
				Case "System.String"
					tmpCmdString = tmpCmdString & "TEXT, "
				Case "System.DateTime"
					tmpCmdString = tmpCmdString & "DATETIME, "
				Case "System.Boolean"
					tmpCmdString = tmpCmdString & "BOOLEAN, "
				Case Else
					tmpCmdString = tmpCmdString & "TEXT, "
			End Select
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		
		tmpCmdString = tmpCmdString + ")"
		
		createMakeSQLiteTableCmd = tmpCmdString
		
	End Function
	
	Function createInsertSQLiteDataCmd(tableName As String, ByRef dr As DataRow) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "INSERT INTO [" & tableName & "] VALUES("
		
		For Each itm As Object In dr.ItemArray		
			Select Case itm.GetType.ToString
				Case "System.Integer"
					tmpCmdString = tmpCmdString & itm.ToString & ", "
				Case "System.Double"
					tmpCmdString = tmpCmdString & itm.ToString & ", "					
				Case "System.Int32"
					tmpCmdString = tmpCmdString & itm.ToString & ", "
				Case "System.Int16"
					tmpCmdString = tmpCmdString & itm.ToString & ", "
				Case "System.Int64"
					tmpCmdString = tmpCmdString & itm.ToString & ", "
				Case "System.String"
					tmpCmdString = tmpCmdString & Chr(39) & itm.ToString.Replace("'","''") & Chr(39) & ", "
				Case "System.DateTime"
					tmpCmdString = tmpCmdString & Chr(39) & itm.ToString.Replace("'","''") & Chr(39) & ", "
				Case "System.Boolean"
					If itm.ToString = "True"
						tmpCmdString = tmpCmdString & "1, "
					Else
						tmpCmdString = tmpCmdString & "0, "
					End if
				Case Else
					tmpCmdString = tmpCmdString & "NULL, "
			End Select
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		
		tmpCmdString = tmpCmdString + ")"
		
		createInsertSQLiteDataCmd = tmpCmdString
		
	End Function
	
	
	Sub BackgroundWorker1ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
		
		If Not Me.txtStatus.Text.Contains("Error") Then
			Me.pbProgress.Value = e.ProgressPercentage
			Me.txtStatus.Text = e.UserState
			Me.Refresh
		Else
			Me.pbProgress.Value = 0
			Me.txtStatus.Text = "Error: " & e.UserState
			Me.Refresh
		End If

		
	End Sub
	
	Sub BackgroundWorker1DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
		
		importData
		
	End Sub
	

End Class

