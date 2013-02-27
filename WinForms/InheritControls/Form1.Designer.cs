namespace InheritControls
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.myPrompt1 = new ControlLibrary.MyPrompt();
            this.myCheckBox1 = new ControlLibrary.MyCheckBox();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.myRadioButtons1 = new ControlLibrary.MyRadioButtons();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myRadioButtons1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.myRadioButtons1);
            this.ultraTabPageControl1.Controls.Add(this.myPrompt1);
            this.ultraTabPageControl1.Controls.Add(this.myCheckBox1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(356, 246);
            // 
            // myPrompt1
            // 
            this.myPrompt1.BackColorInternal = System.Drawing.Color.Transparent;
            this.myPrompt1.Location = new System.Drawing.Point(95, 50);
            this.myPrompt1.Name = "myPrompt1";
            this.myPrompt1.Size = new System.Drawing.Size(100, 23);
            this.myPrompt1.TabIndex = 1;
            this.myPrompt1.Text = "myPrompt1";
            // 
            // myCheckBox1
            // 
            this.myCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.myCheckBox1.BackColorInternal = System.Drawing.Color.Transparent;
            this.myCheckBox1.Location = new System.Drawing.Point(95, 89);
            this.myCheckBox1.Name = "myCheckBox1";
            this.myCheckBox1.Size = new System.Drawing.Size(120, 20);
            this.myCheckBox1.TabIndex = 0;
            this.myCheckBox1.Text = "myCheckBox1";
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Location = new System.Drawing.Point(91, 108);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(360, 272);
            this.ultraTabControl1.TabIndex = 0;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(356, 246);
            // 
            // myRadioButtons1
            // 
            this.myRadioButtons1.BackColor = System.Drawing.Color.Transparent;
            this.myRadioButtons1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.myRadioButtons1.Enabled = false;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "Default Item";
            this.myRadioButtons1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.myRadioButtons1.Location = new System.Drawing.Point(95, 137);
            this.myRadioButtons1.Name = "myRadioButtons1";
            this.myRadioButtons1.Size = new System.Drawing.Size(96, 32);
            this.myRadioButtons1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 576);
            this.Controls.Add(this.ultraTabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myRadioButtons1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private ControlLibrary.MyCheckBox myCheckBox1;
        private ControlLibrary.MyPrompt myPrompt1;
        private ControlLibrary.MyRadioButtons myRadioButtons1;




    }
}

