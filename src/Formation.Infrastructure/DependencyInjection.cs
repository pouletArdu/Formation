using System.Reflection;

namespace Formation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var assembly = Assembly.GetExecutingAssembly();
        services.AddDbContext<FormationDbContext>(options => options
            .UseSqlite(configuration.GetSection("Sqlite").Value));
        services.AddAutoMapper(assembly);
        services.AddScoped<IAuthorRepository, AuthorRepositoryImp>();
        services.AddScoped<IBookRepository, BookRepositoryImp>();

        return services;
    }
}
