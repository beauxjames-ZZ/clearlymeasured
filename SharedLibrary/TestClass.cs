using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedLibrary
{
    public class TestClass
    {
        public int UpperBound;
        public IList<KeyValuePair<int, string>> NumStrPairs;

        public TestClass(int upperBound)
        {
            UpperBound = upperBound;
            NumStrPairs = new List<KeyValuePair<int, string>>();
        }

        public TestClass(int upperBound, IList<KeyValuePair<int, string>> numStrPairs)
        {
            UpperBound = upperBound;
            NumStrPairs = numStrPairs;
        }

        public IEnumerable<string> ExpandMyMind()
        {
            for (int i = 1; i <= UpperBound; i++)
            {
                yield return CreateString(i);
            }
        }

        private string CreateString(int value)
        {
            var resArray = NumStrPairs == null
                ? new List<string>()
                : (from keyVal in NumStrPairs where value%keyVal.Key == 0 select keyVal.Value).ToList();
                
            if (resArray.Count == 0)
            {
                resArray.Add(value.ToString());
            }

            return String.Join(" ", resArray.ToArray());
        }

    }
}