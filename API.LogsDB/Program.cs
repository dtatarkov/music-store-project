using API.LogsDB.Context;
using API.LogsDB.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static void ConfigureServices(IServiceCollection services)
{
    services
            .AddSingleton(services => new AppSettings(services.GetRequiredService<IConfiguration>()))
            .AddDbContext<ApplicationContext>();
}

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ConfigureServices)
    .Build();