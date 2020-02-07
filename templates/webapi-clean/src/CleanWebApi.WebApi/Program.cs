using System;
using System.IO;
using System.Linq;
using CleanWebApi.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CleanWebApi.WebApi
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                var seed = args.Contains("--seed");
                if (seed)
                {
                    args = args.Except(new[] { "--seed" }).ToArray();
                }

                Log.Information("Creating web host...");
                var host = CreateHostBuilder(args).Build();

                if (seed)
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        try
                        {
                            var env = scope.ServiceProvider.GetService<IWebHostEnvironment>();
                            var context = scope.ServiceProvider.GetService<CleanWebApiDbContext>();

                            Log.Information("Migrating database schema...");
                            context.Database.Migrate();

                            Log.Information("Seeding data...");
                            CleanWebApiInitializer.Initialize(context);
                        }
                        catch (Exception ex)
                        {
                            Log.Error("An error occured while migrating or initializing the database.", ex);
                            return 1;
                        }
                    }

                    Log.Information("Done seeding database.");
                    return 0;
                }

                Log.Information("Starting host...");
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseConfiguration(Configuration)
                        .UseSerilog();
                });
    }
}
