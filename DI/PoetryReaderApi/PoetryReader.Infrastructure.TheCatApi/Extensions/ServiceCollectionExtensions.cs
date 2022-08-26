using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PoetryReader.Api.Repository;

namespace PoetryReader.Infrastructure.TheCatApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTheCatApi(this IServiceCollection services, Action<TheCatApiOptions> configure)
    {
        services.Configure(configure);
        
        services
            .AddTransient<ICat, TheCatApiCat>();
        services.AddHttpClient<ICat, TheCatApiCat>((sp, x) =>
        {
            var options = sp.GetRequiredService<IOptions<TheCatApiOptions>>();
            x.BaseAddress = new Uri(options.Value.Url);
            x.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Value.Token);
        });
        return services;
    }
}