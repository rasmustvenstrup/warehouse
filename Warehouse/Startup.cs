﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Contracts;
using Warehouse.DbContexts;
using Warehouse.Entities;
using Warehouse.Repositories;
using Warehouse.Repositories.EntityFramework;

namespace Warehouse
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Action<DbContextOptionsBuilder> optionsAction = options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            };

            // TODO: Find ud af tracke changes så EF kun opdaterer felter som er ændret.
            // TODO: Lav også ADO og Dapper repositories og mål performance.
            // TODO: Lav Unit of Work
            // TODO: Skal vi kun have en DbContext?
            services.AddDbContext<CustomerDbContext>(optionsAction);
            services.AddDbContext<OrderDbContext>(optionsAction);
            services.AddDbContext<ProductDbContext>(optionsAction);
            services.AddScoped<IDatabaseRepository<Customer>, CustomerRepository>();
            services.AddScoped<IDatabaseRepository<Order>, OrderRepository>();
            services.AddScoped<IDatabaseRepository<Product>, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
