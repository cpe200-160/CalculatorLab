using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPE200Lab1;

namespace CPE200Lab1Test
{
    [TestClass]
    public class RPNCalculatorEngineTest
    {
        RPNCalculatorEngine engine = new RPNCalculatorEngine();

        [TestMethod]
        public void ConstructorTest()
        {
            RPNCalculatorEngine engine = new RPNCalculatorEngine();
            Assert.IsNotNull(engine);
            Assert.IsInstanceOfType(engine, typeof(RPNCalculatorEngine));
        }

        [TestMethod]
        public void EmptyArgumentTest()
        {
            RPNCalculatorEngine engine = new RPNCalculatorEngine();
        }
    }
}
