using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CombineStrings;

namespace CombineStringsTest {

    [TestClass]
    public class CombineStringsTest
    {
        const char separator = ',';


        //Test main function with correct input
        [TestMethod]
        public void Maintest()
        {
            string[] fragments = new string[] { "Main", "test", "here" };
            string expected = "Main,test,here";
            string tester = CombineStrings.Combiner.Combine(separator, fragments);
            Assert.AreEqual(expected, tester);
        }

        //Test default constructor
        [TestMethod]
        public void defaulttest()
        {
            Combiner defaulttest = new Combiner();
            string finalstring = defaulttest.GetCombination();
            Assert.AreEqual("This-is-default", finalstring);
        }

        [TestMethod]
        [Owner("Chase")]
        [TestCategory("NULLs")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void separatornull()
        {
            char separator = '\0';
            string[] fragments = new string[] { "Dont", "pass", "this" };
            string tester = CombineStrings.Combiner.Combine(separator, fragments);
            Assert.Fail("Exception was not thrown");
        }

        [TestMethod]
        [Owner("Chase")]
        [TestCategory("NULLs")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void listofstringsnull()
        {
            string[] fragments = null;
            string tester = CombineStrings.Combiner.Combine(separator, fragments);
            Assert.Fail("Exception was not thrown");
        }
    }
}
