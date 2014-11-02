using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment36_ReversePolishCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ReversePolishCalculator rpCalculator;

        [TestInitialize]
        public void SetUp()
        {
            rpCalculator = new ReversePolishCalculator();
        }

        /// <summary>
        ///     test if "Given an empty or null string it should return the result 0"
        ///     without infix notation
        /// </summary>
        [TestMethod]
        public void TestNothingAndNull()
        {
            Assert.AreEqual(0d, rpCalculator.Calculate(""));
            Assert.AreEqual(0d, rpCalculator.Calculate(null));
        }

        /// <summary>
        ///     test "All implemented operations"
        ///     without infix notation
        /// </summary>
        [TestMethod]
        public void TestAllOperaters()
        {
            Assert.AreEqual(4d, rpCalculator.Calculate("2 2 +"));
            Assert.AreEqual(1d, rpCalculator.Calculate("3 2 -"));
            Assert.AreEqual(9d, rpCalculator.Calculate("3 3 *"));
            Assert.AreEqual(1d, rpCalculator.Calculate("3 3 /"));
            Assert.AreEqual(81d, rpCalculator.Calculate("3 4 ^"));
        }

        /// <summary>
        ///     test "Complex expressions, i.e. expressions with two, three, and four different operators"
        ///     without infix notation
        /// </summary>
        [TestMethod]
        public void TestComplexExpressions()
        {
            Assert.AreEqual(2d, rpCalculator.Calculate("2 2 + 2 -"));
            Assert.AreEqual(9d, rpCalculator.Calculate("3 2 - 2 + 3 *"));
            Assert.AreEqual(6d, rpCalculator.Calculate("3 3 * 5 2 - + 2 /"));
        }

        /// <summary>
        ///     test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        ///     without infix notation
        /// </summary>
        [TestMethod]
        public void TestShouldGive14()
        {
            Assert.AreEqual(14d, rpCalculator.Calculate("5 1 2 + 4 * + 3 -"));
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        ///     test if "Given an empty or null string it should return the result 0"
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestNothingAndNull()
        {
            Assert.AreEqual(0d, rpCalculator.InfixCalculate(""));
            Assert.AreEqual(0d, rpCalculator.InfixCalculate(null));
        }

        /// <summary>
        ///     test "All implemented operations"
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestAllOperaters()
        {
            Assert.AreEqual(4d, rpCalculator.InfixCalculate("2 + 2"));
            Assert.AreEqual(1d, rpCalculator.InfixCalculate("3 - 2"));
            Assert.AreEqual(9d, rpCalculator.InfixCalculate("3 * 3"));
            Assert.AreEqual(1d, rpCalculator.InfixCalculate("3 / 3"));
            Assert.AreEqual(81d, rpCalculator.InfixCalculate("3 ^ 4"));
        }

        /// <summary>
        ///     test "Complex expressions, i.e. expressions with two, three, and four different operators"
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestComplexExpressions()
        {
            Assert.AreEqual(2d, rpCalculator.InfixCalculate("( 2 + 2 ) - 2"));
            Assert.AreEqual(9d, rpCalculator.InfixCalculate("( ( 3 - 2 ) + 2 ) * 3"));
            Assert.AreEqual(6d, rpCalculator.InfixCalculate("( ( 3 * 3 ) + ( 5 - 2 ) ) / 2"));
        }

        /// <summary>
        ///     test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestShouldGive14()
        {
            Assert.AreEqual(14d, rpCalculator.InfixCalculate("( 5 + ( ( 1 + 2 ) * 4 ) ) - 3"));
        }

        /// <summary>
        ///     test if * comes before + and ^ is first
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestXBeforePlus()
        {
            Assert.AreEqual(7d, rpCalculator.InfixCalculate("1 + 2 * 3"));
            Assert.AreEqual(5d, rpCalculator.InfixCalculate("1 * 2 + 3"));
            Assert.AreEqual(33d, rpCalculator.InfixCalculate("5 + ( 1 + 2 * 3 ) * 4"));
        }

        /// <summary>
        ///     test if ^ comes before *
        ///     with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestPowBeforeX()
        {
            Assert.AreEqual(1d, rpCalculator.InfixCalculate("1 ^ 2 * 3"));
            Assert.AreEqual(8d, rpCalculator.InfixCalculate("1 * 2 ^ 3"));
        }

        /// <summary>
        ///     Test if a exception is thrown, given to few values
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (Exception),
            "The user has not input sufficient values in the expression.")]
        public void TestInsufficientValues()
        {
            Assert.AreEqual(double.NaN, rpCalculator.Calculate("2 +"));
        }

        /// <summary>
        ///     Test if a exception is thrown, given to many values
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "The user input has too many values.")]
        public void TestToManyValues()
        {
            Assert.AreEqual(double.NaN, rpCalculator.Calculate("2 2 2 +"));
        }

        /// <summary>
        ///     Test if a exception is thrown, without spacing
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "misformet input.")]
        public void InfixTestMisformetInput1()
        {
            Assert.AreEqual(double.NaN, rpCalculator.InfixCalculate("(2 + 2)"));
        }

        /// <summary>
        ///     Test if a exception is thrown, not given correct brackets
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "misformet input.")]
        public void InfixTestMisformetInput2()
        {
            Assert.AreEqual(double.NaN, rpCalculator.InfixCalculate("2 + 2 ) * 2 "));
        }

        /// <summary>
        ///     Test if a exception is thrown, given a unsupported operator
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "operator not supported, misformed expression!")]
        public void InfixTestOperatorNotSupported()
        {
            Assert.AreEqual(double.NaN, rpCalculator.InfixCalculate("2 % 2"));
        }



    }
}