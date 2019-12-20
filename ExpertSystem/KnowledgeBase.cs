using System;
using System.IO;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Parsing;
using ExpertSystem.Properties;
namespace ExpertSystem
{
    public static class KnowledgeBase
    {
        public readonly static Graph MyGraph = new Graph();

        static KnowledgeBase()
        {
            Console.WriteLine(Application.StartupPath);
            FileLoader.Load(MyGraph, Resources.KnowledgeBaseFileName);
        }
    }
}