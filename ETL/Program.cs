using ETL;
using ETL.Service.Settings;
using Microsoft.Extensions.Options;

IHost? host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<PathConfig>(hostContext.Configuration.GetSection("AppSettings"));
        services.AddTransient(service =>
        {
            return service.GetRequiredService<IOptions<PathConfig>>().Value;
        });
            
        services.AddETLService();
    })
    .Build();
await host.RunAsync();
