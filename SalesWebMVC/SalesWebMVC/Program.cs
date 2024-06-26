using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
namespace SalesWebMVC {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            string _connectionString = builder.Configuration.GetConnectionString("SalesWebMVCContext") ?? 
                                       throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.");
            builder.Services.AddDbContext<SalesWebMVCContext>(options =>
                options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString), 
                        options => options.MigrationsAssembly("SalesWebMVC")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
