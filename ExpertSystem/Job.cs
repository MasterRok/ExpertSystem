using System.Collections;
using Microsoft.Office.Interop.Excel;

namespace ExpertSystem
{
    public class Job
    {
        public Job(string name, string[] skills)
        {
            Skills = skills;
            Name = name;
        }

        private string Name { get; }
        private string[] Skills { get; }
    }
}