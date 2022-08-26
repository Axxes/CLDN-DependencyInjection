namespace PoetryReader.Api.Repository;

public interface ICat
{
    Task<string> Random(CancellationToken cancellationToken);
}