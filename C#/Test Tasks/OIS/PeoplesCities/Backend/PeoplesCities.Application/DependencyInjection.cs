using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PeoplesCities.Application.Common.Behaviors;
using PeoplesCities.Application.Interfaces;
using System.Reflection;

namespace PeoplesCities.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
