﻿using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace GiTinder
{
    public class Startup
    {
        private IConfiguration _configuration;
        private string connectionString;    

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //var config = builder.Build();

            //var constr = _configuration.GetConnectionString(@"Server = (localdb)\mssqllocaldb; Database = MyDatabase; Trusted_Connection = True;");

            _configuration = builder.Build();
            Console.WriteLine(env.EnvironmentName);

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string getEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            services.AddDbContext<GiTinderContext>(options => options.UseSqlServer(getEnv));
            //services.AddDbContext<GiTinderContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<SettingsServices>();
            services.AddTransient<UserServices>();

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
            //app.UseDefaultFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
