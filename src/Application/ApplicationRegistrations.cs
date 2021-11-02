using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using SharedKernel;

namespace Application
{
    public static class ApplicationRegistrations
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // register all mediator handlers
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // register all fluent validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // intercept all MediatR handlers with ValidationBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
