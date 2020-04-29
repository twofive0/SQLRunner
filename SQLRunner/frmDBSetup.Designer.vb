<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    	Me.txtServer = New System.Windows.Forms.TextBox()
    	Me.Label1 = New System.Windows.Forms.Label()
    	Me.Label2 = New System.Windows.Forms.Label()
    	Me.txtPW = New System.Windows.Forms.TextBox()
    	Me.Label3 = New System.Windows.Forms.Label()
    	Me.txtUser = New System.Windows.Forms.TextBox()
    	Me.Label4 = New System.Windows.Forms.Label()
    	Me.txtDatabase = New System.Windows.Forms.TextBox()
    	Me.btnSave = New System.Windows.Forms.Button()
    	Me.btnCancel = New System.Windows.Forms.Button()
    	Me.txtTimeout = New System.Windows.Forms.NumericUpDown()
    	Me.Label5 = New System.Windows.Forms.Label()
    	Me.grpSQL = New System.Windows.Forms.GroupBox()
    	Me.cboDBType = New System.Windows.Forms.ComboBox()
    	Me.Label6 = New System.Windows.Forms.Label()
    	Me.txtSDF = New System.Windows.Forms.TextBox()
    	Me.Label7 = New System.Windows.Forms.Label()
    	Me.btnFileChoose = New System.Windows.Forms.Button()
    	Me.Label8 = New System.Windows.Forms.Label()
    	Me.txtSDFPW = New System.Windows.Forms.TextBox()
    	Me.groupBox1 = New System.Windows.Forms.GroupBox()
    	Me.txtEMail = New System.Windows.Forms.TextBox()
    	Me.label9 = New System.Windows.Forms.Label()
    	CType(Me.txtTimeout,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.grpSQL.SuspendLayout
    	Me.groupBox1.SuspendLayout
    	Me.SuspendLayout
    	'
    	'txtServer
    	'
    	Me.txtServer.Location = New System.Drawing.Point(81, 19)
    	Me.txtServer.Name = "txtServer"
    	Me.txtServer.Size = New System.Drawing.Size(180, 20)
    	Me.txtServer.TabIndex = 4
    	'
    	'Label1
    	'
    	Me.Label1.AutoSize = true
    	Me.Label1.Location = New System.Drawing.Point(14, 22)
    	Me.Label1.Name = "Label1"
    	Me.Label1.Size = New System.Drawing.Size(38, 13)
    	Me.Label1.TabIndex = 0
    	Me.Label1.Text = "Server"
    	'
    	'Label2
    	'
    	Me.Label2.AutoSize = true
    	Me.Label2.Location = New System.Drawing.Point(14, 100)
    	Me.Label2.Name = "Label2"
    	Me.Label2.Size = New System.Drawing.Size(53, 13)
    	Me.Label2.TabIndex = 3
    	Me.Label2.Text = "Password"
    	'
    	'txtPW
    	'
    	Me.txtPW.Location = New System.Drawing.Point(81, 97)
    	Me.txtPW.Name = "txtPW"
    	Me.txtPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    	Me.txtPW.Size = New System.Drawing.Size(180, 20)
    	Me.txtPW.TabIndex = 7
    	'
    	'Label3
    	'
    	Me.Label3.AutoSize = true
    	Me.Label3.Location = New System.Drawing.Point(14, 74)
    	Me.Label3.Name = "Label3"
    	Me.Label3.Size = New System.Drawing.Size(60, 13)
    	Me.Label3.TabIndex = 2
    	Me.Label3.Text = "User Name"
    	'
    	'txtUser
    	'
    	Me.txtUser.Location = New System.Drawing.Point(81, 71)
    	Me.txtUser.Name = "txtUser"
    	Me.txtUser.Size = New System.Drawing.Size(180, 20)
    	Me.txtUser.TabIndex = 6
    	'
    	'Label4
    	'
    	Me.Label4.AutoSize = true
    	Me.Label4.Location = New System.Drawing.Point(14, 48)
    	Me.Label4.Name = "Label4"
    	Me.Label4.Size = New System.Drawing.Size(53, 13)
    	Me.Label4.TabIndex = 1
    	Me.Label4.Text = "Database"
    	'
    	'txtDatabase
    	'
    	Me.txtDatabase.Location = New System.Drawing.Point(81, 45)
    	Me.txtDatabase.Name = "txtDatabase"
    	Me.txtDatabase.Size = New System.Drawing.Size(180, 20)
    	Me.txtDatabase.TabIndex = 5
    	'
    	'btnSave
    	'
    	Me.btnSave.Location = New System.Drawing.Point(159, 447)
    	Me.btnSave.Name = "btnSave"
    	Me.btnSave.Size = New System.Drawing.Size(75, 23)
    	Me.btnSave.TabIndex = 8
    	Me.btnSave.Text = "&Save"
    	Me.btnSave.UseVisualStyleBackColor = true
    	'
    	'btnCancel
    	'
    	Me.btnCancel.Location = New System.Drawing.Point(240, 447)
    	Me.btnCancel.Name = "btnCancel"
    	Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    	Me.btnCancel.TabIndex = 9
    	Me.btnCancel.Text = "&Cancel"
    	Me.btnCancel.UseVisualStyleBackColor = true
    	'
    	'txtTimeout
    	'
    	Me.txtTimeout.Location = New System.Drawing.Point(148, 145)
    	Me.txtTimeout.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
    	Me.txtTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    	Me.txtTimeout.Name = "txtTimeout"
    	Me.txtTimeout.Size = New System.Drawing.Size(113, 20)
    	Me.txtTimeout.TabIndex = 10
    	Me.txtTimeout.Value = New Decimal(New Integer() {500, 0, 0, 0})
    	'
    	'Label5
    	'
    	Me.Label5.AutoSize = true
    	Me.Label5.Location = New System.Drawing.Point(14, 147)
    	Me.Label5.Name = "Label5"
    	Me.Label5.Size = New System.Drawing.Size(128, 13)
    	Me.Label5.TabIndex = 11
    	Me.Label5.Text = "Connection Timeout (sec)"
    	'
    	'grpSQL
    	'
    	Me.grpSQL.Controls.Add(Me.txtServer)
    	Me.grpSQL.Controls.Add(Me.Label1)
    	Me.grpSQL.Controls.Add(Me.txtPW)
    	Me.grpSQL.Controls.Add(Me.Label5)
    	Me.grpSQL.Controls.Add(Me.Label2)
    	Me.grpSQL.Controls.Add(Me.txtTimeout)
    	Me.grpSQL.Controls.Add(Me.txtUser)
    	Me.grpSQL.Controls.Add(Me.Label3)
    	Me.grpSQL.Controls.Add(Me.txtDatabase)
    	Me.grpSQL.Controls.Add(Me.Label4)
    	Me.grpSQL.Location = New System.Drawing.Point(31, 72)
    	Me.grpSQL.Name = "grpSQL"
    	Me.grpSQL.Size = New System.Drawing.Size(284, 188)
    	Me.grpSQL.TabIndex = 14
    	Me.grpSQL.TabStop = false
    	Me.grpSQL.Text = "SQL Server Parameters"
    	'
    	'cboDBType
    	'
    	Me.cboDBType.FormattingEnabled = true
    	Me.cboDBType.Items.AddRange(New Object() {"SQL Server", "SQL Compact (SDF)", "SQLite"})
    	Me.cboDBType.Location = New System.Drawing.Point(114, 21)
    	Me.cboDBType.Name = "cboDBType"
    	Me.cboDBType.Size = New System.Drawing.Size(178, 21)
    	Me.cboDBType.TabIndex = 15
    	Me.cboDBType.Text = "SQL Server"
    	'
    	'Label6
    	'
    	Me.Label6.AutoSize = true
    	Me.Label6.Location = New System.Drawing.Point(28, 24)
    	Me.Label6.Name = "Label6"
    	Me.Label6.Size = New System.Drawing.Size(80, 13)
    	Me.Label6.TabIndex = 16
    	Me.Label6.Text = "Database Type"
    	'
    	'txtSDF
    	'
    	Me.txtSDF.Location = New System.Drawing.Point(66, 31)
    	Me.txtSDF.Name = "txtSDF"
    	Me.txtSDF.Size = New System.Drawing.Size(159, 20)
    	Me.txtSDF.TabIndex = 17
    	'
    	'Label7
    	'
    	Me.Label7.AutoSize = true
    	Me.Label7.Location = New System.Drawing.Point(13, 34)
    	Me.Label7.Name = "Label7"
    	Me.Label7.Size = New System.Drawing.Size(48, 13)
    	Me.Label7.TabIndex = 18
    	Me.Label7.Text = "File Path"
    	'
    	'btnFileChoose
    	'
    	Me.btnFileChoose.Location = New System.Drawing.Point(235, 28)
    	Me.btnFileChoose.Name = "btnFileChoose"
    	Me.btnFileChoose.Size = New System.Drawing.Size(26, 23)
    	Me.btnFileChoose.TabIndex = 19
    	Me.btnFileChoose.Text = "..."
    	Me.btnFileChoose.UseVisualStyleBackColor = true
    	'
    	'Label8
    	'
    	Me.Label8.AutoSize = true
    	Me.Label8.Location = New System.Drawing.Point(13, 60)
    	Me.Label8.Name = "Label8"
    	Me.Label8.Size = New System.Drawing.Size(53, 13)
    	Me.Label8.TabIndex = 21
    	Me.Label8.Text = "Password"
    	'
    	'txtSDFPW
    	'
    	Me.txtSDFPW.Location = New System.Drawing.Point(66, 57)
    	Me.txtSDFPW.Name = "txtSDFPW"
    	Me.txtSDFPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    	Me.txtSDFPW.Size = New System.Drawing.Size(159, 20)
    	Me.txtSDFPW.TabIndex = 20
    	'
    	'groupBox1
    	'
    	Me.groupBox1.Controls.Add(Me.txtSDF)
    	Me.groupBox1.Controls.Add(Me.Label8)
    	Me.groupBox1.Controls.Add(Me.Label7)
    	Me.groupBox1.Controls.Add(Me.txtSDFPW)
    	Me.groupBox1.Controls.Add(Me.btnFileChoose)
    	Me.groupBox1.Location = New System.Drawing.Point(31, 275)
    	Me.groupBox1.Name = "groupBox1"
    	Me.groupBox1.Size = New System.Drawing.Size(284, 101)
    	Me.groupBox1.TabIndex = 22
    	Me.groupBox1.TabStop = false
    	Me.groupBox1.Text = "File Based DB Parameters"
    	'
    	'txtEMail
    	'
    	Me.txtEMail.Location = New System.Drawing.Point(142, 401)
    	Me.txtEMail.Name = "txtEMail"
    	Me.txtEMail.Size = New System.Drawing.Size(173, 20)
    	Me.txtEMail.TabIndex = 23
    	'
    	'label9
    	'
    	Me.label9.Location = New System.Drawing.Point(44, 393)
    	Me.label9.Name = "label9"
    	Me.label9.Size = New System.Drawing.Size(92, 28)
    	Me.label9.TabIndex = 24
    	Me.label9.Text = "E-Mail Send-To Address"
    	'
    	'frmDBSetup
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(340, 501)
    	Me.Controls.Add(Me.label9)
    	Me.Controls.Add(Me.txtEMail)
    	Me.Controls.Add(Me.groupBox1)
    	Me.Controls.Add(Me.Label6)
    	Me.Controls.Add(Me.cboDBType)
    	Me.Controls.Add(Me.grpSQL)
    	Me.Controls.Add(Me.btnCancel)
    	Me.Controls.Add(Me.btnSave)
    	Me.Name = "frmDBSetup"
    	Me.Text = "Database Setup"
    	CType(Me.txtTimeout,System.ComponentModel.ISupportInitialize).EndInit
    	Me.grpSQL.ResumeLayout(false)
    	Me.grpSQL.PerformLayout
    	Me.groupBox1.ResumeLayout(false)
    	Me.groupBox1.PerformLayout
    	Me.ResumeLayout(false)
    	Me.PerformLayout
    End Sub
    Private txtEMail As System.Windows.Forms.TextBox
    Private label9 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpSQL As System.Windows.Forms.GroupBox
    Friend WithEvents cboDBType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSDF As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnFileChoose As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSDFPW As System.Windows.Forms.TextBox
End Class
