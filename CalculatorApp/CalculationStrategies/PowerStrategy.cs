namespace CalculatorApp.CalculationStrategies
{
    using System;
    using Constants;

    public class PowerStrategy : CalculationStrategy
    {
        private const string Operation = Operations.Power;

        public override decimal Calculate(decimal numberOne, decimal numberTwo)
        {
            return (decimal)Math.Pow((double) numberOne, (double) numberTwo);
        }
    }
}
