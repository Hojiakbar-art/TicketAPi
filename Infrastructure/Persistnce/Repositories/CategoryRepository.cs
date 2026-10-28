using Domain.Filters;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository(AppDbContext appContext) : ICategoryRepository
{
    private AppDbContext context=appContext;
    public async Task<int> AddAsync(Category category)
    {
        context.Categories.Add(category);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var res=await context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
        if (res != null)
        {
            context.Categories.Remove(res);
        }
        return await context.SaveChangesAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await context.Categories.SingleOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<PagedResult<Category>> GetPagedAsync(CategoryFilter filter, CancellationToken ct)
    {
        var query=context.Categories.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var search=filter.Search.ToLower().Trim();
            query=query.Where(x=>x.Name.ToLower().Trim().Contains(search));

        }
        return await query.ToPagedListAsync(filter.Page, filter.PageSize, ct);
    }

    public async Task<int> UpdateAsync(Category category)
    {
        context.Categories.Update(category);
        return await context.SaveChangesAsync();
    }
}