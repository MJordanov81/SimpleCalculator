namespace CalculatorApp.CalculationStrategies
{
    using Constants;

    public class SumStrategy : CalculationStrategy
    {
        private const string Operation = Operations.Sum;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return numberOne + numberTwo;
        }
    }
}
