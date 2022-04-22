using System.Diagnostics.CodeAnalysis;

using Citrix.Microservices.Microservice;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Ipfs
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args)
        {
            var host = new MicroserviceBuilder<Startup>("ipfs")
                .ConfigureLoadBalancer(LoadBalancer.AmazonELB)
                .CreateHostBuilder()
                .Build();

            host.Run();
        }
    }
}
