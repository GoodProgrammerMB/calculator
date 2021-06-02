using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using GP.Calculator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GP.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetService<ILogger>();
            var calculation = host.Services.GetService<ICalculations>();
            Console.WriteLine("Start application CALCULATOR");
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a numeric argument.");
                Console.WriteLine("Usage: Factorial <num>");
            }
            else
            {
                try
                {
                    var fileLines = File.ReadLines(args[0]);
                    
                    var stepResult = (decimal)calculation.GetFirstArgument(fileLines);

                    var rows = fileLines.ToList();
                    for (var i = 0; i < rows.Count() - 1; i++)
                    {
                        stepResult = calculation.Calculate(rows[i], stepResult);
                    }
                    Console.WriteLine($"Calculation result: {stepResult}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unhandled exception: {ex}");
                    logger.Log(LogLevel.Error, ex.ToString());
                }
            }
            Console.WriteLine("Done.");
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    var options = new Log4NetProviderOptions($"log4net.config");

                    logging.AddLog4Net(options);

                    logging.SetMinimumLevel(LogLevel.Information);
                }).ConfigureServices(ConfigureServices);

            return builder;
        }

        private static void ConfigureServices(HostBuilderContext hostingContext, IServiceCollection services)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new Log4NetProvider($"log4net.config"));

            services
                .AddTransient<ICalculations, Calculations>()
                .AddSingleton(s => loggerFactory.CreateLogger("default"));
        }
    }
}
