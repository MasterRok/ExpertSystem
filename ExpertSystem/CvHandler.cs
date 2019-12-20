using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using WindowsApplication = System.Windows.Forms.Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExpertSystem
{
    public static class CvHandler
    {
        public static Cv LoadCv(string cvFileName)
        {
            var cv = new Cv();

            // Open xlsx file and read from 1st sheet
            Excel.Application oExcel = new Excel.Application();
            Workbook workBook = oExcel.Workbooks.Open(cvFileName, null, true);
            var workSheet = (Worksheet) workBook.Sheets.Item[1];
            var excelRange = workSheet.UsedRange;

            // Read cv columns
            foreach (Range row in excelRange.Rows)
                cv.Add((string) ((Range) excelRange.Cells[row.Row, 1]).Value,
                    (string) ((Range) excelRange.Cells[row.Row, 2]).Value);

            // Release objects
            workBook.Close();
            oExcel.Quit();
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(workBook);
            Marshal.ReleaseComObject(oExcel);
            return cv;
        }

        public static void AnalyzeCv(Cv cv)
        {
            var c = KnowledgeBase.MyGraph.Triples.Count;
            // Check cv for uncertainty
            if (CheckForUncertainty(cv))
            {
                MessageBox.Show("Incorrect CV", "Oops..", MessageBoxButtons.OK);
                var experimenterForm = new Experimenter(cv);

                if (experimenterForm.ShowDialog() == DialogResult.OK)
                {
                    // return experimenterForm.GetCv();
                }
            }
        }


        private static bool CheckForUncertainty(Cv cv)
        {
            foreach (var row in cv)
            {
                if ((row.Value == null || row.Value.Trim().Equals("")) && row.Key.Equals("Навык"))
                    return true; // Empty Skill Value
            }

            return false;
        }
    }
}