using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Demo4
{
    /// <summary>
    /// principal class for start app
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main of app
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// method for init app
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
