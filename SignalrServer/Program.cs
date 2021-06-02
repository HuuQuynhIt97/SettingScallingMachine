using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("License key: "); 
            var license_key = Console.ReadLine();
            string license_key_default = "SHC";
            if (license_key_default == license_key)
            {
                Console.WriteLine("Config Setting Scaling Machine ");
            }else
            {
                return;
            }
            //Console.WriteLine("Hello {0}!", license_key);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://127.0.0.1:5001");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
