namespace OfficeAutomationTest
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
            this.btnCreateSpreadsheet = new System.Windows.Forms.Button();
            this.btnCreateWordDoc = new System.Windows.Forms.Button();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateSpreadsheet
            // 
            this.btnCreateSpreadsheet.Location = new System.Drawing.Point(35, 39);
            this.btnCreateSpreadsheet.Name = "btnCreateSpreadsheet";
            this.btnCreateSpreadsheet.Size = new System.Drawing.Size(120, 23);
            this.btnCreateSpreadsheet.TabIndex = 0;
            this.btnCreateSpreadsheet.Text = "Create Spreadsheet";
            this.btnCreateSpreadsheet.UseVisualStyleBackColor = true;
            this.btnCreateSpreadsheet.Click += new System.EventHandler(this.btnCreateSpreadsheet_Click);
            // 
            // btnCreateWordDoc
            // 
            this.btnCreateWordDoc.Location = new System.Drawing.Point(35, 68);
            this.btnCreateWordDoc.Name = "btnCreateWordDoc";
            this.btnCreateWordDoc.Size = new System.Drawing.Size(120, 23);
            this.btnCreateWordDoc.TabIndex = 1;
            this.btnCreateWordDoc.Text = "Create Word Doc";
            this.btnCreateWordDoc.UseVisualStyleBackColor = true;
            this.btnCreateWordDoc.Click += new System.EventHandler(this.btnCreateWordDoc_Click);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(35, 97);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(120, 23);
            this.btnCreateMap.TabIndex = 2;
            this.btnCreateMap.Text = "Create MapPoint Map";
            this.btnCreateMap.UseVisualStyleBackColor = true;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 394);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.btnCreateWordDoc);
            this.Controls.Add(this.btnCreateSpreadsheet);
            this.Name = "Form1";
            this.Text = "Microsoft Office Automation Tests";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateSpreadsheet;
        private System.Windows.Forms.Button btnCreateWordDoc;
        private System.Windows.Forms.Button btnCreateMap;
    }
}

