using System;

namespace ExpertSystem
{
    public static class NeuralNetwork
    {
        public static bool Analyze(string skillName, string result)
        {
            var random = new Random();
            return random.Next(0, 1) == 0;
        }
    }
}