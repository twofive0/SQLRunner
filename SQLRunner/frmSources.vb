'
' Created by SharpDevelop.
' User: Media
' Date: 8/14/2013
' Time: 9:28 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class frmSources
	
	Private tblSources As Data.DataTable
	Private ds As DataSet
	
	Public Sub New()

		Me.InitializeComponent()
		Me.CboDBTypeSelectedValueChanged(Me, Nothing)
		ds = New DataSet
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
		
		'load our settings for active database
	 	Me.txtDatabase.Text = My.Settings.Database
        Me.txtPW.Text = My.Settings.Password
        Me.txtServer.Text = My.Settings.Server
        Me.txtUser.Text = My.Settings.User
        Me.txtTimeout.Value = My.Settings.Timeout
        Me.txtSDF.Text = My.Settings.SDFFile
        Me.cboDBType.Text = My.Settings.DBType
        Me.txtSDFPW.Text = My.Settings.SDFPW
        Me.txtConnectionName.Text = My.Settings.CurrentDatabase
        
        If My.Settings.EMailAddr = "" Then
        	Me.txtEMail.Text = "EMail goes here"
    	Else
    	   	Me.txtEMail.Text = My.Settings.EMailAddr
    	end if
		
		'if there's no currently saved database and we've imported one, let's save it.
		Button2Click(Me, Nothing, False)
		
		'try to set the currently active database
		Me.lstConnections.Text = My.Settings.CurrentDatabase
		

	End Sub
	
	Sub CboDBTypeSelectedValueChanged(sender As Object, e As EventArgs)
		
		
        If Me.cboDBType.Text = "SQL Server" Then
            Me.grpSQL.Enabled = True
            Me.txtSDF.Enabled = False
            Me.btnFileChoose.Enabled = False
            Me.txtSDFPW.Enabled = False
        Else
            Me.grpSQL.Enabled = False
            Me.txtSDF.Enabled = True
            Me.btnFileChoose.Enabled = True
            Me.txtSDFPW.Enabled = True
        End If
        
	End Sub
	
	Sub Button2Click(sender As Object, e As EventArgs, Optional showErrors As Boolean = True)
		
        Dim fieldEmpty As Boolean
        fieldEmpty = False

		If Me.cboDBType.Text = "SQL Server" Then
			If Me.txtConnectionName.Text = Nothing Then fieldEmpty = true
            If Me.txtDatabase.Text = Nothing Then fieldEmpty = True
            If Me.txtPW.Text = Nothing Then fieldEmpty = True
            If Me.txtServer.Text = Nothing Then fieldEmpty = True
            If Me.txtUser.Text = Nothing Then fieldEmpty = True
            If Me.txtTimeout.Value = Nothing Then fieldEmpty = True
        Else
            If Me.txtSDF.Text = Nothing Then fieldEmpty = True
        End If

        If fieldEmpty Then
            If showErrors Then MsgBox("Please fill in all fields")
            Exit Sub
        End If
        
        Dim rowFound As Boolean = false
	    Dim foundRows() As DataRow        
	    Try
        	foundRows = tblSources.Select("ConnectionName = '" & Me.txtConnectionName.Text & "'")        	
        	rowFound = true
        Catch ex As Exception
        End Try
        
        If foundRows.Length > 0 Then
        	foundRows(0).BeginEdit
              foundRows(0).Item("DBType") = Me.cboDBType.Text
              foundRows(0).Item("Server") = Me.txtServer.Text
              foundRows(0).Item("User") = Me.txtUser.text
              foundRows(0).Item("Password") = Me.txtPW.Text
              foundRows(0).Item("Timeout") = Me.txtTimeout.Text
              foundRows(0).Item("Path") = Me.txtSDF.Text
              foundRows(0).Item("FilePassword") = Me.txtSDFPW.Text
              foundRows(0).Item("Database") = Me.txtDatabase.Text
              foundRows(0).Item("ConnectionName") = Me.txtConnectionName.Text
              foundRows(0).EndEdit        	
        Else
        	Dim newConnRow As DataRow = tblSources.NewRow()

			newConnRow("DBType") = Me.cboDBType.Text
			newConnRow("Server") = Me.txtServer.Text
			newConnRow("User") = Me.txtUser.Text
			newConnRow("Password") = Me.txtPW.Text
			newConnRow("Timeout") = Me.txtTimeout.Text
			newConnRow("Path") = Me.txtSDF.Text
			newConnRow("FilePassword") = Me.txtSDFPW.Text
			newConnRow("Database") = Me.txtDatabase.Text
			newConnRow("ConnectionName") = Me.txtConnectionName.Text

			tblSources.Rows.Add(newConnRow)
        	
        End If
        
        Me.lstConnections.Refresh
        Me.lstConnections.SelectedValue = Me.txtConnectionName.text
        My.Settings.EMailAddr = Me.txtEMail.Text
		My.Settings.Save()
        
        ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory & "SavedConnections.xml")
	
	End Sub
	
	Sub BtnDeleteClick(sender As Object, e As EventArgs)
		
		Try
			
			tblSources.Rows.Remove(tblSources.Select("ConnectionName = '" & Me.lstConnections.Text & "'")(0))
			Me.lstConnections.SelectedIndex = 0
		Catch ex As exception
		End Try
		
		Me.lstConnections.Refresh
		ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory & "SavedConnections.xml")
		
	End Sub
	
	
	
	Sub BtnFileChooseClick(sender As Object, e As EventArgs)
		
		
        Dim fd As New OpenFileDialog

        With fd
            .Multiselect = False
        End With

        fd.ShowDialog()

		Me.txtSDF.Text = fd.FileName

	End Sub
	
	
	Sub LstConnectionsSelectedValueChanged(sender As Object, e As EventArgs)
		
		try
			Dim dr As DataRow() = tblSources.Select("ConnectionName = '" & Me.lstConnections.Text & "'")
			
			Me.txtConnectionName.Text = dr(0).Item("ConnectionName")
			Me.txtDatabase.Text = dr(0).Item("Database")
			Me.txtPW.Text = dr(0).Item("Password")
			Me.txtSDF.Text = dr(0).Item("Path")
			Me.txtSDFPW.Text = dr(0).Item("FilePassword")
			Me.txtServer.Text = dr(0).Item("Server")
			Me.txtTimeout.Text = dr(0).Item("Timeout")
			Me.txtUser.Text = dr(0).Item("User")
			Me.cboDBType.Text = dr(0).Item("DBType")
		Catch ex As Exception
			'fail quietly please
		End Try
		
	End Sub
	
	Sub BtnNewClick(sender As Object, e As EventArgs)
		
			Me.txtConnectionName.Text = Nothing
			Me.txtDatabase.Text = Nothing
			Me.txtPW.Text = Nothing
			Me.txtSDF.Text = Nothing
			Me.txtSDFPW.Text = Nothing
			Me.txtServer.Text = Nothing
			Me.txtTimeout.Text = 500
			Me.txtUser.Text = Nothing

		
	End Sub
	
	Sub BtnSaveUseClick(sender As Object, e As EventArgs)
		
		Button2Click(Me, Nothing)
		
        My.Settings.Database = Me.txtDatabase.Text
        My.Settings.Password = Me.txtPW.Text
        My.Settings.Server = Me.txtServer.Text
        My.Settings.User = Me.txtUser.Text
        My.Settings.Timeout = Me.txtTimeout.Value
        My.Settings.SDFFile = Me.txtSDF.Text
        My.Settings.DBType = Me.cboDBType.Text
        My.Settings.SDFPW = Me.txtSDFPW.Text
        My.Settings.CurrentDatabase = Me.txtConnectionName.Text
        My.Settings.EMailAddr = Me.txtEMail.Text

        My.Settings.Save()

        If frmMain.testConnection() = False Then
            MsgBox("Could not connect to database")
        End If
        

        Me.Close()
		
	End Sub

	
	Sub LstConnectionsDoubleClick(sender As Object, e As EventArgs)
		
		BtnSaveUseClick(Me, Nothing)
		
	End Sub
	
End Class
