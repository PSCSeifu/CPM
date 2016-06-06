using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CPM.Web;
using AutoMapper;
using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Models;
using CPM.Data.Wallet;

namespace CPM.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();

            Data.ModelMappings.Configure();
            Business.ModelMappings.Configure();
            Web.ModelMappings.Configure();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            //AddIdentity();
            services.AddMvc();
            AddBusiness(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            //First check for static files.
            // app.UseIdentity(); //Identity before the MVC to ensure cookies,401 errors are processed.
            // app.UseSession(); //Session before MVC
            UsePlatform(app, env);

            Mapper.Initialize(config =>
            {
                #region " Wallets "
                config.CreateMap<WalletBM, WalletInfoVM>();
                config.CreateMap<WalletInfoVM, WalletBM>();
                config.CreateMap<WalletDM, WalletBM>();
                #endregion
            });

            UseMvc(app);
           
            // UseMappings();
        }

        #region " Add Service "

        private void AddMvc(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
        }

        private void AddIdentity(IServiceCollection services)
        {
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();
        }

        private void AddBusiness(IServiceCollection services)
        {
            DependecyInjection.Configure(services);
        }

        #endregion

        #region " Use Services "

        private void UsePlatform(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //Home>Controller Error>Action
            }

            app.UseStaticFiles();
        }

        private void UseMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{area=Global}/{controller=Home}/{action=Index}/");
        });

        }

        private void UseMappings()
        {
            Data.ModelMappings.Configure();
            Business.ModelMappings.Configure();
            Web.ModelMappings.Configure();
        }

        #endregion
    }
}
