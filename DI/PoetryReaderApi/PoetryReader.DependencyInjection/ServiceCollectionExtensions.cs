using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoetryReader.Api.Repository;
using PoetryReader.Core.Models;
using PoetryReader.Infrastructre.InMemory.Extensions;
using PoetryReader.Infrastructure.TheCatApi.Extensions;

namespace PoetryReader.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPoetryReaderDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddInMemoryPoetryReader()
            .AddTheCatApi(x =>
            {
                x.Url = configuration["THECATAPI_DEFAULTURL"];
                x.Token = "SECRET";
            })
            .AddTransient<ICatWithPoem, PoetryReader.Application.CatWithPoem>();
    }
}