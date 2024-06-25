using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SportsBettingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("BetOnline", c =>
            {
                c.BaseAddress = new Uri("https://api.betonline.ag/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("Pinnacle", c =>
            {
                c.BaseAddress = new Uri("https://api.pinnacle.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("DraftKings", c =>
            {
                c.BaseAddress = new Uri("https://api.draftkings.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("FanDuel", c =>
            {
                c.BaseAddress = new Uri("https://api.fanduel.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("BetMGM", c =>
            {
                c.BaseAddress = new Uri("https://api.betmgm.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("Caesars", c =>
            {
                c.BaseAddress = new Uri("https://api.caesars.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("Circa", c =>
            {
                c.BaseAddress = new Uri("https://api.circa.com/");
                // Add headers or authentication if needed
            });

            services.AddHttpClient("ESPNBet", c =>
            {
                c.BaseAddress = new Uri("https://api.espn.com/");
                // Add headers or authentication if needed
            });

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
