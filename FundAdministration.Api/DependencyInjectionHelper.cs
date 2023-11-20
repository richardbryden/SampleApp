using FundAdministration.Db;
using FundAdministration.Service;
using Microsoft.EntityFrameworkCore;

namespace FundAdministration.Api
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection AddFundAdministration(this IServiceCollection services)
        {
            services.AddDbContext<FundAdministrationContext>(options =>
            {
                //options.UseSqlServer("Server=localhost;Database=FundAdministration;Trusted_Connection=True;");
                options.UseSqlServer("Data Source=.;Initial Catalog=FundAdministration;Integrated Security=True;");
            }, ServiceLifetime.Singleton);

            // Add the service interfaces
            services.AddScoped<IFundService, FundService>();
            services.AddScoped<IManagerService, ManagerService>();

            return services;
        }
    }
}
