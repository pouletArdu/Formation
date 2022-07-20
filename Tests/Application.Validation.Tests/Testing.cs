using Application.Validation.Tests.Drivers;
using Formation.Application;
using Formation.Application.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Application.Validation.Tests
{
    [SetUpFixture]
    public class Testing
    {
        private static IServiceScopeFactory _scopeFactory = null!;
        private static readonly List<object> _repositories = new();

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddApplication();
            services.AddScoped<AuthorRepository, AuthorRepositoryMock>();
            _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
        }
        public async static Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

            return await mediator.Send(request);
        }

        public static T GetService<T>() where T : notnull
        {
            var repository = _repositories.FirstOrDefault(r => r is T);
            if (repository == null)
            {
                using var scope = _scopeFactory.CreateScope();
                repository = scope.ServiceProvider.GetRequiredService<T>();
                _repositories.Add(repository);
            }
            return (T)repository;
        }
    }
}
