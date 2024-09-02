using AvanSight.DAL;
using AvanSight.Services;

namespace AvanSight.Server.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            //PharmaDataService
            services.AddSingleton<PharmaDataService>();


            //IDapperContext

            //PatientService

        }
    }    
}
