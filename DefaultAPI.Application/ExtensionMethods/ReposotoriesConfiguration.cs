
using DefaultAPI.Domain.Interfaces.Repositories;
using DefaultAPI.Infra.Repositories;

namespace DefaultAPI.Application.ExtensionMethods
{
    public static class ReposotoryConfiguration
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection service)
        {
            service.AddScoped<IDefaultRepository, DefaultReposotory>();
            return service;
        }
    }
}
