Public Class frmDBSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim fieldEmpty As Boolean
        fieldEmpty = False

        If Me.cboDBType.Text = "SQL Server" Then
            If Me.txtDatabase.Text = Nothing Then fieldEmpty = True
            If Me.txtPW.Text = Nothing Then fieldEmpty = True
            If Me.txtServer.Text = Nothing Then fieldEmpty = True
            If Me.txtUser.Text = Nothing Then fieldEmpty = True
            If Me.txtTimeout.Value = Nothing Then fieldEmpty = True
        Else
            If Me.txtSDF.Text = Nothing Then fieldEmpty = True
        End If

        If fieldEmpty Then
            MsgBox("Please fill in all fields")
            Exit Sub
        End If


        My.Settings.Database = Me.txtDatabase.Text
        My.Settings.Password = Me.txtPW.Text
        My.Settings.Server = Me.txtServer.Text
        My.Settings.User = Me.txtUser.Text
        My.Settings.Timeout = Me.txtTimeout.Value
        My.Settings.SDFFile = Me.txtSDF.Text
        My.Settings.DBType = Me.cboDBType.Text
        My.Settings.SDFPW = Me.txtSDFPW.Text
        My.Settings.EMailAddr = Me.txtEMail.Text

        My.Settings.Save()

        If frmMain.testConnection() = False Then
            MsgBox("Could not connect to database")
        End If

        Me.Close()


    End Sub

    Private Sub frmDBSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtDatabase.Text = My.Settings.Database
        Me.txtPW.Text = My.Settings.Password
        Me.txtServer.Text = My.Settings.Server
        Me.txtUser.Text = My.Settings.User
        Me.txtTimeout.Value = My.Settings.Timeout
        Me.txtSDF.Text = My.Settings.SDFFile
        Me.cboDBType.Text = My.Settings.DBType
        Me.txtSDFPW.Text = My.Settings.SDFPW
        
        If My.Settings.EMailAddr = "" Then
        	Me.txtEMail.Text = "E-Mail Goes Here"
    	Else
    	   	Me.txtEMail.Text = My.Settings.EMailAddr
    	end if

    End Sub

    Private Sub cboDBType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDBType.SelectedValueChanged

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

    Private Sub btnFileChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileChoose.Click

        Dim fd As New OpenFileDialog

        With fd
            .Multiselect = False
        End With

        fd.ShowDialog()

        Me.txtSDF.Text = fd.FileName

    End Sub

End Class