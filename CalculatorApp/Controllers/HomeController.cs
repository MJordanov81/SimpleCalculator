namespace CalculatorApp.Controllers
{
    using CalculationStrategies;
    using MyWebServer.Server.Enums;
    using MyWebServer.Server.HTTP.Contracts;
    using MyWebServer.Server.HTTP.Response;
    using MyWebServer.Server.Utils;
    using System;
    using System.Collections.Generic;
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
            Dictionary<string, string> response = new Dictionary<string, string>();

            decimal numberOne = NumberParser.TryParseDecimalOrReturnZero(httpContext.Request.FormData[HomeControllerConstants.FirstNumberParameterName]);

            decimal numberTwo = NumberParser.TryParseDecimalOrReturnZero(httpContext.Request.FormData[HomeControllerConstants.SecondNumberParameterName]);

            string operation = httpContext.Request.FormData[HomeControllerConstants.OperatorParameterName];

            if (!this.IsValidMathOperation(numberOne, numberTwo, operation))
            {
                return new ViewResponse(ResponseStatusCode.Ok, new IndexView(this.GenerateResponse(response, numberOne, numberTwo, operation, HomeControllerConstants.InvalidOperationMessage)));
            }

            CalculationStrategy strategy;

            bool isThereRelevantStrategy = this.TryGetStrategy(operation, out strategy);

            if (!isThereRelevantStrategy)
            {
                return new ViewResponse(ResponseStatusCode.Ok, new IndexView(this.GenerateResponse(response, numberOne, numberTwo, operation, HomeControllerConstants.InvalidOperationMessage)));
            }
               
            decimal result = strategy.Calculate(numberOne, numberTwo);

            return new ViewResponse(ResponseStatusCode.Ok, new IndexView(this.GenerateResponse(response, numberOne, numberTwo, operation, this.GetResultString(numberOne, numberTwo, operation, result))));            
        }

        private bool TryGetStrategy(string operation, out CalculationStrategy strategy)
        {          
            try
            {
                Type strategyType = CalculationStrategies.Strategies[operation];
                strategy = (CalculationStrategy)Activator.CreateInstance(strategyType);
                return true;
            }
            catch (Exception)
            {
                strategy = null;
                return false;
            }            
        }

        private Dictionary<string, string> GenerateResponse(Dictionary<string, string> response, decimal numberOne, decimal numberTwo, string operation, string result)
        {
            response[HomeControllerConstants.FirstNumberParameterName] = $"{numberOne}";
            response[HomeControllerConstants.SecondNumberParameterName] = $"{numberTwo}";
            response[HomeControllerConstants.OperatorParameterName] = $"{operation}";
            response[HomeControllerConstants.Result] = result;

            return response;

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
