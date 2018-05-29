using CurrencyFeed;
using Topshelf;
namespace WindowsServiceWithTopshelf
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<CurrencyFeedService>(service =>
                {
                    service.ConstructUsing(s => new CurrencyFeedService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("CurrencyFeedService");
                configure.SetDisplayName("PalTripAdvisorJob");
                configure.SetDescription("Sync Currencies to PalTripAdvisor database");
            });
        }
    }
}