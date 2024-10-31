using Microsoft.Extensions.Options;
using SEA.Core;
using SEA.Data;
using SEA.Data.ContextConfig;
using SEA.Services;

namespace ESA.API
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // Register DbContextFactory using the IOptions<DatabaseOptions>
            services.AddScoped<DbContextFactory>(serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
                return new DbContextFactory(options);
            });
            // Register your repository
            services.AddScoped(typeof(IRepository<>), typeof(EntityframeworkRepository<>));
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
