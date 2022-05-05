using ExcelPOS.Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPOS.Views
{
    public partial class frmEditDetails : Form
    {
        public DataTable dtOrderDetails;
        public DataTable dtItemSource;
        public string Courier;
        public frmEditDetails()
        {
            InitializeComponent();
        }

        private void frmEditDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                this.Close();
        }

        private void frmEditDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void LoadRecords()
        {
            try
            {
                if (dtOrderDetails == null)
                {
                    MessageBox.Show("Warning. Please scan first waybill before proceed on this checking.", "Error: No details Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                DataView dvDetails = new DataView(dtOrderDetails);
                DataTable dtViewer = new DataTable();
                dtViewer = dvDetails.ToTable(false, "Order ID", "Quantity", "SKU (Parent)", "CSKU");
                dtViewer.Columns.Add("is Matched");

                dataGridView1.DataSource = dtViewer;
            }
            catch (Exception)
            {

            }
        }
        private void frmEditDetails_Load(object sender, EventArgs e)
        {
            LoadRecords();
            CheckMyOrder(string.Empty);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(tbBarcode.Text))
                {
                    DataView dv = new DataView(dtItemSource);
                    dv.RowFilter = "[Barcode]='" + tbBarcode.Text + "'";
                    DataTable dtResult = dv.ToTable();
                    if (dtResult.Rows.Count == 1)
                    {
                        tbDescription.Text = Courier;
                        tbPSKU.Text = dtResult.Rows[0]["Parent SKU"].ToString();
                        tbRSKU.Text = dtResult.Rows[0]["SKU"].ToString();

                        DataTable dtSourceChecker = (DataTable)dataGridView1.DataSource;
                        if (dtSourceChecker.Select("[SKU (Parent)]='" + tbPSKU.Text + "' and CSKU='" + tbRSKU.Text + "'").Count() > 0)
                        {

                            dtOrderDetails = MatchMyResult(dataGridView1, tbPSKU.Text, tbRSKU.Text);
                            DataView dvDetails = new DataView(dtOrderDetails);
                            DataTable dtViewer = new DataTable();
                            dtViewer = dvDetails.ToTable(false, "Order ID", "Quantity", "SKU (Parent)", "CSKU", "is Matched");
                            dataGridView1.DataSource = dtViewer;

                        }
                    }
                }
                tbBarcode.Focus();
                tbBarcode.SelectAll();
                CheckMyOrder(string.Empty);
            }
        }
        private DataTable MatchMyResult(DataGridView dgv, string PSKU, string SKU)
        {
            DataTable dtResult = (DataTable)dgv.DataSource;
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    Validation.Validation valid = new Validation.Validation();
                    foreach (DataGridViewRow dgrow in dgv.Rows)
                    {
                        string FPSKU = dgrow.Cells["SKU (Parent)"].Value.ToString();
                        string FSKU = dgrow.Cells["CSKU"].Value.ToString();

                        if (PSKU == FPSKU && SKU == FSKU)
                        {
                            string isMatch = dgrow.Cells["is Matched"].Value.ToString();
                            if (isMatch == "")
                            {
                                dgrow.Cells["is Matched"].Value = "1";
                            } else
                            {
                                if (valid.isInteger(isMatch) >= 0)
                                {
                                    dgrow.Cells["is Matched"].Value = (int.Parse(isMatch) + 1).ToString();
                                }
                            }
                            string Quantity = dgrow.Cells["Quantity"].Value.ToString();
                            string Matched = dgrow.Cells["is Matched"].Value.ToString();

                            if (int.Parse(Quantity) < int.Parse(Matched))
                            {
                                MessageBox.Show("Error: Scanned Items exceeed. Please check your item", "Quantity Not matched", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (int.Parse(Matched) > 0)
                                    dgrow.Cells["is Matched"].Value = (int.Parse(isMatch) - 1).ToString();
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return dtResult;
        }

        private void tbBarcode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBarcode.Text))
                tbBarcode.Text = String.Empty;
        }
        private void CheckMyOrder(string EnteredValue)
        {
            btnPassed.Enabled = false;
            bool isNotMatched = false;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgrow in dataGridView1.Rows)
                {
                    if (dgrow.Cells["Order ID"].Value == null)
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(dgrow.Cells["Order ID"].Value.ToString()))
                    {
                        if (dgrow.Cells["Quantity"].Value.ToString().Trim() != dgrow.Cells["is Matched"].EditedFormattedValue.ToString())
                        {
                            isNotMatched = true;
                            break;
                        }
                    }
                }
                foreach (DataGridViewColumn dgc in dataGridView1.Columns)
                {
                    if (dgc.HeaderText != "is Matched")
                    {
                        dgc.ReadOnly = true;
                    }
                }
            }
            btnPassed.Enabled = !isNotMatched;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "is Matched")
            {
                string ValueEntered = dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString();
                CheckMyOrder(ValueEntered);

                string Quantity = dataGridView1["Quantity", e.RowIndex].Value.ToString();
                string Matched = dataGridView1["is Matched", e.RowIndex].EditedFormattedValue.ToString();
                if (!string.IsNullOrEmpty(Quantity) && !string.IsNullOrEmpty(Matched))
                {
                    if (int.Parse(Quantity) < int.Parse(Matched))
                    {
                        MessageBox.Show("Error: Scanned Items exceeed. Please check your item", "Quantity Not matched", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (int.Parse(Matched) > 0)
                            dataGridView1["is Matched", e.RowIndex].Value = (int.Parse(Matched) - 1).ToString();
                    }
                }
            }
        }

        private void btnPassed_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("Would you like to add this order on your output list for today?", "Output List for " + DateTime.Now.ToString("MMM dd, yyyy"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if(dr == DialogResult.Yes)
            //{
            DefaultValues defVal = new DefaultValues();
            DataProcess dpro = new DataProcess();

            DataTable dtOutput = dpro.DTForOut();
            string OutputDirectory = defVal.GetOutputFolder();

            OutputDirectory = Directory.Exists(OutputDirectory) ? OutputDirectory : string.Empty;

            if (dpro.SaveDataOut(dtOutput, dataGridView1, OutputDirectory, Courier))
            {
                this.Close();
            }
            //}
        }

        private void passedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPassed.PerformClick();
        }

        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReject.PerformClick();
        }

        private void manualQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Validation.Validation valid = new Validation.Validation();

            int SelectedItem = dataGridView1.SelectedCells.Count;
            if (SelectedItem == 0 || SelectedItem != 1)
            {
                return;
            }

            int SelectedRow = dataGridView1.SelectedCells[0].RowIndex;

            if(valid.isInteger(dataGridView1["Quantity", SelectedRow].Value.ToString()) == 0)
            {
                return;
            }

            frmManualScanning manscan = new frmManualScanning();
            
            manscan.CSKU = dataGridView1["SKU (Parent)", SelectedRow].Value.ToString();
            manscan.SKU = dataGridView1["CSKU", SelectedRow].Value.ToString();            
            manscan.Quantity = valid.isInteger(dataGridView1["Quantity", SelectedRow].Value.ToString());
            manscan.ShowDialog();
            dataGridView1["is Matched", SelectedRow].Value = manscan.ScannedQuantity;

            CheckMyOrder(manscan.ScannedQuantity);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            DataProcess dpro = new DataProcess();

            int SelectedItem = dataGridView1.SelectedCells.Count;
            if (SelectedItem == 0 || SelectedItem != 1)
            {
                return;
            }

            string OrderID = string.Empty;
            string ErrFound = string.Empty;

            int SelectedRow = dataGridView1.SelectedCells[0].RowIndex;
            OrderID = dataGridView1["Order ID", SelectedRow].Value.ToString();

            if (!dpro.SaveReject(OrderID, ref ErrFound))
                MessageBox.Show(ErrFound, "Error Reject Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
