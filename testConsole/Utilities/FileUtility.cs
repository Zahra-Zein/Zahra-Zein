using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

namespace testConsole.Utilities
{
    public class FileUtility
    {
        private Application excelApp;
        private Workbook excelWorkbook;
        private Worksheet excelWorksheet;

        public FileUtility()
        {
            excelApp = new Application();
            excelWorkbook = excelApp.Workbooks.Add();
            excelWorksheet = (Worksheet)excelWorkbook.Sheets.Add();
        }
        public void MakeFile<T>(List<T> data, string fileName)
        {
            if (excelApp != null)
            {

                this.AddHeader(data);

                this.AddHeaderStyle(typeof(T));

               
                this.AddData(data);

                this.AddStyleToExcel(data);

                this.SaveFiles(fileName);

               
            }
        }

        private void SaveFiles(string fileName)
        {
            excelApp.ActiveWorkbook.SaveAs(@$"D:\{fileName}.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

            excelWorkbook.Close();
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void AddStyleToExcel<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            var excelCellrange = excelWorksheet.Range[excelWorksheet.Cells[1, 1], excelWorksheet.Cells[data.Count+1, properties.Count]];
            excelCellrange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            excelWorksheet.Rows.RowHeight = 18;
            excelWorksheet.Columns.ColumnWidth = 30;

            //excelWorksheet.Range[$"A1:G{data.Count + 1}"].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


            //throw new NotImplementedException();
        }

        private void AddHeaderStyle(Type type)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);

            var excelCellrange = excelWorksheet.Range[excelWorksheet.Cells[1, 1], excelWorksheet.Cells[1, properties.Count]];
            excelCellrange.Interior.Color = System.Drawing.Color.Gray;
        }

        private void AddData<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            int i = 1;
            int j = 2;
            foreach (T item in data)
            {

                foreach (PropertyDescriptor prop in properties)
                {
                    excelWorksheet.Cells[j, i].Value = prop.GetValue(item) ?? DBNull.Value;
                    i++;
                }
                j++;
                i = 1;
            }
         



        }

        private void AddHeader<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            int i = 1;
            foreach (PropertyDescriptor prop in properties)
            {
                excelWorksheet.Cells[1,i].Value = prop.Name;
                i++;
            }
        }
    }
}
