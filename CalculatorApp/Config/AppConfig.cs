namespace CalculatorApp.Config
{
    using Contracts;
    using Controllers;
    using MyWebServer.Server.Enums;
    using MyWebServer.Server.Handlers;
    using MyWebServer.Server.Routing.Contracts;

    public class AppConfig : IApplicationConfiguration
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            // GET
            appRouteConfig.AddRoute(RequestMethod.Get, "/", new RequestHandler(httpContext => new HomeController().Index()));


            //POST
            appRouteConfig.AddRoute(RequestMethod.Post, "/", new RequestHandler(httpContext => new HomeController().IndexPost(httpContext)));

        }
    }
}
