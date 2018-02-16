using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Trendy.Seeder;

namespace Trendy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seeder = new Seeder.MongoSeeder();
            seeder.ImportJson("SEED_DATA.json").Wait();

            var dbSeeder = new MSSQLSeeder();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
