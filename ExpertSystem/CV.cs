using System.Collections.Generic;

namespace ExpertSystem
{
    public class Cv
    {
        private List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

        public int Count => data.Count;

        public void Add(string key, string value)
        {
            data.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}