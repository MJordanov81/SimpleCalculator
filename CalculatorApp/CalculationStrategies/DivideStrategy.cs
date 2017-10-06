namespace CalculatorApp.CalculationStrategies
{
    using Constants;

    public class DivideStrategy : CalculationStrategy
    {
        private const string Operation = Operations.Divide;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return numberOne / numberTwo;
        }
    }
}
