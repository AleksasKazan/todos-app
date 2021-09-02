﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services
                .AddSqlClient()
                .AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<ITodosRepository, TodosRepository>();
        }

        private static IServiceCollection AddSqlClient(this IServiceCollection services)
        {
            var fluentConnectionStringBuilder = new FluentConnectionStringBuilder();

            var connnectionString = fluentConnectionStringBuilder
                .AddServer("localhost")
                .AddPort(3306)
                .AddUserId("root")
                .AddPassword("rootroot")
                .AddDatabase("TodosApp")
                .BuildConnectionString(true);
            return services.AddTransient<ISqlClient>(_ => new SqlClient(connnectionString));
        }
    }
}
