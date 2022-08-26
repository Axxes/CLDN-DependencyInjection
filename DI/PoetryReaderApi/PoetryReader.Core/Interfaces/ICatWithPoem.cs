using PoetryReader.Core.Models;

namespace PoetryReader.Api.Repository;

public interface ICatWithPoem
{
    Task<CatWithPoem> Random(CancellationToken cancellationToken);
}