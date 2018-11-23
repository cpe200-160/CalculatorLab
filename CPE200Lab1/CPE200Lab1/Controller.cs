namespace CPE200Lab1
{
    public class Controller
    {
        CalculatorEngine engine1;
        RPNCalculatorEngine engine2;

        public Controller()
        {
            engine1 = new CalculatorEngine();
            engine2 = new RPNCalculatorEngine();
        }
        public string Calculate(string str)
        {
            return engine1.Process(str);
        }
        public string RPNcalculate(string str)
        {
            return engine2.Process(str);
        }

    }
}