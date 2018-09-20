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
            Assert.AreEqual("2", r.RPNProcess("1 1 +"));
            Assert.AreEqual("1", r.RPNProcess("3 2 -"));
            Assert.AreEqual("6", r.RPNProcess("3 2 X"));
            Assert.AreEqual("2", r.RPNProcess("4 2 ÷"));
            Assert.AreEqual("0", r.RPNProcess("1 -1 +"));
            Assert.AreEqual("5", r.RPNProcess("3 -2 -"));
            Assert.AreEqual("-1", r.RPNProcess("2 3 -"));
            Assert.AreEqual("-6", r.RPNProcess("3 -2 X"));
            Assert.AreEqual("-2", r.RPNProcess("-4 2 ÷"));
        }

        [TestMethod()]
        public void Process_Complex_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("8", r.RPNProcess("1 3 + 2 X"));
            Assert.AreEqual("5", r.RPNProcess("1 3 2 + X"));
            Assert.AreEqual("-5", r.RPNProcess("1 2 3 4 + - X"));
        }

        [TestMethod()]
        public void Process_Unary_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            Assert.AreEqual("1", r.RPNProcess("1 √"));
            Assert.AreEqual("2", r.RPNProcess("4 √"));
            Assert.AreEqual("3", r.RPNProcess("9 √"));
            Assert.AreEqual("6", r.RPNProcess("9 √ 9 √ +"));
            Assert.AreEqual("0", r.RPNProcess("4 √ 2 -"));
            Assert.AreEqual("0", r.RPNProcess("1 √ 1 + 2 -"));
            Assert.AreEqual("1", r.RPNProcess("1 1/x"));
            Assert.AreEqual("0.5", r.RPNProcess("2 1/x"));
            Assert.AreEqual("0.1", r.RPNProcess("10 1/x"));

        }

        [TestMethod()]
        public void Process_Error_Test()
        {
            RPNCalculatorEngine r = new RPNCalculatorEngine();
            // Assert.AreEqual("E", r.Process("1")); should be correct
            Assert.AreEqual("E", r.RPNProcess("1 +"));
            Assert.AreEqual("E", r.RPNProcess("1 + 1"));
            Assert.AreEqual("E", r.RPNProcess("1 1 1 +"));
            Assert.AreEqual("E", r.RPNProcess("+"));
            Assert.AreEqual("E", r.RPNProcess("+ 1"));
            Assert.AreEqual("E", r.RPNProcess("+ 1 1"));
            Assert.AreEqual("E", r.RPNProcess("1 1 1 + + +"));
        }
    }
}