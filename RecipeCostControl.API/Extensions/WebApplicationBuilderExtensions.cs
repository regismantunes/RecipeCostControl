using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Context;
using RecipeCostControl.Data.Map;
using RecipeCostControl.Data.Repositories.Interfaces;
using RecipeCostControl.Data.Repositories;
using RecipeCostControl.Services.Interfaces;
using RecipeCostControl.Services;
using RecipeCostControl.API.Middlewares;
using RecipeCostControl.API.Routes;

namespace RecipeCostControl.API.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDatabaseComponents(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")))
                .AddScoped<DbContext, MyDbContext>();

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
                .UseAuthorization()
                .UseMiddleware<ExceptionHandlingMiddleware>();

            //app.MapControllers();
            app.AddRoutes();

            return app;
        }
    }
}
