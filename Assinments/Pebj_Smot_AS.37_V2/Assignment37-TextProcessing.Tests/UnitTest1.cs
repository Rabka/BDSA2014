using NUnit.Framework;

namespace Assignment37_TextProcessing.Tests
{
    /// <summary>
    /// Unit Test for the class TextProcessing.
    /// </summary>
    public class UnitTest1
    {
        private TextProcessing TP;

        [SetUp]
        public void SetUp()
        {
            TP = new TextProcessing();
        }

        [TestCase(true, "http://ererer")]
        [TestCase(true, "C://på.min_pc")]
        [TestCase(true, "jaiguadugfhusdgugk://asfafs.asfasfasf;asfasfafs:asfasfafsf,asfasfafw*afawfawfawf'awfawfawf")]
        [TestCase(true, "Test://test://test")]
        [TestCase(false, "://")]
        [TestCase(false, "ikkeEnUml")]
        [TestCase(false, "Liner//:EnUMl")]
        [TestCase(false, "almost:/AnUml")]
        [TestCase(false, "almost://An Uml")]
        [TestCase(false, "alm ost://AnUml")]
        public void TestUrlRegex(bool b, string s)
        {
            Assert.AreEqual(b,TP.RegexUrlTest(s));
        }

        [TestCase(true, "test", "test")]
        [TestCase(false, "test", "tes")]
        [TestCase(false, "test", "tests")]
        [TestCase(false, "test", "test test")]
        [TestCase(true, "*t", "test")]
        [TestCase(true, "*t", "t")]
        [TestCase(false, "*t", "testfail")]
        [TestCase(false, "*t", "fail test")]
        [TestCase(true, "t*", "test")]
        [TestCase(true, "t*", "t")]
        [TestCase(false, "t*", "failtest")]
        [TestCase(false, "*t", "test fail")]
        [TestCase(true, "*t*", "estes")]
        [TestCase(true, "*t*", "estwqrwrqwres")]
        [TestCase(true, "*t*", "t")]
        [TestCase(true, "*t*", "ttttt")]
        [TestCase(false, "*t*", "ttt ttt")]
        [TestCase(false, "*t*", "abc")]
        [TestCase(false, "t*", "abc")]
        [TestCase(true, "t+t", "t t")]
        [TestCase(true, "test+test", "test test")]
        [TestCase(false, "test+test", "test test test")]
        [TestCase(false, "test+test", "test")]
        [TestCase(false, "test+test", "tests test")]
        [TestCase(true, "a+t*", "a test")]
        [TestCase(true, "a+t*+a+t*", "a test a test")]
        [TestCase(false, "a+t*+a+t*", "a test")]
        [TestCase(true, "a+t*+t*+*o", "a test times two")]
        [TestCase(false, "a+t*+t*+*o", "a test times over")]
        [TestCase(true, "a+t*+t*+*o+w*+*r*", "a test times two with more")]
        [TestCase(false, "a+t*+t*+*o+w*+*r*", "a test times two with more fail")]
        [TestCase(false, "a+t*+t*+*o+w*+*r*", "fail a test times two with more")]
        public void TestInputRegex(bool b, string testRegex, string testText)
        {
            TP.SetRegexInput(testRegex);
            Assert.AreEqual(b, TP.RegexInputTest(testText));
        }

        [TestCase(true, "12 aug 2013")]
        [TestCase(true, "sun, 12 aug 2013")]
        [TestCase(true, "sun 12 aug 2013")]
        [TestCase(true, "man, 1 aug 2013")]
        [TestCase(true, "man 1 aug 2013")]
        [TestCase(true, "24 12 2013")]
        [TestCase(true, "tir, 24 12 2013")]
        [TestCase(true, "tir 24 12 2013")]
        [TestCase(true, "2 12 2013")]
        [TestCase(true, "fri, 2 12 2013")]
        [TestCase(true, "fri 2 12 2013")]
        [TestCase(false, "12 aug 201")]
        [TestCase(false, "122 aug 2301")]
        [TestCase(false, "aug 2301")]
        [TestCase(false, "213 aug")]
        [TestCase(false, "23 aug 13")]
        [TestCase(false, "02-11-2014")]
        [TestCase(false, "02:11:2014")]
        public void TestDateRegex(bool b, string s)
        {
            Assert.AreEqual(b, TP.RegexDateTest(s));
        }
    }
}
