using Microsoft.Extensions.DependencyInjection;
using System;
using TestDapper.DapperImplementation.Connection;
using TestDapper.Domain.Models;
using TestDapper.Domain.Repositories;
using TestDapper.IRepositories;

namespace TestDapper.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            string connectionString = "Server=localhost,1433; Database=WrapperDb;User Id=sa; Password=Password1!;";

            services.AddTransient<IDatabaseConnectionFactory>(conn => {
                return new SqlConnectionFactory(connectionString);
            });
            
            services.AddScoped<IGeneralRepository<Product>, GeneralRepository<Product>>();

            return services;
        }
    }
}
