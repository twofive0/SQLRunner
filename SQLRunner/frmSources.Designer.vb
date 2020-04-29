'
' Created by SharpDevelop.
' User: Media
' Date: 8/14/2013
' Time: 9:28 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class frmSources
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.lstConnections = New System.Windows.Forms.ListBox()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.txtSDF = New System.Windows.Forms.TextBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtSDFPW = New System.Windows.Forms.TextBox()
		Me.btnFileChoose = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.cboDBType = New System.Windows.Forms.ComboBox()
		Me.grpSQL = New System.Windows.Forms.GroupBox()
		Me.txtServer = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtPW = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtTimeout = New System.Windows.Forms.NumericUpDown()
		Me.txtUser = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtDatabase = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.txtConnectionName = New System.Windows.Forms.TextBox()
		Me.label9 = New System.Windows.Forms.Label()
		Me.btnNew = New System.Windows.Forms.Button()
		Me.btnSaveUse = New System.Windows.Forms.Button()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.txtEMail = New System.Windows.Forms.TextBox()
		Me.groupBox1.SuspendLayout
		Me.grpSQL.SuspendLayout
		CType(Me.txtTimeout,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'lstConnections
		'
		Me.lstConnections.FormattingEnabled = true
		Me.lstConnections.Location = New System.Drawing.Point(13, 26)
		Me.lstConnections.Name = "lstConnections"
		Me.lstConnections.Size = New System.Drawing.Size(215, 485)
		Me.lstConnections.TabIndex = 1
		AddHandler Me.lstConnections.SelectedValueChanged, AddressOf Me.LstConnectionsSelectedValueChanged
		AddHandler Me.lstConnections.DoubleClick, AddressOf Me.LstConnectionsDoubleClick
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.txtSDF)
		Me.groupBox1.Controls.Add(Me.Label8)
		Me.groupBox1.Controls.Add(Me.Label7)
		Me.groupBox1.Controls.Add(Me.txtSDFPW)
		Me.groupBox1.Controls.Add(Me.btnFileChoose)
		Me.groupBox1.Location = New System.Drawing.Point(243, 300)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(284, 101)
		Me.groupBox1.TabIndex = 7
		Me.groupBox1.TabStop = false
		Me.groupBox1.Text = "File Based DB Parameters"
		'
		'txtSDF
		'
		Me.txtSDF.Location = New System.Drawing.Point(66, 31)
		Me.txtSDF.Name = "txtSDF"
		Me.txtSDF.Size = New System.Drawing.Size(159, 20)
		Me.txtSDF.TabIndex = 1
		'
		'Label8
		'
		Me.Label8.AutoSize = true
		Me.Label8.Location = New System.Drawing.Point(13, 60)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(53, 13)
		Me.Label8.TabIndex = 3
		Me.Label8.Text = "Password"
		'
		'Label7
		'
		Me.Label7.AutoSize = true
		Me.Label7.Location = New System.Drawing.Point(13, 34)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(48, 13)
		Me.Label7.TabIndex = 0
		Me.Label7.Text = "File Path"
		'
		'txtSDFPW
		'
		Me.txtSDFPW.Location = New System.Drawing.Point(66, 57)
		Me.txtSDFPW.Name = "txtSDFPW"
		Me.txtSDFPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtSDFPW.Size = New System.Drawing.Size(159, 20)
		Me.txtSDFPW.TabIndex = 4
		'
		'btnFileChoose
		'
		Me.btnFileChoose.Location = New System.Drawing.Point(235, 28)
		Me.btnFileChoose.Name = "btnFileChoose"
		Me.btnFileChoose.Size = New System.Drawing.Size(26, 23)
		Me.btnFileChoose.TabIndex = 2
		Me.btnFileChoose.Text = "..."
		Me.btnFileChoose.UseVisualStyleBackColor = true
		AddHandler Me.btnFileChoose.Click, AddressOf Me.BtnFileChooseClick
		'
		'Label6
		'
		Me.Label6.AutoSize = true
		Me.Label6.Location = New System.Drawing.Point(242, 73)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(80, 13)
		Me.Label6.TabIndex = 2
		Me.Label6.Text = "Database Type"
		'
		'cboDBType
		'
		Me.cboDBType.FormattingEnabled = true
		Me.cboDBType.Items.AddRange(New Object() {"SQL Server", "SQL Compact (SDF)", "SQLite"})
		Me.cboDBType.Location = New System.Drawing.Point(328, 70)
		Me.cboDBType.Name = "cboDBType"
		Me.cboDBType.Size = New System.Drawing.Size(178, 21)
		Me.cboDBType.TabIndex = 3
		Me.cboDBType.Text = "SQL Server"
		AddHandler Me.cboDBType.SelectedValueChanged, AddressOf Me.CboDBTypeSelectedValueChanged
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
		Me.grpSQL.Location = New System.Drawing.Point(243, 97)
		Me.grpSQL.Name = "grpSQL"
		Me.grpSQL.Size = New System.Drawing.Size(284, 188)
		Me.grpSQL.TabIndex = 6
		Me.grpSQL.TabStop = false
		Me.grpSQL.Text = "SQL Server Parameters"
		'
		'txtServer
		'
		Me.txtServer.Location = New System.Drawing.Point(81, 19)
		Me.txtServer.Name = "txtServer"
		Me.txtServer.Size = New System.Drawing.Size(180, 20)
		Me.txtServer.TabIndex = 1
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
		'txtPW
		'
		Me.txtPW.Location = New System.Drawing.Point(81, 97)
		Me.txtPW.Name = "txtPW"
		Me.txtPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtPW.Size = New System.Drawing.Size(180, 20)
		Me.txtPW.TabIndex = 7
		'
		'Label5
		'
		Me.Label5.AutoSize = true
		Me.Label5.Location = New System.Drawing.Point(14, 147)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(128, 13)
		Me.Label5.TabIndex = 8
		Me.Label5.Text = "Connection Timeout (sec)"
		'
		'Label2
		'
		Me.Label2.AutoSize = true
		Me.Label2.Location = New System.Drawing.Point(14, 100)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(53, 13)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Password"
		'
		'txtTimeout
		'
		Me.txtTimeout.Location = New System.Drawing.Point(148, 145)
		Me.txtTimeout.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
		Me.txtTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.txtTimeout.Name = "txtTimeout"
		Me.txtTimeout.Size = New System.Drawing.Size(113, 20)
		Me.txtTimeout.TabIndex = 9
		Me.txtTimeout.Value = New Decimal(New Integer() {500, 0, 0, 0})
		'
		'txtUser
		'
		Me.txtUser.Location = New System.Drawing.Point(81, 71)
		Me.txtUser.Name = "txtUser"
		Me.txtUser.Size = New System.Drawing.Size(180, 20)
		Me.txtUser.TabIndex = 5
		'
		'Label3
		'
		Me.Label3.AutoSize = true
		Me.Label3.Location = New System.Drawing.Point(14, 74)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(60, 13)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "User Name"
		'
		'txtDatabase
		'
		Me.txtDatabase.Location = New System.Drawing.Point(81, 45)
		Me.txtDatabase.Name = "txtDatabase"
		Me.txtDatabase.Size = New System.Drawing.Size(180, 20)
		Me.txtDatabase.TabIndex = 3
		'
		'Label4
		'
		Me.Label4.AutoSize = true
		Me.Label4.Location = New System.Drawing.Point(14, 48)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(53, 13)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "Database"
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(350, 458)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 23)
		Me.btnDelete.TabIndex = 9
		Me.btnDelete.Text = "&Delete"
		Me.btnDelete.UseVisualStyleBackColor = true
		AddHandler Me.btnDelete.Click, AddressOf Me.BtnDeleteClick
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(431, 458)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(75, 23)
		Me.btnSave.TabIndex = 10
		Me.btnSave.Text = "&Save"
		Me.btnSave.UseVisualStyleBackColor = true
		AddHandler Me.btnSave.Click, AddressOf Me.Button2Click
		'
		'txtConnectionName
		'
		Me.txtConnectionName.Location = New System.Drawing.Point(340, 23)
		Me.txtConnectionName.Name = "txtConnectionName"
		Me.txtConnectionName.Size = New System.Drawing.Size(166, 20)
		Me.txtConnectionName.TabIndex = 5
		'
		'label9
		'
		Me.label9.Location = New System.Drawing.Point(242, 26)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(92, 23)
		Me.label9.TabIndex = 4
		Me.label9.Text = "Connection Name"
		'
		'btnNew
		'
		Me.btnNew.Location = New System.Drawing.Point(269, 458)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(75, 23)
		Me.btnNew.TabIndex = 8
		Me.btnNew.Text = "&New"
		Me.btnNew.UseVisualStyleBackColor = true
		AddHandler Me.btnNew.Click, AddressOf Me.BtnNewClick
		'
		'btnSaveUse
		'
		Me.btnSaveUse.Location = New System.Drawing.Point(332, 487)
		Me.btnSaveUse.Name = "btnSaveUse"
		Me.btnSaveUse.Size = New System.Drawing.Size(103, 23)
		Me.btnSaveUse.TabIndex = 11
		Me.btnSaveUse.Text = "Save and &Use"
		Me.btnSaveUse.UseVisualStyleBackColor = true
		AddHandler Me.btnSaveUse.Click, AddressOf Me.BtnSaveUseClick
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(12, 6)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(142, 17)
		Me.label10.TabIndex = 0
		Me.label10.Text = "Available Connections"
		'
		'label11
		'
		Me.label11.Location = New System.Drawing.Point(243, 404)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(92, 28)
		Me.label11.TabIndex = 26
		Me.label11.Text = "E-Mail Send-To Address"
		'
		'txtEMail
		'
		Me.txtEMail.Location = New System.Drawing.Point(341, 412)
		Me.txtEMail.Name = "txtEMail"
		Me.txtEMail.Size = New System.Drawing.Size(173, 20)
		Me.txtEMail.TabIndex = 25
		'
		'frmSources
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(549, 524)
		Me.Controls.Add(Me.label11)
		Me.Controls.Add(Me.txtEMail)
		Me.Controls.Add(Me.label10)
		Me.Controls.Add(Me.btnSaveUse)
		Me.Controls.Add(Me.btnNew)
		Me.Controls.Add(Me.label9)
		Me.Controls.Add(Me.txtConnectionName)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.groupBox1)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.cboDBType)
		Me.Controls.Add(Me.grpSQL)
		Me.Controls.Add(Me.lstConnections)
		Me.Name = "frmSources"
		Me.Text = "SQLRunner Setup"
		Me.groupBox1.ResumeLayout(false)
		Me.groupBox1.PerformLayout
		Me.grpSQL.ResumeLayout(false)
		Me.grpSQL.PerformLayout
		CType(Me.txtTimeout,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private txtEMail As System.Windows.Forms.TextBox
	Private label11 As System.Windows.Forms.Label
	Private btnSaveUse As System.Windows.Forms.Button
	Private label10 As System.Windows.Forms.Label
	Private btnNew As System.Windows.Forms.Button
	Private txtConnectionName As System.Windows.Forms.TextBox
	Private lstConnections As System.Windows.Forms.ListBox
	Private label9 As System.Windows.Forms.Label
	Private btnDelete As System.Windows.Forms.Button
	Private btnSave As System.Windows.Forms.Button
	Friend Label4 As System.Windows.Forms.Label
	Friend txtDatabase As System.Windows.Forms.TextBox
	Friend Label3 As System.Windows.Forms.Label
	Friend txtUser As System.Windows.Forms.TextBox
	Friend txtTimeout As System.Windows.Forms.NumericUpDown
	Friend Label2 As System.Windows.Forms.Label
	Friend Label5 As System.Windows.Forms.Label
	Friend txtPW As System.Windows.Forms.TextBox
	Friend Label1 As System.Windows.Forms.Label
	Friend txtServer As System.Windows.Forms.TextBox
	Friend grpSQL As System.Windows.Forms.GroupBox
	Friend cboDBType As System.Windows.Forms.ComboBox
	Friend Label6 As System.Windows.Forms.Label
	Friend btnFileChoose As System.Windows.Forms.Button
	Friend txtSDFPW As System.Windows.Forms.TextBox
	Friend Label7 As System.Windows.Forms.Label
	Friend Label8 As System.Windows.Forms.Label
	Friend txtSDF As System.Windows.Forms.TextBox
	Private groupBox1 As System.Windows.Forms.GroupBox
End Class
