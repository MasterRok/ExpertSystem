﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using WindowsApplication = System.Windows.Forms.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace ExpertSystem
{
    public class CvHandler
    {
        public CvHandler()
        {
        }

        public Dictionary<string, string> LoadCv(string cvFileName)
        {
            Console.WriteLine("Cv Handler");

            ExcelApplication oExcel = new ExcelApplication();
            Workbook workBook = oExcel.Workbooks.Open(cvFileName);
            var workSheet = (Worksheet) workBook.Worksheets[0];
            Console.WriteLine(workSheet.Rows);

            if (true /*If have some uncertainty*/)
            {
                var cv = new Dictionary<string, string>();
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
        }
    }
}