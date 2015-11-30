using System.Collections.Generic;
using SharedLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValuePair<int, string>[] fooList =
            {
                new KeyValuePair<int, string>(3, "monkey"),
                new KeyValuePair<int, string>(6, "banana"),
                new KeyValuePair<int, string>(10, "aphid")
            };

            var testClass = new TestClass(4096, fooList);

            foreach (var num in testClass.ExpandMyMind())
            {
                System.Console.WriteLine(num);
            }
            
            System.Console.ReadKey();
        }
    }
}

// Unit tests to prove the '15' case -- ensure it never breaks
// Tests to ensure stability over time

// pass in their own word/number pairs 

// EC -- add a build script and set up Git Src Control in a way that a team could work in a continuous integration env. 
// post on Git and send to Rayne

