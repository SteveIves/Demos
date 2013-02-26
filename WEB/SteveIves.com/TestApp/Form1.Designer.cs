namespace TestApp
{
    partial class Form1
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
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airlineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcaoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCallSign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlightPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebSite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveGridLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.airlineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ContextMenuStrip = this.contextMenuStrip1;
            this.grid.DataSource = this.airlineBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.view;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(841, 524);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGridLayoutToolStripMenuItem,
            this.resetGridToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 70);
            // 
            // resetGridToolStripMenuItem
            // 
            this.resetGridToolStripMenuItem.Name = "resetGridToolStripMenuItem";
            this.resetGridToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.resetGridToolStripMenuItem.Text = "Reset Grid";
            this.resetGridToolStripMenuItem.Click += new System.EventHandler(this.resetGridToolStripMenuItem_Click);
            // 
            // airlineBindingSource
            // 
            this.airlineBindingSource.DataSource = typeof(TestApp.Airline);
            // 
            // view
            // 
            this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colIcaoCode,
            this.colCallSign,
            this.colCountryCode,
            this.colFlightPrefix,
            this.colWebSite});
            this.view.GridControl = this.grid;
            this.view.Name = "view";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colIcaoCode
            // 
            this.colIcaoCode.FieldName = "IcaoCode";
            this.colIcaoCode.Name = "colIcaoCode";
            this.colIcaoCode.Visible = true;
            this.colIcaoCode.VisibleIndex = 1;
            // 
            // colCallSign
            // 
            this.colCallSign.FieldName = "CallSign";
            this.colCallSign.Name = "colCallSign";
            this.colCallSign.Visible = true;
            this.colCallSign.VisibleIndex = 2;
            // 
            // colCountryCode
            // 
            this.colCountryCode.FieldName = "CountryCode";
            this.colCountryCode.Name = "colCountryCode";
            this.colCountryCode.Visible = true;
            this.colCountryCode.VisibleIndex = 3;
            // 
            // colFlightPrefix
            // 
            this.colFlightPrefix.FieldName = "FlightPrefix";
            this.colFlightPrefix.Name = "colFlightPrefix";
            this.colFlightPrefix.Visible = true;
            this.colFlightPrefix.VisibleIndex = 4;
            // 
            // colWebSite
            // 
            this.colWebSite.FieldName = "WebSite";
            this.colWebSite.Name = "colWebSite";
            this.colWebSite.Visible = true;
            this.colWebSite.VisibleIndex = 5;
            // 
            // saveGridLayoutToolStripMenuItem
            // 
            this.saveGridLayoutToolStripMenuItem.Name = "saveGridLayoutToolStripMenuItem";
            this.saveGridLayoutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveGridLayoutToolStripMenuItem.Text = "Save Grid Layout";
            this.saveGridLayoutToolStripMenuItem.Click += new System.EventHandler(this.saveGridLayoutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 524);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Test Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.airlineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private System.Windows.Forms.BindingSource airlineBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIcaoCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCallSign;
        private DevExpress.XtraGrid.Columns.GridColumn colCountryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFlightPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colWebSite;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGridLayoutToolStripMenuItem;
    }
}

