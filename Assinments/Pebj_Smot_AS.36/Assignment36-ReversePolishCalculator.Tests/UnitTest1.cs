using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment36_ReversePolishCalculator;

namespace Assignment36_ReversePolishCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test if "Given an empty or null string it should return the result 0"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestNothingAndNull()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(0d, RPC.Calculate(""));
            Assert.AreEqual(0d, RPC.Calculate(null));
        }

        /// <summary>
        /// test "All implemented operations"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestAllOperaters()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(4d, RPC.Calculate("2 2 +"));
            Assert.AreEqual(1d, RPC.Calculate("3 2 -"));
            Assert.AreEqual(9d, RPC.Calculate("3 3 *"));
            Assert.AreEqual(1d, RPC.Calculate("3 3 /"));
            Assert.AreEqual(81d, RPC.Calculate("3 4 ^"));
        }

        /// <summary>
        /// test "Complex expressions, i.e. expressions with two, three, and four different operators"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestComplexExpressions()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(2d, RPC.Calculate("2 2 + 2 -"));
            Assert.AreEqual(9d, RPC.Calculate("3 2 - 2 + 3 *"));
            Assert.AreEqual(6d, RPC.Calculate("3 3 * 5 2 - + 2 /"));
        }

        /// <summary>
        /// test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestShouldGive14()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(14d, RPC.Calculate("5 1 2 + 4 * + 3 -"));
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// test if "Given an empty or null string it should return the result 0"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestNothingAndNull()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(0d, RPC.InfixCalculate(""));
            Assert.AreEqual(0d, RPC.InfixCalculate(null));
        }

        /// <summary>
        /// test "All implemented operations"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestAllOperaters()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(4d, RPC.InfixCalculate("2 + 2"));
            Assert.AreEqual(1d, RPC.InfixCalculate("3 - 2"));
            Assert.AreEqual(9d, RPC.InfixCalculate("3 * 3"));
            Assert.AreEqual(1d, RPC.InfixCalculate("3 / 3"));
            Assert.AreEqual(81d, RPC.InfixCalculate("3 ^ 4"));
        }

        /// <summary>
        /// test "Complex expressions, i.e. expressions with two, three, and four different operators"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestComplexExpressions()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(2d, RPC.InfixCalculate("( 2 + 2 ) - 2"));
            Assert.AreEqual(9d, RPC.InfixCalculate("( ( 3 - 2 ) + 2 ) * 3"));
            Assert.AreEqual(6d, RPC.InfixCalculate("( ( 3 * 3 ) + ( 5 - 2 ) ) / 2"));
        }

        /// <summary>
        /// test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestShouldGive14()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(14d, RPC.InfixCalculate("( 5 + ( ( 1 + 2 ) * 4 ) ) - 3"));
        }

        /// <summary>
        /// test if * comes before + and ^ is first
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestXBeforePlus()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(7d, RPC.InfixCalculate("1 + 2 * 3"));
            Assert.AreEqual(5d, RPC.InfixCalculate("1 * 2 + 3"));
            Assert.AreEqual(33d, RPC.InfixCalculate("5 + ( 1 + 2 * 3 ) * 4"));
        }

        /// <summary>
        /// test if ^ comes before *
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestPowBeforeX()
        {
            var RPC = new ReversePolishCalculator();

            Assert.AreEqual(1d, RPC.InfixCalculate("1 ^ 2 * 3"));
            Assert.AreEqual(8d, RPC.InfixCalculate("1 * 2 ^ 3"));
        }
    }
}
