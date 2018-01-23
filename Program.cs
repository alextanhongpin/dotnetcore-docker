using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace microservice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();
            
            host.Run();
        }
    }

    public class Startup 
    {
        public Startup(IHostingEnvironment env) 
        {

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, ILoggerFactory loggerFactory) 
        {
            app.Run(async (context) => 
            {
                await context.Response.WriteAsync("Hello, world!");
            });
        }
    }
}
