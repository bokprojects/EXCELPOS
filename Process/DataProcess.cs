using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPOS.Process
{
    public class DataProcess
    {
        public bool SaveDataOut(DataTable dtR, DataGridView dgv, string OutputFolder, string Courier)
        {
            bool result = false;
            try
            {
                if(string.IsNullOrEmpty(OutputFolder))
                {
                    OutputFolder = Environment.CurrentDirectory + "\\Output";
                }

                OutputFolder = OutputFolder + "\\" + DateTime.Now.ToString("MMddyyyy");

                if(!Directory.Exists(OutputFolder))
                    Directory.CreateDirectory(OutputFolder);

                string Filename = "For Out as of " + DateTime.Now.ToString("MMddyyyy");

                result = saveToExcel(OutputFolder + "\\" + Filename + ".xlsx",dgv, Courier);
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool SaveReject(string OrderID, ref string ErrFound)
        {
            bool result = false;
            try
            {
                if(string.IsNullOrEmpty(OrderID))
                {
                    ErrFound = "No Order ID found. Please check - value is empty";
                    return false;
                }

                string RejectFolder = Environment.CurrentDirectory + "\\Reject";
                RejectFolder = RejectFolder + "\\" + DateTime.Now.ToString("MMddyyyy");

                if(!Directory.Exists(RejectFolder))
                    Directory.CreateDirectory(RejectFolder);

                string Filename = RejectFolder + "\\" + OrderID + ".txt";

                if(File.Exists(Filename))
                {
                    ErrFound = "Order ID is alread rejected. Kindly check your Reject Folder";
                    return false;
                }

                using(StreamWriter sw = new StreamWriter(Filename))
                {
                    sw.Write("Reject Date: " + DateTime.Now.ToString());
                }
                result = true;
            }
            catch (Exception ex)
            {
                ErrFound = ex.Message.ToString();
            }
            return result;
        }

        public bool saveToExcel(string Filename, DataGridView dgv, string Courier)
        {
            bool result = false;
            bool isFileExist = false;
            try
            {
                isFileExist = File.Exists(Filename);

                DataTable dtExcel = new DataTable();

                if (isFileExist)
                {
                    dtExcel = ExcelToDataTable(Filename);
                }
                else
                {
                    dtExcel = dtOutputExcel(dgv);
                }

                bool isOrderIDExsist = false;
                string OrderID = String.Empty;
                if (dtExcel != null)
                {
                    OrderID = dgv["Order ID",0].Value.ToString();
                    if (dtExcel.Select("[Order ID]='" + OrderID + "'").Count() >= 1 && isOrderIDExsist == false)
                    {
                        isOrderIDExsist = true;                        
                    }

                    if (!isOrderIDExsist)
                    {
                        foreach (DataGridViewRow dgrow in dgv.Rows)
                        {
                            if (dgrow.Cells["Order ID"].Value == null || string.IsNullOrEmpty(dgrow.Cells["Order ID"].Value.ToString()))
                            {
                                break;
                            }

                            DataRow drow = dtExcel.NewRow();
                            foreach (DataGridViewColumn dgc in dgv.Columns)
                            {
                                if (dgc.Name == "is Matched")
                                {
                                    drow["Courier"] = Courier;
                                }
                                else
                                {
                                    drow[dgc.Name] = dgrow.Cells[dgc.HeaderText].Value.ToString();
                                }
                            }
                            drow["TimeStamp"] = DateTime.Now.ToString();
                            dtExcel.Rows.Add(drow);
                        }
                    }
                }

                if (!isOrderIDExsist)
                {
                    DataTableToExcel(Filename, dtExcel);
                    result = true;
                }
                else{
                    MessageBox.Show("Order ID: " + OrderID + " already saved in the list. Please check it again.", "Duplicate Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public void SearchAndListFileDirectory(string DirectorySource,ListView lv)
        {
            lv.Items.Clear();
            try
            {
                foreach(string DirectoryName in Directory.GetFiles(DirectorySource,"For*.xlsx",SearchOption.AllDirectories))
                {                                       
                    ListViewItem lvi = new ListViewItem(Path.GetFileName(DirectoryName));
                    lvi.Tag = DirectoryName;
                    lvi.SubItems.Add(CountRAWdata(DirectoryName).ToString());
                    lv.Items.Add(lvi);
                }
            }
            catch (Exception)
            {

            }
        }
        public int CountRAWdata(string Filename)
        {
            int result = 0;
            try
            {
                DataTable dtRecord = ExcelToDataTable(Filename);                
                result = dtRecord.DefaultView.ToTable(true,"Order ID").Rows.Count;
            }
            catch (Exception)
            {
            }
            return result;
        }
        public void DataTableToExcel(string ExcelFile, DataTable dtExcel)
        {
            try
            {
                if (!File.Exists(ExcelFile))
                {
                    FileInfo newFile = new FileInfo(ExcelFile);
                    using (ExcelPackage pck = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                        ws.Cells["A1"].LoadFromDataTable(dtExcel, true);
                        pck.Save();
                    }
                    MessageBox.Show("Done Saving");
                }
                else
                {
                    DataTable dtExist = dtExcel; //ExcelToDataTable(ExcelFile);
                    string OrderID = dtExcel.Rows[0]["Order ID"].ToString();
                    
                        //foreach (DataRow drow in dtExcel.Rows)
                        //{
                        //    DataRow NewDTExist = dtExist.NewRow();
                        //    NewDTExist["Order ID"] = drow["Order ID"].ToString();
                        //    NewDTExist["Quantity"] = drow["Quantity"].ToString();
                        //    NewDTExist["SKU (Parent)"] = drow["SKU (Parent)"].ToString();
                        //    NewDTExist["CSKU"] = drow["CSKU"].ToString();
                        //    NewDTExist["Courier"] = drow["Courier"].ToString();
                        //    NewDTExist["TimeStamp"] = DateTime.Now.ToString();
                        //    dtExist.Rows.Add(NewDTExist);   
                        //}
                        File.Delete(ExcelFile);
                        FileInfo newFile = new FileInfo(ExcelFile);
                        using (ExcelPackage pck = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                            ws.Cells["A1"].LoadFromDataTable(dtExist, true);
                            pck.Save();
                        }
                        MessageBox.Show("Done Saving");
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error Deleting excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable DTForOut()
        {
            DataTable dtResult = new DataTable();
            try
            {
                if(dtResult.Columns.Count > 0)
                    dtResult.Columns.Clear();

                dtResult.Columns.Add("OrderID");
                dtResult.Columns.Add("TimeStamp");
                dtResult.Columns.Add("Courier");
                dtResult.Columns.Add("ScannedSKU");
                dtResult.Columns.Add("ScannedCSKU");
                dtResult.Columns.Add("Quantity");

            }
            catch
            { }
            return dtResult;
        }
        public bool SaveToExcelOutput(DataSet DSFiles, string Filename,ref string ErrFound)
        {
            bool result = false;
            try
            {
                if (File.Exists(Filename))
                    File.Delete(Filename);
                
                FileInfo fi = new FileInfo(Filename);
                using (ExcelPackage pck = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Order ID Fulfilled");
                    ws.Cells["A1"].LoadFromDataTable(DSFiles.Tables[0], true);

                    ExcelWorksheet wp = pck.Workbook.Worksheets.Add("Parcel Count per Courier");
                    wp.Cells["A1"].LoadFromDataTable(DSFiles.Tables[1], true);

                    ExcelWorksheet wx = pck.Workbook.Worksheets.Add("Items Out");
                    wx.Cells["A1"].LoadFromDataTable(DSFiles.Tables[2], true);

                    pck.Save();
                }
                result = true;
            }
            catch (Exception ex)
            {
                ErrFound = ex.Message.ToString();
            }
            return result;
        }
        public DataTable dtOutputExcel(DataGridView dgv)
        {
            DataTable dtResult = new DataTable();

            try
            {
                dtResult.Columns.Clear();
                foreach (DataGridViewColumn dgc in dgv.Columns)
                {
                    string ColumnName = dgc.Name;
                    if (ColumnName == "is Matched")
                        ColumnName = "Courier";
                    DataColumn dcol = new DataColumn(ColumnName);
                    dtResult.Columns.Add(dcol);
                }
                DataColumn dcTS = new DataColumn("TimeStamp");
                dtResult.Columns.Add(dcTS);
            }
            catch (Exception)
            {

            }
            return dtResult;
        }
        public DataTable dtIO(DataTable dtRecords)
        {
            DataTable NewData = new DataTable();
            try
            {   
                NewData.Columns.Clear();
                NewData.Columns.Add("Scanned SKU");
                NewData.Columns.Add("Scanned CSKU");
                NewData.Columns.Add("Quanity");

                foreach (DataRow drow in dtRecords.DefaultView.ToTable(true, "SKU (Parent)").Rows)
                {
                    string SKU = drow["SKU (Parent)"].ToString();
                    string CSKU = string.Empty;
                    foreach(DataRow drow2 in dtRecords.DefaultView.ToTable(true, "CSKU").Rows)
                    {
                        CSKU = drow2["CSKU"].ToString();
                        DataRow dtrow = NewData.NewRow();
                        dtrow["Scanned SKU"] = SKU;
                        dtrow["Scanned CSKU"] = CSKU;
                        int TotalQuanity = 0;

                        foreach (DataRow drw in dtRecords.Select("[SKU (Parent)] = '" + SKU + "' and [CSKU]='" + CSKU + "'"))
                        {
                            if (!string.IsNullOrEmpty(drw["Quantity"].ToString()))
                                TotalQuanity = TotalQuanity + int.Parse(drw["Quantity"].ToString());
                        }

                        dtrow["Quanity"] = TotalQuanity.ToString();

                        if(TotalQuanity >= 1)
                            NewData.Rows.Add(dtrow);
                    }
                    
                }                
            }
            catch (Exception ex)
            {
            }
            return NewData;
        }
        public DataTable dtPPC(DataTable dtRecords)
        {
            DataTable dtFilterRecords = dtRecords;
            try
            {
                DataView dvOF = new DataView(dtRecords);
                DataTable NewData = new DataTable();
                NewData.Columns.Clear();
                NewData.Columns.Add("Courier");
                NewData.Columns.Add("Parcel Fulfilled");
                //NewData.Columns.Add("Order ID Count");
                NewData.Columns.Add("Total Quantity");

                foreach (DataRow drow in dtRecords.DefaultView.ToTable(true, "Courier").Rows)
                {
                    DataRow dtNew = NewData.NewRow();
                    string Courier = drow[0].ToString();
                    dtNew["Courier"] = Courier;
                    int countSum = 0;
                    foreach(DataRow drw in dtRecords.Select("Courier='" + Courier + "'"))
                    {
                        if (!string.IsNullOrEmpty(drw["Courier"].ToString()))
                        {
                            countSum = countSum + int.Parse(drw["Quantity"].ToString());
                        }
                    }

                    DataView dvOrderID = new DataView(dtRecords);
                    dvOrderID.RowFilter = "Courier='" + Courier + "'";
                    DataTable dtOrders = dvOrderID.ToTable(true,"Order ID");

                    dtNew["Parcel Fulfilled"] = dtOrders.Rows.Count;
                    dtNew["Total Quantity"] = countSum;

                    NewData.Rows.Add(dtNew);
                }
                dtFilterRecords = NewData;
            }
            catch (Exception)
            {

            }
            return dtFilterRecords;
        }
        public DataTable dtOrderFulFill(DataTable dtRecords)
        {
            DataTable dtFilterRecords = dtRecords;
            DataTable dtOrders = new DataTable();
            try
            {   
                dtOrders.Columns.Add("Order ID");
                dtOrders.Columns.Add("Total Item Count");

                DataView dvOF = new DataView(dtRecords);
                dtFilterRecords = dvOF.ToTable(true, "Order ID");

                foreach(DataRow drow in dtFilterRecords.Rows)
                {
                    string OrderID = drow["Order ID"].ToString();
                    DataRow newOrder = dtOrders.NewRow();
                    newOrder["Order ID"] = OrderID;

                    int TotalQuantity = 0;

                    foreach(DataRow drowQuantity in dtRecords.Select("[Order ID] = '" + OrderID + "'"))
                    {
                        TotalQuantity = TotalQuantity + int.Parse(drowQuantity["Quantity"].ToString());
                    }

                    newOrder["Total Item Count"] = TotalQuantity.ToString();
                    dtOrders.Rows.Add(newOrder);
                }

            }
            catch (Exception)
            {

            }
            return dtOrders;
        }
        public DataTable ExcelToDataTable(string path)
        {
            DataTable tbl = new DataTable();
            try
            {
                FileInfo fi = new FileInfo(path);
                using (var pck = new OfficeOpenXml.ExcelPackage(fi))
                {                    
                    var ws = pck.Workbook.Worksheets.First();

                    bool hasHeader = true;
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = hasHeader ? 2 : 1;
                    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        var row = tbl.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        tbl.Rows.Add(row);
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Failed to read excel.Please check your file. \n" + path, "Error Reading Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tbl;
        }
        public DataTable ExcelToDataTable(string path,ProgressBar pb)
        {
            DataTable tbl = new DataTable();
            try
            {
                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    pck.Load(File.OpenRead(path));
                    var ws = pck.Workbook.Worksheets.First();

                    bool hasHeader = true;
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = hasHeader ? 2 : 1;
                    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        var row = tbl.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        tbl.Rows.Add(row);
                        pb.Value = (rowNum * 100) / ws.Dimension.End.Row;
                    }
                    pck.Dispose();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: Failed to read excel.Please check your file. \n" + path, "Error Reading Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tbl;
        }
        public DataTable ExcelToDataTable(string path, ProgressBar pb,int WorksheetName)
        {
            DataTable tbl = new DataTable();
            try
            {
                FileInfo fi = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(fi))
                {
                    var ws = pck.Workbook.Worksheets[WorksheetName];

                    bool hasHeader = true;
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }

                    var startRow = hasHeader ? 2 : 1;
                    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        var row = tbl.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        tbl.Rows.Add(row);
                        pb.Value = (rowNum * 100) / ws.Dimension.End.Row;
                    }
                }
            }catch
            {

            }
            return tbl;
        }
        public void ComboBoxInitialized(ComboBox cbCtrl,DataTable dtRecords,bool isAutoComplete,string ValueMember,string DisplayMember)
        {
            try
            {
                cbCtrl.Items.Clear();
                cbCtrl.DataSource = dtRecords;
                cbCtrl.ValueMember = ValueMember;
                cbCtrl.DisplayMember = DisplayMember;

                if(isAutoComplete)
                {                    
                    cbCtrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbCtrl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception)
            {
            }
        }
        public void DataColumnToCombo(DataTable dtRecords,ComboBox cbData)
        {
            try
            {
                cbData.Items.Clear();
                if(dtRecords != null)
                {
                    foreach(DataColumn dc in dtRecords.Columns)
                    {
                        if(!string.IsNullOrEmpty(dc.ColumnName))
                        {
                            cbData.Items.Add(dc.ColumnName);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataView dvFilterBarcode(DataTable dtRecords, string TrackingNumber,string SearchColumn)
        {
            DataView dv = new DataView();
            try
            {
                if (string.IsNullOrEmpty(SearchColumn))
                    SearchColumn = "Tracking Number*";

                dv = dtRecords.DefaultView;
                dv.RowFilter = "["+ SearchColumn +"] = '"+ TrackingNumber +"'";
                return dv.ToTable(false, "Order id","Shipping Option", "Parent SKU Reference No.", "SKU Reference No.","Quantity").DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Filtering Orders Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            return dv;
        }
        public DataTable dtConvertDataGridToDataTable(DataGridView dgv)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();
            try
            {
                //Adding the Columns.
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataRow drow = dt.NewRow();
                    int col = 0;
                    foreach(DataGridViewCell dcell in row.Cells)
                    {
                        string ValueCell = String.Empty;
                        if (dgv[col, row.Index].Value != null)
                        {
                            ValueCell = dgv[col, row.Index].Value.ToString();
                        }
                        drow[col] = ValueCell;
                        col++;
                    }
                    dt.Rows.Add(drow);                    
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public void PopulateMyFrontEnd(DataGridView dgv, DataTable dtRecords)
        {
            try
            {
                dgv.Rows.Clear();
                //int Counter = 1;
                //foreach (DataRow dr in dtRecords.Rows)
                //{
                //    DataGridViewRow dgrItemNumber = (DataGridViewRow)dgv.Rows[0].Clone();
                //    dgrItemNumber.Cells[0].Value = Counter.ToString();
                //    dgrItemNumber.Cells[1].Value = dr["Order id"].ToString();
                //    dgrItemNumber.Cells[2].Value = string.Empty;
                //    dgrItemNumber.Cells[3].Value = dr["Shipping Option"].ToString();
                //    dgrItemNumber.Cells[4].Value = dr["Parent SKU Reference No."].ToString();
                //    dgrItemNumber.Cells[5].Value = dr["SKU Reference No."].ToString();
                //    dgrItemNumber.Cells[6].Value = dr["Quantity"].ToString();


                //    dgv.Rows.Add(dgrItemNumber);
                //    Counter++;
                //}
                DataView dview = new DataView(dtRecords);
                DataView dviewS = new DataView(dtRecords);

                DataTable dtNewRecords = new DataTable();
                dtNewRecords.Columns.Clear();

                dtNewRecords.Columns.Add("Order ID");
                dtNewRecords.Columns.Add("Shop");
                dtNewRecords.Columns.Add("Shipping Option");
                dtNewRecords.Columns.Add("Parent SKU Reference No.");
                dtNewRecords.Columns.Add("SKU Reference No.");
                dtNewRecords.Columns.Add("Quantity");
                
                foreach(DataRow drow in dtRecords.Rows)
                {
                    string CSKU = drow["Parent SKU Reference No."].ToString();
                    string SKU = drow["SKU Reference No."].ToString();
                    DataView OrderCount = new DataView(dtRecords);
                    OrderCount.RowFilter = "[Parent SKU Reference No.] = '" + CSKU + "' and [SKU Reference No.]='" + SKU + "'";
                    DataTable resultFilter = OrderCount.ToTable();
                    int TotalQuantiy = 0;
                    if(resultFilter.Rows.Count > 1)
                    {
                        foreach(DataRow drQ in OrderCount.ToTable().Rows)
                        {
                            TotalQuantiy = TotalQuantiy + int.Parse(drQ["Quantity"].ToString());
                        }
                    }else
                    {
                        TotalQuantiy = int.Parse(drow["Quantity"].ToString());
                    }
                    DataRow NewRecords = dtNewRecords.NewRow();
                    NewRecords["Order ID"] = drow["Order ID"];
                    NewRecords["Shop"] = string.Empty;
                    NewRecords["Shipping Option"] = drow["Shipping Option"];
                    NewRecords["Parent SKU Reference No."] = CSKU;
                    NewRecords["SKU Reference No."] = SKU;
                    NewRecords["Quantity"] = TotalQuantiy.ToString();

                    if (dtNewRecords.Select("[Parent SKU Reference No.] = '" + CSKU + "' and [SKU Reference No.]='" + SKU + "'").Count() == 0)
                    {
                        dtNewRecords.Rows.Add(NewRecords);
                    }
                } 

                if(dtNewRecords.Rows.Count > 0)
                {
                    int counter = 1;
                    foreach(DataRow drw in dtNewRecords.Rows)
                    {
                        DataGridViewRow dgrItemNumber = (DataGridViewRow)dgv.Rows[0].Clone();
                        dgrItemNumber.Cells[0].Value = counter.ToString();
                        dgrItemNumber.Cells[1].Value = drw["Order id"].ToString();
                        dgrItemNumber.Cells[2].Value = string.Empty;
                        dgrItemNumber.Cells[3].Value = drw["Shipping Option"].ToString();
                        dgrItemNumber.Cells[4].Value = drw["Parent SKU Reference No."].ToString();
                        dgrItemNumber.Cells[5].Value = drw["SKU Reference No."].ToString();
                        dgrItemNumber.Cells[6].Value = drw["Quantity"].ToString();

                        dgv.Rows.Add(dgrItemNumber);
                        counter++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Retrieving Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool UpdateMyrecords(DataTable dtRecords, string ExcelFilename, string WorksheetName)
        {
            bool result = false;
            try
            {
                if (dtRecords.Rows.Count > 0)
                {
                    FileInfo fi = new FileInfo(ExcelFilename);
                    using (ExcelPackage pck = new ExcelPackage(fi))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets[WorksheetName];
                        int counter = 0;
                        foreach(DataRow dr in dtRecords.Rows)
                        {
                            if(counter >= 1)
                                ws.Cells[counter, 1].Value = dr[0].ToString();
                            counter++;
                        }
                        pck.Save();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Saving Excel Record Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool SaveMySourceItem(DataTable dtRecords)
        {
            bool result = false;
            string ExcelFile = Environment.CurrentDirectory + "\\Reference\\ItemDB.xlsx";
            try
            {
                if(File.Exists(ExcelFile))
                {
                    FileInfo fi = new FileInfo(ExcelFile);
                    using (ExcelPackage pck = new ExcelPackage(fi))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets["Source Item"];
                        int counter = 0;
                        foreach (DataRow dr in dtRecords.Rows)
                        {
                            if (counter >= 1)
                                ws.Cells[counter, 1].Value = dr[0].ToString();
                            counter++;
                        }
                        pck.Save();
                        result = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
