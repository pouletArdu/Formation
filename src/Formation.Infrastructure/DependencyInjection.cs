using Formation.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FormationDbContext>(options => options
              .UseSqlite(configuration.GetSection("Sqlite").Value));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<AuthorRepository, AuthorRepositoryImp>();

            return services;
        }
    }
}
