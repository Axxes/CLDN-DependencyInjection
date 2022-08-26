using Microsoft.Extensions.Options;

namespace PoetryReader.Infrastructure.TheCatApi.Extensions;

public class TheCatApiOptions
{
    public string Url { get; set; }
    public string Token { get; set; }
}