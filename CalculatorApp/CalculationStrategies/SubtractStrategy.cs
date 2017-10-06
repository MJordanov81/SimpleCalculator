namespace CalculatorApp.CalculationStrategies
{
    using Constants;

    public class SubtractStrategy : CalculationStrategy
    {
        private const string Operation = Operations.Substract;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return numberOne - numberTwo;
        }
    }
}
