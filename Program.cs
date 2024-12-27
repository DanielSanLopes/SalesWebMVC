using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
using SalesWebMVC.Services;


namespace SalesWebMVC {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            string _connectionString = builder.Configuration.GetConnectionString("SalesWebMVCContext") ?? 
                                       throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.");

            builder.Services.AddDbContext<SalesWebMVCContext>(options =>
                options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString),
                                            options => options.MigrationsAssembly("SalesWebMVC")
                                            )
                );

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope()) {
                var service = scope.ServiceProvider.GetService<SeedingService>();
                service.Seed();

            }


            //app.Start();


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
