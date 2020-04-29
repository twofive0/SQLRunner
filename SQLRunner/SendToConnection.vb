'
' Created by SharpDevelop.
' User: Devin
' Date: 8/16/2013
' Time: 1:10 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.Data.SQLite

Public Partial Class SendToConnection

	Private tblSources As Data.DataTable
	private tblListTable As DataTable
	Private ds As DataSet
	Private dt As DataTable
	
	'SQL Server connection objects
    Private dbConect As SqlClient.SqlConnection
    Private sqlCommand As SqlClient.SqlCommand
    Private tblListCommand As SqlClient.SqlCommand
    Friend WithEvents sqlDA As SqlClient.SqlDataAdapter
    Private sqlDATableList As SqlClient.SqlDataAdapter

    'SQL Server CE connection objects
    Private ceConect As SqlCeConnection
    Private ceCommand As SqlCeCommand
    Private tblCEListCommand As SqlCeCommand
    Friend WithEvents CEDA As SqlCeDataAdapter
    Private CETableList As SqlCeDataAdapter
    
    'SQLite connection objects
    Private sqliteConnect As SQLiteConnection
    Private sqliteCommand As SQLiteCommand
    Private tblSQLiteListCommand As SQLiteCommand
    Friend WithEvents sqliteDA As SQLiteDataAdapter
    Private sqliteTableList As SQLiteDataAdapter
    
    'Selected DB Props
    Private ConnType As String
    Private ServerName As String
    Private DatabaseName As String
    Private UserName As String
    Private PW As String
    Private FileName As String
    Private FilePW As String
    Private xferTableName As string
    
		
	Public Sub New(byref tblData As DataTable)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		ds = New DataSet
		tblListTable = New DataTable
		dt = tblData
		
		Try
			ds.ReadXmlSchema(AppDomain.CurrentDomain.BaseDirectory & "SavedConnections.xsd")
			tblSources = ds.Tables("Connections")
			tblSources.ReadXml(AppDomain.CurrentDomain.BaseDirectory & "SavedConnections.xml")
		Catch ex As Exception
			'if we can't load, no biggie
		End Try
		
		'setup binding
		Me.lstConnections.DataSource = tblSources
		Me.lstConnections.DisplayMember = "ConnectionName"
		Me.lstConnections.ValueMember = "ConnectionName"

		
	End Sub
	
	Sub BtnSendClick(sender As Object, e As EventArgs)
		
				
		getDBConnProps
		
		xferTableName = InputBox("Enter the table name you would like to transfer to","Table Name")
		
		'SendData
		backgroundWorker1.RunWorkerAsync
		
	
	End Sub
	
	Sub SendData

		
		Select Case ConnType
			Case "SQL Server"
				CopyToSQL(DoesTableExistSQL, dt)
			Case "SQL Compact (SDF)"
				CopyToSQLCE(doesTableExistSQLCE, dt)
			Case "SQLite"				
				If Not IO.File.Exists(FileName) Then
					Try
						SQLiteConnection.CreateFile(FileName)
			        Catch ex As Exception
			            Me.backgroundWorker1.ReportProgress(0, "Couldn't create SQLite 3 database" & ex.Message)
			        End Try
				End If
				CopyToSQLite(DoesTableExistSQLite, dt, FileName)
				
		End Select
		
	End Sub
	
	Private Sub getDBConnProps
		
		'that's not what your mother said last night, Trebek!
		Dim rowSet() As DataRow
		
		rowSet = tblSources.Select("ConnectionName = '" & Me.lstConnections.Text & "'")
		
		ConnType = rowSet(0).Item("DBType")
    	ServerName = rowSet(0).Item("Server")
     	DatabaseName = rowSet(0).Item("Database")
     	UserName = rowSet(0).Item("User")
     	PW = rowSet(0).Item("Password")
     	FileName = rowSet(0).Item("Path")
     	FilePW = rowSet(0).Item("FilePassword")
		
	End Sub
	
    

    
#region "SQLite"
    
    Private function DoesTableExistSQLite As Boolean

		DoesTableExistSQLite = False

		Try
			Dim connString As String
			If FilePW = Nothing Then
	            connString = "Data Source =" & FileName & ";Version=3;DateTimeFormat=CurrentCulture;"
	        Else
	            connString = "Data Source =" & FileName & ";Version=3;Password =" & FilePW & ";DateTimeFormat=CurrentCulture;"
	        End If
		    Dim sqliteConnect As New SQLiteConnection(connString)
			sqliteDA = New SqliteDataAdapter("SELECT name FROM sqlite_master WHERE type='table' and name = '" & xferTableName & "'", sqliteConnect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            sqliteDA.Fill(tblListTable)
            
            If tblListTable.Rows.Count > 0 Then DoesTableExistSQLite = True
           
		Catch ex As Exception
			MsgBox(ex.Message)
        End Try
        
      End Function
        
	
	Private Sub CopyToSQLite(tableExists as boolean, byref source As DataTable, target As string)
		
		Me.backgroundWorker1.ReportProgress(0,"Saving to SQLite")
		
		Dim rowCtr As Integer = 0
			
		Try
			Dim connString As String = "Data Source =" & FileName & ";Version=3;"
		    Dim sqlConnection As New SQLiteConnection(connString)
		    Dim addTblCommand As String = createMakeSQLiteTableCmd(source)
		    Dim sqliteCommand As New SQLiteCommand(addTblCommand, sqlConnection)
		    Dim sqliteCommand2 As New SQLiteCommand("",sqlConnection)
		    sqlConnection.Open
		    if not DoesTableExistSQLite then sqliteCommand.ExecuteNonQuery
		    For Each dtRow As DataRow In source.Rows
		    	sqliteCommand2.CommandText = createInsertSQLiteDataCmd(xferTableName, dtRow)
		    	sqliteCommand2.ExecuteNonQuery
		    	Me.backgroundWorker1.ReportProgress((rowCtr/source.Rows.Count)*100, "Saving to SQLite: " & xferTableName)
		    	rowCtr += 1
		    Next
		    sqlConnection.Close
		Catch ex As Exception
			Me.backgroundWorker1.ReportProgress(0, "Error Saving to SQLite: " & ex.Message) 
	    End Try
	    
	End Sub
	
	Function createMakeSQLiteTableCmd(ByRef dt As DataTable) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "CREATE TABLE [" & xferTableName & "] ("
		
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
		
		tmpCmdString = "INSERT INTO [" & tableName & "]("
		
		For Each col As DataColumn In dr.Table.Columns
			tmpCmdString = tmpCmdString + col.ColumnName & ", "
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		tmpCmdString = tmpCmdString + ") VALUES("
		
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
	
#End Region
	
#region "MSSQL"
    
    Private function DoesTableExistSQL As Boolean

		DoesTableExistSQL = False

		Try
			Dim connString As String
            connString = "Data Source =" & ServerName & "; Initial Catalog =" & DatabaseName & "; User Id =" & UserName & "; Password =" & PW & "; "
		    Dim sqlConnect As New SqlConnection(connString)
			sqlDA = New SqlDataAdapter("SELECT TABLE_NAME AS name FROM information_schema.TABLES where TABLE_NAME = '" & xferTableName & "'", sqlConnect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            sqlDA.Fill(tblListTable)
            
            If tblListTable.Rows.Count > 0 Then DoesTableExistSQL = True
           
		Catch ex As Exception
			MsgBox(ex.Message)
        End Try
        
      End Function
        
	
	Private Sub CopyToSQL(tableExists as boolean, byref source As DataTable)
		
		Me.backgroundWorker1.ReportProgress(0,"Saving to SQL")
		
		Dim rowCtr As Integer = 0
			
		Try
			Dim connString As String = "Data Source =" & ServerName & "; Initial Catalog =" & DatabaseName & "; User Id =" & UserName & "; Password =" & PW & "; "
		    Dim sqlConnection As New SQLConnection(connString)
		    Dim addTblCommand As String = createMakeSQLTableCmd(source)
		    Dim sqlCommand As New SQLCommand(addTblCommand, sqlConnection)
		    Dim sqlCommand2 As New SQLCommand("",sqlConnection)
		    sqlConnection.Open
		    if not DoesTableExistSQL then sqlCommand.ExecuteNonQuery
		    For Each dtRow As DataRow In source.Rows
		    	sqlCommand2.CommandText = createInsertSQLDataCmd(xferTableName, dtRow)
		    	sqlCommand2.ExecuteNonQuery
		    	Me.backgroundWorker1.ReportProgress((rowCtr/source.Rows.Count)*100, "Saving to SQL: " & xferTableName)
		    	rowCtr += 1
		    Next
		    sqlConnection.Close
		Catch ex As Exception
			Me.backgroundWorker1.ReportProgress(0, "Error Saving to SQL: " & ex.Message) 
	    End Try
	    
	End Sub
	
	Function createMakeSQLTableCmd(ByRef dt As DataTable) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "CREATE TABLE [" & xferTableName & "] ("
		
		For Each clm As DataColumn In dt.Columns
			tmpCmdString = tmpCmdString & "[" & clm.ColumnName.ToString & "] "
			Select Case clm.DataType.ToString
				Case "System.Integer"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Int32"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Double"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Int16"
					tmpCmdString = tmpCmdString & "INT, "
				Case "System.Int64"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.String"
					tmpCmdString = tmpCmdString & "NVARCHAR(MAX), "
				Case "System.DateTime"
					tmpCmdString = tmpCmdString & "DATETIME, "
				Case "System.Boolean"
					tmpCmdString = tmpCmdString & "BIT, "
				Case Else
					tmpCmdString = tmpCmdString & "NVARCHAR(MAX), "
			End Select
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		
		tmpCmdString = tmpCmdString + ")"
		
		createMakeSQLTableCmd = tmpCmdString
		
	End Function
	
	Function createInsertSQLDataCmd(tableName As String, ByRef dr As DataRow) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "INSERT INTO [" & tableName & "]("
		
		For Each col As DataColumn In dr.Table.Columns
			tmpCmdString = tmpCmdString + col.ColumnName & ", "
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		tmpCmdString = tmpCmdString + ") VALUES("
		
		
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
					tmpCmdString = tmpCmdString & Chr(39) & itm.ToString & Chr(39) & ", "
				Case "System.DateTime"
					tmpCmdString = tmpCmdString & Chr(39) & itm.ToString & Chr(39) & ", "
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
		
		createInsertSQLDataCmd = tmpCmdString
		
	End Function
	
	#End Region
	
#region "MSSQLCE"
    

   Private function doesTableExistSQLCE As Boolean
    	
    	doesTableExistSQLCE = False
    	
    	Try
    		CEDA = New SqlCEDataAdapter("SELECT TABLE_NAME AS name FROM information_schema.TABLES where TABLE_NAME = '" & xferTableName & "'", ceConect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            CEDA.Fill(tblListTable)
            
            If tblListTable.Rows.Count > 0 Then doesTableExistSQLCE = True
           
        Catch ex As Exception
        End Try

        
    End Function      
	
	Private Sub CopyToSQLCE(tableExists as boolean, byref source As DataTable)
		
		Me.backgroundWorker1.ReportProgress(0,"Saving to SQLCE")
		
		Dim rowCtr As Integer = 0
		
		Dim sqlText As String
			
		Try
			Dim connString As String
			If My.Settings.SDFPW = Nothing Then
	            connString = "Data Source =" & FileName & ";Persist Security Info=False;"
	        Else
	            connString = "Data Source =" & FileName & "; Password =" & My.Settings.SDFPW & ";"
	        End If
	        
	        'Dim sqlCEConnection As New SQLCEConnection(connString)
	        ceConect = New SqlCeConnection(connString)
		    Dim addTblCommand As String = createMakeSQLCETableCmd(source)
		    Dim sqlCommand As New SQLCECommand(addTblCommand, ceConect)
		    Dim sqlCommand2 As New SQLCECommand("",ceConect)
		    ceConect.Open
		    if not DoesTableExistSQLCE then sqlCommand.ExecuteNonQuery
		    For Each dtRow As DataRow In source.Rows
		    	sqlCommand2.CommandText = createInsertSQLCEDataCmd(xferTableName, dtRow)
		    	sqlText = sqlCommand2.CommandText
		    	sqlCommand2.ExecuteNonQuery
		    	Me.backgroundWorker1.ReportProgress((rowCtr/source.Rows.Count)*100, "Saving to SQL: " & xferTableName)
		    	rowCtr += 1
		    Next
		    ceConect.Close
		Catch ex As Exception
			Me.backgroundWorker1.ReportProgress(0, "Error Saving to SQL: " & ex.Message & " - SQL: " & sqlText) 
	    End Try
	    
	End Sub
	
	Function createMakeSQLCETableCmd(ByRef dt As DataTable) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "CREATE TABLE [" & xferTableName & "] ("
		
		For Each clm As DataColumn In dt.Columns
			tmpCmdString = tmpCmdString & "[" & clm.ColumnName.ToString & "] "
			Select Case clm.DataType.ToString
				Case "System.Integer"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Int32"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Double"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.Int16"
					tmpCmdString = tmpCmdString & "INT, "
				Case "System.Int64"
					tmpCmdString = tmpCmdString & "DECIMAL, "
				Case "System.String"
					tmpCmdString = tmpCmdString & "NVARCHAR(255), "
				Case "System.DateTime"
					tmpCmdString = tmpCmdString & "DATETIME, "
				Case "System.Boolean"
					tmpCmdString = tmpCmdString & "BIT, "
				Case Else
					tmpCmdString = tmpCmdString & "NVARCHAR(255), "
			End Select
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		
		tmpCmdString = tmpCmdString + ")"
		
		createMakeSQLCETableCmd = tmpCmdString
		
	End Function
	
	Function createInsertSQLCEDataCmd(tableName As String, ByRef dr As DataRow) As String
		
		Dim tmpCmdString As String
		
		tmpCmdString = "INSERT INTO [" & tableName & "]("
		
		For Each col As DataColumn In dr.Table.Columns
			tmpCmdString = tmpCmdString + col.ColumnName & ", "
		Next
		
		'trim extra comma
		tmpCmdString = Mid(tmpCmdString,1,Len(tmpCmdString)-2)
		tmpCmdString = tmpCmdString + ") VALUES("
		
		
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
					tmpCmdString = tmpCmdString & Chr(39) & itm.ToString & Chr(39) & ", "
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
		
		createInsertSQLCEDataCmd = tmpCmdString
		
	End Function
	
#End Region
	
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
		
		SendData

		
	End Sub
	
	
	Sub BackgroundWorker1RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
		
		If Not Me.txtStatus.Text.Contains("Error") Then Me.txtStatus.Text = "Save Complete"
		Me.pbProgress.Value = 0
		Me.pbProgress.Refresh
		Me.txtStatus.Refresh
		
	End Sub
	
	Sub BtnCloseClick(sender As Object, e As EventArgs)
		
		Me.Close
		
	End Sub
	
	Sub LstConnectionsDoubleClick(sender As Object, e As EventArgs)
		
		BtnSendClick(Me, Nothing)
		
	End Sub
End Class
