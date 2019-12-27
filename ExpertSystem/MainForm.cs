using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadCv_Click(object sender, EventArgs e)
        {
            using (var openCvFileDialog = new OpenFileDialog())
            {
                openCvFileDialog.Filter = "Книга Excel (*.xlsx)|*.xlsx| (*.xls)|*.xls";
                if (openCvFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openCvFileDialog.FileName;
                    openCvFileDialog.Reset();
                    var cv = CvHandler.LoadCv(fileName);
                    foreach (var pair in cv)
                    {
                        string[] arr = {pair.Key, pair.Value};
                        lvCv.Items.Add(new ListViewItem(arr));
                        lvCv.Update();
                    }

                    var jobs = KnowledgeBase.GetJobs();

                    cv = cv.FilterValues();
                    CvHandler.AnalyzeCv(cv, jobs);
                }
            }
        }
    }
}