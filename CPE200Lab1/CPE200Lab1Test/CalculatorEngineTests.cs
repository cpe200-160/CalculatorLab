using CPE200Lab1;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPE200Lab1.Tests
{
    [TestClass()]
    public class CalculatorEngineTest
    {
        //
        // Test process()
        //
        [TestMethod()]
        public void Process_BasicPlus_Test()
        {
            string input = "1 + 2";
            string expected = "3";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Process_BasicMinus_Test()
        {
            string input = "5 - 3";
            string expected = "2";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Process_BasicMultiply_Test()
        {
            string input = "5 X 3";
            string expected = "15";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Process_BasicDivide_Test()
        {
            string input = "6 ÷ 3";
            string expected = "2";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Process_ErrorDivideByZero_Test()
        {
            string input = "6 ÷ 0";
            string expected = "E";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Process_ErrorMalformate_Test()
        {
            string input = "1+2";
            string expected = "E";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate(input);
            Assert.AreEqual(expected, actual);
        }


        //
        // Test calculate()
        //
        [TestMethod()]
        public void Calculate_BasicPlus_Test()
        {
            string firstOperand = "1";
            string secondOperand = "2";
            string expected = "3";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("+", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicNegativePlus_Test()
        {
            string firstOperand = "-1";
            string secondOperand = "2";
            string expected = "1";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("+", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicMinus_Test()
        {
            string firstOperand = "2";
            string secondOperand = "1";
            string expected = "1";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("-", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicNegativeMinus_Test()
        {
            string firstOperand = "2";
            string secondOperand = "-1";
            string expected = "3";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("-", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        public void Calculate_BasicMinusNegative_Test()
        {
            string firstOperand = "1";
            string secondOperand = "2";
            string expected = "-1";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("-", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicMultiply_Test()
        {
            string firstOperand = "2";
            string secondOperand = "2";
            string expected = "4";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("X", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicNegativeMultiply_Test()
        {
            string firstOperand = "-2";
            string secondOperand = "2";
            string expected = "-4";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("X", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicDivide_Test()
        {
            string firstOperand = "4";
            string secondOperand = "2";
            string expected = "2";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("÷", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_BasicNegativeDivide_Test()
        {
            string firstOperand = "-4";
            string secondOperand = "2";
            string expected = "-2";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("÷", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Calculate_DivideByZero_Test()
        {
            string firstOperand = "4";
            string secondOperand = "0";
            string expected = "E";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("÷", firstOperand, secondOperand);
            Assert.AreEqual(expected, actual);
        }


        //
        // Test Unary()
        //
        [TestMethod()]
        public void UnaryCalculate_BasicSquareRoot_Test()
        {
            string operand = "4";
            string expected = "2";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("√", operand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UnaryCalculate_BasicOneOverX_Test()
        {
            string operand = "4";
            string expected = "0.25";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("1/x", operand);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UnaryCalculate_ErrorOneOverX_Test()
        {
            string operand = "0";
            string expected = "E";
            string actual;

            CalculatorEngine engine = new CalculatorEngine();
            actual = engine.calculate("1/x", operand);
            Assert.AreEqual(expected, actual);
        }
    }
}

