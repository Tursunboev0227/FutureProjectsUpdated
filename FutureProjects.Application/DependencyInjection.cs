using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Application.Services.AuthServices;
using FutureProjects.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace FutureProjects.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
