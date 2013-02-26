namespace FlightTracker
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAirports = new DevExpress.XtraBars.BarButtonItem();
            this.btnAirlines = new DevExpress.XtraBars.BarButtonItem();
            this.btnCountries = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageTables = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAirports,
            this.btnAirlines,
            this.btnCountries});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.Size = new System.Drawing.Size(708, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnAirports
            // 
            this.btnAirports.Caption = "Airports";
            this.btnAirports.Id = 0;
            this.btnAirports.Name = "btnAirports";
            this.btnAirports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAirports_ItemClick);
            // 
            // btnAirlines
            // 
            this.btnAirlines.Caption = "Airlines";
            this.btnAirlines.Id = 1;
            this.btnAirlines.Name = "btnAirlines";
            this.btnAirlines.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAirlines_ItemClick);
            // 
            // btnCountries
            // 
            this.btnCountries.Caption = "Countries";
            this.btnCountries.Id = 2;
            this.btnCountries.Name = "btnCountries";
            this.btnCountries.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCountries_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageTables});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageTables
            // 
            this.ribbonPageTables.ItemLinks.Add(this.btnCountries);
            this.ribbonPageTables.ItemLinks.Add(this.btnAirports);
            this.ribbonPageTables.ItemLinks.Add(this.btnAirlines);
            this.ribbonPageTables.Name = "ribbonPageTables";
            this.ribbonPageTables.ShowCaptionButton = false;
            this.ribbonPageTables.Text = "Tables";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 556);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(708, 23);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 147);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(708, 409);
            this.clientPanel.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 579);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FlightTracker by SteveIves.com";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageTables;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.BarButtonItem btnAirports;
        private DevExpress.XtraBars.BarButtonItem btnAirlines;
        private DevExpress.XtraBars.BarButtonItem btnCountries;
    }
}