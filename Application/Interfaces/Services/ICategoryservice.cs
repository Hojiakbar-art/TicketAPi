using Domain.Filters;

public interface ICategoryService
{
    Task<Result<PagedResult<CategoryDTO>>> GetPagedAsync(CategoryFilter filter, CancellationToken ct);
    Task<Result<CategoryDTO>> CreateAsync(CategoryDTO dto);
}