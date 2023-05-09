using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Dependencies.DALConfiguration
{
    public static class DALConfiguration
    {
        public static IServiceCollection ConfigureDALServices(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MSSQL");

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddSingleton(configuration);
               // services.AddScoped<IA, TaskService>();
                //services.AddScoped<ITaskRepository, TaskRepository>(provider => new TaskRepository(connectionString));
                //services.AddScoped<ICategoryRepository, CategoryRepository>(provider => new CategoryRepository(connectionString));
                return services;
            }
            else
            {
                throw new ArgumentNullException($"The connection string \"{connectionString}\" is null or empty in {typeof(DALConfiguration)}.");
            }
        }
    }
}
