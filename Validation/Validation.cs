using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPOS.Validation
{
    public class Validation
    {
        public int isInteger(string Value)
        {
            int result = 0;
            try
            {
                result = int.Parse(Value);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool isBool(string Result)
        {
            bool TestVal = false;
            try
            {
                TestVal = bool.Parse(Result);
                return TestVal;
            }
            catch (Exception)
            {

                throw;
            }
            return TestVal;
        }
        public string GetIniPath()
        {
            return Environment.CurrentDirectory + "\\Settings.ini";
        }
        public string BrowseFolder()
        {
            string result = string.Empty;
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = true;
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                if(fbd.ShowDialog()== DialogResult.OK)
                {                   
                    result = fbd.SelectedPath;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public string BrowseFile(string IndexFilter)
        {
            string result = string.Empty;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = IndexFilter;
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    result = ofd.FileName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public bool checkDatabaseFile(string DatabaseFile,ref string LastErrorFound)
        {
            bool result = false;
            try
            {
                if(Path.GetExtension(DatabaseFile) != ".db")
                {
                    LastErrorFound = "Invalid Database file. Please check your database file first.";
                    return false;
                }
                LastErrorFound = string.Empty;
                result = true;
            }
            catch (Exception ex)
            {
                LastErrorFound = ex.Message;
                throw;
            }
            return result;
        }
        public bool checkSelectedDirectory(string DirectoryName,ref string LastErrorFound)
        {
            bool result = false;
            try
            {
                result = Directory.Exists(DirectoryName);
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
        public bool checkIniFile(ref string ErrFound)
        {
            bool result = false;
            try
            {     
                string IniFilePath= GetIniPath();
                result = File.Exists(IniFilePath);
                if (!result)
                    ErrFound = "No Settings.ini found. Please check this path:\n" + IniFilePath;
            }
            catch (Exception ex)
            {
                ErrFound = ex.Message;
                throw;
            }
            return result;
        }
        
        public bool checkDatabase(string DatabaseName,ref string ErrFound)
        {
            bool result = false;
            try
            {
                if (!File.Exists(DatabaseName))
                {
                    ErrFound = "No Database Found. Please check your setting first.";
                    return result;
                }

                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;    
        }
        public bool CheckError(bool HasError,string LastError)
        {
            if (HasError && !string.IsNullOrEmpty(LastError))
                MessageBox.Show("Error: " + LastError, "Please check error before continue", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return HasError;
        }
    }
}
