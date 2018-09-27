using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPE200Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1.Tests
{
    [TestClass()]
    public class RPNCalculatorEngineTests
    {
        [TestMethod()]
        public void Process_Basic_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("2", r.Process("1 1 +"));
            Assert.AreEqual("1", r.Process("3 2 -"));
            Assert.AreEqual("6", r.Process("3 2 X"));
            Assert.AreEqual("2", r.Process("4 2 ÷"));
            Assert.AreEqual("0", r.Process("1 -1 +"));
            Assert.AreEqual("5", r.Process("3 -2 -"));
            Assert.AreEqual("-1", r.Process("2 3 -"));
            Assert.AreEqual("-6", r.Process("3 -2 X"));
            Assert.AreEqual("-2", r.Process("-4 2 ÷"));
        }

        [TestMethod()]
        public void Process_Complex_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("8", r.Process("1 3 + 2 X"));
            Assert.AreEqual("5", r.Process("1 3 2 + X"));
            Assert.AreEqual("-5", r.Process("1 2 3 4 + - X"));
        }

        [TestMethod()]
        public void Process_Unary_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("1", r.Process("1 √"));
            Assert.AreEqual("2", r.Process("4 √"));
            Assert.AreEqual("3", r.Process("9 √"));
            Assert.AreEqual("6", r.Process("9 √ 9 √ +"));
            Assert.AreEqual("0", r.Process("4 √ 2 -"));
            Assert.AreEqual("0", r.Process("1 √ 1 + 2 -"));
            Assert.AreEqual("1", r.Process("1 1/x"));
            Assert.AreEqual("0.5", r.Process("2 1/x"));
            Assert.AreEqual("0.1", r.Process("10 1/x"));

        }

        /*[TestMethod()]
        public void Process_Percent_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("110", r.RPNProcess("100 10 % +"));
            Assert.AreEqual("240", r.RPNProcess("200 20 % +"));
            Assert.AreEqual("210", r.RPNProcess("300 30 % -"));
        }*/

        [TestMethod()]
        public void Process_Error_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            // Assert.AreEqual("E", r.Process("1")); should be correct
            Assert.AreEqual("E", r.Process("1 +"));
            Assert.AreEqual("E", r.Process("1 + 1"));
            Assert.AreEqual("E", r.Process("1 1 1 +"));
            Assert.AreEqual("E", r.Process("+"));
            Assert.AreEqual("E", r.Process("+ 1"));
            Assert.AreEqual("E", r.Process("+ 1 1"));
            Assert.AreEqual("E", r.Process("1 1 1 + + +"));
        }
    }
}