using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Parsing;
using ExpertSystem.Properties;

namespace ExpertSystem
{
    public static class KnowledgeBase
    {
        private static Graph MyGraph = new Graph();

        static KnowledgeBase()
        {
            Console.WriteLine(Application.StartupPath);
            FileLoader.Load(MyGraph, Resources.KnowledgeBaseFileName);
        }

        private static string GetNodeNameLocal(INode node)
        {
            return Regex.Replace(node.ToString(), @"((\w)+:){2}", "");
        }

        public static List<Job> GetJobs()
        {
            var jobs = new List<Job>();

            var roleTriples = MyGraph.GetTriplesWithPredicateObject(
                MyGraph.CreateUriNode("rdf:type"), MyGraph.GetUriNode("pc:role"));

            foreach (var roleTriple in roleTriples)
            {
                var jobName = GetNodeNameLocal(roleTriple.Subject);
                var skillTriplesEnumerator = MyGraph.GetTriplesWithPredicateObject(
                    MyGraph.CreateUriNode("pred:inOrderTo"), MyGraph.GetUriNode($"po:{jobName}"));

                var jobSkills = new List<string>();
                foreach (var skillTriple in skillTriplesEnumerator)
                    jobSkills.Add(GetNodeNameLocal(skillTriple.Subject));
                jobs.Add(new Job(jobName, jobSkills.ToArray()));
            }

            return jobs;
        }
    }
}