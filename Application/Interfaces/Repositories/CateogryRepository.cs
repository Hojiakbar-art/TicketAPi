using Domain.Filters;

public interface ICategoryRepository
{
    Task<int> AddAsync(Category category);
    Task<int> UpdateAsync(Category category);
    Task<int> DeleteAsync(int id);
    Task<Category?> GetByIdAsync(int id);
    Task<PagedResult<Category>> GetPagedAsync(CategoryFilter filter, CancellationToken ct);
}