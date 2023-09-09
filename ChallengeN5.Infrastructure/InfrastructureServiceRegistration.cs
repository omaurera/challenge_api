using ChallengeN5.Application.Contracts;
using ChallengeN5.Application.Services;
using ChallengeN5.Infrastructure.Persistence;
using ChallengeN5.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<ChallengeN5DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProduceMessage, ProduceMessage>();
            return services;
        }
	}
}

