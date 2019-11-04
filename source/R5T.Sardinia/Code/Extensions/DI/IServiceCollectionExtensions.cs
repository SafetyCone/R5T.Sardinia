using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using R5T.Dacia.Extensions;


namespace R5T.Sardinia
{
    public static class IServiceCollectionExtensions
    {
        public static IConfiguration GetConfiguration(this IServiceCollection services)
        {
            var configuration = services.GetIntermediateRequiredService<IConfiguration>();
            return configuration;
        }

        public static IServiceCollection Configure<TOptions>(this IServiceCollection services)
            where TOptions: class // Must be a reference type for the generic parameter of the Configure() method.
        {
            var configuration = services.GetConfiguration();

            services
                .Configure<TOptions>(configuration)
                ;

            return services;
        }
    }
}
