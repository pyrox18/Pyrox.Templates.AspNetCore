using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanWebApi.Application.Interfaces;
using CleanWebApi.Persistence;
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
                Log.Information("Creating web host...");
                var host = CreateWebHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var env = scope.ServiceProvider.GetService<IHostingEnvironment>();
                        var context = scope.ServiceProvider.GetService<ICleanWebApiDbContext>();
                        var concreteContext = context as CleanWebApiDbContext;

                        Log.Information("Migrating database schema...");
                        concreteContext.Database.Migrate();

                        Log.Information("Seeding data...");
                        CleanWebApiInitializer.Initialize(concreteContext);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("An error occured while migrating or initializing the database.", ex);
                        return 1;
                    }
                }

                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .UseSerilog();
    }
}
