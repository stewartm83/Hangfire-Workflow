using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Hangfire;
using Hangfire.Redis;
using StackExchange.Redis;

namespace Hangfire.Lib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHangfireConnection(this IServiceCollection services, ConnectionMultiplexer Redis)
        {
            services.AddHangfire(configuration =>
            {
                configuration.UseRedisStorage(Redis, new RedisStorageOptions {
                    Prefix = "JobItem_",
                });
            });

            return services;
        }
    }

    public static class RuntimePipelineExtensions
    {
        public static IApplicationBuilder AddHangfireDashboard(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            return app;
        }

        public static IApplicationBuilder AddHangfireServer(this IApplicationBuilder app)
        {
            var options = new BackgroundJobServerOptions
            {
                ServerName = String.Format(
                    "{0}.{1}",
                    Environment.MachineName,
                    Guid.NewGuid().ToString())
            };
            app.UseHangfireServer(options);
            return app;
        }
    }
}
