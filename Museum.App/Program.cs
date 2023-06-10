using Microsoft.AspNetCore;
using Museum.App.Adapters;
using Museum.App.Adapters.DALConfiguration;

namespace Museum.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton(DALConfiguration.ConfigureMapper().CreateMapper());

            DALConfiguration.ConfigureDALServices(builder.Services, builder.Configuration);

            InitilizeComponent(builder).Run();
        }

        private static WebApplication InitilizeComponent(WebApplicationBuilder Builder)
        {
            var app = Builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default", 
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}