using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoetryReader.Api.Repository;

namespace PoetryReader.Api.Controllers;

[Route("api/[controller]")]
public class CatWithPoemController : Controller
{
    private readonly ICatWithPoem _catWithPoem;

    public CatWithPoemController(ICatWithPoem catWithPoem)
    {
        _catWithPoem = catWithPoem;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await _catWithPoem.Random(cancellationToken);

        return Ok(result);
    }
}