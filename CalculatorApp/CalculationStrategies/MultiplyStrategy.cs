namespace CalculatorApp.CalculationStrategies
{
    using Constants;

    public class MultiplyStrategy : CalculationStrategy
    {
        private const string Operation = Operations.Multiply;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return numberOne * numberTwo;
        }
    }
}
