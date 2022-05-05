using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPOS.Views
{
    public partial class LoadDataToDataTable : Form
    {
        Process.DataProcess dpro = new Process.DataProcess();
     
        public bool isAutoload;
        public DataTable dtResult;
        public DataTable dtSourceItem;
        public DataTable dtSKUList;
        public DataTable dtPSKUList;
        public string excelFilename;
        public string excelItemReference;
        public string WorkSheetItem;
        public LoadDataToDataTable()
        {
            InitializeComponent();
        }

        private void LoadDataToDataTable_Load(object sender, EventArgs e)
        {
            if(File.Exists(excelFilename))
            {
                bgAnalyzeFile.RunWorkerAsync();
            }else
            {
                MessageBox.Show("Error: No excel file to process. Please select a new one.", "Excel is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgAnalyzeFile_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                dtResult = dpro.ExcelToDataTable(excelFilename, pb);

                if (!File.Exists(excelItemReference) || string.IsNullOrEmpty(excelItemReference))
                {
                    excelItemReference = Environment.CurrentDirectory + "\\Reference\\ItemDB.xlsx";
                }
                Thread.Sleep(1000);
                dtSourceItem = dpro.ExcelToDataTable(excelItemReference, pb, 1);
                Thread.Sleep(1000);
                dtPSKUList = dpro.ExcelToDataTable(excelItemReference, pb, 2);
                Thread.Sleep(1000);
                dtSKUList = dpro.ExcelToDataTable(excelItemReference, pb,3);

                if (!isAutoload)
                    MessageBox.Show("Done Reading file.");
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
