using System;

namespace ExpertSystem
{
    public static class NeuralNetwork
    {
        private static readonly Random Random = new Random();

        public static bool Analyze(string skillName, string result)
        {
            
            return Random.Next(0,3) != 0;
        }
    }
}