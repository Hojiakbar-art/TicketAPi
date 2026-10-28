using Domain.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService Service) : ApiController
{
    private ICategoryService service=Service;
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCategories( [FromQuery] CategoryFilter filter, CancellationToken ct)
    {
        var result = await service.GetPagedAsync(filter, ct);

        return Ok(result);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create( CategoryDTO dto, CancellationToken ct)
    {
        var result = await service.CreateAsync(dto);

        return ToResponse(result);
    }
}
