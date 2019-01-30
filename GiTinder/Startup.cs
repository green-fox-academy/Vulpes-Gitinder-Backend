using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using GiTinder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GiTinder
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GiTinderContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GiTinderContextMSSqlDb")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<UserServices>();
            services.AddTransient<SettingsServices>();
            services.AddTransient<LanguageServices>();
            services.AddTransient<ProfileService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GiTinderContext>();
                context.Database.Migrate();
            }
        }
    }
}
