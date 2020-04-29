'
' Created by SharpDevelop.
' User: Devin
' Date: 8/16/2013
' Time: 1:10 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class SendToConnection
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
		Me.label10 = New System.Windows.Forms.Label()
		Me.lstConnections = New System.Windows.Forms.ListBox()
		Me.btnSend = New System.Windows.Forms.Button()
		Me.pbProgress = New System.Windows.Forms.ProgressBar()
		Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		Me.txtStatus = New System.Windows.Forms.Label()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'label10
		'
		Me.label10.Location = New System.Drawing.Point(11, 7)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(142, 17)
		Me.label10.TabIndex = 2
		Me.label10.Text = "Available Connections"
		'
		'lstConnections
		'
		Me.lstConnections.FormattingEnabled = true
		Me.lstConnections.Location = New System.Drawing.Point(12, 27)
		Me.lstConnections.Name = "lstConnections"
		Me.lstConnections.Size = New System.Drawing.Size(330, 277)
		Me.lstConnections.TabIndex = 3
		AddHandler Me.lstConnections.DoubleClick, AddressOf Me.LstConnectionsDoubleClick
		'
		'btnSend
		'
		Me.btnSend.Location = New System.Drawing.Point(103, 310)
		Me.btnSend.Name = "btnSend"
		Me.btnSend.Size = New System.Drawing.Size(75, 23)
		Me.btnSend.TabIndex = 4
		Me.btnSend.Text = "&Send"
		Me.btnSend.UseVisualStyleBackColor = true
		AddHandler Me.btnSend.Click, AddressOf Me.BtnSendClick
		'
		'pbProgress
		'
		Me.pbProgress.Location = New System.Drawing.Point(12, 381)
		Me.pbProgress.Name = "pbProgress"
		Me.pbProgress.Size = New System.Drawing.Size(330, 23)
		Me.pbProgress.TabIndex = 5
		'
		'backgroundWorker1
		'
		Me.backgroundWorker1.WorkerReportsProgress = true
		AddHandler Me.backgroundWorker1.DoWork, AddressOf Me.BackgroundWorker1DoWork
		AddHandler Me.backgroundWorker1.ProgressChanged, AddressOf Me.BackgroundWorker1ProgressChanged
		AddHandler Me.backgroundWorker1.RunWorkerCompleted, AddressOf Me.BackgroundWorker1RunWorkerCompleted
		'
		'txtStatus
		'
		Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStatus.Location = New System.Drawing.Point(11, 336)
		Me.txtStatus.Name = "txtStatus"
		Me.txtStatus.Size = New System.Drawing.Size(329, 42)
		Me.txtStatus.TabIndex = 6
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(184, 310)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(75, 23)
		Me.btnClose.TabIndex = 7
		Me.btnClose.Text = "&Close"
		Me.btnClose.UseVisualStyleBackColor = true
		AddHandler Me.btnClose.Click, AddressOf Me.BtnCloseClick
		'
		'SendToConnection
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(354, 416)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.txtStatus)
		Me.Controls.Add(Me.pbProgress)
		Me.Controls.Add(Me.btnSend)
		Me.Controls.Add(Me.label10)
		Me.Controls.Add(Me.lstConnections)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "SendToConnection"
		Me.Text = "SendToConnection"
		Me.ResumeLayout(false)
	End Sub
	Private btnClose As System.Windows.Forms.Button
	Private txtStatus As System.Windows.Forms.Label
	Private backgroundWorker1 As System.ComponentModel.BackgroundWorker
	Private pbProgress As System.Windows.Forms.ProgressBar
	Private btnSend As System.Windows.Forms.Button
	Private lstConnections As System.Windows.Forms.ListBox
	Private label10 As System.Windows.Forms.Label
End Class
