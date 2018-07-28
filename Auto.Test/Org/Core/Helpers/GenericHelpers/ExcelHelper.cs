using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;

namespace Auto.Test.GenericHelpers
{
    public class ExcelHelper
    {
        OleDbConnection con = null;
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =<FILE_PATH>;Extended Properties=Excel 12.0;";
        System.Data.OleDb.OleDbDataAdapter dataadapter = null;
        System.Data.DataTable datatable = null;
        private void GetConnection(string filename)
        {
            if (con == null)
            {
                con = new OleDbConnection(conStr.Replace("<FILE_PATH>", filename));
                con.Open();
            }

        }
        private string GetColumnCommnd(string sheetname)
        {
            return "select * from [" + sheetname + "$]";
        }
        public List<string> GetSheetNames(string filename)
        {
            List<string> res = null;
            GetConnection(filename);
            datatable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (datatable == null)
                return res;
            foreach (System.Data.DataRow row in datatable.Rows)
            {
                res.Add(row["TABLE_NAME"].ToString());
            }

            return res;
        }
        public List<string> GetColumns(string filename, string sheetname)
        {
            List<string> res = new List<string>();
            GetConnection(filename);
            var cmd = new OleDbCommand(GetColumnCommnd(sheetname), con);
            var reader = cmd.ExecuteReader(System.Data.CommandBehavior.SchemaOnly);

            datatable = reader.GetSchemaTable();
            var nameCol = datatable.Columns["ColumnName"];
            foreach (System.Data.DataRow row in datatable.Rows)
            {
                try
                {
                    res.Add(row[nameCol].ToString());
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }
            }

            return res;
        }
        public List<Dictionary<string, string>> GetDataRows(string filename, string sheetname)
        {
            List<Dictionary<string, string>> res = new List<Dictionary<string, string>>();
            Dictionary<string, string> rowdata = null;
            List<string> columns = GetColumns(filename, sheetname);
            System.Data.DataSet excelDataSet = new System.Data.DataSet();
            GetConnection(filename);
            dataadapter = new OleDbDataAdapter(GetColumnCommnd(sheetname), con);
            dataadapter.Fill(excelDataSet);
            con.Close();
            con.Dispose();
            con = null;
            datatable = excelDataSet.Tables[0];
            foreach (System.Data.DataRow row in datatable.Rows)
            {
                rowdata = new Dictionary<string, string>();
                foreach (string colname in columns)
                {
                    rowdata.Add(colname, row[colname].ToString());
                }
                res.Add(rowdata);
            }
            return res;
        }
        public List<Dictionary<int, string>> GetDataRows(string filename, string sheetname, int[] targetcolumns)
        {
            List<Dictionary<int, string>> res = new List<Dictionary<int, string>>();
            Dictionary<int, string> rowdata = null;
            System.Data.DataSet excelDataSet = new System.Data.DataSet();
            GetConnection(filename);
            dataadapter = new OleDbDataAdapter(GetColumnCommnd(sheetname), con);
            dataadapter.Fill(excelDataSet);
            con.Close();
            con.Dispose();
            con = null;
            datatable = excelDataSet.Tables[0];
            foreach (System.Data.DataRow row in datatable.Rows)
            {
                rowdata = new Dictionary<int, string>();
                foreach (int colname in targetcolumns)
                {
                    rowdata.Add(colname, row[colname].ToString());
                }
                res.Add(rowdata);
            }
            return res;
        }

        public string ValidateFinancials(string baseFilePath, string actFilePath, string sheetName, int finAccountIndex, string[] ignorelist = null, int[] ignorerows = null)
        {
            string res = "";
            Application xlApp = null;
            Workbook baseWorkbook = null;
            Workbook actWorkbook = null;
            try
            {
                xlApp = new Application();
                baseWorkbook = xlApp.Workbooks.Open(baseFilePath);
                actWorkbook = xlApp.Workbooks.Open(actFilePath);
                Worksheet baseWorksheet = baseWorkbook.Sheets[sheetName];
                Worksheet actWorksheet = actWorkbook.Sheets[sheetName];
                Range baseSheetRange = baseWorksheet.UsedRange;
                Range actSheetRange = actWorksheet.UsedRange;

                for (int rowIndex = 1; rowIndex < baseSheetRange.Rows.Count; rowIndex++)
                {
                    if (!CanIIgnoreRow(ignorerows, rowIndex))
                    {
                        string curRowAccount = (baseSheetRange.Cells[rowIndex, finAccountIndex].value.ToString());
                        for (int colIndex = finAccountIndex; colIndex <= baseSheetRange.Columns.Count; colIndex++)
                        {
                            string baseAccountValue = (baseSheetRange.Cells[rowIndex, colIndex].value.ToString());
                            string actAccountValue = (actSheetRange.Cells[rowIndex, colIndex].value.ToString());
                            if (baseAccountValue != actAccountValue)
                            {
                                bool isResultsCanAdd = true;
                                if (ignorelist != null)
                                {
                                    foreach (string item in ignorelist)
                                    {
                                        if (item.ToLower().Trim() == curRowAccount.ToLower().Trim())
                                        {
                                            isResultsCanAdd = false;
                                            break;
                                        }
                                    }
                                }
                                if (isResultsCanAdd)
                                    res = res + "\n For Account \t" + curRowAccount + "\t Difference between base value \t" + baseAccountValue + " \t actual value \t" + actAccountValue + " \t at base sheet Row index \t" + rowIndex;
                            }

                        }
                    }
                }

            }
            catch (Exception er)
            {
                res = null;
            }
            finally
            {
                if (xlApp != null)
                {
                    baseWorkbook.Close();
                    actWorkbook.Close();
                    xlApp = null;
                }
            }
            return res;
        }
        public List<string> GetFinancialsFromBaseSheet(string baseFilePath, string sheetName, int finAccountIndex)
        {

            Application xlApp = null;
            Workbook baseWorkbook = null;
            List<string> res = new List<string>();
            try
            {
                xlApp = new Application();
                baseWorkbook = xlApp.Workbooks.Open(baseFilePath);
                Worksheet baseWorksheet = baseWorkbook.Sheets[sheetName];
                Range baseSheetRange = baseWorksheet.UsedRange;

                for (int rowIndex = 1; rowIndex < baseSheetRange.Rows.Count; rowIndex++)
                {
                    string toConcat = "";
                    for (int colIndex = finAccountIndex; colIndex < baseSheetRange.Columns.Count; colIndex++)
                    {
                        toConcat = toConcat + " " + (baseSheetRange.Cells[rowIndex, colIndex].value.ToString());

                    }
                    res.Add(toConcat);
                }

            }
            catch (Exception er)
            {
                res = null;
            }
            finally
            {
                if (xlApp != null)
                {
                    baseWorkbook.Close();
                    xlApp = null;
                }
            }
            return res;
        }
        public string GetLatestFileFromDir(string dir)
        {
            var directory = new DirectoryInfo(dir);
            var myFile = (from f in directory.GetFiles()
                          orderby f.LastWriteTime descending
                          select f).First();
            return myFile.FullName;
        }

        public void WriteResultsFile(string responceResultsPath, string contentToWrite)
        {
            if (File.Exists(responceResultsPath))
                File.Delete(responceResultsPath);
            using (StreamWriter sw = File.CreateText(responceResultsPath))
            {
                sw.WriteLine(contentToWrite);
            }
        }
        private bool CanIIgnoreRow(int[] list, int curRow)
        {

            bool retval = false;
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == curRow)
                    {
                        return true;
                    }
                }
            }
            return retval;
        }
    }
}
