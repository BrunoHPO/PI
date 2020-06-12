using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;

namespace WhattaMovie.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services)
        {
            services.AddScoped<Logger>((provider) =>
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .WriteTo.File(
                    "LOG_.txt",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
                ).CreateLogger()
            );

            return services;
        }
    }
}
