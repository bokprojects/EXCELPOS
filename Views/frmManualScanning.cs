using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPOS.Views
{
    public partial class frmManualScanning : Form
    {
        public string CSKU;
        public string SKU;
        public int Quantity;
        public bool isMatched;
        public string ScannedQuantity;
        
        public frmManualScanning()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void frmManualScanning_Load(object sender, EventArgs e)
        {
            tbCSKU.Text = CSKU;
            tbSKU.Text = SKU;
            tbQuantity.Text = Quantity.ToString();
            tbScannedQuantity.Focus();
        }

        private void tbScannedQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyData == Keys.Back) || (e.KeyData == Keys.Escape) || 
                    (e.KeyData == Keys.Alt) || (e.KeyData == Keys.Tab))
                {
                    return;
                }
                if (e.KeyData.ToString().Split(',').Count() > 1)
                {
                    return;
                }

                int keyRes = int.Parse(e.KeyValue.ToString());

                if((keyRes >= 48 && keyRes <= 58) || (keyRes >= 96 && keyRes <=105) || e.KeyCode == Keys.Enter)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (tbQuantity.Text.Trim() != tbScannedQuantity.Text.Trim())
                        {
                            MessageBox.Show("Error: Scanned Quantity is not matched in Expected Quantity. Kindly check it first.", "Quantity is not matched", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isMatched = true;
                        this.Close();
                    }
                }else
                {
                    MessageBox.Show("Please enter number only.", "Error: Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbScannedQuantity.Text = "";
                }
            }catch(Exception)
            {
                MessageBox.Show("Please enter number only.", "Error: Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScannedQuantity.Text = "";
            }
        }

        private void frmManualScanning_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmManualScanning_FormClosed(object sender, FormClosedEventArgs e)
        {
            ScannedQuantity = tbScannedQuantity.Text;
        }
    }
}
