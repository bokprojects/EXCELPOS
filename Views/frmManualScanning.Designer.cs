namespace ExcelPOS.Views
{
    partial class frmManualScanning
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCSKU = new System.Windows.Forms.TextBox();
            this.tbSKU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbScannedQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSKU:";
            // 
            // tbCSKU
            // 
            this.tbCSKU.Location = new System.Drawing.Point(66, 9);
            this.tbCSKU.Name = "tbCSKU";
            this.tbCSKU.ReadOnly = true;
            this.tbCSKU.Size = new System.Drawing.Size(189, 20);
            this.tbCSKU.TabIndex = 1;
            this.tbCSKU.TabStop = false;
            // 
            // tbSKU
            // 
            this.tbSKU.Location = new System.Drawing.Point(66, 35);
            this.tbSKU.Name = "tbSKU";
            this.tbSKU.ReadOnly = true;
            this.tbSKU.Size = new System.Drawing.Size(189, 20);
            this.tbSKU.TabIndex = 3;
            this.tbSKU.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SKU:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(66, 64);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(189, 20);
            this.tbQuantity.TabIndex = 5;
            this.tbQuantity.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity:";
            // 
            // tbScannedQuantity
            // 
            this.tbScannedQuantity.Location = new System.Drawing.Point(104, 109);
            this.tbScannedQuantity.Name = "tbScannedQuantity";
            this.tbScannedQuantity.Size = new System.Drawing.Size(151, 20);
            this.tbScannedQuantity.TabIndex = 7;
            this.tbScannedQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScannedQuantity_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scanned Quantity:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 143);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(267, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel1.Text = "Press Enter to Confirm";
            // 
            // frmManualScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 165);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbScannedQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSKU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCSKU);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManualScanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Scanning";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmManualScanning_FormClosed);
            this.Load += new System.EventHandler(this.frmManualScanning_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmManualScanning_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCSKU;
        private System.Windows.Forms.TextBox tbSKU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScannedQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}