namespace DateTest
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            this.realRadioButtons1 = new DateTest.RealRadioButtons();
            ((System.ComponentModel.ISupportInitialize)(this.realRadioButtons1)).BeginInit();
            this.SuspendLayout();
            // 
            // realRadioButtons1
            // 
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "A";
            valueListItem2.DataValue = 2;
            valueListItem2.DisplayText = "B";
            valueListItem3.DataValue = 3;
            valueListItem3.DisplayText = "C";
            this.realRadioButtons1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.realRadioButtons1.Location = new System.Drawing.Point(170, 111);
            this.realRadioButtons1.Name = "realRadioButtons1";
            this.realRadioButtons1.Size = new System.Drawing.Size(202, 180);
            this.realRadioButtons1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 433);
            this.Controls.Add(this.realRadioButtons1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.realRadioButtons1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RealRadioButtons realRadioButtons1;














    }
}

