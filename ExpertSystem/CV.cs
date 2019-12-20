using System.Collections;
using System.Collections.Generic;

namespace ExpertSystem
{
    public class Cv: IEnumerable<KeyValuePair<string, string>>, IEnumerable
    {
        private List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

        public int Count => data.Count;

        public void Add(string key, string value)
        {
            data.Add(new KeyValuePair<string, string>(key, value));
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}