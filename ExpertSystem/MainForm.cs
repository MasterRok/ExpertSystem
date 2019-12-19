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
                    var cvHandler = new CvHandler();
                    openCvFileDialog.Reset();
                    cvHandler.LoadCv(fileName);
                }
            }
        }
    }
}