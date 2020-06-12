using Microsoft.Extensions.DependencyInjection;
using WhattaMovie.Application;
using Microsoft.EntityFrameworkCore;

namespace WhattaMovie.Persistency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistency(this IServiceCollection services)
        {
            services.AddDbContext<WhattaMovieDbContext>(options =>
            {                
                options.UseSqlite("Filename=../WhattaMovie.Persistency/WhattaMovie.db", opt =>
                {
                    opt.MigrationsAssembly(
                        typeof(WhattaMovieDbContext).Assembly.FullName
                    );
                });

                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IApplicationDbContext>(ctx =>
                ctx.GetRequiredService<WhattaMovieDbContext>());

            return services;
        }
    }
}
