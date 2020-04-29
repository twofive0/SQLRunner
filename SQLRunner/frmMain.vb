Imports System.Data
Imports System.Data.SQLite
Imports System.Data.SqlServerCe
Imports Microsoft.Office.Interop

Public Class frmMain

    Private ServerName As String
    Private DBName As String
    Private conectString As String
    Private Const softwareTitle As String = "SQLRunner 17.02.24"

    'SQL Server connection objects
    Private dbConect As SqlClient.SqlConnection
    Private sqlCommand As SqlClient.SqlCommand
    Private tblListCommand As SqlClient.SqlCommand
    Friend WithEvents sqlDA As SqlClient.SqlDataAdapter
    Private sqlDATableList As SqlClient.SqlDataAdapter
    Private sqlDAViewList As SqlClient.SqlDataAdapter

  
    'SQLite connection objects
    Private sqliteConnect As SQLiteConnection
    Private sqliteCommand As SQLiteCommand
    Private tblSQLiteListCommand As SQLiteCommand
    Friend WithEvents sqliteDA As SQLiteDataAdapter
    Private sqliteTableList As SQLiteDataAdapter
    
    'SQLCE connection objects
    Private ceConect As SqlCeConnection
    Private CEDA As SqlCeDataAdapter
    Private ceCommand As SqlCeCommand
    
    Public dt As DataTable
    Private tblListTable As DataTable
    Private tblListViews As DataTable
    Private firstOpen As Boolean = True
    Friend WithEvents currentTextBox As FastColoredTextBoxNS.FastColoredTextBox
    
    Public Function getCurrentTable As DataTable
    	
    	Return dt
    	
    End Function


    Private Sub currentTextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles currentTextBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub


    Private Sub currentTextBox_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles currentTextBox.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Me.currentTextBox.Text = System.IO.File.ReadAllText(e.Data.GetData(DataFormats.FileDrop)(0))
        End If

        If e.Data.GetDataPresent(DataFormats.Text) Then
            Me.currentTextBox.Text = e.Data.GetData(DataFormats.Text)
        End If

    End Sub


    Private Sub btnRunQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunQuery.Click

        dt.Dispose()
        dt = New DataTable
        Me.txtRunAction.Enabled = False
        Me.btnRunQuery.Enabled = False
        Me.backRunQuery.RunWorkerAsync()
        Me.sendResultsToStoredConnectionToolStripMenuItem.Enabled = True

    End Sub

    Public Function testConnection() As Boolean

        testConnection = True
		clearTreeView

        If My.Settings.DBType = "SQL Server" Then
            testConnection = checkSQLConect()
        Else
            testConnection = checkCEConect()
        End If
        
        Select Case My.Settings.DBType
        	Case "SQL Server"
        		testConnection = checkSQLConect()
        	Case "SQL Compact (SDF)"
        		testConnection = checkCEConect()
        	Case "SQLite"
        		testConnection = checkSQLiteConnect()
        End Select
        
        Me.Text = softwareTitle & " - " & My.Settings.CurrentDatabase

    End Function

    Private Function checkSQLConect() As Boolean

        checkSQLConect = True

        conectString = "Data Source =" & My.Settings.Server & "; Initial Catalog =" & My.Settings.Database & "; User Id =" & My.Settings.User & "; Password =" & My.Settings.Password & "; "
        dbConect = New SqlClient.SqlConnection(conectString)

        Try
            dbConect.Open()
        Catch ex As Exception
            Me.txtStatusLabel.Text = "Database: (Not Available)"
            checkSQLConect = False
            Exit Function
        End Try

		If checkSQLConect Then
			Me.txtStatusLabel.BackColor = SystemColors.Control
			Me.txtStatusLabel.ForeColor = Color.green
            Me.txtStatusLabel.Text = "Database: " & My.Settings.Server & " - " & My.Settings.Database
        End If

        'load the table list
		loadTreeView

    End Function

    Private Function checkCEConect() As Boolean

        checkCEConect = True

        If My.Settings.SDFPW = Nothing Then
            conectString = "Data Source =" & My.Settings.SDFFile & ";Persist Security Info=False;"
        Else
            conectString = "Data Source =" & My.Settings.SDFFile & "; Password =" & My.Settings.SDFPW & ";"
        End If

        ceConect = New SqlCeConnection(conectString)

        Try
            ceConect.Open()
        Catch ex As Exception
            Me.txtStatusLabel.Text = "Database: (Not Available)"
            checkCEConect = False
            Exit Function
        End Try

        If checkCEConect Then
        	Me.txtStatusLabel.Text = "Database: " & My.Settings.SDFFile
        	Me.txtStatusLabel.BackColor = SystemColors.Control
			Me.txtStatusLabel.ForeColor = Color.green
        End If

		'load the table list
		loadTreeViewCE


    End Function
    
        Private Function checkSQLiteConnect() As Boolean

        checkSQLiteConnect = True

        If My.Settings.SDFPW = Nothing Then
            conectString = "Data Source =" & My.Settings.SDFFile & ";Version=3;DateTimeFormat=CurrentCulture;"
        Else
            conectString = "Data Source =" & My.Settings.SDFFile & ";Version=3;Password =" & My.Settings.SDFPW & ";DateTimeFormat=CurrentCulture;"
        End If

        sqliteConnect = New SqliteConnection(conectString)

        Try
            sqliteConnect.Open()
        Catch ex As Exception
            Me.txtStatusLabel.Text = "Database: (Not Available)"
            checkSQLiteConnect = False
            Exit Function
        End Try

        If checkSQLiteConnect Then
        	Me.txtStatusLabel.Text = "Database: " & My.Settings.SDFFile
        	Me.txtStatusLabel.BackColor = SystemColors.Control
			Me.txtStatusLabel.ForeColor = Color.green
        End If

		'load the table list
		loadTreeViewSQLite


    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim fd As New SaveFileDialog
        Dim ea As New ExportAdapter
        Dim tabName As String
        
        tabName = cleanTXT(Me.tbEditTabs.SelectedTab.Text)
        
        Application.UseWaitCursor = true
        Me.txtStatus.Text = "Saving File..."

        Try
            Select Case Me.cboSaveAs.Text
                Case Is = "Excel (Tab Delimited)"
                    fd.DefaultExt = "xls"
                    fd.Filter = "Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*"
                    fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString & ".xls"
                    If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    Me.txtStatus.Text = "Status: Saving File"
                    ea.DataTable2Excel(dt, fd.FileName)
                Case Is = "XML"
                    fd.DefaultExt = "xml"
                    fd.Filter = "XML Data File (*.xml)|*.xml|All files (*.*)|*.*"
                    fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString & ".xml"
                    If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    Me.txtStatus.Text = "Status: Saving File"
                    dt.WriteXml(fd.FileName, System.Data.XmlWriteMode.WriteSchema)
                Case Is = "CSV"
                    fd.DefaultExt = "csv"
                    fd.Filter = "Comma Separated Values File (*.csv)|*.csv|All files (*.*)|*.*"
                    fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString & ".csv"
                    If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    Me.txtStatus.Text = "Status: Saving File"
                    ea.DataTable2CSV(dt, fd.FileName)
                Case Is = "Choose Delimiter"
                    fd.DefaultExt = "txt"
                    fd.Filter = "Delimited File (*.txt)|*.txt|All files (*.*)|*.*"
                    fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString & ".txt"
                    If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    Me.txtStatus.Text = "Status: Saving File"
                    ea.DataTable2txt(dt, fd.FileName, InputBox("Please Input Delimiter Value"))
                Case Is = "High Compression Format"
                    fd.Filter = "High Compression Format (*.7z)|*.7z|All files (*.*)|*.*"
                    fd.AddExtension = False
                    fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString
                    If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    Me.txtStatus.Text = "Status: Saving File"
                    ea.DataTable2Guardian(dt, fd.FileName + ".txt")
                    Dim szip As New SevenZip.SevenZipCompressor
                    szip.ScanOnlyWritable = True
                    szip.CompressFiles(fd.FileName, fd.FileName + ".txt")
                    System.IO.File.Delete(fd.FileName + ".txt")
                Case Else
                    MsgBox("Please select file type")
                    Exit Sub
            End Select
        Catch ex As Exception
            MsgBox("Could not save file: " & ex.Message)
            Me.txtStatus.Text = "Status: Error Saving File"
            Application.UseWaitCursor = False
        End Try
		
		Me.txtStatus.Text = "Status: Saved file: " & fd.FileName 
		Application.UseWaitCursor = False

    End Sub


    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click

        Dim fd As New OpenFileDialog

        fd.Filter = "SQLRunner Script (*.srn)|*.srn|All files (*.*)|*.*"
        fd.Multiselect = False

        fd.ShowDialog()

        If fd.FileName <> Nothing Then
            Try
            	If currentTextBox.text <> "" Then NewTabToolStripMenuItemClick(Me, Nothing)
            	Me.currentTextBox.Text = System.IO.File.ReadAllText(fd.FileName)
            	Me.tbEditTabs.SelectedTab.Text = Mid(fd.FileName.tostring,InStrRev(fd.FileName,"\")+1,9999)
            Catch ex As Exception
                MsgBox("Error opening file: " & ex.Message)
            End Try
        End If
    End Sub

    Private Function testKOD() As Boolean

        If Not adminModeToolStripMenuItem.Checked And txtRunAction.Enabled Then
            Dim dr As DialogResult
            dr = MsgBox("Are you sure you want to run the action query?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm")
            If dr = Windows.Forms.DialogResult.Cancel Then
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

        frmHelp.ShowDialog()

    End Sub

    Private Sub checkFolders()

        Dim localAppFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SQLRunner"

        If Not System.IO.Directory.Exists(localAppFolder) Then
            Try
                System.IO.Directory.CreateDirectory(localAppFolder)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub updateLog()

        Dim logFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SQLRunner\ExecLog.txt"

        Try
            System.IO.File.AppendAllText(logFile, My.User.Name & "  -  " & Now.ToString & Environment.NewLine & _
                                         "----------------------------------------------" & Environment.NewLine & _
                                         Me.currentTextBox.Text & Environment.NewLine & Environment.NewLine)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtRunAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRunAction.Click

        If Not Me.adminModeToolStripMenuItem.Checked Then If testKOD() = False Then Exit Sub

        If MsgBox("This will modify records in the database.  This action cannot be undone!  Continue?", Microsoft.VisualBasic.MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.No Then Exit Sub

        Me.BindingSource1.DataSource = Nothing
        Me.txtRunAction.Enabled = False
        Me.btnRunQuery.Enabled = False

        backRunAction.RunWorkerAsync()

    End Sub

    Private Sub BindingSource1_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingSource1.DataSourceChanged

        Try
            If Me.DataGridView1.RowCount > 0 Then
                Me.btnSave.Enabled = True
            Else
                Me.btnSave.Enabled = False
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub currentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs, optional setEditFlag As Boolean = true) Handles currentTextBox.TextChanged

        Dim updateFlag As String

        If Me.currentTextBox.Text = Nothing Then
            Me.btnRunQuery.Enabled = False
            Me.txtRunAction.Enabled = False
            Exit Sub
        End If

        updateFlag = "Run"

        If Me.currentTextBox.Text.ToLower.Contains("update ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("delete ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("alter ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("add ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("modify ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("remove ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("create ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.ToLower.Contains("insert ") Then updateFlag = "Update"
        If Me.currentTextBox.Text.StartsWith("!MultiSet") Then updateFlag = "MultiSet"

    Select Case UpdateFlag
    	Case "Update"
    		Me.txtRunAction.Enabled = True
    		Me.btnRunQuery.Enabled = False
    		Me.btnExportDataset.Enabled = False
    		Me.btnEmailMultiSet.Enabled = False
    	Case "MultiSet"
    		Me.txtRunAction.Enabled = False
    		Me.btnRunQuery.Enabled = False
    		Me.btnExportDataset.Enabled = True
    		Me.btnEmailMultiSet.Enabled = True
    		Me.btnSave.Enabled = False
    	Case "Run"
            Me.txtRunAction.Enabled = False
            Me.btnRunQuery.Enabled = True
            Me.btnExportDataset.Enabled = False
            Me.btnEmailMultiSet.Enabled = False
    End Select
    
    If My.Settings.DBType <> "SQL Server" Then
    	Me.btnExportDataset.Enabled = False
    	Me.btnEmailMultiSet.Enabled = False
    End If
    
        If adminModeToolStripMenuItem.Checked Then
            btnRunQuery.Enabled = True
            txtRunAction.Enabled = True
        End If

    	
      
        If instr(me.tbEditTabs.SelectedTab.Text,"*") < 1  And setEditFlag Then Me.tbEditTabs.SelectedTab.Text = Me.tbEditTabs.SelectedTab.Text & " *"
        
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  		Me.Show
        Me.txtStatusLabel.Text = "Not Connected (press refresh)"
        Application.DoEvents()

		tblListTable = New DataTable
		tblListViews = New DataTable


    	NewTabToolStripMenuItemClick(Me,nothing)

        Try
            If firstOpen Then
            	Me.currentTextBox.Text = System.IO.File.ReadAllText(System.Environment.GetCommandLineArgs(1))
            	tbEditTabs.SelectedTab.Text = Mid(System.Environment.GetCommandLineArgs(1),InStrRev(System.Environment.GetCommandLineArgs(1),"\")+1,9999)
                firstOpen = False
            End If
        Catch ex As Exception
        End Try


		clearTreeView
		checkFolders()

        If My.Settings.DBType = Nothing Then
            My.Settings.DBType = "SQL Server"
            My.Settings.Save()
        End If

		If My.Settings.CurrentDatabase = Nothing Then
			If Not ImportODBC Then
            	Me.Show()
            	frmSources.ShowDialog()
            End if
        Else
            'testConnection()
        End If

        If My.Settings.Timeout = Nothing Then
            My.Settings.Timeout = 500
            My.Settings.Save()
        End If
        
        Me.Text = softwareTitle & " - " & My.Settings.CurrentDatabase

        dt = New DataTable
        Me.BindingSource1.DataSource = dt
        Me.BindingNavigator1.BindingSource = BindingSource1
        Me.DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub backRunQuery_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backRunQuery.DoWork

        If testKOD() = False Then Exit Sub

		Select Case My.Settings.DBType
			Case "SQL Server"
	            Try
	                Me.txtStatus.Text = "Status: Running SQL Query"
	                sqlDA = New SqlDataAdapter(Me.currentTextBox.Text, dbConect)
	                sqlDA.SelectCommand.CommandTimeout = My.Settings.Timeout
	                dt.TableName = "SQLRunnerResult"
	                sqlDA.Fill(dt)
	                updateLog()
	            Catch ex As Exception
	                MsgBox("Error running SQL: " & ex.Message)
	                Me.txtStatus.Text = "Status: SQL Error"
	                Exit Sub
	            End Try				
			Case "SQL Compact (SDF)"
				Try
	                Me.txtStatus.Text = "Status: Running SQL Query"
	                CEDA = New SqlCeDataAdapter(Me.currentTextBox.Text, ceConect)
	                dt.TableName = "SQLRunnerResult"
	                CEDA.Fill(dt)
	                updateLog()
	            Catch ex As Exception
	                MsgBox("Error running SQL: " & ex.Message)
	                Me.txtStatus.Text = "Status: SQL Error"
	                Exit Sub
	            End Try
			Case "SQLite"
				Try
					Me.txtStatus.Text = "Status: Running SQL Query"
	                sqliteDA = New SqliteDataAdapter(Me.currentTextBox.Text, sqliteConnect)
	                dt.TableName = "SQLRunnerResult"
	                sqliteDA.Fill(dt)
	                updateLog()
	            Catch ex As Exception
	                MsgBox("Error running SQL: " & ex.Message)
	                Me.txtStatus.Text = "Status: SQL Error"
	                Exit Sub
	            End Try
		End Select

    End Sub

    Private Sub backRunQuery_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backRunQuery.RunWorkerCompleted

        BindingSource1.DataSource = dt
        Me.DataGridView1.Refresh()
        Me.txtStatus.Text = "Status: " & Me.DataGridView1.RowCount & " Records Loaded."
        currentTextBox_TextChanged(Me, EventArgs.Empty, False)


    End Sub


    Private Sub backRunAction_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backRunAction.DoWork

		Dim recordsModded As Integer = 0

		Select Case My.Settings.DBType
			Case "SQL Server"
		            Try
		                Me.txtRunAction.Enabled = False
		                Me.btnRunQuery.Enabled = False
		                Me.txtStatus.Text = "Status: Running SQL Query"
		                sqlCommand = New SqlCommand(Me.currentTextBox.Text, dbConect)
		                sqlCommand.CommandTimeout = My.Settings.Timeout
		                recordsModded = sqlCommand.ExecuteNonQuery
		                updateLog()
		            Catch ex As Exception
		                MsgBox("Error running SQL: " & ex.Message)
		                Me.txtStatus.Text = "Status: SQL Error"
		                Exit Sub
		            End Try		
			Case "SQL Compact (SDF)"
				    Try
		                Me.txtRunAction.Enabled = False
		                Me.btnRunQuery.Enabled = False
		                Me.txtStatus.Text = "Status: Running SQL Query"
		                ceCommand = New SqlCeCommand(Me.currentTextBox.Text, ceConect)
		                recordsModded = ceCommand.ExecuteNonQuery
		                updateLog()
		            Catch ex As Exception
		                MsgBox("Error running SQL: " & ex.Message)
		                Me.txtStatus.Text = "Status: SQL Error"
		                Exit Sub
		            End Try
			Case "SQLite"
				    Try
		                Me.txtRunAction.Enabled = False
		                Me.btnRunQuery.Enabled = False
		                Me.txtStatus.Text = "Status: Running SQL Query"
		                sqliteCommand = New SqliteCommand(Me.currentTextBox.Text, sqliteConnect)
		                recordsModded = sqliteCommand.ExecuteNonQuery
		                updateLog()
		            Catch ex As Exception
		                MsgBox("Error running SQL: " & ex.Message)
		                Me.txtStatus.Text = "Status: SQL Error"
		                Exit Sub
		            End Try				
		End Select

        Me.txtStatus.Text = "Status: " & recordsModded & " Records modified."

    End Sub

    Private Sub OpenScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenScriptToolStripMenuItem.Click

        btnOpenFile_Click(Me, System.EventArgs.Empty)

    End Sub

    Private Sub SaveScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveScriptToolStripMenuItem.Click

        Dim fd As New SaveFileDialog

		fd.Filter = "SQLRunner Script (*.srn)|*.srn|All files (*.*)|*.*"
		fd.FileName = Trim(tbEditTabs.SelectedTab.Text.Replace("*",nothing))

        fd.ShowDialog()

        If fd.FileName <> Nothing Then
            Try
            	System.IO.File.WriteAllText(fd.FileName, Me.currentTextBox.Text)
            	tbEditTabs.SelectedTab.Text = Mid(fd.FileName.tostring,InStrRev(fd.FileName,"\")+1,9999)
            Catch ex As Exception
                MsgBox("Error saving file: " & ex.Message)
            End Try
        End If
        
        tbEditTabs.SelectedTab.Text = Mid(fd.FileName.tostring,InStrRev(fd.FileName,"\")+1,9999)

    End Sub

    Private Sub AboutManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutManualToolStripMenuItem.Click

        frmHelp.ShowDialog()

    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click

        Me.currentTextBox.Undo()

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click

        Me.currentTextBox.Cut()

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click

        Me.currentTextBox.Copy()

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click

        Me.currentTextBox.Paste()

    End Sub

    Private Sub PrintHTMLReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintHTMLReportToolStripMenuItem.Click

        Dim ea As New ExportAdapter
        Dim htmlTempFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SQLRunner\htmlReport.html"

        ea.ConvertToHtmlFile(dt, htmlTempFile)

        Try
            System.Diagnostics.Process.Start(htmlTempFile)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click

        Me.currentTextBox.SelectAll()

    End Sub

    Private Sub backRunAction_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backRunAction.RunWorkerCompleted

        BindingSource1.DataSource = Nothing
        Me.DataGridView1.Refresh()
        currentTextBox_TextChanged(Me, EventArgs.Empty, False)

    End Sub

    
    Private Sub NewTabToolStripMenuItemClick(sender As Object, e As EventArgs) Handles newTabToolStripMenuItem.Click


        Me.tbEditTabs.TabPages.Add(New TabPage("New" & tbEditTabs.TabPages.Count + 1))
        Dim tx As New FastColoredTextBoxNS.FastColoredTextBox
        tx.Language = FastColoredTextBoxNS.Language.SQL
        tx.Tag = "New" & tbEditTabs.TabPages.Count + 1
        tx.Parent = tbEditTabs.TabPages(Me.tbEditTabs.TabPages.Count - 1)
        tx.Dock = Dock.Fill
        Dim popupmenu As New FastColoredTextBoxNS.AutocompleteMenu(tx)
        popupmenu.Items.SetAutocompleteItems({"SELECT", "UPDATE", "DELETE", "INNER", "JOIN"})
        popupmenu.MaximumSize = New System.Drawing.Size(200, 300)
        popupmenu.Items.Width = 200
        Me.tbEditTabs.SelectedIndex = Me.tbEditTabs.TabPages.Count - 1
        Me.currentTextBox = Me.tbEditTabs.TabPages(Me.tbEditTabs.TabPages.Count - 1).Controls.Item(0)

    End Sub
    
    Sub CloseTabToolStripMenuItemClick(sender As Object, e As EventArgs) Handles closeTabToolStripMenuItem.Click

        If Me.tbEditTabs.TabCount < 2 Then Exit Sub

        Dim mbResult As MsgBoxResult

        If tbEditTabs.SelectedTab.Text.Contains("*") Then
            mbResult = MsgBox("This tab hasn't been saved.  Would you like to save now?", vbYesNoCancel, "Save Script?")
            If mbResult = vbYes Then SaveScriptToolStripMenuItem_Click(Me, Nothing)
            If mbResult = vbCancel Then Exit Sub
        End If

        Me.tbEditTabs.TabPages.Remove(Me.tbEditTabs.SelectedTab)

    End Sub
    
    
    Sub TbEditTabsDoubleClick(sender As Object, e As EventArgs) Handles tbEditTabs.DoubleClick

        RenameTabToolStripMenuItemClick(Me, Nothing)

    End Sub
    
    
    Sub TbEditTabsSelected(sender As Object, e As TabControlEventArgs) Handles tbEditTabs.Selected

        Me.currentTextBox = Me.tbEditTabs.SelectedTab.Controls.Item(0)
        currentTextBox_TextChanged(Me, Nothing, False)

    End Sub
    
    
    Sub FrmMainFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim unsavedstuff As Boolean

        unsavedstuff = False

        For Each t As TabPage In tbEditTabs.TabPages
            If InStr(t.Text, "*") Then
                unsavedstuff = True
            End If
        Next

        If unsavedstuff Then
            If MsgBox("There are unsaved tabs, would you like to close anyway?", vbYesNo, "Save Scripts?") = vbNo Then e.Cancel = True
        End If

    End Sub
    
    Sub RenameTabToolStripMenuItemClick(sender As Object, e As EventArgs) Handles renameTabToolStripMenuItem.Click

        Dim newTabName As String

        newTabName = InputBox("New Tab Name")

        If newTabName <> Nothing Then Me.tbEditTabs.SelectedTab.Text = newTabName

    End Sub
    
    Sub BtnExportDatasetClick(sender As Object, e As EventArgs) Handles btnExportDataset.Click

        Dim tabName As String
        Dim fd As New SaveFileDialog

        tabName = cleanTXT(Me.tbEditTabs.SelectedTab.Text)
        Me.btnEmailMultiSet.Enabled = False
        Me.btnExportDataset.Enabled = False
        Me.btnRunQuery.Enabled = False
        Me.txtRunAction.Enabled = False

        fd.Filter = "High Compression Format (*.7z)|*.7z|All files (*.*)|*.*"
        fd.AddExtension = False
        fd.FileName = tabName & "_" & Today.Month.ToString & "-" & Today.Day.ToString & "-" & Today.Year.ToString
        If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Me.backExportMultiSet.RunWorkerAsync(fd.FileName)
        'exportMultiSet(False, fd.FileName)

    End Sub
    
    Private Function exportDatasetPiece(sql As String, fileName As string) As Boolean
    	
    	
    	'TODO: Make this work with all database types
    	Dim exDT As DataTable
    	exportDatasetPiece = True
    	Dim ea As New ExportAdapter
    	exDT = New DataTable
    	Dim dAdapt As SqlClient.SqlDataAdapter

 	
    	Try
            dAdapt = New SqlDataAdapter(sql, dbConect)
            dAdapt.SelectCommand.CommandTimeout = My.Settings.Timeout
            exDT.TableName = System.IO.Path.GetFileNameWithoutExtension(fileName).Replace(".txt","")
            dAdapt.Fill(exDT)
            updateLog()
        Catch ex As Exception
            'MsgBox("Error running SQL: " & ex.Message)
            backExportMultiSet.ReportProgress(0,"Error saving " & fileName & " " & ex.message)
            exportDatasetPiece = False
            Exit function
        End Try
        
        'export schema with data 5/28/13 DW
        exDT.WriteXmlSchema(fileName & ".xsd")
        ea.DataTable2Guardian(exDT, fileName)
        
    End Function
    
    Private Sub exportMultiSet(eMail As Boolean, optional saveFile As String = "")
    	
        Dim ea As New ExportAdapter
        Dim tempScript As String
        Dim scriptSet As String()
        Dim resultFileSet As New List(Of String)
        Dim fileName As String
        Dim queryName As String
        Dim szip As New SevenZip.SevenZipCompressor
        
        tempScript = currentTextBox.text
        tempScript = Replace(tempScript, vbCrLf, " ")
        tempScript = Replace(tempScript, "!MultiSet", Nothing)
        scriptSet = tempScript.Split("{")
        
       backExportMultiSet.ReportProgress(0,"Exporting Dataset...")
        
        Try
        	System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath & "\SQLRunnerTemp")
 			For Each foundFile As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath & "SQLRunnerTemp", "*.*")
   				System.IO.File.Delete(foundFile)
			Next
        Catch ex1 As Exception
        	MsgBox("Unable to write to temp directory!")
        	Exit Sub
        End Try
        
        For Each scr As String In scriptSet
        	If scr <> "MultiSet" And scr.Trim <> "" Then
        		queryName = Mid(scr, 1, InStr(scr,"}"))
        		queryName = Replace(queryName,"}",nothing)
        		scr = Replace(scr,queryName & "}", Nothing)
        		fileName = System.IO.Path.GetTempPath & "SQLRunnerTemp\" & queryName & ".txt"
        		backExportMultiSet.ReportProgress(0,"Exporting " & fileName)
	        	exportDatasetPiece(scr, fileName)
        	End if
        Next

        Try
            backExportMultiSet.ReportProgress(0,"Compressing File: " & saveFile )
            szip.ScanOnlyWritable = True
            For Each f As String In System.IO.Directory.GetFiles(System.IO.Path.GetTempPath & "SQLRunnerTemp")
            	resultFileSet.Add(f)
            Next
            szip.CompressFiles(saveFile, resultFileSet.ToArray)
        Catch ex As Exception
            MsgBox("Could not save file: " & ex.Message)
            backExportMultiSet.ReportProgress(0,"Error Saving File: " & ex.message )
        End Try
		
		backExportMultiSet.ReportProgress(0,"Saved File: " & saveFile ) 
		
	
    End Sub

    
    Sub BtnEmailMultiSetClick(sender As Object, e As EventArgs) Handles btnEmailMultiSet.Click

        Me.btnEmailMultiSet.Enabled = False
        Me.btnExportDataset.Enabled = False
        Me.btnRunQuery.Enabled = False
        Me.txtRunAction.Enabled = False

        backExportMultiSet.RunWorkerAsync("*EMail*" & System.IO.Path.GetTempPath & "SQLRunnerTemp\" & cleanTXT(Me.tbEditTabs.SelectedTab.Text) & ".7z")
        'exportMultiSet(True)
        '	sendEMailAttach

    End Sub
    
    Sub sendEMailAttach(fName As String)
    	
    	backExportMultiSet.ReportProgress(0,"Sending Outlook E-Mail")
    	
    	try
	    	' Create an Outlook application.
	        Dim oApp As Outlook._Application
	        oApp = New Outlook.Application()
	        oApp.GetNamespace("MAPI")
	        oApp.Session.Logon
	
	        ' Create a new MailItem.
	        Dim oMsg As Outlook._MailItem
	        oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
	        oMsg.Subject = "Message From SQLRunner"
	        oMsg.Body = "This is an automated e-mail message from SQLRunner " & Application.ProductVersion & vbCr & vbCr
	
	        oMsg.To = My.Settings.EMailAddr
	
	        ' Add an attachment
	        Dim sSource As String = fName
	        Dim sDisplayName As String = fName
	
	        Dim sBodyLen As String = oMsg.Body.Length
	        Dim oAttachs As Outlook.Attachments = oMsg.Attachments
	        Dim oAttach As Outlook.Attachment
	        oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)
	
	        ' Send
	        oMsg.Send()
	
	        ' Clean up
	        oApp = Nothing
	        oMsg = Nothing
	        oAttach = Nothing
	        oAttachs = Nothing
    	Catch ex As Exception
    		backExportMultiSet.ReportProgress(0,"Error Sending E-Mail: " & ex.message )
    		Exit Sub
    	End Try
    	
    	backExportMultiSet.ReportProgress(0,"E-Mail Sent @ " & Now() )
        
    End Sub
    
    Private Function cleanTXT(inTXT As String) As String
    	
    	Dim tmpString As String
    	
    	inTXT = Replace(inTXT,".srn",Nothing)
    	
    	For Each c As Char In inTXT
    		If Char.IsLetterOrDigit(c) Then tmpString = tmpString + c
    	Next
    	
    	cleanTXT = tmpString
    	
    End Function
    
    Sub BtnCloseTabClick(sender As Object, e As EventArgs) Handles btnCloseTab.Click

        If Me.tbEditTabs.TabCount < 2 Then Exit Sub

        Dim mbResult As MsgBoxResult

        If tbEditTabs.SelectedTab.Text.Contains("*") Then
            mbResult = MsgBox("This tab hasn't been saved.  Would you like to save now?", vbYesNoCancel, "Save Script?")
            If mbResult = vbYes Then SaveScriptToolStripMenuItem_Click(Me, Nothing)
            If mbResult = vbCancel Then Exit Sub
        End If

        Me.tbEditTabs.TabPages.Remove(Me.tbEditTabs.SelectedTab)

    End Sub
    
    Sub BtnNewTabClick(sender As Object, e As EventArgs) Handles btnNewTab.Click

        NewTabToolStripMenuItemClick(Me, Nothing)

    End Sub
    
    Sub loadTreeView
    	
    	Dim tableRoot As TreeNode() = tvTables.Nodes.Find("Tables",false)
    	Dim viewRoot As TreeNode() = tvTables.Nodes.Find("Views", false)
    	
    	Try
    		sqlDATableList = New SqlDataAdapter("SELECT TABLE_NAME AS name FROM information_schema.TABLES where TABLE_TYPE='BASE TABLE' ORDER BY name", dbConect)
    		sqlDAViewList = New SqlDataAdapter("SELECT TABLE_NAME AS name FROM information_schema.TABLES where TABLE_TYPE='VIEW' ORDER BY name", dbConect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            tblListViews.TableName = "ViewList"
            tblListViews.Clear()
            sqlDATableList.Fill(tblListTable)
            sqlDAViewList.Fill(tblListViews)
            
            For Each row As DataRow In tblListTable.Rows
            	tableRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,0,0))
            Next
            
            For Each row As DataRow In tblListViews.Rows
            	viewRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,1,1))
            Next

            
        Catch ex As Exception
        End Try
        Me.tvTables.Refresh
        
        Me.tvTables.Nodes(0).Expand
        
    End Sub
    
        Sub loadTreeViewCE
    	
    	Dim tableRoot As TreeNode() = tvTables.Nodes.Find("Tables",false)
    	Dim viewRoot As TreeNode() = tvTables.Nodes.Find("Views", false)
    	
    	Try
    		CEDA = New SqlCEDataAdapter("SELECT TABLE_NAME AS name FROM information_schema.TABLES ORDER BY name", ceConect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            tblListViews.TableName = "ViewList"
            tblListViews.Clear()
            CEDA.Fill(tblListTable)
            
            For Each row As DataRow In tblListTable.Rows
            	tableRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,0,0))
            Next
            
            For Each row As DataRow In tblListViews.Rows
            	viewRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,1,1))
            Next
           
    	Catch ex As Exception
    		MessageBox.Show(ex.Message)
        End Try
        Me.tvTables.Refresh
        
        Me.tvTables.Nodes(0).Expand
        
    End Sub
    
    Sub loadTreeViewSQLite
    	
    	Dim tableRoot As TreeNode() = tvTables.Nodes.Find("Tables",false)
    	Dim viewRoot As TreeNode() = tvTables.Nodes.Find("Views", false)
    	
    	Try
    		sqliteDA = New SqliteDataAdapter("SELECT name FROM sqlite_master WHERE type='table'", sqliteConnect)
            tblListTable.TableName = "TableList"
            tblListTable.Clear()
            tblListViews.TableName = "ViewList"
            tblListViews.Clear()
            sqliteDA.Fill(tblListTable)
            
            For Each row As DataRow In tblListTable.Rows
            	tableRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,0,0))
            Next
            
            For Each row As DataRow In tblListViews.Rows
            	viewRoot(0).Nodes.Add(New TreeNode(row.Item(0).tostring,1,1))
            Next
           
        Catch ex As Exception
        End Try
        Me.tvTables.Refresh
        
        Me.tvTables.Nodes(0).Expand
        
    End Sub    
    
    
    Sub TvTablesDoubleClick(sender As Object, e As EventArgs) Handles tvTables.DoubleClick


        Select Case My.Settings.DBType
            Case "SQL Server"
                If currentTextBox.Text <> "" Then NewTabToolStripMenuItemClick(Me, Nothing)
                Me.currentTextBox.Text = "select top 1000 * from " + Me.tvTables.SelectedNode.Text
            Case "SQL Compact (SDF)"
                If currentTextBox.Text <> "" Then NewTabToolStripMenuItemClick(Me, Nothing)
                Me.currentTextBox.Text = "select top(1000) * from " + Me.tvTables.SelectedNode.Text
            Case "SQLite"
                If currentTextBox.Text <> "" Then NewTabToolStripMenuItemClick(Me, Nothing)
                Me.currentTextBox.Text = "select * from " + Me.tvTables.SelectedNode.Text & " limit 1000"

        End Select

        Me.btnRunQuery_Click(Me, System.EventArgs.Empty)


    End Sub
    
    Sub RenameToolStripMenuItemClick(sender As Object, e As EventArgs) Handles renameToolStripMenuItem.Click

        RenameTabToolStripMenuItemClick(Me, Nothing)

    End Sub
    
    Private Sub clearTreeView
    	
    	Dim tableRoot As TreeNode() = tvTables.Nodes.Find("Tables",false)
    	Dim viewRoot As TreeNode() = tvTables.Nodes.Find("Views", false)
    	
		tableRoot(0).Nodes.Clear
		viewRoot(0).Nodes.Clear
		
		tvTables.Refresh
    	
    End Sub
    
    Sub BackExportMultiSetDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backExportMultiSet.DoWork

        If InStr(e.Argument.ToString, "*EMail*") = 0 Then
            exportMultiSet(False, e.Argument.ToString)
        Else
            exportMultiSet(True, Mid(e.Argument.ToString, 8, 9999))
            sendEMailAttach(Mid(e.Argument.ToString, 8, 9999))
        End If

    End Sub
    
    
    Sub BackExportMultiSetProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles backExportMultiSet.ProgressChanged

        Me.txtStatus.Text = e.UserState.ToString

    End Sub
    
    
    Sub BackExportMultiSetRunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backExportMultiSet.RunWorkerCompleted

        currentTextBox_TextChanged(Me, Nothing, False)

    End Sub
    
    Private Function ImportODBC As Boolean
    	
    	Dim txtLines() As String
    	Dim txtParams() As String
    	ImportODBC = False
    	
    	If Not System.IO.File.Exists(Application.StartupPath & "\odbcinfo.txt") Then
    		Exit Function
    	End If
    	
    	If My.settings.Server <> Nothing Then Exit Function
    	
    	Try
    		txtLines = System.IO.File.ReadAllLines(Application.StartupPath & "\odbcinfo.txt")
    		txtParams = txtLines(1).Split(",")
    		My.Settings.CurrentDatabase = "Default"
    		My.Settings.Database = txtParams(3)
	        My.Settings.Password = txtParams(5)
	        My.Settings.Server = txtParams(2)
	        My.Settings.User = txtParams(4)
	        My.Settings.Timeout = 500
	        My.Settings.SDFFile = Nothing
	        My.Settings.DBType = "SQL Server"
	        My.Settings.SDFPW = Nothing
            My.Settings.EMailAddr = "someone@someemail.com"
	        My.Settings.Save
    
    	Catch ex As Exception
    		My.Settings.Database = "<Insert DB Here>"
    	End Try
    	
    	testConnection()
    	
    	ImportODBC = True
    	
    End Function
    
    
    Sub ConvertMultisetToAccessToolStripMenuItemClick(sender As Object, e As EventArgs) Handles convertMultisetToAccessToolStripMenuItem.Click

        Dim ac As New AccessConvert
        ac.ShowDialog()

    End Sub
    
    Sub RefreshTablesToolStripMenuItemClick(sender As Object, e As EventArgs) Handles refreshTablesToolStripMenuItem.Click

        testConnection()

    End Sub
    
    Sub SettingsToolStripMenuItemClick(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click

        Dim frmSrc As New frmSources
        frmSrc.ShowDialog()

    End Sub
    
    Sub ConvertMultisetToSQLiteToolStripMenuItemClick(sender As Object, e As EventArgs) Handles convertMultisetToSQLiteToolStripMenuItem.Click

        Dim ac As New SQLiteConvert
        ac.ShowDialog()

    End Sub
    
    
    Sub SendResultsToStoredConnectionToolStripMenuItemClick(sender As Object, e As EventArgs) Handles sendResultsToStoredConnectionToolStripMenuItem.Click
    	
    	Try
    		ceConect.Close()
    		Catch ex As Exception
    	End Try
        Dim ed As New SendToConnection(dt)
        ed.ShowDialog()

    End Sub
    
    Sub OpenScriptLogToolStripMenuItemClick(sender As Object, e As EventArgs) Handles openScriptLogToolStripMenuItem.Click

        NewTabToolStripMenuItemClick(Me, Nothing)

        Dim logFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SQLRunner\ExecLog.txt"

        Try
            currentTextBox.Text = System.IO.File.ReadAllText(logFile)

        Catch ex As Exception
        End Try

    End Sub
    
    
    Sub LoadFromXMLToolStripMenuItemClick(sender As Object, e As EventArgs) Handles loadFromXMLToolStripMenuItem.Click

        Try
            dt.Clear()
        Catch ex As Exception
        End Try

        Dim ds As New DataSet
        Dim fc As New OpenFileDialog
        fc.Multiselect = False
        fc.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*"
        Me.txtStatus.Text = "Please wait, loading XML..."

        fc.ShowDialog()

        If fc.FileName = Nothing Then Exit Sub

        ds.ReadXml(fc.FileName)

        If ds.Tables.Count > 1 Then
            dt = ds.Tables(pickXMLTable(ds))
        Else
            dt = ds.Tables(0)
        End If



        Try
            BindingSource1.DataSource = dt
            Me.DataGridView1.Refresh()
            Me.txtStatus.Text = "Status: " & Me.DataGridView1.RowCount & " Records Loaded."
            currentTextBox_TextChanged(Me, EventArgs.Empty, False)
            Me.sendResultsToStoredConnectionToolStripMenuItem.Enabled = True
        Catch ex As Exception
            MsgBox("Could not load XML: " & ex.Message)
        End Try


    End Sub
    
    function pickXMLTable(byref dts As DataSet) As string
    	
    	Dim ptForm As New frmPickXMLTable(dts)
    	
    	ptForm.ShowDialog
    	
    	pickXMLTable = ptForm.getSelectedTable
    	
    End function
    
    Sub AdminModeToolStripMenuItemClick(sender As Object, e As EventArgs) Handles adminModeToolStripMenuItem.Click

        If Not adminModeToolStripMenuItem.Checked Then
            Dim dr As DialogResult
            dr = MsgBox("Enable admin mode?", MsgBoxStyle.YesNo, "Confirm")
            If dr = Windows.Forms.DialogResult.Yes Then
                adminModeToolStripMenuItem.Checked = True
                btnRunQuery.Enabled = True
                txtRunAction.Enabled = True
            End If
        Else
            adminModeToolStripMenuItem.Checked = Not adminModeToolStripMenuItem.Checked
        End If

    End Sub
    
    Sub XMLDataEditorToolStripMenuItemClick(sender As Object, e As EventArgs) Handles xMLDataEditorToolStripMenuItem.Click

        Dim xmledit As New frmXMLEdit
        xmledit.ShowDialog()

    End Sub
    
    Private Sub ToolStripButtonConnect_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonConnect.Click

        testConnection()

    End Sub
End Class


