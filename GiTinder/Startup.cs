﻿using System;
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

namespace GiTinder
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

<<<<<<< HEAD
        private IConfiguration _configuration;

=======
>>>>>>> d7161859c4d022f04d6196325c1681daf70d60ac
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GiTinderContext>(options => options.UseSqlServer(_configuration.GetConnectionString("GiTinderContextMSSqlDb")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
<<<<<<< HEAD

            services.AddDbContext<GiTinderContext>(options => options.UseSqlServer(_configuration.GetConnectionString("GiTinderContextMSSqlDb")));
            services.AddTransient<UserServices>(); 
=======
            services.AddTransient<SettingsServices>();
            services.AddTransient<UserServices>();
>>>>>>> d7161859c4d022f04d6196325c1681daf70d60ac
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
        }
    }
}
