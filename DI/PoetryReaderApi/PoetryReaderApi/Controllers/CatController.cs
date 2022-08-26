using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoetryReader.Api.Repository;

namespace PoetryReader.Api.Controllers;

[Route("api/[controller]")]
public class CatController : Controller
{
    private readonly ICat _cat;

    public CatController(ICat cat)
    {
        _cat = cat;
    }

    [HttpGet]
    public async Task<string> Get(CancellationToken cancellationToken)
        => await _cat.Random(cancellationToken);
}