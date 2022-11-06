 using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.BL.AutoMapper;
using WebApplication1.BL.Interface;
using WebApplication1.BL.Reposatory;
using WebApplication1.DAL.Database;


namespace WebApplication1
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
           
            services.AddControllersWithViews()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization()
                    .AddNewtonsoftJson(opt => {
                        opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            
            services.AddDbContextPool<DbContainer>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("COMPANY_DBConnection")));
            //Auto mapping
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddScoped<IDepartmentRep, DepartmentRep>(); //for loose coupling
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();




            //services.AddMvc();

            //1) Addtransient -> take an instance of the class, for each request (Action call)
            //services.AddTransient<DepartmentRep>();
            //2) AddScoped -> take an instance of the class, for each user uses the department controller
            //services.AddScoped<DepartmentRep>();

            //2) AddSingleton -> take a shared instance of the class, for all users
            //services.AddSingleton<DepartmentRep>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //take instance from languages
            var supportedCultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("ar-EG")

            };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            });



            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
