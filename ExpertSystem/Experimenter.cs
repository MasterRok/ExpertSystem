using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!_cv.IsValueExists("Имя"))
            {
                var names = new[] {"Андрей", "Игорь", "Анатолий", "Вячеслав", "Никита", "Николай", "Кирилл"};
                Random rand = new Random();
                _cv.UpdateValue("Имя", names[rand.Next(names.Length)]);
            }

            if (!_cv.IsValueExists("Фамилия"))
            {
                var surnames = new[] {"Смирнов", "Родионов", "Соловьёв", "Комаров", "Семёнов", "Самойлов", "Веселов"};
                Random rand = new Random();
                _cv.UpdateValue("Фамилия", surnames[rand.Next(surnames.Length)]);
            }

            // If job is specified
            if (jobs.Find(job => job.Name.Equals(jobName)) != null)
            {
                // Check for unknown skills
                var requiredSkills = jobs.Find(job => jobName == job.Name).Skills;
                Reshuffle(requiredSkills);
                offeredJob = jobName;
                foreach (var skill in requiredSkills)
                    if (!_cv.IsSkillExists(skill))
                    {
                        var answer = "";
                        var result = NeuralNetwork.Analyze(skill, answer);
                        System.Diagnostics.Debug.WriteLine($"Тестируем навык:\t{skill}:\t{result}");

                        if (!result)
                        {
                            offeredJob = "Упс.. Вы не получили работу :(";
                            break;
                        }
                    }
            }
            else
            {
                var skillsList = new List<string>();
                foreach (var job in jobs)
                {
                    foreach (var skill in job.Skills)
                        skillsList.Add(skill);
                }

                skillsList = new List<string>(skillsList.Distinct());
                Reshuffle(skillsList);

                bool canGetJob = false;
                foreach (var skill in skillsList)
                {
                    var answer = "";
                    var result = NeuralNetwork.Analyze(skill, answer);
                    System.Diagnostics.Debug.WriteLine($"Тестируем навык:\t{skill}:\t{result}");
                    if (result)
                    {
                        _cv.Add("Навык", skill);
                        foreach (var job in jobs)
                        {
                            bool isEnough = true;
                            // Check if enough skills for any job
                            var requiredSkills = jobs.Find(j => job.Name == j.Name).Skills;
                            foreach (var s in requiredSkills)
                                if (!_cv.IsSkillExists(s))
                                    isEnough = false;
                            canGetJob = isEnough;
                            if (isEnough)
                            {
                                offeredJob = job.Name;
                                break;
                            }
                        }

                        if (canGetJob) break;
                    }
                }
                if (!canGetJob)
                {
                    offeredJob = "Упс.. Вы не получили работу :(";
                }
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

        void Reshuffle(List<string> texts)
        {
            for (int t = 0; t < texts.Count; t++)
            {
                string tmp = texts[t];
                var random = new Random();
                int r = random.Next(t, texts.Count);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timer.Enabled = false;
                MessageBox.Show("Готово! Закройте окно.");
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