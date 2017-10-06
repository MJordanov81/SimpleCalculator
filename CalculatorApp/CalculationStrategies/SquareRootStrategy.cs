namespace CalculatorApp.CalculationStrategies
{
    using System;
    using Constants;

    public class SquareRootStrategy : CalculationStrategy
    {
        private const string Operation = Operations.SquareRoot;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return (decimal) Math.Sqrt((double) numberOne);
        }
    }
}
