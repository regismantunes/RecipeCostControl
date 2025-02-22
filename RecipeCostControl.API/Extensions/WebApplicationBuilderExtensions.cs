using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Context;
using RecipeCostControl.Data.Map;
using RecipeCostControl.Data.Repositories.Interfaces;
using RecipeCostControl.Data.Repositories;
using RecipeCostControl.Services.Interfaces;
using RecipeCostControl.Services;
using RecipeCostControl.API.Middlewares;
using RecipeCostControl.API.Extensions;
using RecipeCostControl.Data.Extensions;

namespace RecipeCostControl.API.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDatabaseComponents(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDbContext<AppDbContext>(options =>
                    options.UseConfiguration(builder.Configuration))
                .AddScoped<DbContext, AppDbContext>();

            return builder;
        }

        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            return builder;
        }

        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IMeasurementUnitRepository, MeasuremantUnitRepository>();

            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped(typeof(IService<>), typeof(Service<>))
                .AddScoped<IMeasuremantUnitService, MeasuremantUnitService>();

            return builder;
        }

        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAutoMapper(config => config.AddProfile<MappingProfile>());

            return builder;
        }

        public static WebApplication BuildConfiguredApplication(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseHttpsRedirection()
                .UseMiddleware<ExceptionHandlingMiddleware>();

            //app.MapControllers();
            app.AddRoutes();

            return app;
        }
    }
}
