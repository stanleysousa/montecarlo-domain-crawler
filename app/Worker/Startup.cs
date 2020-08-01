using Worker.Models;
using Worker.Services;
using Worker.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Worker
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .Configure<Config>(Configuration.GetSection("Config"))
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"))
                        .AddConsole()
                        .AddDebug();
                })
                .AddSingleton<IConfigurationRoot>(Configuration)
                .AddSingleton<IDomainProcessor, DomainProcessor>();
        }
    }
}