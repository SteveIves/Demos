namespace MyClassLibrary
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.MyPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblFirstName = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.LblLastName = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.LblHired = new System.Windows.Forms.Label();
            this.DtmHired = new System.Windows.Forms.DateTimePicker();
            this.LblReview = new System.Windows.Forms.Label();
            this.TrkReview = new System.Windows.Forms.TrackBar();
            this.LblReviewDisplay = new System.Windows.Forms.Label();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MyPanel
            // 
            this.MyPanel.Controls.Add(this.BtnCancel);
            this.MyPanel.Controls.Add(this.BtnOk);
            this.MyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MyPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.MyPanel.Location = new System.Drawing.Point(0, 276);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(495, 30);
            this.MyPanel.TabIndex = 0;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(417, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(336, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "&OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LblFirstName
            // 
            this.LblFirstName.AutoSize = true;
            this.LblFirstName.Location = new System.Drawing.Point(220, 13);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(57, 13);
            this.LblFirstName.TabIndex = 2;
            this.LblFirstName.Text = "First Name";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "FirstName", true));
            this.TxtFirstName.Location = new System.Drawing.Point(280, 10);
            this.TxtFirstName.MaxLength = 30;
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(200, 20);
            this.TxtFirstName.TabIndex = 3;
            // 
            // LblLastName
            // 
            this.LblLastName.AutoSize = true;
            this.LblLastName.Location = new System.Drawing.Point(220, 47);
            this.LblLastName.Name = "LblLastName";
            this.LblLastName.Size = new System.Drawing.Size(58, 13);
            this.LblLastName.TabIndex = 4;
            this.LblLastName.Text = "Last Name";
            // 
            // TxtLastName
            // 
            this.TxtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "LastName", true));
            this.TxtLastName.Location = new System.Drawing.Point(280, 44);
            this.TxtLastName.MaxLength = 30;
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(200, 20);
            this.TxtLastName.TabIndex = 5;
            // 
            // LblHired
            // 
            this.LblHired.AutoSize = true;
            this.LblHired.Location = new System.Drawing.Point(220, 80);
            this.LblHired.Name = "LblHired";
            this.LblHired.Size = new System.Drawing.Size(52, 13);
            this.LblHired.TabIndex = 6;
            this.LblHired.Text = "Hire Date";
            // 
            // DtmHired
            // 
            this.DtmHired.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "HireDate", true));
            this.DtmHired.Location = new System.Drawing.Point(280, 77);
            this.DtmHired.Name = "DtmHired";
            this.DtmHired.Size = new System.Drawing.Size(200, 20);
            this.DtmHired.TabIndex = 7;
            // 
            // LblReview
            // 
            this.LblReview.AutoSize = true;
            this.LblReview.Location = new System.Drawing.Point(220, 110);
            this.LblReview.Name = "LblReview";
            this.LblReview.Size = new System.Drawing.Size(43, 13);
            this.LblReview.TabIndex = 8;
            this.LblReview.Text = "Review";
            // 
            // TrkReview
            // 
            this.TrkReview.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "Reviewed", true));
            this.TrkReview.LargeChange = 1;
            this.TrkReview.Location = new System.Drawing.Point(280, 107);
            this.TrkReview.Maximum = 5;
            this.TrkReview.Minimum = 1;
            this.TrkReview.Name = "TrkReview";
            this.TrkReview.Size = new System.Drawing.Size(125, 45);
            this.TrkReview.TabIndex = 9;
            this.TrkReview.Value = 1;
            this.TrkReview.ValueChanged += new System.EventHandler(this.TrkReview_ValueChanged);
            // 
            // LblReviewDisplay
            // 
            this.LblReviewDisplay.AutoSize = true;
            this.LblReviewDisplay.Location = new System.Drawing.Point(410, 110);
            this.LblReviewDisplay.Name = "LblReviewDisplay";
            this.LblReviewDisplay.Size = new System.Drawing.Size(35, 13);
            this.LblReviewDisplay.TabIndex = 10;
            this.LblReviewDisplay.Text = "label1";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(MyClassLibrary.Employee);
            // 
            // EmployeeForm
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(495, 306);
            this.Controls.Add(this.LblReviewDisplay);
            this.Controls.Add(this.TrkReview);
            this.Controls.Add(this.LblReview);
            this.Controls.Add(this.DtmHired);
            this.Controls.Add(this.LblHired);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.LblLastName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.LblFirstName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(140, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Information";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.MyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MyPanel;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.Label LblLastName;
        private System.Windows.Forms.Label LblHired;
        private System.Windows.Forms.Label LblReview;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox TxtFirstName;
        public System.Windows.Forms.TextBox TxtLastName;
        public System.Windows.Forms.DateTimePicker DtmHired;
        public System.Windows.Forms.TrackBar TrkReview;
        public System.Windows.Forms.Label LblReviewDisplay;
        private System.Windows.Forms.BindingSource employeeBindingSource;
    }
}