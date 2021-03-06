﻿' Created by SharpDevelop.
' User: Devin
' Date: 5/29/2013
' Time: 8:59 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
Partial Class SQLiteConvert
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
		Me.txtSourceFile = New System.Windows.Forms.TextBox()
		Me.btnSelectSource = New System.Windows.Forms.Button()
		Me.btnSelectTarget = New System.Windows.Forms.Button()
		Me.txtTargetFile = New System.Windows.Forms.TextBox()
		Me.btnGo = New System.Windows.Forms.Button()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.pbProgress = New System.Windows.Forms.ToolStripProgressBar()
		Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.txtStatus = New System.Windows.Forms.ToolStripStatusLabel()
		Me.label1 = New System.Windows.Forms.Label()
		Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		Me.statusStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'txtSourceFile
		'
		Me.txtSourceFile.Location = New System.Drawing.Point(33, 52)
		Me.txtSourceFile.Name = "txtSourceFile"
		Me.txtSourceFile.Size = New System.Drawing.Size(273, 20)
		Me.txtSourceFile.TabIndex = 0
		'
		'btnSelectSource
		'
		Me.btnSelectSource.Location = New System.Drawing.Point(322, 50)
		Me.btnSelectSource.Name = "btnSelectSource"
		Me.btnSelectSource.Size = New System.Drawing.Size(105, 23)
		Me.btnSelectSource.TabIndex = 1
		Me.btnSelectSource.Text = "Select Source"
		Me.btnSelectSource.UseVisualStyleBackColor = true
		AddHandler Me.btnSelectSource.Click, AddressOf Me.BtnSelectSourceClick
		'
		'btnSelectTarget
		'
		Me.btnSelectTarget.Location = New System.Drawing.Point(322, 85)
		Me.btnSelectTarget.Name = "btnSelectTarget"
		Me.btnSelectTarget.Size = New System.Drawing.Size(105, 23)
		Me.btnSelectTarget.TabIndex = 3
		Me.btnSelectTarget.Text = "Select Target"
		Me.btnSelectTarget.UseVisualStyleBackColor = true
		AddHandler Me.btnSelectTarget.Click, AddressOf Me.BtnSelectTargetClick
		'
		'txtTargetFile
		'
		Me.txtTargetFile.Location = New System.Drawing.Point(33, 87)
		Me.txtTargetFile.Name = "txtTargetFile"
		Me.txtTargetFile.Size = New System.Drawing.Size(273, 20)
		Me.txtTargetFile.TabIndex = 2
		'
		'btnGo
		'
		Me.btnGo.Location = New System.Drawing.Point(172, 119)
		Me.btnGo.Name = "btnGo"
		Me.btnGo.Size = New System.Drawing.Size(87, 48)
		Me.btnGo.TabIndex = 4
		Me.btnGo.Text = "Go!"
		Me.btnGo.UseVisualStyleBackColor = true
		AddHandler Me.btnGo.Click, AddressOf Me.BtnGoClick
		'
		'statusStrip1
		'
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbProgress, Me.toolStripStatusLabel1, Me.txtStatus})
		Me.statusStrip1.Location = New System.Drawing.Point(0, 186)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(440, 22)
		Me.statusStrip1.TabIndex = 5
		Me.statusStrip1.Text = "statusStrip1"
		'
		'pbProgress
		'
		Me.pbProgress.Name = "pbProgress"
		Me.pbProgress.Size = New System.Drawing.Size(100, 16)
		'
		'toolStripStatusLabel1
		'
		Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
		Me.toolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
		Me.toolStripStatusLabel1.Text = "|"
		'
		'txtStatus
		'
		Me.txtStatus.Name = "txtStatus"
		Me.txtStatus.Size = New System.Drawing.Size(39, 17)
		Me.txtStatus.Text = "Ready"
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(22, 10)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(397, 37)
		Me.label1.TabIndex = 6
		Me.label1.Text = "Select Source (SQLRunner-created .7z File) then select a target (SQLite file) the"& _ 
		"n click the Go! button"
		'
		'backgroundWorker1
		'
		Me.backgroundWorker1.WorkerReportsProgress = true
		Me.backgroundWorker1.WorkerSupportsCancellation = true
		AddHandler Me.backgroundWorker1.DoWork, AddressOf Me.BackgroundWorker1DoWork
		AddHandler Me.backgroundWorker1.ProgressChanged, AddressOf Me.BackgroundWorker1ProgressChanged
		'
		'SQLiteConvert
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(440, 208)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.btnGo)
		Me.Controls.Add(Me.btnSelectTarget)
		Me.Controls.Add(Me.txtTargetFile)
		Me.Controls.Add(Me.btnSelectSource)
		Me.Controls.Add(Me.txtSourceFile)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "SQLiteConvert"
		Me.Text = "Multiset Convert-O-Matic (SQLite)"
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private backgroundWorker1 As System.ComponentModel.BackgroundWorker
	Private label1 As System.Windows.Forms.Label
	Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
	Private txtStatus As System.Windows.Forms.ToolStripStatusLabel
	Private pbProgress As System.Windows.Forms.ToolStripProgressBar
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private btnGo As System.Windows.Forms.Button
	Private txtTargetFile As System.Windows.Forms.TextBox
	Private btnSelectTarget As System.Windows.Forms.Button
	Private btnSelectSource As System.Windows.Forms.Button
	Private txtSourceFile As System.Windows.Forms.TextBox
	
End Class
