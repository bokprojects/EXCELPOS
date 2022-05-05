using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelPOS.Process;
namespace ExcelPOS.Views
{
    public partial class frmSourceItems : Form
    {
        DataProcess dpo;

        public DataTable dtSourceItem;
        public DataTable dtSKU;
        public DataTable dtPSKU;

        string worksheetName = string.Empty;
        private void InitializedForm()
        {
            dpo.ComboBoxInitialized(cbPSKU, dtPSKU, true, "SKU", "SKU");
            dpo.ComboBoxInitialized(cbRSKU, dtSKU, true, "SKU", "SKU");
        }
        public frmSourceItems()
        {
            InitializeComponent();            
        }

        private void LoadRecord()
        {
            if(dtSourceItem != null)
            {
                dataGridView1.DataSource = dtSourceItem;
            }
        }

        private void frmSourceItems_Load(object sender, EventArgs e)
        {
            dpo = new DataProcess();
            InitializedForm();
            LoadRecord();
        }

        private void parentSKUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataBuilder dbuilder = new frmDataBuilder();
            dbuilder.dtInfo = dtPSKU;
            dbuilder.ExcelFileRef = Environment.CurrentDirectory + "\\Reference\\ItemDB.xlsx";            
            dbuilder.ExcelWorkSheetName = "Parent SKU";
            dtPSKU = dbuilder.dtInfo;
            dbuilder.ShowDialog();
            InitializedForm();
        }

        private void refSKUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataBuilder dbuilder = new frmDataBuilder();
            dbuilder.dtInfo = dtSKU;
            dbuilder.ExcelFileRef = Environment.CurrentDirectory + "\\Reference\\ItemDB.xlsx";
            dbuilder.ExcelWorkSheetName = "SKU";
            dtSKU = dbuilder.dtInfo;            
            dbuilder.ShowDialog();
            InitializedForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbBarcode.Text))
            {            
                MessageBox.Show("Error: No barcode defined. Please enter a value", "Barcode is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(cbPSKU.Text) || string.IsNullOrEmpty(cbRSKU.Text))
            {
                MessageBox.Show("Error: SKU is invalid. Please select another", "SKU error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Would you like to save this entry?", "Save Source item information?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                DataRow drow = dtSourceItem.NewRow();
                drow["Barcode"] = tbBarcode.Text;
                drow["Description"] = tbDescription.Text;
                drow["Parent SKU"] = cbPSKU.Text;
                drow["SKU"] = cbRSKU.Text;

                dtSourceItem.Rows.Add(drow);

                if (!dpo.SaveMySourceItem(dtSourceItem))
                {
                    MessageBox.Show("Error: Data could not save. Please check the entry or file", "Unable to save item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbBarcode.Text))
            {
                MessageBox.Show("Error: No entry to delete. Please select on the list first", "Delete Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this item?", "Delete Barcode: " + tbBarcode.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                if(dtSourceItem.Rows.Count > 0)
                {
                    DataRow[] drow = dtSourceItem.Select("Barcode = '" + tbBarcode.Text + "'");
                    foreach(var drw in drow)
                    {
                        drw.Delete();
                    }
                    dtSourceItem.AcceptChanges();
                }
                else
                {
                    MessageBox.Show("Warning: No Items found on the list", "Delete Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            LoadRecord();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbBarcode.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            tbDescription.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            cbPSKU.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            cbRSKU.Text = dataGridView1[3, e.RowIndex].Value.ToString();
        }
    }
}
