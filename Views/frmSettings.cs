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
    public partial class frmSettings : Form
    {
        Validation.Validation valid = new Validation.Validation();
        Process.DefaultValues defVal = new Process.DefaultValues();
        string IniPath = string.Empty;
        string LastErrorFound = string.Empty;
        public frmSettings()
        {
            InitializeComponent();
        }
        public void LoadValues()
        {
            tbDatabaseName.Text = defVal.GetDatabaseName();
            if(Path.GetExtension(tbDatabaseName.Text) != ".db")
            {
                LastErrorFound = "Database file is invalid. Please set a valid database file.";
                return;
            }
            tbExcelFolder.Text = defVal.GetExcelFolder();
            cbIsFilebased.Checked = defVal.GetIsFileBased();
            cbAutoScan.Checked = defVal.GetIsAutoScanned();
            tbBarcodeLength.Text = defVal.GetMinBarcodeLength().ToString();
            tbBarcodeReference.Text = defVal.GetBarcodeColumn().ToString();
        }
        public void SaveValues()
        {
            if (valid.checkDatabaseFile(tbDatabaseName.Text, ref LastErrorFound))
                valid.checkSelectedDirectory(tbExcelFolder.Text, ref LastErrorFound);


            if(!string.IsNullOrEmpty(tbBarcodeReference.Text))
                defVal.setIniSettingValue("SearchColumn", "System", tbBarcodeReference.Text, ref LastErrorFound);

            if (!string.IsNullOrEmpty(tbBarcodeLength.Text))
                defVal.setIniSettingValue("MinBarcodeLength", "System", tbBarcodeLength.Text, ref LastErrorFound);

            if (string.IsNullOrEmpty(LastErrorFound))
            {
                defVal.setIniSettingValue("DatabaseName", "System", tbDatabaseName.Text, ref LastErrorFound);            
            }
            if (string.IsNullOrEmpty(LastErrorFound))
            {
                defVal.setIniSettingValue("ExcelFolder", "System", tbExcelFolder.Text, ref LastErrorFound);
            }
            if (string.IsNullOrEmpty(LastErrorFound))
            {
                defVal.setIniSettingValue("AutoScan", "System", cbAutoScan.Checked.ToString(), ref LastErrorFound);
            }
            if (string.IsNullOrEmpty(LastErrorFound))
            {
                defVal.setIniSettingValue("CheckDatabase", "System", (!cbIsFilebased.Checked).ToString(), ref LastErrorFound);
            }

        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            IniPath = valid.GetIniPath();  
            tbIniPath.Text= IniPath;
            LoadValues();
            if (!valid.checkIniFile(ref LastErrorFound))
            {
                MessageBox.Show("Error:" + LastErrorFound, "Error reading settings.ini file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
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

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Would you like to save your setting?", "Overwrite the current setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                SaveValues();
                if(!string.IsNullOrEmpty(LastErrorFound))
                {
                    MessageBox.Show("Error:" + LastErrorFound, "Cannot save the details. Please check the error first.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Saving done.");
                this.Close();
            }
        }

        private void btnBrowseDBName_Click(object sender, EventArgs e)
        {
            string DBFilterFile = "database files (*.db)|*.db|All files (*.*)|*.*";
            tbDatabaseName.Text = valid.BrowseFile(DBFilterFile);
        }

        private void btnExcelFolder_Click(object sender, EventArgs e)
        {
            tbExcelFolder.Text = valid.BrowseFolder();
        }

        private void tbBarcodeLength_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbBarcodeLength.TextLength > 0)
                {
                    int result = int.Parse(tbBarcodeLength.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Barcode length must be integer.", "Number Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbBarcodeLength.Focus();
            }
                
        }

        private void frmSettings_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                this.Close();
        }
    }
}
