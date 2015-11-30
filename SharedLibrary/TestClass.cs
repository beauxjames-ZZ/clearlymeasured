using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace SharedLibrary
{
    public class TestClass
    {
        private bool _isComplete;

        public bool IsComplete => _isComplete;

        public int UpperBound;
        public IList<KeyValuePair<int, string>> NumStrPairs;

        public IList<string> ResultList { get; private set; }

        public TestClass(int upperBound)
        {
            _isComplete = false;
            UpperBound = upperBound;
            NumStrPairs = new List<KeyValuePair<int, string>>();
            ResultList = new List<string>();    
        }

        public TestClass(int upperBound, IList<KeyValuePair<int, string>> numStrPairs)
        {
            UpperBound = upperBound;
            NumStrPairs = numStrPairs;
            _isComplete = false;
            ResultList = new List<string>();
        }
        public void AsyncPrintNumbers()
        {
            var thread = new Thread(PrintNumbers);
            thread.Start();
        }

        public void PrintNumbers()
        {
            /*for (int i = 1; i <= UpperBound; i++)
            {
                lock (ResultList)
                {
                    ResultList.Add(CreateString(i));
                }
            }*/

            string[] items;
            lock (ResultList) items = ResultList.ToArray();
            for (int i = 1; i <= UpperBound; i++)
            {
                ResultList.Add(CreateString(i));
                //Console.WriteLine(CreateString(i));
            }
            _isComplete = true;
        }

        public void ResetUpperBound(int newUpperBound)
        {
            UpperBound = newUpperBound;
            PrintNumbers();
        }

        public void ResetNumStrPairs(IList<KeyValuePair<int, string>> newNumStrPairs)
        {
            NumStrPairs = newNumStrPairs;
            PrintNumbers();
        }

        public void ResetAll(int newUpperBound, IList<KeyValuePair<int, string>> newNumStrPairs)
        {
            UpperBound = newUpperBound;
            NumStrPairs = newNumStrPairs;
            PrintNumbers();
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