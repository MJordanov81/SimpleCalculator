namespace CalculatorApp.CalculationStrategies.Contracts
{
    public interface ICalculationStrategy
    {
        decimal Calculate(decimal numberOne, decimal numberTwo);
    }
}
