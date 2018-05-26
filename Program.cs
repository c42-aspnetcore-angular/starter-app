using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace starter_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logBuilder) => {
                    logBuilder.AddConfiguration(hostingContext.Configuration.GetSection("logging"));
                    logBuilder.AddConsole();
                    logBuilder.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();
    }
}
