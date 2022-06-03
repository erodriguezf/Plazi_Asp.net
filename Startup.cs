using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HolamundoMVC.Models;

namespace HolamundoMVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc();

            /*services.AddDbContext<EscuelaContex>(
                options => options.UseInMemoryDatabase(databaseName:"testDB" )
            )*/;
            
           /* string conectionstring="Server=127.0.0.1;Databese=escuelatest;Uid=root;Pwd=1234;port=3306;Connect Timeout=5;";
             services.AddDbContext<EscuelaContex>(
                options => options.UseMySql(conectionstring,new MySqlServerVersion(new Version(6,0,1)))
            );*/
           // string connString = builder.Configuration.GetConnectionString("DefaultConnectionString");
            //Services.AddDbContext<EscuelaContext>(options => options.UseNpgsql(connString));
            string connString =Configuration.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<EscuelaContex>(options=>options.UseNpgsql(connString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseCors();

           /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Escuela}/{action=Index}/{id?}");

            });*/
           
           app.UseEndpoints(endpoints => {
               endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Escuela}/{action=Index}/{id?}"
               );
           });

           
    
        
    }
       }
    }
    
