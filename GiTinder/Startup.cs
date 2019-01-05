using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



namespace GiTinder
{
    public class Startup
    {
        //IConfiguration Startup.Configuration { get; }

        //public IConfiguration Configuration { get; }

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddDbContext<GiTinderContext>();
            //services.AddDbContext<GiTinderContext>(options => options.UseMySQL("server=localhost;database=newgitinder;user=root;password=1234"));

            //services.AddDbContext<GiTinderContext>(options => options.UseMySQL(_configuration.GetConnectionString("GiTinderContextMySqlDb")));
            services.AddDbContext<GiTinderContext>(options => options.UseSqlServer(_configuration.GetConnectionString("GiTinderContextMSSqlDb")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //     services.AddDbContext<GiTinderContext>(options =>
            //options.UseMySQL(Configuration.GetConnectionString("GiTinderContextDatabase")));
            // comment: 
            //in appsettings.json
            //, "ConnectionStrings": {
            //  "GiTinderContextDatabase": "server=localhost;database=newgitinder;user=root;password=1234"
            //}

            //string connectionString = Startup.Configuration["connectionStrings: GiTinderContextDBConnectionString"];
            //services.AddDbContext<GiTinderContext>(o => o.UseMySQL(connectionString));
            //in Environment Variables / System Variables:  
            //connectionStrings: GiTinderContextDBConnectionString 
            //server=localhost;database=newgitinder;user=root;password=1234

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //, ILoggerFactory loggerFactory
            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug();

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



