using Domain.Filters;

public class CategoryService(ICategoryRepository _repository) : ICategoryService
{
    private ICategoryRepository repository=_repository;


        
public async Task<Result<CategoryDTO>> CreateAsync(CategoryDTO dto)
{
    if (string.IsNullOrWhiteSpace(dto.Name))
    {
        return Result<CategoryDTO>.Fail(
            "Category name is required.",
            ErrorType.Validation);
    }

    var name = dto.Name.Trim();

    if (name.Length < 2 || name.Length > 100)
    {
        return Result<CategoryDTO>.Fail(
            "Category name must be between 2 and 100 characters.",
            ErrorType.Validation);
    }



    var category = new Category
    {
        Name = name
    };

    await repository.AddAsync(category);

    var categoryDto = new CategoryDTO
    {
        Id = category.Id,
        Name = category.Name
    };

    return Result<CategoryDTO>.Success(categoryDto);
}

    

    public async Task<Result<PagedResult<CategoryDTO>>> GetPagedAsync(CategoryFilter filter, CancellationToken ct)
    {
        var res=await repository.GetPagedAsync(filter, ct);
        var categories=res.Items.Select(x=>new CategoryDTO
        {
            Id=x.Id,
            Name=x.Name
        }).ToList();
        var pagedResult=new PagedResult<CategoryDTO>(categories, res.Page, res.PageSize, res.TotalCount);
        return Result<PagedResult<CategoryDTO>>.Success(pagedResult);        
    }
}