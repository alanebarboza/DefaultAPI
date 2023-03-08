using DefaultAPI.Domain.Commands.Default;
using DefaultAPI.Infra.Context;
using DefaultAPI.Services.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DefaultAPI.Application.ExtensionMethods
{
    public static class APIConfiguration
    {
        public static IServiceCollection ConfigureAPI(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            return service;
        }
        public static IServiceCollection ConfigureDataBase(this IServiceCollection service, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration.GetSection("UseInMemoryDb").Value))
                service.AddDbContext<DefaultDbContext>(options => options.UseInMemoryDatabase("DefaultConnection"));
            else
                service.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(configuration.GetSection("SQLConnection").Value));
            return service;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection service) => service.AddSwaggerGen();
        public static IServiceCollection ConfigureMediatR(this IServiceCollection service) => service.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DefaultClassHandler).Assembly));
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection service) => service.AddAutoMapper(typeof(DefaultClassCreateCommand).Assembly);

        public static IServiceCollection AddCorsAllowAll(this IServiceCollection service) =>
            service.AddCors(opt => opt.AddPolicy("AllowAll", (x) => x
                                                     .AllowAnyOrigin()
                                                     .AllowAnyHeader()
                                                     .AllowAnyMethod()));

        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }

        public static IApplicationBuilder UseCorsAllowAll(this IApplicationBuilder app) => app.UseCors("AllowAll");

        public static IApplicationBuilder UseHttpAuthorization(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            return app;
        }
    }
}
