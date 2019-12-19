using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using WindowsApplication = System.Windows.Forms.Application;
using Excel= Microsoft.Office.Interop.Excel;

namespace ExpertSystem
{
    public class CvHandler
    {
        public Dictionary<string, string> LoadCv(string cvFileName)
        {
            var cv = new Dictionary<string, string>();

            // Open xlsx file and read from 1st sheet
            Excel.Application oExcel = new Excel.Application();
            Workbook workBook = oExcel.Workbooks.Open(cvFileName, null, true);
            var workSheet = (Worksheet) workBook.Sheets.Item[1];
            var excelRange = workSheet.UsedRange;
            
            // Read cv columns
            foreach (Range row in excelRange.Rows)
               cv.Add((string)((Range) excelRange.Cells[row.Row, 1]).Value, 
                   (string)((Range) excelRange.Cells[row.Row, 2]).Value);
            
            // Release objects
            workBook.Close();
            oExcel.Quit();
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(workBook);
            Marshal.ReleaseComObject(oExcel);

            if (CheckForUncertainty(cv))
            {
                var experimenterForm = new Experimenter(cv);
                if (Control.ModifierKeys == Keys.Control)
                {
                    ((Control) WindowsApplication.OpenForms["MainForm"]).Hide();
                }

                if (experimenterForm.ShowDialog() == DialogResult.OK)
                {
                    return experimenterForm.GetCv();
                }
                else
                    throw new Exception("Error while interview");
            }

            return cv;
        }

        private bool CheckForUncertainty(Dictionary<string, string> cv)
        {
            return false;
        }
    }
}