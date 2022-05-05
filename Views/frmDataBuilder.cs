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
using ExcelPOS.Process;
namespace ExcelPOS.Views
{
    public partial class frmDataBuilder : Form
    {
        DataProcess dpro;

        public DataTable dtInfo;
        public string ExcelFileRef;
        public string ExcelWorkSheetName;

        public frmDataBuilder()
        {
            InitializeComponent();
        }
        private void LoadRecord()
        {
            dataGridView1.DataSource = dtInfo;
            dataGridView1.Refresh();
        }
        private void CheckRecord()
        {
            tssTotalRecord.Text = "Total Record: " + (dataGridView1.Rows.Count -1);
        }
        private void frmDataBuilder_Load(object sender, EventArgs e)
        {
            dpro = new DataProcess();
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtInfo;
                CheckRecord();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("Error: No Item to Delete. Please select one", "Delete Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("Error: No entry to delete. Please select on the list first", "Delete Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this item?", "Delete Entry: " + tbValue.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    DataRow[] drow = dtInfo.Select("SKU = '" + tbValue.Text + "'");
                    foreach (var drw in drow)
                    {
                        drw.Delete();
                    }
                    dtInfo.AcceptChanges();
                    tbValue.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Warning: No Items found on the list", "Delete Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            CheckRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ExcelFileRef))
            {
                MessageBox.Show("Error: Excel reference not found. Please Check first", "Save Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbValue.Text))
            {
                MessageBox.Show("Error: No Item to Save. Please select one", "Save Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Would you like to add this on your record?", "Add record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                DataRow drow = dtInfo.NewRow();
                drow[0] = tbValue.Text;
                dtInfo.Rows.Add(drow);
                dtInfo.AcceptChanges();
                if (dpro.UpdateMyrecords(dtInfo, ExcelFileRef, ExcelWorkSheetName))
                {
                    tbValue.Text = String.Empty;
                    MessageBox.Show("Successfully Added on the record.");                    
                }
            }
            LoadRecord();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbValue.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }
    }
}
