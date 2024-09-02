using AvanSight.Server.Extentions;
using AvanSight.Services;

namespace AvanSight.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Register the PharmaDataService as a singleton
            builder.Services.AddServices();

            var app = builder.Build();

            // Prepare pharma data on application startup
            var pharmaDataService = app.Services.GetRequiredService<PharmaDataService>();
            pharmaDataService.PreparePharmaData();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.UseCors("AllowAllOrigins");

            app.Run();
        }
    }
}
