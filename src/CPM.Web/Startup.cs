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

using CPM.Business.Wallet;
using CPM.Web.Areas.Wallet.Models;
using CPM.Data.Wallet;
using CPM.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;
using CPM.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CPM.Data.Client;
using Microsoft.AspNetCore.Identity;
using CPM.Data.Global.Account;
using CPM.Data.Offer;
using Newtonsoft.Json.Serialization;
using CPM.Business;

namespace CPM.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
      

            Configuration = builder.Build();
            AutoMapper.Mapper.Initialize(config => {
                config.AddProfile<BusinessModelMappings>();
                config.AddProfile<DataModelMappings>();
                config.AddProfile<WebModelMappings>();
                
                });
            //Data.ModelMappings.Configure();
            //Business.ModelMappings.Configure();
            //Web.ModelMappings.Configure();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AddIdentity(services);
            AddMvc(services);
            AddBusiness(services);          
            AddEntityFramework(services);
            AddThirdParty(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {             
            UsePlatform(app, env);
            UseIdentity(app);
            UseMvc(app);

            app.UseKendo(env);
            // UseSeedDataWriter(@"C:\Projects\CPM\src\CPM.Data\Resources");
            UseSeedData(@"C:\Projects\CPM\src\CPM.Data\Resources");
            
        }

        #region " Add Service "

        private void AddMvc(IServiceCollection services)
        {
            services.AddMvc()
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddOptions();
        }

        private void AddThirdParty(IServiceCollection services)
        {
            //services.AddKendo();
        }

        private void AddEntityFramework (IServiceCollection services)
        {
            services.AddDbContext<WalletContext>(options => 
                     options.UseSqlServer(Configuration["Data:CPMConnection"],b => b.MigrationsAssembly("CPM.Web")));
            services.AddDbContext<ClientContext>(options =>
                     options.UseSqlServer(Configuration["Data:CPMConnection"], b => b.MigrationsAssembly("CPM.Web")));
            services.AddDbContext<CPMUserContext>(options =>
                     options.UseSqlServer(Configuration["Data:CPMConnection"], b => b.MigrationsAssembly("CPM.Web")));
            services.AddDbContext<OfferContext>(options =>
                     options.UseSqlServer(Configuration["Data:CPMConnection"], b => b.MigrationsAssembly("CPM.Web")));
        }

        private void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<CPMUserEntity, IdentityRole>()
                        .AddEntityFrameworkStores<CPMUserContext>()
                        .AddDefaultTokenProviders();
        }

        private void AddBusiness(IServiceCollection services)
        {
            DependecyInjection.Configure(services);
        }
               
        private void AddDbCOntext(IServiceCollection services)
        {
            services.AddDbContext<ClientContext>(options =>
                options.UseSqlServer(Configuration[""]));
        }
        
        #endregion

        #region " Use Services "
        //First check for static files.
        // app.UseIdentity(); //Identity before the MVC to ensure cookies,401 errors are processed.
        // app.UseSession(); //Session before MVC
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

        private void UseIdentity(IApplicationBuilder app)
        {
            app.UseIdentity();
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
        //    Data.ModelMappings.Configure();
        //    Business.ModelMappings.Configure();
        //    Web.ModelMappings.Configure();
        }
        
        private void UseSeedDataWriter(string folderPath)
        {
            if (!string.IsNullOrWhiteSpace(folderPath) && Directory.Exists(folderPath))
            {                
                SeedTemplateJsonWriter seeWriter = new SeedTemplateJsonWriter();                
                seeWriter.CreateWallet(Path.Combine(folderPath,"wallets.json"));
                seeWriter.CreateOffer(Path.Combine(folderPath, "offers.json"));
            }
        }

        private void UseSeedData(string folderPath)
        {
            if (!string.IsNullOrWhiteSpace(folderPath) && Directory.Exists(folderPath))
            {
                EnsureSeedData seeder = new EnsureSeedData();
                seeder.EnsureSeedWalletData(Path.Combine(folderPath, "wallets.json"));
                seeder.EnsureSeedWalletTypeData(Path.Combine(folderPath, "walletTypes.json"));
                seeder.EnsureSeedOfferData(Path.Combine(folderPath, "offers.json"));
                seeder.EnsureSeedClientData(Path.Combine(folderPath, "clients.json"));
                seeder.EnsureSeedCurrencyData(Path.Combine(folderPath, "currency.json"));
            }
        }

        #endregion
    }
}
