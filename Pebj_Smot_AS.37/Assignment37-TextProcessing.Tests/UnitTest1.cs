using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment37_TextProcessing.Tests
{
    /// <summary>
    /// Unit Test for the class TextProcessing.
    /// We do not know how if the program Writes in the right color in thr console.
    /// Not even how to test if writes in teh console.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test if the program does not fail.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string[] sa = {"in"};
            TextProcessing.Main(sa);
            Assert.IsTrue(true);
        }
    }
}
