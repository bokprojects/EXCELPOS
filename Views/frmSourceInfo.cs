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
    public partial class frmSourceInfo : Form
    {
        Process.DefaultValues defVal = new Process.DefaultValues();
        public string ExcelName;
        public bool isFileBased;
        public DataTable dtSourceInfo;
        public DataView dvFilter;
        public frmSourceInfo()
        {
            InitializeComponent();
        }

        public void LoadExcelfromFolder()
        {
            try
            {
                if (Directory.Exists(defVal.GetExcelFolder()))
                {
                    cmbExcelFile.Items.Clear();
                    foreach (string filename in Directory.GetFiles(defVal.GetExcelFolder(), "*.xlsx", SearchOption.TopDirectoryOnly))
                    {
                        if(!filename.Contains("~"))                            
                            cmbExcelFile.Items.Add(Path.GetFileName(filename));                            
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void Countrecords()
        {
            if (dtSourceInfo != null)
                tssTotalRecord.Text = "Total Record(s): " + (dtSourceInfo.Rows.Count - 0).ToString();
        }
        private void ReadingExcel(string Excelfile)
        {
            if (!File.Exists(Excelfile))
            {
                MessageBox.Show("Source information is invalid. Please select another file.", "Failed Reading Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Views.LoadDataToDataTable loading = new LoadDataToDataTable();
            loading.excelFilename = Excelfile;
            loading.dtResult = new DataTable();
            loading.ShowDialog();
            dtSourceInfo = loading.dtResult;
            dgDataRecords.DataSource = dtSourceInfo;
            Process.DataProcess dpro = new Process.DataProcess();
            dpro.DataColumnToCombo(dtSourceInfo, cmbFilter1);
            dpro.DataColumnToCombo(dtSourceInfo, cmbFilter2);
            dpro.DataColumnToCombo(dtSourceInfo, cmbFilter3);
            ExcelName = Path.GetFileName(Excelfile);
        }
        
        private void frmSourceInfo_Load(object sender, EventArgs e)
        {
            lblExcelQuery.Visible = cmbExcelFile.Visible = isFileBased;
            LoadExcelfromFolder();
            if(dtSourceInfo != null && dtSourceInfo.Rows.Count > 0)
            {
                dvFilter = new DataView(dtSourceInfo);
            }
            Countrecords();
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
        private void cmbExcelFile_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(cmbExcelFile.Text))
            {                
                dtSourceInfo = new DataTable();
                string ExcelFile = defVal.GetExcelFolder() + "\\" + cmbExcelFile.Text;
                if (Directory.Exists(defVal.GetExcelFolder()))
                    ReadingExcel(ExcelFile);

                Countrecords();
                if(dtSourceInfo.Rows.Count > 0)
                {
                    dvFilter = new DataView(dtSourceInfo);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExcelUpload.Text))
            {
                MessageBox.Show("Error: No File to upload. Please select valid excel and try again", "File is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!File.Exists(tbExcelUpload.Text))
            {
                MessageBox.Show("Error: File is not valid. Please try again", "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string UploadFolder = defVal.GetExcelFolder();

            File.Copy(tbExcelUpload.Text, UploadFolder + "\\" + Path.GetFileName(tbExcelUpload.Text), true);

            if(File.Exists(UploadFolder + "\\" + Path.GetFileName(tbExcelUpload.Text)))
                MessageBox.Show("Done uploading excel file. This will be your default data.", "Set Data Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcelBrowse_Click(object sender, EventArgs e)
        {
            Validation.Validation valid = new Validation.Validation();
            string FileIndex = "Source files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            tbExcelUpload.Text = valid.BrowseFile(FileIndex);
        }

        private void frmSourceInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbValueFilter1.Text) && string.IsNullOrEmpty(tbValueFilter2.Text) && string.IsNullOrEmpty(tbValueFilter3.Text))
            {
                MessageBox.Show("Error: No Filter found. Please set atleast one filter to search", "Filter Search Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string QueryFilter = string.Empty;
            string QueryFilter2 = string.Empty;
            string QueryFilter3 = string.Empty;
            string ConditionFilter1 = string.Empty;
            string ConditionFilter2 = string.Empty;
            string ConditionFilter3 = string.Empty;
            string Conj2 = String.Empty;

            if (radioButton1.Checked)
                ConditionFilter1 = "LIKE '*" + tbValueFilter1.Text + "'";
            if (radioButton2.Checked)
                ConditionFilter1 = "LIKE '%" + tbValueFilter1.Text + "%'";
            if(radioButton3.Checked)
                ConditionFilter1 = "='"+ tbValueFilter1.Text +"'";

            if(!string.IsNullOrEmpty(tbValueFilter1.Text) && !string.IsNullOrEmpty(ConditionFilter1))
            {
                QueryFilter = QueryFilter + "[" + cmbFilter1.Text + "]" + ConditionFilter1;
            }
            //Condition 2
            if (!string.IsNullOrEmpty(cmbConj1.Text) && !string.IsNullOrEmpty(cmbFilter2.Text) && !string.IsNullOrEmpty(tbValueFilter2.Text))
            {
                if (radioButton4.Checked)
                    ConditionFilter2 = "LIKE '*" + tbValueFilter2.Text + "'";
                if (radioButton5.Checked)
                    ConditionFilter2 = "LIKE '%" + tbValueFilter2.Text + "%'";
                if (radioButton6.Checked)
                    ConditionFilter2 = "= '" + tbValueFilter2.Text + "'";

                ConditionFilter2 = " " + cmbConj1.Text + " ["+ cmbFilter2.Text +"] " + " " + ConditionFilter2;

                QueryFilter2 = ConditionFilter2;
                QueryFilter = QueryFilter + QueryFilter2;
            }
            //Condition 3
            if (!string.IsNullOrEmpty(cmbConj2.Text) && !string.IsNullOrEmpty(cmbFilter3.Text) && !string.IsNullOrEmpty(tbValueFilter3.Text))
            {
                if (radioButton4.Checked)
                    ConditionFilter3 = "LIKE '*" + tbValueFilter3.Text + "'";
                if (radioButton5.Checked)
                    ConditionFilter3 = "LIKE '%" + tbValueFilter3.Text + "%'";
                if (radioButton6.Checked)
                    ConditionFilter3 = "= '" + tbValueFilter3.Text + "'";

                ConditionFilter3 = " " + cmbConj2.Text + " [" + cmbFilter3.Text + "] " + " " + ConditionFilter3;

                QueryFilter3 = ConditionFilter3;
                QueryFilter = QueryFilter + QueryFilter2 + QueryFilter3;
            }

            if (!string.IsNullOrEmpty(QueryFilter))
            {
                dvFilter.RowFilter = QueryFilter;
                dgDataRecords.DataSource = dvFilter.ToTable();
            }
            Countrecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //dvFilter.RowFilter = null;
                dgDataRecords.DataSource = dtSourceInfo;
                dgDataRecords.Refresh();
                Countrecords();
            }
            catch (Exception)
            {
            }            
        }
    }
}
