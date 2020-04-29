<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tables")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Views")
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tbEditTabs = New System.Windows.Forms.TabControl()
        Me.popupTabMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCloseTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.renameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnRunQuery = New System.Windows.Forms.ToolStripButton()
        Me.txtRunAction = New System.Windows.Forms.ToolStripButton()
        Me.btnOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.cboSaveAs = New System.Windows.Forms.ToolStripComboBox()
        Me.btnExportDataset = New System.Windows.Forms.ToolStripButton()
        Me.btnEmailMultiSet = New System.Windows.Forms.ToolStripButton()
        Me.btnHelp = New System.Windows.Forms.ToolStripButton()
        Me.backRunQuery = New System.ComponentModel.BackgroundWorker()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.backRunAction = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintHTMLReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.convertMultisetToAccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.convertMultisetToSQLiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.sendResultsToStoredConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.xMLDataEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.loadFromXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.openScriptLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.adminModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.newTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.renameTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tvTables = New System.Windows.Forms.TreeView()
        Me.popupTablesListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.refreshTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.backExportMultiSet = New System.ComponentModel.BackgroundWorker()
        Me.ToolStripButtonConnect = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.popupTabMenu.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.popupTablesListMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtStatusLabel, Me.ToolStripStatusLabel1, Me.txtStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 511)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(914, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtStatusLabel
        '
        Me.txtStatusLabel.Name = "txtStatusLabel"
        Me.txtStatusLabel.Size = New System.Drawing.Size(140, 17)
        Me.txtStatusLabel.Text = "Database: (Not Available)"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'txtStatus
        '
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(77, 17)
        Me.txtStatus.Text = "Status: Ready"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbEditTabs)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BindingNavigator1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(662, 462)
        Me.SplitContainer1.SplitterDistance = 224
        Me.SplitContainer1.TabIndex = 1
        '
        'tbEditTabs
        '
        Me.tbEditTabs.ContextMenuStrip = Me.popupTabMenu
        Me.tbEditTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEditTabs.Location = New System.Drawing.Point(0, 0)
        Me.tbEditTabs.Name = "tbEditTabs"
        Me.tbEditTabs.SelectedIndex = 0
        Me.tbEditTabs.Size = New System.Drawing.Size(662, 224)
        Me.tbEditTabs.TabIndex = 4
        '
        'popupTabMenu
        '
        Me.popupTabMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCloseTab, Me.btnNewTab, Me.renameToolStripMenuItem})
        Me.popupTabMenu.Name = "popupTabMenu"
        Me.popupTabMenu.Size = New System.Drawing.Size(118, 70)
        '
        'btnCloseTab
        '
        Me.btnCloseTab.Name = "btnCloseTab"
        Me.btnCloseTab.Size = New System.Drawing.Size(117, 22)
        Me.btnCloseTab.Text = "Close"
        '
        'btnNewTab
        '
        Me.btnNewTab.Name = "btnNewTab"
        Me.btnNewTab.Size = New System.Drawing.Size(117, 22)
        Me.btnNewTab.Text = "New"
        '
        'renameToolStripMenuItem
        '
        Me.renameToolStripMenuItem.Name = "renameToolStripMenuItem"
        Me.renameToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.renameToolStripMenuItem.Text = "Rename"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 209)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(662, 25)
        Me.BindingNavigator1.TabIndex = 1
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(662, 206)
        Me.DataGridView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonConnect, Me.btnRunQuery, Me.txtRunAction, Me.btnOpenFile, Me.btnSave, Me.cboSaveAs, Me.btnExportDataset, Me.btnEmailMultiSet, Me.btnHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(914, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRunQuery
        '
        Me.btnRunQuery.Enabled = False
        Me.btnRunQuery.Image = CType(resources.GetObject("btnRunQuery.Image"), System.Drawing.Image)
        Me.btnRunQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRunQuery.Name = "btnRunQuery"
        Me.btnRunQuery.Size = New System.Drawing.Size(83, 22)
        Me.btnRunQuery.Text = "Run Query"
        '
        'txtRunAction
        '
        Me.txtRunAction.Enabled = False
        Me.txtRunAction.Image = CType(resources.GetObject("txtRunAction.Image"), System.Drawing.Image)
        Me.txtRunAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.txtRunAction.Name = "txtRunAction"
        Me.txtRunAction.Size = New System.Drawing.Size(121, 22)
        Me.txtRunAction.Text = "Run Action Query"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Image = CType(resources.GetObject("btnOpenFile.Image"), System.Drawing.Image)
        Me.btnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(89, 22)
        Me.btnOpenFile.Text = "Open Script"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 22)
        Me.btnSave.Text = "Save Data As"
        '
        'cboSaveAs
        '
        Me.cboSaveAs.Items.AddRange(New Object() {"CSV", "High Compression Format", "Excel (Tab Delimited)", "XML", "Choose Delimiter"})
        Me.cboSaveAs.Name = "cboSaveAs"
        Me.cboSaveAs.Size = New System.Drawing.Size(140, 25)
        Me.cboSaveAs.Text = "CSV"
        '
        'btnExportDataset
        '
        Me.btnExportDataset.Enabled = False
        Me.btnExportDataset.Image = CType(resources.GetObject("btnExportDataset.Image"), System.Drawing.Image)
        Me.btnExportDataset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportDataset.Name = "btnExportDataset"
        Me.btnExportDataset.Size = New System.Drawing.Size(102, 22)
        Me.btnExportDataset.Text = "Export Dataset"
        '
        'btnEmailMultiSet
        '
        Me.btnEmailMultiSet.Enabled = False
        Me.btnEmailMultiSet.Image = CType(resources.GetObject("btnEmailMultiSet.Image"), System.Drawing.Image)
        Me.btnEmailMultiSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEmailMultiSet.Name = "btnEmailMultiSet"
        Me.btnEmailMultiSet.Size = New System.Drawing.Size(103, 22)
        Me.btnEmailMultiSet.Text = "E-Mail Dataset"
        '
        'btnHelp
        '
        Me.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(23, 22)
        Me.btnHelp.Text = "Help/About"
        '
        'backRunQuery
        '
        '
        'BindingSource1
        '
        '
        'backRunAction
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.toolsToolStripMenuItem, Me.tabsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(914, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenScriptToolStripMenuItem, Me.SaveScriptToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintHTMLReportToolStripMenuItem, Me.ToolStripSeparator3, Me.SettingsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenScriptToolStripMenuItem
        '
        Me.OpenScriptToolStripMenuItem.Name = "OpenScriptToolStripMenuItem"
        Me.OpenScriptToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenScriptToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.OpenScriptToolStripMenuItem.Text = "&Open Script"
        '
        'SaveScriptToolStripMenuItem
        '
        Me.SaveScriptToolStripMenuItem.Name = "SaveScriptToolStripMenuItem"
        Me.SaveScriptToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveScriptToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SaveScriptToolStripMenuItem.Text = "&Save Script (Current Tab)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        '
        'PrintHTMLReportToolStripMenuItem
        '
        Me.PrintHTMLReportToolStripMenuItem.Name = "PrintHTMLReportToolStripMenuItem"
        Me.PrintHTMLReportToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.PrintHTMLReportToolStripMenuItem.Text = "&Print HTML Report"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(242, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SettingsToolStripMenuItem.Text = "S&ettings/DB Connections"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator2, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.convertMultisetToAccessToolStripMenuItem, Me.convertMultisetToSQLiteToolStripMenuItem, Me.sendResultsToStoredConnectionToolStripMenuItem, Me.toolStripSeparator4, Me.xMLDataEditorToolStripMenuItem, Me.loadFromXMLToolStripMenuItem, Me.toolStripSeparator5, Me.openScriptLogToolStripMenuItem, Me.adminModeToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.toolsToolStripMenuItem.Text = "T&ools"
        '
        'convertMultisetToAccessToolStripMenuItem
        '
        Me.convertMultisetToAccessToolStripMenuItem.Name = "convertMultisetToAccessToolStripMenuItem"
        Me.convertMultisetToAccessToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.convertMultisetToAccessToolStripMenuItem.Text = "Convert Multiset to &Access"
        '
        'convertMultisetToSQLiteToolStripMenuItem
        '
        Me.convertMultisetToSQLiteToolStripMenuItem.Name = "convertMultisetToSQLiteToolStripMenuItem"
        Me.convertMultisetToSQLiteToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.convertMultisetToSQLiteToolStripMenuItem.Text = "Convert Multiset to S&QLite"
        '
        'sendResultsToStoredConnectionToolStripMenuItem
        '
        Me.sendResultsToStoredConnectionToolStripMenuItem.Enabled = False
        Me.sendResultsToStoredConnectionToolStripMenuItem.Name = "sendResultsToStoredConnectionToolStripMenuItem"
        Me.sendResultsToStoredConnectionToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.sendResultsToStoredConnectionToolStripMenuItem.Text = "&Send Results to Stored Connection"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(253, 6)
        '
        'xMLDataEditorToolStripMenuItem
        '
        Me.xMLDataEditorToolStripMenuItem.Name = "xMLDataEditorToolStripMenuItem"
        Me.xMLDataEditorToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.xMLDataEditorToolStripMenuItem.Text = "X&ML Data Editor"
        '
        'loadFromXMLToolStripMenuItem
        '
        Me.loadFromXMLToolStripMenuItem.Name = "loadFromXMLToolStripMenuItem"
        Me.loadFromXMLToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.loadFromXMLToolStripMenuItem.Text = "Load From &XML"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(253, 6)
        '
        'openScriptLogToolStripMenuItem
        '
        Me.openScriptLogToolStripMenuItem.Name = "openScriptLogToolStripMenuItem"
        Me.openScriptLogToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.openScriptLogToolStripMenuItem.Text = "Open Script &Log"
        '
        'adminModeToolStripMenuItem
        '
        Me.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem"
        Me.adminModeToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.adminModeToolStripMenuItem.Text = "A&dmin Mode"
        '
        'tabsToolStripMenuItem
        '
        Me.tabsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newTabToolStripMenuItem, Me.closeTabToolStripMenuItem, Me.renameTabToolStripMenuItem})
        Me.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem"
        Me.tabsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.tabsToolStripMenuItem.Text = "&Tabs"
        '
        'newTabToolStripMenuItem
        '
        Me.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem"
        Me.newTabToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.newTabToolStripMenuItem.Text = "&New Tab"
        '
        'closeTabToolStripMenuItem
        '
        Me.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem"
        Me.closeTabToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.closeTabToolStripMenuItem.Text = "&Close Tab"
        '
        'renameTabToolStripMenuItem
        '
        Me.renameTabToolStripMenuItem.Name = "renameTabToolStripMenuItem"
        Me.renameTabToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.renameTabToolStripMenuItem.Text = "&Rename Tab"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutManualToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutManualToolStripMenuItem
        '
        Me.AboutManualToolStripMenuItem.Name = "AboutManualToolStripMenuItem"
        Me.AboutManualToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutManualToolStripMenuItem.Text = "&About/Manual"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tvTables)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(914, 462)
        Me.SplitContainer2.SplitterDistance = 248
        Me.SplitContainer2.TabIndex = 3
        '
        'tvTables
        '
        Me.tvTables.ContextMenuStrip = Me.popupTablesListMenu
        Me.tvTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvTables.ImageIndex = 0
        Me.tvTables.ImageList = Me.imageList1
        Me.tvTables.Location = New System.Drawing.Point(0, 0)
        Me.tvTables.Name = "tvTables"
        TreeNode1.ImageKey = "table"
        TreeNode1.Name = "Tables"
        TreeNode1.SelectedImageKey = "table"
        TreeNode1.Tag = "Tables"
        TreeNode1.Text = "Tables"
        TreeNode2.ImageKey = "query"
        TreeNode2.Name = "Views"
        TreeNode2.SelectedImageKey = "query"
        TreeNode2.Tag = "Views"
        TreeNode2.Text = "Views"
        Me.tvTables.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.tvTables.SelectedImageIndex = 0
        Me.tvTables.Size = New System.Drawing.Size(248, 462)
        Me.tvTables.TabIndex = 1
        '
        'popupTablesListMenu
        '
        Me.popupTablesListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.refreshTablesToolStripMenuItem})
        Me.popupTablesListMenu.Name = "popupTablesListMenu"
        Me.popupTablesListMenu.Size = New System.Drawing.Size(151, 26)
        '
        'refreshTablesToolStripMenuItem
        '
        Me.refreshTablesToolStripMenuItem.Name = "refreshTablesToolStripMenuItem"
        Me.refreshTablesToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.refreshTablesToolStripMenuItem.Text = "Refresh Tables"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "table")
        Me.imageList1.Images.SetKeyName(1, "query")
        '
        'backExportMultiSet
        '
        Me.backExportMultiSet.WorkerReportsProgress = True
        '
        'ToolStripButtonConnect
        '
        Me.ToolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonConnect.Image = CType(resources.GetObject("ToolStripButtonConnect.Image"), System.Drawing.Image)
        Me.ToolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonConnect.Name = "ToolStripButtonConnect"
        Me.ToolStripButtonConnect.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonConnect.Text = "Connect"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 533)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "SQL Runner"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.popupTabMenu.ResumeLayout(False)
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.popupTablesListMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents xMLDataEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents adminModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents loadFromXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openScriptLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sendResultsToStoredConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents convertMultisetToSQLiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents refreshTablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popupTablesListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents convertMultisetToAccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents renameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tvTables As System.Windows.Forms.TreeView
    Friend WithEvents btnNewTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCloseTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popupTabMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents backExportMultiSet As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEmailMultiSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExportDataset As System.Windows.Forms.ToolStripButton
    Friend WithEvents renameTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbEditTabs As System.Windows.Forms.TabControl
    Friend WithEvents closeTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents newTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRunQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboSaveAs As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRunAction As System.Windows.Forms.ToolStripButton
    Friend WithEvents backRunQuery As System.ComponentModel.BackgroundWorker
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents backRunAction As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintHTMLReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripButtonConnect As System.Windows.Forms.ToolStripButton

End Class
