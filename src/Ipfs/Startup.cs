using System;
using System.Diagnostics.CodeAnalysis;
using Citrix.Microservices.Environment;
using Citrix.Microservices.Extensions.HealthCheck;
using Citrix.Microservices.Extensions.Logging;
using Citrix.Microservices.Extensions.Logging.Product;
using Citrix.Microservices.Microservice;
using Citrix.Microservices.Microservice.ServiceLifetime;
using Citrix.Microservices.RequestLogging;
using Ipfs.CoreApi;
using Ipfs.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ipfs
{
    [ExcludeFromCodeCoverage]
    public partial class Startup : MicroserviceStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
            : base(configuration, env)
        {
        }

        protected override void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMicroserviceApplicationLifetime appLifetime)
        {
            var loggerConfiguration = new CitrixLoggerBuilder()
                .AddProductLogging(Configuration)
                .AddRequestLogging(Configuration)
                .Build();

            loggerFactory.AddCitrixLogging(loggerConfiguration, Configuration);

            ILogger logger = loggerFactory.CreateLogger<Startup>();

            // Register for lifecycle events in order.  Killswitch is not guaranteed to happen, but Killswitch and Stopping should be treated similar that the service
            // is being shutdown and should stop doing any background work.
            appLifetime.ApplicationStarted.Register(() =>
            {
                // Register for application started.
            });

            appLifetime.ApplicationKillswitched.Register(() =>
            {
                // Register for application killswitched.
            });

            appLifetime.ApplicationStopping.Register(() =>
            {
                // Register for application stopping.
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                // Register for application stopped.
            });
        }

        protected override void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration, EnvironmentInfo environmentInfo)
        {
            // Configure any additional services for Ipfs
            services.AddLogging();
            services.AddSingleton<IpfsClient>();
            services.AddSingleton<IGenericApi>(x => x.GetRequiredService<IpfsClient>());
            services.AddSingleton<ICoreApi>(x => x.GetRequiredService<IpfsClient>());

            base.ConfigureApplicationServices(services, configuration, environmentInfo);
        }

        protected override void ConfigureAdditionalHealthChecks(IServiceCollection services, HealthCheckServicesBuilder builder)
        {
            // Configure additional health checks you may need.
        }
    }
}
