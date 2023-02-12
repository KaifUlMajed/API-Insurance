using API_Markel.Data.Repositories;
using API_Markel.Data.Services;

namespace API_Markel.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICompanyClaimsService, CompanyClaimsService>();

            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IClaimsRepository, ClaimsRepository>();
        }
    }
}
