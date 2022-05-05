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
using ExcelPOS.Validation;
using ExcelPOS.Views;

namespace ExcelPOS
{
    public partial class POS : Form
    {
        Validation.Validation checker = new Validation.Validation();
        Process.Message msg = new Process.Message();
        Process.DefaultValues defVal = new Process.DefaultValues();
        Process.DataProcess dpro = new Process.DataProcess();

        DataTable dtSourceInfo;
        DataTable dtSourceItem;
        DataTable dtPSKU;
        DataTable dtSKU;
        DataTable dtForOut;

        string FolderExcelDirectory = string.Empty;
        string LastWorksheet = string.Empty;
        string LastErrorFound = string.Empty;
        string BarcodeColumn = string.Empty;
        string ExcelReferenceFile = string.Empty;
        bool hasError = false;
        bool isFileBased = false;
        bool isAutoScanned = false;
        int MinBarcodeLength = 0;

        public void Initialized()
        {
            defVal.DatabaseName = defVal.GetDatabaseName();
            MinBarcodeLength = defVal.GetMinBarcodeLength();
            BarcodeColumn = defVal.GetBarcodeColumn();
            ExcelReferenceFile = defVal.GetExcelItemReference();
        }

        public POS()
        {
            InitializeComponent();
            Initialized();
        }

        private bool ValidateProgram(ref string ErrFound)
        {
            bool result = false;
            try
            {
                //Check if ini file is found
                result = checker.checkIniFile(ref ErrFound);
                isFileBased = defVal.GetIsFileBased();
                LastWorksheet = defVal.GetExcelFolder() + "\\" + defVal.GetLastWorksheet();
                
                if(result && !isFileBased)
                    //Check if database is already found
                    result = checker.checkDatabase(defVal.DatabaseName,ref ErrFound);

                //Check if filebased data to be used
                if(isFileBased)
                {
                    FolderExcelDirectory = defVal.ExcelDataRepository();
                    if (string.IsNullOrEmpty(FolderExcelDirectory))
                    {
                        ErrFound = "You are in filebase mode. Excel Directory is not set. Please check it first";
                        return false;
                    }
                    if(!Directory.Exists(FolderExcelDirectory))
                    {
                        ErrFound = "You are in filebase mode. Your Directory is invalid. Please check it first";
                        return false;
                    }
                    if(!File.Exists(ExcelReferenceFile))
                    {
                        ErrFound = "Your reference file is missing (ItemDB.xlsx) . Please check it first";
                        return false;
                    }
                    if(!File.Exists(Environment.CurrentDirectory + "\\Reference\\Output.xlsx"))
                    {
                        ErrFound = "Your Output reference file is missing (Output.xlsx) . Please check it first";
                        return false;
                    }
                    tssDatabase.Text = "File Based Data";
                }else
                {
                    tssDatabase.Text = "Database: ";
                }

                //Set for AutoScanned
                isAutoScanned = defVal.GetIsAutoScanned();
                if(File.Exists(LastWorksheet))
                {
                    RefreshData(LastWorksheet);
                }

                if (result)
                    ErrFound = string.Empty;


            }
            catch (Exception ex)
            {
                ErrFound = ex.Message;
                throw;
            }
            return result;
        }
        private void RefreshData(string LastWorksheet)
        {
            //Loading Data from Excel
            LoadDataToDataTable loading = new LoadDataToDataTable();
            loading.excelFilename = LastWorksheet;
            loading.excelItemReference = defVal.GetExcelItemReference();
            loading.WorkSheetItem = defVal.GetSourceItemWorksheet();

            loading.dtResult = new DataTable();
            loading.dtSourceItem = new DataTable();
            loading.dtPSKUList = new DataTable();
            loading.dtSKUList = new DataTable();

            loading.isAutoload = true;
            loading.ShowDialog();

            dtSourceInfo = new DataTable();
            dtSKU = new DataTable();
            dtPSKU = new DataTable();            

            dtSourceInfo = loading.dtResult;
            dtSourceItem = loading.dtSourceItem;
            dtSKU = loading.dtSKUList;
            dtPSKU = loading.dtPSKUList;

            tssExcelName.Text = "Excel Name: " + Path.GetFileName(LastWorksheet);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tssDate.Text = "Today is: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }
        private void CheckDefault()
        {
            Initialized();
            hasError = !ValidateProgram(ref LastErrorFound);
            if (hasError)
            {   
                msg.DisplayStatus(tssMessage, "Error: " + LastErrorFound);
                MessageBox.Show("Error: " + LastErrorFound, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }else
            {
                //Set all value when no error found.
                cbAutoScan.Checked = isAutoScanned;
                msg.DisplayStatus(tssMessage, "Ready...");
                if (isFileBased)
                {                    
                    tssDatabase.Text = "Filebased: " + defVal.GetExcelFolder();
                    return;
                }                
                tssDatabase.Text = "Database: " + defVal.GetDatabaseName();
            }
            tbBarcode.Focus();
            tbBarcode.SelectAll();
        }
        private void POS_Load(object sender, EventArgs e)
        {
            CheckDefault();
            tbBarcode.Focus();
            tbBarcode.SelectAll();
            dtForOut = new DataTable();
            dtForOut = dpro.DTForOut();
        }

        private void btnSourceInfo_Click(object sender, EventArgs e)
        {
            if (checker.CheckError(hasError, LastErrorFound))
            {
                msg.DisplayStatus(tssMessage, "Error: " + LastErrorFound);
                return;
            }
            Views.frmSourceInfo sourceInfo = new Views.frmSourceInfo();
            sourceInfo.isFileBased = isFileBased;
            sourceInfo.ShowDialog();
            dtSourceInfo = sourceInfo.dtSourceInfo;
            if(isFileBased)
                tssExcelName.Text = "Excel Name: " + sourceInfo.ExcelName;
            if(!string.IsNullOrEmpty(sourceInfo.ExcelName))
                defVal.setIniSettingValue("LastExcel", "System", sourceInfo.ExcelName, ref LastErrorFound);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Views.frmSettings settings = new Views.frmSettings();
            settings.ShowDialog();
            CheckDefault();
        }

        private void cbAutoScan_CheckedChanged(object sender, EventArgs e)
        {
            defVal.setIniSettingValue("AutoScan", "System", cbAutoScan.Checked.ToString(), ref LastErrorFound);
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            
        }       
        private void RecountItems()
        {
            Validation.Validation valid = new Validation.Validation();
            if(dataGridView1.Rows.Count > 0)
                tbNumberItems.Text = (dataGridView1.Rows.Count - 1).ToString();
            int TotalQuantity = 0;
            foreach(DataGridViewRow dgr in dataGridView1.Rows)
            {
                if(dgr.Cells[6].Value != null)
                    TotalQuantity += valid.isInteger(dgr.Cells[6].Value.ToString());
            }
            tbTotaQuantity.Text = TotalQuantity.ToString();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBarcode.Text))
            {
                if (tbBarcode.Text.Length > MinBarcodeLength)
                {
                    DataView dv = dpro.dvFilterBarcode(dtSourceInfo, tbBarcode.Text.Trim(),BarcodeColumn);
                    dpro.PopulateMyFrontEnd(dataGridView1, dv.ToTable());
                    RecountItems();
                    dataGridView1.Refresh();
                }
            }else
            {
                MessageBox.Show("No Data found. Please select a valid barcode.","Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbBarcode.Focus();
            tbBarcode.SelectAll();
        }

        private void tbBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\b')
            {
                tbBarcode.Text = String.Empty;
                tbBarcode.Focus();
            }
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Return)
            {
                if (!string.IsNullOrEmpty(tbBarcode.Text))
                {
                    if (tbBarcode.Text.Length > MinBarcodeLength)
                    {
                        DataView dv = dpro.dvFilterBarcode(dtSourceInfo, tbBarcode.Text.Trim(),BarcodeColumn);
                        dpro.PopulateMyFrontEnd(dataGridView1, dv.ToTable());
                        RecountItems();
                        dataGridView1.Refresh();
                    }else
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("No Data found. Please select a valid barcode.", "Invalid Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBarcode.Focus();
                tbBarcode.SelectAll();
            }
            if (string.IsNullOrEmpty(tbBarcode.Text))
                dataGridView1.Rows.Clear();
        }

        private void enterBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            tbBarcode.SelectAll();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("Error: Please select order first before proceed in Cross-details Checker", "No Order to check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmEditDetails editdet = new frmEditDetails();

            if(dataGridView1.SelectedRows.Count == 1)
                editdet.Courier = dataGridView1.SelectedRows[0].Cells["Courier"].Value.ToString();

            editdet.dtOrderDetails = dpro.dtConvertDataGridToDataTable(dataGridView1);
            editdet.dtItemSource = dtSourceItem;
            editdet.ShowDialog();
        }

        private void sourceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSourceInfo.PerformClick();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSettings.PerformClick();
        }

        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tbBarcode.Text) || e.KeyData == Keys.Back)
                dataGridView1.Rows.Clear();

            if (e.KeyData == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(tbBarcode.Text))
                {
                    if (tbBarcode.Text.Length > MinBarcodeLength)
                    {
                        DataView dv = dpro.dvFilterBarcode(dtSourceInfo, tbBarcode.Text.Trim(), BarcodeColumn);
                        dpro.PopulateMyFrontEnd(dataGridView1, dv.ToTable());
                        RecountItems();
                        dataGridView1.Refresh();
                    }
                }
                tbBarcode.Focus();
                tbBarcode.SelectAll();
            }
        }

        private void sourceItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSourceItems SourceItem = new frmSourceItems();
            SourceItem.dtPSKU = dtPSKU;
            SourceItem.dtSKU = dtSKU;            
            SourceItem.dtSourceItem = dtSourceItem;
            SourceItem.ShowDialog();    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(LastWorksheet);
            RefreshData(LastWorksheet);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData(LastWorksheet);
        }

        private void forOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOut fo = new frmOut();
            fo.DirectorySource = defVal.GetOutputFolder();
            fo.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReject reject = new frmReject();
            reject.ShowDialog();
        }

        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }
    }
}
