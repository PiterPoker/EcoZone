using System;
using System.Threading.Tasks;
using DataAccessProvider;
using Domain;
using Domain.Model;
using EcoZone.Data;
using EcoZone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EcoZone
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddJsonFile("config.json", true, true);
            if (env.IsDevelopment())
                builder.AddUserSecrets();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("EcoZoneDb");

            services.AddDbContext<DomainModelContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("ecozone")
                ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DomainModelContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IDataAccessProvider<Block>, DataAccessProvider<Block>>();
            services.AddScoped<IDataAccessProvider<BlockType>, DataAccessProvider<BlockType>>();
            services.AddScoped<IDataAccessProvider<Comment>, DataAccessProvider<Comment>>();
            services.AddScoped<IDataAccessProvider<Like>, DataAccessProvider<Like>>();
            services.AddScoped<IDataAccessProvider<Tag>, DataAccessProvider<Tag>>();
            services.AddScoped<IDataAccessProvider<Unit>, DataAccessProvider<Unit>>();

            services.AddMvc()
                .AddJsonOptions(
                    options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            DatabaseInitialize(app.ApplicationServices).Wait();
        }
        private async Task DatabaseInitialize(IServiceProvider serviceProvider)
        {
            string[] roles = { "Moderator", "Author", "User", "Admin" };

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminEmail = "admin@admin.com";
            var password = "Aaa123!";

            foreach (var role in roles)
                if (await roleManager.FindByNameAsync(role) == null)
                    await roleManager.CreateAsync(new IdentityRole(role));

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = "Администратор"
                };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}