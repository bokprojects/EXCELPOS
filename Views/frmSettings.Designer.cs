namespace ExcelPOS.Views
{
    partial class frmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbIniPath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutoScan = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIsFilebased = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcelFolder = new System.Windows.Forms.Button();
            this.tbExcelFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseDBName = new System.Windows.Forms.Button();
            this.tbDatabaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveButton = new System.Windows.Forms.Button();
            this.tbBarcodeLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBarcodeReference = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbIniPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings Path";
            // 
            // tbIniPath
            // 
            this.tbIniPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIniPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbIniPath.Location = new System.Drawing.Point(6, 19);
            this.tbIniPath.Name = "tbIniPath";
            this.tbIniPath.ReadOnly = true;
            this.tbIniPath.Size = new System.Drawing.Size(764, 20);
            this.tbIniPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbBarcodeReference);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbBarcodeLength);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbAutoScan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbIsFilebased);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnExcelFolder);
            this.groupBox2.Controls.Add(this.tbExcelFolder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBrowseDBName);
            this.groupBox2.Controls.Add(this.tbDatabaseName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Barcode Length:";
            // 
            // cbAutoScan
            // 
            this.cbAutoScan.AutoSize = true;
            this.cbAutoScan.Location = new System.Drawing.Point(230, 71);
            this.cbAutoScan.Name = "cbAutoScan";
            this.cbAutoScan.Size = new System.Drawing.Size(44, 17);
            this.cbAutoScan.TabIndex = 9;
            this.cbAutoScan.Text = "Yes";
            this.cbAutoScan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "is AutoScan:";
            // 
            // cbIsFilebased
            // 
            this.cbIsFilebased.AutoSize = true;
            this.cbIsFilebased.Location = new System.Drawing.Point(94, 71);
            this.cbIsFilebased.Name = "cbIsFilebased";
            this.cbIsFilebased.Size = new System.Drawing.Size(44, 17);
            this.cbIsFilebased.TabIndex = 7;
            this.cbIsFilebased.Text = "Yes";
            this.cbIsFilebased.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Is Filebased:";
            // 
            // btnExcelFolder
            // 
            this.btnExcelFolder.Location = new System.Drawing.Point(687, 39);
            this.btnExcelFolder.Name = "btnExcelFolder";
            this.btnExcelFolder.Size = new System.Drawing.Size(75, 23);
            this.btnExcelFolder.TabIndex = 5;
            this.btnExcelFolder.Text = "&Browse";
            this.btnExcelFolder.UseVisualStyleBackColor = true;
            this.btnExcelFolder.Click += new System.EventHandler(this.btnExcelFolder_Click);
            // 
            // tbExcelFolder
            // 
            this.tbExcelFolder.Location = new System.Drawing.Point(94, 41);
            this.tbExcelFolder.Name = "tbExcelFolder";
            this.tbExcelFolder.Size = new System.Drawing.Size(587, 20);
            this.tbExcelFolder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Excel Folder:";
            // 
            // btnBrowseDBName
            // 
            this.btnBrowseDBName.Location = new System.Drawing.Point(687, 13);
            this.btnBrowseDBName.Name = "btnBrowseDBName";
            this.btnBrowseDBName.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDBName.TabIndex = 2;
            this.btnBrowseDBName.Text = "&Browse";
            this.btnBrowseDBName.UseVisualStyleBackColor = true;
            this.btnBrowseDBName.Click += new System.EventHandler(this.btnBrowseDBName_Click);
            // 
            // tbDatabaseName
            // 
            this.tbDatabaseName.Location = new System.Drawing.Point(94, 15);
            this.tbDatabaseName.Name = "tbDatabaseName";
            this.tbDatabaseName.Size = new System.Drawing.Size(587, 20);
            this.tbDatabaseName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database File:";
            // 
            // btnSaveButton
            // 
            this.btnSaveButton.Location = new System.Drawing.Point(713, 407);
            this.btnSaveButton.Name = "btnSaveButton";
            this.btnSaveButton.Size = new System.Drawing.Size(75, 23);
            this.btnSaveButton.TabIndex = 2;
            this.btnSaveButton.Text = "&Save";
            this.btnSaveButton.UseVisualStyleBackColor = true;
            this.btnSaveButton.Click += new System.EventHandler(this.btnSaveButton_Click);
            // 
            // tbBarcodeLength
            // 
            this.tbBarcodeLength.Location = new System.Drawing.Point(380, 67);
            this.tbBarcodeLength.Name = "tbBarcodeLength";
            this.tbBarcodeLength.Size = new System.Drawing.Size(30, 20);
            this.tbBarcodeLength.TabIndex = 11;
            this.tbBarcodeLength.Text = "0";
            this.tbBarcodeLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcodeLength_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Barcode Column Reference:";
            // 
            // tbBarcodeReference
            // 
            this.tbBarcodeReference.Location = new System.Drawing.Point(567, 67);
            this.tbBarcodeReference.Name = "tbBarcodeReference";
            this.tbBarcodeReference.Size = new System.Drawing.Size(195, 20);
            this.tbBarcodeReference.TabIndex = 13;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSettings_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbIniPath;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseDBName;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveButton;
        private System.Windows.Forms.Button btnExcelFolder;
        private System.Windows.Forms.TextBox tbExcelFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIsFilebased;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAutoScan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBarcodeLength;
        private System.Windows.Forms.TextBox tbBarcodeReference;
        private System.Windows.Forms.Label label6;
    }
}