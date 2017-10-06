namespace CalculatorApp.CalculationStrategies
{
    using Contracts;

    public abstract class CalculationStrategy : ICalculationStrategy
    {
        public abstract decimal Calculate(decimal numberOne, decimal numberTwo);
    }
}
