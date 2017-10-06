namespace CalculatorApp.Constants
{
    using CalculatorApp.CalculationStrategies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class CalculationStrategies
    {
        public static Dictionary<string, Type> Strategies = new Dictionary<string, Type>();

        public static void GetStrategies()
        {
            Type[] types = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(t => t.GetTypeInfo().IsSubclassOf(typeof(CalculationStrategy)))
                .ToArray();

            foreach (Type strategy in types)
            {
                string operation = (string) strategy
                    .GetFields(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance)
                    .FirstOrDefault(f => f.Name == "Operation")?
                    .GetValue(null);


                Strategies.Add(operation, strategy);
            }
        }
    }
}
