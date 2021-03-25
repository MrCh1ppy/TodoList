using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TodoList {
    public class Program {
        public static void Main(string[] args) {
            var host = BuildWebHost(args);
            InitializeDatabase(host);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void InitializeDatabase(IWebHost host) {
            using (var scope=host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try {
                    SeedData.InitializeAsync(services).Wait();
                    /*这个services是啥*/
                    /*只有在这里不能使用await*/
                }
                catch (Exception ex) {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex,"在为数据库赋初值的时候出错");
                }
            }
        }
    }
}