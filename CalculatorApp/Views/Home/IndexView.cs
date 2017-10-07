namespace CalculatorApp.Views.Home
{
    using System.Collections.Generic;
    using MyWebServer.Server.Contracts;

    public class IndexView : IView
    {
        private string result;
        private string numberOne;
        private string numberTwo;
        private string operation;

        public IndexView(Dictionary<string, string> parameters = null)
        {
            if (parameters != null)
            {               
                this.result = parameters["result"];
                this.numberOne = parameters["numberOne"];
                this.numberTwo = parameters["numberTwo"];
                this.operation = parameters["operation"];
            }            
        }

        public string View()
        {

            if (this.result == null)
            {
                this.result = "nothing to show";
            }

            return
            @"<style>
                footer { text-align: center }
                .result {color: red; font-weight: bold}
            </style>

            <head>
                <title>My calculator</title>
                <meta charset=""utf-8"">
                <meta name=""description"" content =""My Calculator"" >
                <meta name= ""keywords"" content = ""calculator"" >
                <meta name= ""author"" content = ""Marian Jordanov"" >
            </head> 
            <body>  
            <h1>My Calculator</h1>
            <form method=""post"" action=""/"">" + 
                $"<input type=\"number\" step=\"0.01\" name=\"numberOne\" placeholder=\"Enter number one...\" value=\"{this.numberOne}\"/>" +
                $"<input type=\"text\" name=\"operation\" placeholder=\"+ - * / ^ sqrt\" value=\"{this.operation}\"/>" +
                $"<input type=\"number\" step=\"0.01\" name=\"numberTwo\" placeholder=\"Enter number two...\" value=\"{this.numberTwo}\"/>" +
                @"<input type=""submit"" value=""Calculate""/>
            </form>" +

            $"<div><p class=\"result\">Result: {this.result}</p></div>" + 
                    @"<footer>&reg; All Rights Reserved</footer> 
            </body>";
        }
    }
}
