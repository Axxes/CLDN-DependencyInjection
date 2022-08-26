using System.Net.Http.Json;
using PoetryReader.Api.Repository;
using PoetryReader.Infrastructure.TheCatApi.Models;

namespace PoetryReader.Infrastructure.TheCatApi;

internal class TheCatApiCat : ICat
{
    private readonly HttpClient _httpClient;

    public TheCatApiCat(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Random(CancellationToken cancellationToken)
    {
        var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApiCat>>("/v1/images/search", cancellationToken: cancellationToken);

        return result!.Single().Url.ToString();
    }
}