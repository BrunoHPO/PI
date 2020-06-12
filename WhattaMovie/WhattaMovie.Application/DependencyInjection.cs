using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WhattaMovie.Domain;

namespace WhattaMovie.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEntityCrudHandler<Movie>>(
                serviceProvider => new MovieHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            services.AddScoped<IEntityCrudHandler<Rating>>(
                serviceProvider => new RatingHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            services.AddScoped<IEntityCrudHandler<Review>>(
                serviceProvider => new ReviewHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            services.AddScoped<UserHandler>(
                serviceProvider => new UserHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            return services;
        }
    }
}
