using Application.Authentification;
using Application.BusinessLogic.Objava.Policy;
using Application.Common.Behaviours;
using Application.Shared.Services.Create;
using Application.Shared.Services.Delete;
using Application.Shared.Services.Queries.GetAll;
using Application.Shared.Services.Queries.GetByID;
using Application.Shared.Services.Update;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPermissionService, PermissionService>();

            services.AddScoped(typeof(ObjavaPolicy),typeof(ObjavaPolicy));
            


            return services;
        }
    }
}
