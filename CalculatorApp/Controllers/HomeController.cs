namespace CalculatorApp.Controllers
{
    using CalculationStrategies;
    using MyWebServer.Server.Enums;
    using MyWebServer.Server.HTTP.Contracts;
    using MyWebServer.Server.HTTP.Response;
    using MyWebServer.Server.Utils;
    using System;
    using Constants;
    using Views.Home;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(ResponseStatusCode.Ok, new IndexView());
        }

        public IHttpResponse IndexPost(IHttpContext httpContext)
        {
            decimal numberOne;
            decimal numberTwo;

            try
            {
                numberOne = NumberParser.ParseDecimal(httpContext.Request.FormData[HomeControllerConstants.FirstNumberParameterName]);
            }
            catch (Exception)
            {
                numberOne = 0;
            }

            try
            {
                numberTwo = NumberParser.ParseDecimal(httpContext.Request.FormData[HomeControllerConstants.SecondNumberParameterName]);
            }
            catch (Exception)
            {
                numberTwo = 0;
            }

            string operation = httpContext.Request.FormData[HomeControllerConstants.OperatorParameterName];

            Type strategyType;

            try
            {
                strategyType = CalculationStrategies.Strategies[operation];
            }
            catch (Exception)
            {
                return new ViewResponse(ResponseStatusCode.Ok, new IndexView(HomeControllerConstants.InvalidOperationMessage));
            }

            CalculationStrategy strategy =
                (CalculationStrategy)Activator.CreateInstance(strategyType);

            if (!this.IsValidMathOperation(numberOne, numberTwo, operation))
            {
                return new ViewResponse(ResponseStatusCode.Ok, new IndexView(HomeControllerConstants.InvalidOperationMessage));
            }

            decimal result = strategy.Calculate(numberOne, numberTwo);

            return new ViewResponse(ResponseStatusCode.Ok, new IndexView($"{this.GetResultString(numberOne, numberTwo, operation, result)}"));
        }

        private string GetResultString(decimal numberOne, decimal numberTwo, string operation, decimal result)
        {
            if (operation == Operations.SquareRoot)
            {
                return String.Format(HomeControllerConstants.ResultOneNumberString, numberOne, operation, result);
            }

            return String.Format(HomeControllerConstants.ResultString, numberOne, operation, numberTwo, result);
        }

        private bool IsValidMathOperation(decimal numberOne, decimal numberTwo, string operation)
        {
            if (numberTwo == 0 && operation == Operations.Divide)
            {
                return false;
            }
            if (numberOne < 0 && operation == Operations.SquareRoot)
            {
                return false;
            }

            return true;
        }
    }
}
