namespace SynergyConverter
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCsCode = new System.Windows.Forms.TextBox();
            this.mnuCs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCsCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCsPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCsSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCsClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCsTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCsCode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSynergyCode = new System.Windows.Forms.TextBox();
            this.mnuSynergy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSynergyCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSynergyCopySelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSynergyClear = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSynergyCode = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSaveAsTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTranslate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAsTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mnuEditClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mnuCs.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mnuSynergy.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mnuMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(751, 379);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(751, 404);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 330);
            this.panel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(751, 330);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCsCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 317);
            this.panel2.TabIndex = 4;
            // 
            // txtCsCode
            // 
            this.txtCsCode.AcceptsReturn = true;
            this.txtCsCode.AcceptsTab = true;
            this.txtCsCode.ContextMenuStrip = this.mnuCs;
            this.txtCsCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCsCode.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCsCode.Location = new System.Drawing.Point(0, 0);
            this.txtCsCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtCsCode.Multiline = true;
            this.txtCsCode.Name = "txtCsCode";
            this.txtCsCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCsCode.Size = new System.Drawing.Size(378, 317);
            this.txtCsCode.TabIndex = 3;
            this.txtCsCode.WordWrap = false;
            this.txtCsCode.TextChanged += new System.EventHandler(this.txtCsCode_TextChanged);
            this.txtCsCode.Leave += new System.EventHandler(this.configureUI);
            this.txtCsCode.Enter += new System.EventHandler(this.configureUI);
            this.txtCsCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtCsCode_MouseUp);
            // 
            // mnuCs
            // 
            this.mnuCs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCsCut,
            this.mnuCsCopy,
            this.mnuCsPaste,
            this.toolStripMenuItem1,
            this.mnuCsSelectAll,
            this.mnuCsClear,
            this.toolStripMenuItem2,
            this.mnuCsTranslate});
            this.mnuCs.Name = "mnuCs";
            this.mnuCs.Size = new System.Drawing.Size(182, 148);
            this.mnuCs.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuCs_ItemClicked);
            this.mnuCs.Opening += new System.ComponentModel.CancelEventHandler(this.mnuCs_Opening);
            // 
            // mnuCsCut
            // 
            this.mnuCsCut.Image = global::SynergyConverter.Properties.Resources.Cut;
            this.mnuCsCut.Name = "mnuCsCut";
            this.mnuCsCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCsCut.Size = new System.Drawing.Size(181, 22);
            this.mnuCsCut.Text = "Cu&t";
            // 
            // mnuCsCopy
            // 
            this.mnuCsCopy.Name = "mnuCsCopy";
            this.mnuCsCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCsCopy.Size = new System.Drawing.Size(181, 22);
            this.mnuCsCopy.Text = "&Copy";
            // 
            // mnuCsPaste
            // 
            this.mnuCsPaste.Image = global::SynergyConverter.Properties.Resources.Paste;
            this.mnuCsPaste.Name = "mnuCsPaste";
            this.mnuCsPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuCsPaste.Size = new System.Drawing.Size(181, 22);
            this.mnuCsPaste.Text = "&Paste";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuCsSelectAll
            // 
            this.mnuCsSelectAll.Image = global::SynergyConverter.Properties.Resources.Select_All;
            this.mnuCsSelectAll.Name = "mnuCsSelectAll";
            this.mnuCsSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuCsSelectAll.Size = new System.Drawing.Size(181, 22);
            this.mnuCsSelectAll.Text = "&Select All";
            // 
            // mnuCsClear
            // 
            this.mnuCsClear.Name = "mnuCsClear";
            this.mnuCsClear.Size = new System.Drawing.Size(181, 22);
            this.mnuCsClear.Text = "C&lear";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuCsTranslate
            // 
            this.mnuCsTranslate.Image = global::SynergyConverter.Properties.Resources.Pen;
            this.mnuCsTranslate.Name = "mnuCsTranslate";
            this.mnuCsTranslate.Size = new System.Drawing.Size(181, 22);
            this.mnuCsTranslate.Text = "&Translate to Synergy";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.lblCsCode);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(378, 13);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // lblCsCode
            // 
            this.lblCsCode.AutoSize = true;
            this.lblCsCode.Location = new System.Drawing.Point(3, 0);
            this.lblCsCode.Name = "lblCsCode";
            this.lblCsCode.Size = new System.Drawing.Size(49, 13);
            this.lblCsCode.TabIndex = 1;
            this.lblCsCode.Text = "C# Code";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSynergyCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 317);
            this.panel3.TabIndex = 5;
            // 
            // txtSynergyCode
            // 
            this.txtSynergyCode.ContextMenuStrip = this.mnuSynergy;
            this.txtSynergyCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSynergyCode.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSynergyCode.Location = new System.Drawing.Point(0, 0);
            this.txtSynergyCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtSynergyCode.Multiline = true;
            this.txtSynergyCode.Name = "txtSynergyCode";
            this.txtSynergyCode.ReadOnly = true;
            this.txtSynergyCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSynergyCode.Size = new System.Drawing.Size(369, 317);
            this.txtSynergyCode.TabIndex = 3;
            this.txtSynergyCode.WordWrap = false;
            this.txtSynergyCode.Leave += new System.EventHandler(this.configureUI);
            this.txtSynergyCode.Enter += new System.EventHandler(this.configureUI);
            this.txtSynergyCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtSynergyCode_MouseUp);
            // 
            // mnuSynergy
            // 
            this.mnuSynergy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSynergyCopyAll,
            this.mnuSynergyCopySelection,
            this.mnuSynergyClear});
            this.mnuSynergy.Name = "mnuSynergy";
            this.mnuSynergy.Size = new System.Drawing.Size(145, 70);
            this.mnuSynergy.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuSynergy_ItemClicked);
            this.mnuSynergy.Opening += new System.ComponentModel.CancelEventHandler(this.mnuSynergy_Opening);
            // 
            // mnuSynergyCopyAll
            // 
            this.mnuSynergyCopyAll.Name = "mnuSynergyCopyAll";
            this.mnuSynergyCopyAll.Size = new System.Drawing.Size(144, 22);
            this.mnuSynergyCopyAll.Text = "Copy &All";
            // 
            // mnuSynergyCopySelection
            // 
            this.mnuSynergyCopySelection.Name = "mnuSynergyCopySelection";
            this.mnuSynergyCopySelection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuSynergyCopySelection.Size = new System.Drawing.Size(144, 22);
            this.mnuSynergyCopySelection.Text = "&Copy";
            // 
            // mnuSynergyClear
            // 
            this.mnuSynergyClear.Name = "mnuSynergyClear";
            this.mnuSynergyClear.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuSynergyClear.Size = new System.Drawing.Size(144, 22);
            this.mnuSynergyClear.Text = "C&lear";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.lblSynergyCode);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(369, 13);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // lblSynergyCode
            // 
            this.lblSynergyCode.AutoSize = true;
            this.lblSynergyCode.Location = new System.Drawing.Point(3, 0);
            this.lblSynergyCode.Name = "lblSynergyCode";
            this.lblSynergyCode.Size = new System.Drawing.Size(73, 13);
            this.lblSynergyCode.TabIndex = 3;
            this.lblSynergyCode.Text = "Synergy Code";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveAsTemplate,
            this.btnSaveAs,
            this.toolStripSeparator1,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnSelectAll,
            this.toolStripSeparator2,
            this.btnTranslate,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cboFontSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(751, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnSaveAsTemplate
            // 
            this.btnSaveAsTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAsTemplate.Image = global::SynergyConverter.Properties.Resources.Save_as_Template;
            this.btnSaveAsTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAsTemplate.Name = "btnSaveAsTemplate";
            this.btnSaveAsTemplate.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAsTemplate.Text = "toolStripButton2";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAs.Image = global::SynergyConverter.Properties.Resources.Save_As;
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAs.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Enabled = false;
            this.btnCut.Image = global::SynergyConverter.Properties.Resources.Cut;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Text = "Cut";
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = global::SynergyConverter.Properties.Resources.Pen;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "Copy";
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Enabled = false;
            this.btnPaste.Image = global::SynergyConverter.Properties.Resources.Paste;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "Paste";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Image = global::SynergyConverter.Properties.Resources.Select_All;
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(23, 22);
            this.btnSelectAll.Text = "Select All";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTranslate
            // 
            this.btnTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslate.Enabled = false;
            this.btnTranslate.Image = global::SynergyConverter.Properties.Resources.Pen;
            this.btnTranslate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(23, 22);
            this.btnTranslate.Text = "Translate Code";
            this.btnTranslate.ToolTipText = "Translate C# code to Synergy code.";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel1.Text = "Font Size";
            // 
            // cboFontSize
            // 
            this.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontSize.Items.AddRange(new object[] {
            "6 point",
            "8 point",
            "10 point",
            "12 point",
            "14 point"});
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(121, 25);
            this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(751, 24);
            this.mnuMain.TabIndex = 7;
            this.mnuMain.Text = "mnuMain";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileTranslate,
            this.mnuFileSaveAs,
            this.mnuFileSaveAsTemplate,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileTranslate
            // 
            this.mnuFileTranslate.Image = global::SynergyConverter.Properties.Resources.Pen;
            this.mnuFileTranslate.Name = "mnuFileTranslate";
            this.mnuFileTranslate.Size = new System.Drawing.Size(199, 22);
            this.mnuFileTranslate.Text = "&Translate C# to Synergy";
            this.mnuFileTranslate.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Image = global::SynergyConverter.Properties.Resources.Save_As;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(199, 22);
            this.mnuFileSaveAs.Text = "Save &As ...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuFileSaveAsTemplate
            // 
            this.mnuFileSaveAsTemplate.Image = global::SynergyConverter.Properties.Resources.Save_as_Template;
            this.mnuFileSaveAsTemplate.Name = "mnuFileSaveAsTemplate";
            this.mnuFileSaveAsTemplate.Size = new System.Drawing.Size(199, 22);
            this.mnuFileSaveAsTemplate.Text = "Save As Template ...";
            this.mnuFileSaveAsTemplate.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(199, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.toolStripMenuItem3,
            this.mnuEditSelectAll,
            this.mnuEditClear});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Image = global::SynergyConverter.Properties.Resources.Cut;
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEditCut.Size = new System.Drawing.Size(164, 22);
            this.mnuEditCut.Text = "Cu&t";
            this.mnuEditCut.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(164, 22);
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Image = global::SynergyConverter.Properties.Resources.Paste;
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPaste.Size = new System.Drawing.Size(164, 22);
            this.mnuEditPaste.Text = "&Paste";
            this.mnuEditPaste.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuEditSelectAll
            // 
            this.mnuEditSelectAll.Image = global::SynergyConverter.Properties.Resources.Select_All;
            this.mnuEditSelectAll.Name = "mnuEditSelectAll";
            this.mnuEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuEditSelectAll.Size = new System.Drawing.Size(164, 22);
            this.mnuEditSelectAll.Text = "&Select All";
            this.mnuEditSelectAll.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsOptions
            // 
            this.mnuToolsOptions.Name = "mnuToolsOptions";
            this.mnuToolsOptions.Size = new System.Drawing.Size(116, 22);
            this.mnuToolsOptions.Text = "&Options";
            this.mnuToolsOptions.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuHelpAbout.Text = "&About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dbc";
            this.saveFileDialog1.Filter = "Synergy Class|*.dbc|Synergy Source|*.dbl|CodeGen Template|*.tpl|All Files|*.*";
            // 
            // mnuEditClear
            // 
            this.mnuEditClear.Name = "mnuEditClear";
            this.mnuEditClear.Size = new System.Drawing.Size(164, 22);
            this.mnuEditClear.Text = "Clear Windows";
            this.mnuEditClear.Click += new System.EventHandler(this.mainMenuItem);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 426);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mnuCs.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.mnuSynergy.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripButton btnTranslate;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCsCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblCsCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSynergyCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblSynergyCode;
        private System.Windows.Forms.ToolStripMenuItem mnuFileTranslate;
        private System.Windows.Forms.ContextMenuStrip mnuCs;
        private System.Windows.Forms.ToolStripMenuItem mnuCsCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCsCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCsPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCsSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCsTranslate;
        private System.Windows.Forms.ToolStripMenuItem mnuCsClear;
        private System.Windows.Forms.ContextMenuStrip mnuSynergy;
        private System.Windows.Forms.ToolStripMenuItem mnuSynergyCopyAll;
        private System.Windows.Forms.ToolStripMenuItem mnuSynergyClear;
        private System.Windows.Forms.ToolStripMenuItem mnuSynergyCopySelection;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSelectAll;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboFontSize;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAsTemplate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.ToolStripButton btnSaveAsTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuEditClear;
    }
}

