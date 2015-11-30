using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLibrary;

namespace EarthShatteringTests
{
    [TestClass]
    public class EarthShatteringTestNumeroUno
    {
        [TestMethod]
        public void test_the_persistence_of_fifteen ()
        {
            var testClass = new TestClass(14);

            var testList = testClass.ExpandMyMind().ToList();
            Assert.IsTrue(testList.Count < 15, "there should be LT 15 elements if the upper bound is LT 15");

            testClass.UpperBound = 15;
            testList = testClass.ExpandMyMind().ToList();
            Assert.IsTrue(testList.Count == 15 && testList.Last() == "15", "there should be 15 elements and the last element should be 15 if the upper bound EQ 15");

            testClass.UpperBound = 20;
            testList = testClass.ExpandMyMind().ToList();
            Assert.IsTrue(testList.Count > 15, "there should be GT 15 elements if the upper bound is GT 15");

            testClass.NumStrPairs = new List<KeyValuePair<int, string>> {new KeyValuePair<int, string>(3, "foo")};
            testList = testClass.ExpandMyMind().ToList();
            Assert.AreEqual("foo", testList[14], "value at 15 mod 3 Should equal foo");

            testClass.NumStrPairs = new List<KeyValuePair<int, string>> {new KeyValuePair<int, string>(5, "bar")};
            testList = testClass.ExpandMyMind().ToList();
            Assert.AreEqual("bar", testList[14], "value at 15 mod 5 Should equal bar");

            testClass.NumStrPairs = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(3, "foo"),
                new KeyValuePair<int, string>(5, "bar")
            };
            testList = testClass.ExpandMyMind().ToList();
            Assert.AreEqual("foo bar", testList[14], "value at 15 mod 3 Should equal foo bar");
        }

        [TestMethod]
        public void test_stability_over_time()
        {
            var testClass = new TestClass(4096);

            var foo = testClass.ExpandMyMind().ToList();


        }
    }
}
