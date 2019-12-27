using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Parsing;
using ExpertSystem.Properties;
using Newtonsoft.Json.Linq;

namespace ExpertSystem
{
    public static class KnowledgeBase
    {
        private static Graph MyGraph = new Graph();

        static KnowledgeBase()
        {
            System.Diagnostics.Debug.WriteLine(Application.StartupPath);
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

            using (var r = new StreamReader(Resources.TranslationFileName))
            {
                var json = r.ReadToEnd();
                var jObject = JObject.Parse(json);
                    
                foreach (var roleTriple in roleTriples)
                {
                    var jobName = GetNodeNameLocal(roleTriple.Subject);
                    var skillTriplesEnumerator = MyGraph.GetTriplesWithPredicateObject(
                        MyGraph.CreateUriNode("pred:inOrderTo"), MyGraph.GetUriNode($"po:{jobName}"));

                    jobName = jObject.SelectToken($"$.jobs.{jobName}").ToString();
                    var jobSkills = new List<string>();
                    foreach (var skillTriple in skillTriplesEnumerator)
                    {
                        jobSkills.Add(jObject.SelectToken($"$.skills.{GetNodeNameLocal(skillTriple.Subject)}").ToString());
                    }

                    jobs.Add(new Job(jobName, jobSkills.ToArray()));
                }
            }

            return jobs;
        }
    }
}