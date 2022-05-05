namespace ExcelPOS.Views
{
    partial class frmSourceInfo
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTotalRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnExcelBrowse = new System.Windows.Forms.Button();
            this.tbExcelUpload = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbExcelFile = new System.Windows.Forms.ComboBox();
            this.lblExcelQuery = new System.Windows.Forms.Label();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.btnSearchFilter = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbConj2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValueFilter3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.cmbFilter3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbConj1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbValueFilter2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.cmbFilter2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbValueFilter1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmbFilter1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgDataRecords = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDataRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTotalRecord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1414, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTotalRecord
            // 
            this.tssTotalRecord.Name = "tssTotalRecord";
            this.tssTotalRecord.Size = new System.Drawing.Size(97, 17);
            this.tssTotalRecord.Text = "Total Record(s): 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnExcelBrowse);
            this.groupBox1.Controls.Add(this.tbExcelUpload);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1402, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Excel Here";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(695, 18);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "&Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnExcelBrowse
            // 
            this.btnExcelBrowse.Location = new System.Drawing.Point(615, 18);
            this.btnExcelBrowse.Name = "btnExcelBrowse";
            this.btnExcelBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnExcelBrowse.TabIndex = 1;
            this.btnExcelBrowse.Text = "Browse";
            this.btnExcelBrowse.UseVisualStyleBackColor = true;
            this.btnExcelBrowse.Click += new System.EventHandler(this.btnExcelBrowse_Click);
            // 
            // tbExcelUpload
            // 
            this.tbExcelUpload.Location = new System.Drawing.Point(6, 19);
            this.tbExcelUpload.Name = "tbExcelUpload";
            this.tbExcelUpload.Size = new System.Drawing.Size(607, 20);
            this.tbExcelUpload.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbExcelFile);
            this.groupBox2.Controls.Add(this.lblExcelQuery);
            this.groupBox2.Controls.Add(this.btnSearchAll);
            this.groupBox2.Controls.Add(this.btnSearchFilter);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(6, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 556);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Data";
            // 
            // cmbExcelFile
            // 
            this.cmbExcelFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmbExcelFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExcelFile.FormattingEnabled = true;
            this.cmbExcelFile.Location = new System.Drawing.Point(76, 16);
            this.cmbExcelFile.Name = "cmbExcelFile";
            this.cmbExcelFile.Size = new System.Drawing.Size(172, 21);
            this.cmbExcelFile.TabIndex = 1;
            this.cmbExcelFile.Visible = false;
            this.cmbExcelFile.SelectedIndexChanged += new System.EventHandler(this.cmbExcelFile_SelectedIndexChanged);
            // 
            // lblExcelQuery
            // 
            this.lblExcelQuery.AutoSize = true;
            this.lblExcelQuery.Location = new System.Drawing.Point(8, 20);
            this.lblExcelQuery.Name = "lblExcelQuery";
            this.lblExcelQuery.Size = new System.Drawing.Size(62, 13);
            this.lblExcelQuery.TabIndex = 5;
            this.lblExcelQuery.Text = "Excel Data:";
            this.lblExcelQuery.Visible = false;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(155, 523);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(93, 23);
            this.btnSearchAll.TabIndex = 3;
            this.btnSearchAll.Text = "Show &All";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSearchFilter
            // 
            this.btnSearchFilter.Location = new System.Drawing.Point(6, 523);
            this.btnSearchFilter.Name = "btnSearchFilter";
            this.btnSearchFilter.Size = new System.Drawing.Size(93, 23);
            this.btnSearchFilter.TabIndex = 0;
            this.btnSearchFilter.Text = "&Search";
            this.btnSearchFilter.UseVisualStyleBackColor = true;
            this.btnSearchFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmbConj2);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.tbValueFilter3);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.radioButton9);
            this.groupBox6.Controls.Add(this.radioButton8);
            this.groupBox6.Controls.Add(this.radioButton7);
            this.groupBox6.Controls.Add(this.cmbFilter3);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Location = new System.Drawing.Point(6, 347);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(242, 170);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Filter 3";
            // 
            // cmbConj2
            // 
            this.cmbConj2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConj2.FormattingEnabled = true;
            this.cmbConj2.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.cmbConj2.Location = new System.Drawing.Point(91, 17);
            this.cmbConj2.Name = "cmbConj2";
            this.cmbConj2.Size = new System.Drawing.Size(75, 21);
            this.cmbConj2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Conjunction:";
            // 
            // tbValueFilter3
            // 
            this.tbValueFilter3.Location = new System.Drawing.Point(92, 132);
            this.tbValueFilter3.Name = "tbValueFilter3";
            this.tbValueFilter3.Size = new System.Drawing.Size(141, 20);
            this.tbValueFilter3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Value To Search:";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(94, 111);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(75, 17);
            this.radioButton9.TabIndex = 4;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Is Equal to";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(94, 91);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(66, 17);
            this.radioButton8.TabIndex = 3;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Contains";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(94, 72);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(72, 17);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Start With";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // cmbFilter3
            // 
            this.cmbFilter3.FormattingEnabled = true;
            this.cmbFilter3.Location = new System.Drawing.Point(91, 45);
            this.cmbFilter3.Name = "cmbFilter3";
            this.cmbFilter3.Size = new System.Drawing.Size(142, 21);
            this.cmbFilter3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Column Name:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbConj1);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tbValueFilter2);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.radioButton6);
            this.groupBox5.Controls.Add(this.radioButton5);
            this.groupBox5.Controls.Add(this.radioButton4);
            this.groupBox5.Controls.Add(this.cmbFilter2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(6, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(242, 170);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filter 2";
            // 
            // cmbConj1
            // 
            this.cmbConj1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConj1.FormattingEnabled = true;
            this.cmbConj1.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.cmbConj1.Location = new System.Drawing.Point(91, 17);
            this.cmbConj1.Name = "cmbConj1";
            this.cmbConj1.Size = new System.Drawing.Size(75, 21);
            this.cmbConj1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Conjunction:";
            // 
            // tbValueFilter2
            // 
            this.tbValueFilter2.Location = new System.Drawing.Point(92, 132);
            this.tbValueFilter2.Name = "tbValueFilter2";
            this.tbValueFilter2.Size = new System.Drawing.Size(141, 20);
            this.tbValueFilter2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value To Search:";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(94, 111);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(75, 17);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Is Equal to";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(94, 91);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(66, 17);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Contains";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(94, 72);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Start With";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // cmbFilter2
            // 
            this.cmbFilter2.FormattingEnabled = true;
            this.cmbFilter2.Location = new System.Drawing.Point(91, 45);
            this.cmbFilter2.Name = "cmbFilter2";
            this.cmbFilter2.Size = new System.Drawing.Size(142, 21);
            this.cmbFilter2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Column Name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbValueFilter1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.cmbFilter1);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 132);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter 1";
            // 
            // tbValueFilter1
            // 
            this.tbValueFilter1.Location = new System.Drawing.Point(92, 102);
            this.tbValueFilter1.Name = "tbValueFilter1";
            this.tbValueFilter1.Size = new System.Drawing.Size(141, 20);
            this.tbValueFilter1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value To Search:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(94, 81);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Is Equal to";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(94, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(66, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Contains";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(94, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Start With";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cmbFilter1
            // 
            this.cmbFilter1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFilter1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbFilter1.FormattingEnabled = true;
            this.cmbFilter1.Location = new System.Drawing.Point(91, 15);
            this.cmbFilter1.Name = "cmbFilter1";
            this.cmbFilter1.Size = new System.Drawing.Size(142, 21);
            this.cmbFilter1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Column Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgDataRecords);
            this.groupBox3.Location = new System.Drawing.Point(266, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1136, 556);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Record(s)";
            // 
            // dgDataRecords
            // 
            this.dgDataRecords.AllowUserToAddRows = false;
            this.dgDataRecords.AllowUserToDeleteRows = false;
            this.dgDataRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDataRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDataRecords.Location = new System.Drawing.Point(3, 16);
            this.dgDataRecords.Name = "dgDataRecords";
            this.dgDataRecords.ReadOnly = true;
            this.dgDataRecords.Size = new System.Drawing.Size(1130, 537);
            this.dgDataRecords.TabIndex = 0;
            // 
            // frmSourceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 652);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmSourceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source Information";
            this.Load += new System.EventHandler(this.frmSourceInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSourceInfo_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDataRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTotalRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcelBrowse;
        private System.Windows.Forms.TextBox tbExcelUpload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbValueFilter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmbFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnSearchFilter;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbConj2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbValueFilter3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.ComboBox cmbFilter3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbConj1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbValueFilter2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox cmbFilter2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgDataRecords;
        private System.Windows.Forms.ComboBox cmbExcelFile;
        private System.Windows.Forms.Label lblExcelQuery;
    }
}