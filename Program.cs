using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;
using TableDependencyWithSignalR.Hubs;
using TableDependencyWithSignalR.Middlewares;
using TableDependencyWithSignalR.Repositories.Abstract;
using TableDependencyWithSignalR.Repositories.Concret;
using TableDependencyWithSignalR.Subscriptions;

namespace TableDependencyWithSignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR(
                hubOptions =>
                {
                    hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(30);
                    hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(15);
                });
            builder.Services.AddSingleton<DashboardHub>();
            builder.Services.AddSingleton<ProductRepository>();
            builder.Services.AddSingleton<Mediator>();
            builder.Services.AddMediatR(typeof(Program).Assembly);
            builder.Services.AddSingleton<ProductTableSubscription>();
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromMinutes(30);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseProductTableDependency();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapHub<DashboardHub>("/dashboardhub");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}