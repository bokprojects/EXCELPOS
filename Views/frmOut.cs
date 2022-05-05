using ExcelPOS.Process;
using System;
using System.Data;
using System.Windows.Forms;
namespace ExcelPOS.Views
{
    public partial class frmOut : Form
    {
        DataProcess dpro = new DataProcess();
        public string DirectorySource;
        DataTable dtAll = new DataTable();
        public frmOut()
        {
            InitializeComponent();
        }

        private void frmOut_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDirectory.Text))
            {
                tbDirectory.Text = Environment.CurrentDirectory + "\\Output";
            } else
            {
                tbDirectory.Text = DirectorySource;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbDirectory.Text))
            {
                MessageBox.Show("Error: Directory is invalid. Please check your output directory", "Output Directory is not correct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dpro.SearchAndListFileDirectory(tbDirectory.Text, listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectory.Text = fbd.SelectedPath;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string Filename = listView1.SelectedItems[0].Tag.ToString();
            DataTable dtRecords = new DataTable();
            dtRecords = dpro.ExcelToDataTable(Filename);
            dtAll = dtRecords;
            dgAll.DataSource = dtRecords;

            cmbOrderID.DataSource = dtRecords.AsDataView().ToTable(true,"Order ID");
            cmbOrderID.DisplayMember = "Order ID";
            cmbOrderID.ValueMember = "Order ID";
            
            cmbOrderID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbOrderID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            foreach(DataRow dr in dtAll.AsDataView().ToTable(true,"Order ID").Rows)
            {
                if(!acc.Contains(dr["Order ID"].ToString()))
                    acc.Add(dr["Order ID"].ToString());
            }
            cmbOrderID.AutoCompleteCustomSource = acc;

            dgOF.DataSource = dpro.dtOrderFulFill(dtRecords);
            dgPPC.DataSource = dpro.dtPPC(dtRecords);
            dgIO.DataSource = dpro.dtIO(dtRecords);

            lblTotalQuantity.Text = "Total Quantity: 0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet dsFile = new DataSet();
            dsFile.Tables.Clear();
            DialogResult dr = MessageBox.Show("Would you like to save this on your excel file?", "Save to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                string ErrFound = string.Empty;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    sfd.CheckFileExists = true;

                    DataTable dtOF = new DataTable();
                    DataSet dsPPC = new DataSet();
                    DataTable dtPPC = new DataTable();
                    DataSet dsIO = new DataSet();
                    DataTable dtIO = new DataTable();

                    dtOF.TableName = "OrderFulfill";
                    dtOF = (DataTable) dgOF.DataSource;
                    dtPPC.TableName = "PerCourier";
                    dtPPC = (DataTable)dgPPC.DataSource;
                    dtIO.TableName = "ItemOut";
                    dtIO = (DataTable)dgIO.DataSource;

                    if (dsFile.Tables.Contains("OrderFulfill"))
                        dsFile.Tables.Remove("OrderFulfill");

                    dsFile.Tables.Add(dtOF);
                    dsFile.Tables.Add(dtPPC);
                    dsFile.Tables.Add(dtIO);

                    if (dpro.SaveToExcelOutput(dsFile,sfd.FileName,ref ErrFound))
                    {
                        MessageBox.Show("Data successfully saved.", "Saved Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
                    {
                        MessageBox.Show("Error: " + ErrFound, "Error saving data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgAll.DataSource = dtAll;
            dgAll.Refresh();
            lblTotalQuantity.Text = "Total Quantity: 0";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cmbOrderID.Text))
            {
                DataView dvOrder = new DataView(dtAll);
                dvOrder.RowFilter = "[Order ID]='" + cmbOrderID.Text + "'";
                dgAll.DataSource = dvOrder.ToTable();

                int totalQuantity = 0;
                foreach(DataRow drQ in dvOrder.ToTable().Rows)
                {
                    string Quantity = drQ["Quantity"].ToString();

                    if (!string.IsNullOrEmpty(Quantity))
                        totalQuantity = totalQuantity + int.Parse(Quantity);
                }
                lblTotalQuantity.Text = "Total Quantity: " + totalQuantity;

            }
        }
    }
}
