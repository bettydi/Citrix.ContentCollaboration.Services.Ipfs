using System.Collections.Generic;
using System.Reflection;
using Citrix.Microservices.Microservice;

namespace Ipfs
{
    public partial class Startup : MicroserviceStartup
    {
        public override SwaggerConfiguration SwaggerConfiguration => new SwaggerConfiguration
        {
            Docs = new List<SwaggerDocVersion>
            {
                new SwaggerDocVersion
                {
                    RoutePrefix = "v1",
                    Title = "MicroService API"
                }
            },
            ModelAssembly = typeof(Startup).GetTypeInfo().Assembly
        };
    }
}
