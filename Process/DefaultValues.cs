using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelPOS.Process
{
    public class DefaultValues
    {
        Validation.Validation valid = new Validation.Validation();
        public string DatabaseName { get; set; }
        public string GetSourceItemWorksheet()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("SourceItemWorkSheet", "System");
                if(result == null || string.IsNullOrEmpty(result))
                {
                    string ErrFound = string.Empty;
                    setIniSettingValue("SourceItemWorkSheet", "System", "Source Item", ref ErrFound);
                    result = getIniSettingValue("SourceItemWorkSheet", "System");
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public string GetExcelItemReference()
        {
            return Environment.CurrentDirectory + "\\Reference\\ItemDB.xlsx";
        }
        public string GetBarcodeColumn()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("SearchColumn", "System");                
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public int GetMinBarcodeLength()
        {
            int BarcodeLength = 0;
            try
            {
                string result = getIniSettingValue("MinBarcodeLength", "System");
                if(!string.IsNullOrEmpty(result))
                    BarcodeLength = int.Parse(result);
            }
            catch (Exception ex)
            {
            }
            return BarcodeLength;
        }
        public string GetOutputFolder()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("OutputFolder", "System");
            }
            catch (Exception)
            {
            }
            return result;
        }
        public string ExcelDataRepository()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("ExcelFolder", "System");
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string GetLastWorksheet()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("LastExcel", "System");
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public string GetDatabaseName()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("DatabaseName", "System");
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public string GetExcelFolder()
        {
            string result = string.Empty;
            try
            {
                result = getIniSettingValue("ExcelFolder", "System");
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public bool GetIsAutoScanned()
        {
            bool result = false;
            try
            {
                string isFileBased = getIniSettingValue("AutoScan", "System");
                result = valid.isBool(isFileBased.ToLower());                
            }
            catch (Exception)
            {
                result = true;
            }
            return result;
        }
        public bool GetIsFileBased()
        {
            bool result = false;
            try
            {
                string isFileBased = getIniSettingValue("CheckDatabase", "System");
                result = valid.isBool(isFileBased.ToLower());
                if (!result)
                    result = true;
                else
                    result = false;
            }
            catch (Exception)
            {
                result = true;
            }
            return result;
        }
        public string getIniSettingValue(string Field,string Section)
        {
            string result = string.Empty;
            try
            {
                string Inipath = valid.GetIniPath();
                clsINI ini = new clsINI(Inipath);
                result = ini.Read(Field, Section);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public bool setIniSettingValue(string Field, string Section, string Value,ref string ErrorFound)
        {
            bool result = false;
            try
            {
                string Inipath = valid.GetIniPath();
                clsINI ini = new clsINI(Inipath);
                ini.Write(Field, Value, Section);
                result = true;
            }
            catch (Exception ex)
            {
                ErrorFound = ex.Message;
                throw;
            }
            return result;
        }        
    }
}
