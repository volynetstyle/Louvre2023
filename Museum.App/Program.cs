using Museum.App.Adapters.DALConfiguration;

namespace Museum.App
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(DALConfiguration.ConfigureMapper().CreateMapper());
            DALConfiguration.ConfigureDALServices(builder.Services, builder.Configuration);

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}