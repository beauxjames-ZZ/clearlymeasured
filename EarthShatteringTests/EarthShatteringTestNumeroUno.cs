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

            testClass.PrintNumbers();
            Assert.IsTrue(testClass.ResultList.Count < 15, "there should be LT 15 elements if the upper bound is LT 15");

            testClass.ResetUpperBound(15);
            Assert.IsTrue(testClass.ResultList.Count == 15 && testClass.ResultList.Last() == "15", "there should be 15 elements and the last element should be 15 if the upper bound EQ 15");

            testClass.ResetUpperBound(20);
            Assert.IsTrue(testClass.ResultList.Count > 15, "there should be GT 15 elements if the upper bound is GT 15");

            testClass.ResetNumStrPairs(new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(3, "foo") });
            Assert.AreEqual("foo", testClass.ResultList[14], "value at 15 mod 3 Should equal foo");

            testClass.ResetNumStrPairs(new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(5, "bar") });
            Assert.AreEqual("bar", testClass.ResultList[14], "value at 15 mod 5 Should equal bar");

            testClass.ResetNumStrPairs(new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(3, "foo"),
                new KeyValuePair<int, string>(5, "bar")
            });
            Assert.AreEqual("foo bar", testClass.ResultList[14], "value at 15 mod 3 Should equal foo bar");
        }

        [TestMethod]
        public void test_stability_over_time()
        {
            var testClass = new TestClass(4096);

            testClass.PrintNumbers();
        }
    }
}
