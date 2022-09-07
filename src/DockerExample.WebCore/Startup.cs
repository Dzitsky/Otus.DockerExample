using System;
using DockerExample.DataAccess;
using DockerExample.Domain;
using DockerExample.Domain.Abstractions;
using DockerExample.WebCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DockerExample.WebCore
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
            services.AddControllersWithViews();

            // const string connectionString = "Server=localhost;Port=5432;Database=docker;User Id=postgres;Password=1";
            const string connectionString = "Server=docker-example-db;Port=5432;Database=docker;User Id=postgres;Password=1";

            services.AddDbContext<DockerDbContext>(
                options =>
                {
                    options.UseNpgsql(
                        connectionString,
                        npgSqlOptions => npgSqlOptions.SetPostgresVersion(new Version(9, 6)));
                });

            // Регистрируем (добавляем в контейнер) сервис для инициализации БД
            services.AddScoped<DbInitializer>();

            // Регистрируем (добавляем в контейнер) доменный сервис
            services.AddScoped<IUserAppService, UserAppService>();
            // Регистрируем (добавляем в контейнер) репозиторий
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });

            // Инициализируем БД, очищаем и создаём одну запись
            dbInitializer.Initialize();
        }
    }
}
