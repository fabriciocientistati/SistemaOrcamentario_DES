using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace SistemaOrcamentario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ConfigureHttpsDefaults(o =>
                        {
                            o.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
                        });
                    });

                });
    }
}
