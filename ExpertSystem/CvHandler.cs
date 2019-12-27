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

        public static void AnalyzeCv(Cv cv, List<Job> jobs)
        {
            // Check cv for uncertainty
            if (CheckForUncertainty(cv, jobs))
            {
                MessageBox.Show("Incorrect CV", "Oops..", MessageBoxButtons.OK);
                var experimenterForm = new Experimenter(cv);

                if (experimenterForm.ShowDialog() == DialogResult.OK)
                {
                    // return experimenterForm.GetCv();
                }
            }
        }


        private static bool CheckForUncertainty(Cv cv, List<Job> jobs)
        {
            var jobName = cv.FindValueByKey("Должность");
            // If position is not specified
            if (jobs.Find(job => job.Name.Equals(jobName))==null)
                return true;

            // If bio is not specified
            if (!cv.IsValueExists("Имя"))
                return true;
            if (!cv.IsValueExists("Фамилия"))
                return true;
            
            // Check if enough skills for any job
            var requiredSkills = jobs.Find(job => jobName == job.Name).Skills;
            foreach (var skill in requiredSkills)
                if (!cv.IsSkillExists(skill))
                    return true;

            return false;
        }
    }
}