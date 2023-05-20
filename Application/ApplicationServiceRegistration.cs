using Application.BusinessLogic.Shared;
using Application.BusinessLogic.Shared.Create;
using Application.BusinessLogic.Shared.Delete;
using Application.BusinessLogic.Shared.Queries.GetByID;
using Application.BusinessLogic.Shared.Update;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
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
            services.AddScoped(typeof(CreateCommandHandler<,>),typeof(CreateCommandHandler<,>));
            services.AddScoped(typeof(DeleteCommandHandler<,>),typeof(DeleteCommandHandler<,>));
            services.AddScoped(typeof(UpdateCommandHandler<,>),typeof(UpdateCommandHandler<,>));
            services.AddScoped(typeof(GetByIdQueryHandler<,,>),typeof(GetByIdQueryHandler<,,>));
            return services;
        }
    }
}
