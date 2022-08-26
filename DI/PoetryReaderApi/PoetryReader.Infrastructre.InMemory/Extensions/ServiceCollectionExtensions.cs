using Microsoft.Extensions.DependencyInjection;
using PoetryReader.Api.Repository;

namespace PoetryReader.Infrastructre.InMemory.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryPoetryReader(this IServiceCollection services)
        => services.AddTransient<IPoetryReader, InMemoryPoetryRepository>();
}