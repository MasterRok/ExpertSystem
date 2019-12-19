using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;

namespace ExpertSystem
{
    public partial class Experimenter : Form
    {
        private Cv _cv;
        private System.Timers.Timer timer;

        public Experimenter(Cv incompleteCv)
        {
            InitializeComponent();
            this._cv = incompleteCv;

            timer = new System.Timers.Timer(50);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
                timer.Enabled = false;
            else
                progressBar.PerformStep();
        }

        public Cv GetCv()
        {
            return _cv;
        }
    }
}