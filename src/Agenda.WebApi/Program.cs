using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Agenda.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var myArgs = args;
            CreateHostBuilder(myArgs).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
