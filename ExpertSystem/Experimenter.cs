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
        private string offeredJob;

        public Experimenter(Cv incompleteCv, List<Job> jobs)
        {
            InitializeComponent();
            _cv = incompleteCv;

            timer = new System.Timers.Timer(50);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            var jobName = _cv.FindValueByKey("Должность");

            // If job is specified
            if (jobs.Find(job => job.Name.Equals(jobName)) != null)
            {
                // Check for unknown skills
                var requiredSkills = jobs.Find(job => jobName == job.Name).Skills;
                Reshuffle(requiredSkills);
                foreach (var skill in requiredSkills)
                    if (!_cv.IsSkillExists(skill))
                    {
                        Console.WriteLine($"Testing skill: {skill}");
                        var answer = "";
                        var result = NeuralNetwork.Analyze(skill, answer);
                        if (!result)
                        {
                            offeredJob = "Oops.. I can't get this job :(";
                            break;
                        }
                    }
            }
            else
            {
            }
        }

        void Reshuffle(string[] texts)
        {
            for (int t = 0; t < texts.Length; t++)
            {
                string tmp = texts[t];
                var random = new Random();
                int r = random.Next(t, texts.Length);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timer.Enabled = false;
                MessageBox.Show("Finished!");
            }
            else
            {
                progressBar.Invoke(new MethodInvoker(delegate { progressBar.PerformStep(); }));
            }
        }

        public Cv GetCv()
        {
            return _cv;
        }

        public string GetJobResult()
        {
            return offeredJob;
        }

        private void Experimenter_Load(object sender, EventArgs e)
        {
            ((Control) Application.OpenForms["MainForm"]).Hide();
        }

        private void Experimenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Control) Application.OpenForms["MainForm"]).Show(); 
        }
    }
}