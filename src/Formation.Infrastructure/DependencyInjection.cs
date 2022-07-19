using Formation.Infrastructure.Repositories;
using System.Reflection;

namespace Formation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<FormationDbContext>(options => options
            .UseSqlite(configuration.GetSection("Sqlite").Value));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<AuthorRepository,AuthorRepositoryImp>();

            return services;
        }
    }
}
