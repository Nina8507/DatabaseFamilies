using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFamilies.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatabaseFamilies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (CloudContext context = new CloudContext())
            {
                
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}