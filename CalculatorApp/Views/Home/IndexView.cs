namespace CalculatorApp.Views.Home
{
    using MyWebServer.Server.Contracts;

    public class IndexView : IView
    {
        private string result;

        public IndexView(string result = null)
        {
            this.result = result;
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
                pre {background-color: #F94F80}
                span.important {font-style: italic; font-weight: bold}
                .result {color: red; font-weight: bold}
            </style>

            <head>
                <title>By The Cake</title>
                <meta charset=""utf-8"">
                <meta name=""description"" content =""Buy the cake in By The Cake"" >
                <meta name= ""keywords"" content = ""cake, buy"" >
                <meta name= ""author"" content = ""Marian Jordanov"" >
            </head> 
            <body>  
            <h1>My Calculator</h1>
            <form method=""post"" action=""/"">
                <input type=""number"" step=""0.01"" name=""numberOne"" placeholder=""Enter number one...""/>
                <input type=""text"" name=""operator"" placeholder=""+ - * / ^ sqrt""/>
                <input type=""number"" step=""0.01"" name=""numberTwo"" placeholder=""Enter number two...""/>
                <input type=""submit"" value=""Calculate""/>
            </form>" +

            $"<div><p class=\"result\">Result: {this.result}</p></div>" + 
                    @"<footer>&reg; All Rights Reserved</footer> 
            </body>";
        }
    }
}
