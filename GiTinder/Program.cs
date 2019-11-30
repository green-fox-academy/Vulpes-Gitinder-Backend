using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace GiTinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>();
        //          .UseKestrel()
        //          .UseContentRoot(Directory.GetCurrentDirectory())
        //          .UseWebRoot("notusingwwwroot");



        //private static string GetKeyVaultEndpoint() => Environment.GetEnvironmentVariable("TestDb");

    }
}
