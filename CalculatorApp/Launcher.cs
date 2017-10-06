namespace CalculatorApp
{
    using Config;
    using Config.Contracts;
    using MyWebServer.Server;
    using MyWebServer.Server.Routing;
    using MyWebServer.Server.Routing.Contracts;

    public class Launcher
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplicationConfiguration app = new AppConfig();
            IAppRouteConfig appRouteConfig = new AppRouteConfig();
            app.Start(appRouteConfig);

            Constants.CalculationStrategies.GetStrategies();

            this.webServer = new WebServer(8230, appRouteConfig);
            this.webServer.Run();
        }
    }

}