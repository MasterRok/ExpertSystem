using System.Collections;
using System.Collections.Generic;

namespace ExpertSystem
{
    public class Cv : IEnumerable<KeyValuePair<string, string>>, IEnumerable
    {
        private List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

        public int Count => data.Count;

        public void Add(string key, string value)
        {
            data.Add(new KeyValuePair<string, string>(key, value));
        }

        public string FindValueByKey(string key)
        {
            return data.Find(obj => obj.Key == key && obj.Key != "Навык").Value;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool IsValueExists(string key)
        {
            return data.Exists(pair => pair.Key == key && pair.Key != "Навык");
        }

        public bool IsSkillExists(string skill)
        {
            return data.Exists(pair => pair.Key == "Навык" && pair.Value == skill);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public Cv FilterValues()
        {
            var filteredCv = new Cv();
            foreach (var row in data)
                if ((row.Value != null && !row.Value.Trim().Equals("")))
                    filteredCv.Add(row.Key, row.Value);

            return filteredCv;
        }
    }
}