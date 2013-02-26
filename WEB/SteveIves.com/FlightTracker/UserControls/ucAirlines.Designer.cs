namespace FlightTracker.UserControls
{
    partial class ucAirlines
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.airlineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colIcaoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCallSign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlightPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebSite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airlineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblTitle);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(636, 50);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(59, 23);
            this.lblTitle.StyleController = this.layoutControl1;
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Airlines";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(636, 50);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblTitle;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(616, 30);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // grid
            // 
            this.grid.DataSource = this.airlineBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 50);
            this.grid.MainView = this.view;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(636, 312);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIcaoCode,
            this.colName,
            this.colCallSign,
            this.colCountryCode,
            this.colFlightPrefix,
            this.colWebSite,
            this.colCountry});
            this.view.GridControl = this.grid;
            this.view.Name = "view";
            // 
            // airlineBindingSource
            // 
            this.airlineBindingSource.DataSource = typeof(FlightTracker.FlightTrackerService.Airline);
            // 
            // colIcaoCode
            // 
            this.colIcaoCode.FieldName = "IcaoCode";
            this.colIcaoCode.Name = "colIcaoCode";
            this.colIcaoCode.Visible = true;
            this.colIcaoCode.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
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
            // colCountry
            // 
            this.colCountry.FieldName = "Country";
            this.colCountry.Name = "colCountry";
            this.colCountry.Visible = true;
            this.colCountry.VisibleIndex = 6;
            // 
            // ucAirlines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAirlines";
            this.Size = new System.Drawing.Size(636, 362);
            this.ParentChanged += new System.EventHandler(this.ucAirlines_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airlineBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private System.Windows.Forms.BindingSource airlineBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIcaoCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCallSign;
        private DevExpress.XtraGrid.Columns.GridColumn colCountryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFlightPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colWebSite;
        private DevExpress.XtraGrid.Columns.GridColumn colCountry;
    }
}
