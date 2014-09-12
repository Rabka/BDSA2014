using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment37_ReversePolishCalculator.test
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
            RPC.InitOperations();

            Assert.AreEqual(0d, RPC.Calculation(""));
            Assert.AreEqual(0d, RPC.Calculation(null));
        }

        /// <summary>
        /// test "All implemented operations"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestAllOperaters()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(4d, RPC.Calculation("2 2 +"));
            Assert.AreEqual(1d, RPC.Calculation("3 2 -"));
            Assert.AreEqual(9d, RPC.Calculation("3 3 *"));
            Assert.AreEqual(1d, RPC.Calculation("3 3 /"));
            Assert.AreEqual(81d, RPC.Calculation("3 4 ^"));

            Assert.AreEqual(2d, RPC.Calculation("2 4 - abs"));
            Assert.AreEqual(3d, RPC.Calculation("9 sqrt"));
        }

        /// <summary>
        /// test "Complex expressions, i.e. expressions with two, three, and four different operators"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestComplexExpressions()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(2d, RPC.Calculation("2 2 + 2 -"));
            Assert.AreEqual(9d, RPC.Calculation("3 2 - 2 + 3 *"));
            Assert.AreEqual(6d, RPC.Calculation("3 3 * 5 2 - + 2 /"));
        }

        /// <summary>
        /// test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        /// without infix notation
        /// </summary>
        [TestMethod]
        public void TestShouldGive14()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(14d, RPC.Calculation("5 1 2 + 4 * + 3 -"));
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
            RPC.InitOperations();

            Assert.AreEqual(0d, RPC.InfixCalculation(""));
            Assert.AreEqual(0d, RPC.InfixCalculation(null));
        }

        /// <summary>
        /// test "All implemented operations"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestAllOperaters()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(4d, RPC.InfixCalculation("2 + 2"));
            Assert.AreEqual(1d, RPC.InfixCalculation("3 - 2"));
            Assert.AreEqual(9d, RPC.InfixCalculation("3 * 3"));
            Assert.AreEqual(1d, RPC.InfixCalculation("3 / 3"));
            Assert.AreEqual(81d, RPC.InfixCalculation("3 ^ 4"));

            Assert.AreEqual(2d, RPC.InfixCalculation("abs ( 2 - 4 )"));
            Assert.AreEqual(3d, RPC.InfixCalculation("sqrt ( 9 )"));
        }

        /// <summary>
        /// test "Complex expressions, i.e. expressions with two, three, and four different operators"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestComplexExpressions()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(2d, RPC.InfixCalculation("( 2 + 2 ) - 2"));
            Assert.AreEqual(9d, RPC.InfixCalculation("( ( 3 - 2 ) + 2 ) * 3"));
            Assert.AreEqual(6d, RPC.InfixCalculation("( ( 3 * 3 ) + ( 5 - 2 ) ) / 2"));
        }

        /// <summary>
        /// test "The input “5 1 2 + 4 * + 3 -” should give 14 as result"
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestShouldGive14()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(14d, RPC.InfixCalculation("( 5 + ( ( 1 + 2 ) * 4 ) ) - 3"));
        }

        /// <summary>
        /// test if * comes before + and ^ is first
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestXBeforePlus()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(7d, RPC.InfixCalculation("1 + 2 * 3"));
            Assert.AreEqual(5d, RPC.InfixCalculation("1 * 2 + 3"));
            Assert.AreEqual(33d, RPC.InfixCalculation("5 + ( 1 + 2 * 3 ) * 4"));
        }

        /// <summary>
        /// test if ^ comes before *
        /// with infix notation
        /// </summary>
        [TestMethod]
        public void InfixTestPowBeforeX()
        {
            var RPC = new ReversePolishCalculator();
            RPC.InitOperations();

            Assert.AreEqual(1d, RPC.InfixCalculation("1 ^ 2 * 3"));
            Assert.AreEqual(8d, RPC.InfixCalculation("1 * 2 ^ 3"));
        }
    }
}
