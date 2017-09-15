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
        RPNCalculatorEngine engine;

        [TestInitialize()]
        public void Initialize()
        {
            engine = new RPNCalculatorEngine();
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            Assert.IsNotNull(engine);
            Assert.IsInstanceOfType(engine, typeof(RPNCalculatorEngine));
        }

        [TestMethod()]
        public void EmptyArgumentTest()
        {
            Assert.AreEqual("E", engine.Process(null));
            Assert.AreEqual("E", engine.Process(""));
        }

        [TestMethod()]
        public void BasicCalcuationOneTest()
        {
            Assert.AreEqual("0", engine.Process("0"));

            Assert.AreEqual("2", engine.Process("1 1 + "));
            Assert.AreEqual("0", engine.Process("1 1 - "));
            Assert.AreEqual("1", engine.Process("1 1 X "));
            Assert.AreEqual("1", engine.Process("1 1 ÷ "));
        }

        [TestMethod()]
        public void BasicCalcuationTwoTest()
        {
            Assert.AreEqual("10", engine.Process("5 5 + "));
            Assert.AreEqual("10", engine.Process("20 10 - "));
            Assert.AreEqual("10", engine.Process("5 2 X "));
            Assert.AreEqual("10", engine.Process("10 1 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationThreeTest()
        {
            Assert.AreEqual("20", engine.Process("10 10 + "));
            Assert.AreEqual("-10", engine.Process("10 20 - "));
            Assert.AreEqual("100", engine.Process("10 10 X "));
            Assert.AreEqual("10", engine.Process("100 10 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationFourTest()
        {
            Assert.AreEqual("-1", engine.Process("1 2 - "));
            Assert.AreEqual("-1", engine.Process("-1 1 X "));
            Assert.AreEqual("-1", engine.Process("1 -1 X "));
            Assert.AreEqual("-1", engine.Process("1 -1 ÷"));
            Assert.AreEqual("-1", engine.Process("-1 1 ÷"));
        }

        [TestMethod()]
        public void BasicCalcuationFiveTest()
        {
            Assert.AreEqual("0.5", engine.Process("1 2 ÷"));
            Assert.AreEqual("0.3333", engine.Process("1 3 ÷"));
            Assert.AreEqual("0.25", engine.Process("1 4 ÷"));
            Assert.AreEqual("0.1667", engine.Process("1 6 ÷"));
            Assert.AreEqual("0.125", engine.Process("1 8 ÷"));
        }

        [TestMethod()]
        public void ComplexCalcuationTest()
        {
            Assert.AreEqual("3", engine.Process("1 1 1 + + "));
            Assert.AreEqual("-1", engine.Process("1 1 1 + - "));
            Assert.AreEqual("1", engine.Process("1 1 1 - + "));
            Assert.AreEqual("1", engine.Process("1 1 1 - - "));
            Assert.AreEqual("6", engine.Process("2 2 2 X + "));
            Assert.AreEqual("8", engine.Process("2 2 2 + X "));
            Assert.AreEqual("0.5", engine.Process("2 2 2 + ÷"));
            Assert.AreEqual("3", engine.Process("2 2 2 ÷ +"));
        }

        [TestMethod()]
        public void DividedByZeroTest()
        {
            Assert.AreEqual("E", engine.Process("0 0 ÷ "));
            Assert.AreEqual("E", engine.Process("1 0 ÷ "));
            Assert.AreEqual("E", engine.Process("1 2 2 - ÷ "));
        }

        [TestMethod()]
        public void InvalideFormatTest()
        {
            Assert.AreEqual("E", engine.Process("+"));
            Assert.AreEqual("E", engine.Process("1+"));
            Assert.AreEqual("E", engine.Process("+1"));
            Assert.AreEqual("E", engine.Process("1 +"));
            Assert.AreEqual("E", engine.Process("+ 1"));
            Assert.AreEqual("E", engine.Process("1 1"));
            Assert.AreEqual("E", engine.Process("+ 1 1"));
            Assert.AreEqual("E", engine.Process("1 1 ++"));
            Assert.AreEqual("E", engine.Process("1 1 + +"));
            Assert.AreEqual("E", engine.Process("1 1 ++ +"));
            Assert.AreEqual("E", engine.Process("1 1 + + +"));
            Assert.AreEqual("E", engine.Process("1 1 1 + "));
            Assert.AreEqual("E", engine.Process("1 1 1 + "));
        }
    }
}