using PoetryReader.Api.Repository;

namespace PoetryReader.Application;

public class CatWithPoem : ICatWithPoem
{
    private readonly ICat _cat;
    private readonly IPoetryReader _poetryReader;

    public CatWithPoem(ICat cat, IPoetryReader poetryReader)
    {
        _cat = cat;
        _poetryReader = poetryReader;
    }

    public async Task<Core.Models.CatWithPoem> Random(CancellationToken cancellationToken)
    {
        var catUrl = await _cat.Random(cancellationToken);
        var poem = _poetryReader.GetAPoem();

        return new Core.Models.CatWithPoem(catUrl, poem);
    }
}