using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpertSystem
{
    public partial class Experimenter : Form
    {
        private Dictionary<string, string> _cv;

        public Experimenter(Dictionary<string, string> incompleteCv)
        {
            InitializeComponent();
            this._cv = incompleteCv;
        }

        private void Experimenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Cv has been completed");
        }

        public Dictionary<string, string> GetCv()
        {
            return _cv;
        }
    }
}