
using Application.Interfaces;
using Domain.Filters;

public class UserService(IUserRepository user) : IUserService
{
    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var exist = await user.GetByIdAsync(id);

        if (exist == null)
            return Result<bool>.Fail("Пользователь не найден", ErrorType.NotFound);

        await user.DeleteAsync(exist);

        return Result<bool>.Success(true);
    }

    public async Task<Result<UserDTO>> GetByIdAsync(int id)
    {
        var res = await user.GetByIdAsync(id);

        if (res == null)
        {
            return Result<UserDTO>.Fail("This user not found", ErrorType.NotFound);
        }


        var dto = new UserDTO
        {
            Id = res.Id,
            FirstName = res.FirstName,
            LastName = res.LastName,
            Email = res.Email
        };

        return Result<UserDTO>.Success(dto);
    }

    public async Task<Result<PagedResult<UserDTO>>> GetPagedAsync(UserFilter filter, CancellationToken ct)
    {
        if (filter.Page < 1) filter.Page = 1;
        if (filter.PageSize > 100) filter.PageSize = 100;
        if (filter.PageSize < 10) filter.PageSize = 10;

        var pagedUser = await user.GetPagedAsync(filter, ct);

        var item = pagedUser.Items.Select(us => new UserDTO
        {
            Id = us.Id,
            FirstName = us.FirstName,
            LastName = us.LastName,
            BirthDate = us.BirthDate,
            Email = us.Email!
        }
        ).ToList();


        return Result<PagedResult<UserDTO>>.Success(
            new PagedResult<UserDTO>(item, pagedUser.Page, pagedUser.PageSize, pagedUser.TotalCount)
        );
    }

    public async Task<Result<UserDTO>> UpdateAsync(int id, UpdateUserDTO upUser)
    {
        if (upUser.FirstName == null) return Result<UserDTO>.Fail("FirstName must be not null", ErrorType.Validation);
        if (upUser.LastName == null) return Result<UserDTO>.Fail("LastName must be not null", ErrorType.Validation);

        var exist = await user.GetByIdAsync(id);

        if (exist == null) return Result<UserDTO>.Fail("This user not found", ErrorType.NotFound);

        exist.FirstName = upUser.FirstName.Trim();
        exist.LastName = upUser.LastName.Trim();
        exist.BirthDate = upUser.BirthDate;


        await user.UpdateAsync(exist);

        var dto = new UserDTO
        {
            Id = exist.Id,
            FirstName = exist.FirstName,
            LastName = exist.LastName,
            BirthDate = exist.BirthDate,
            Email = exist.Email
        };

        return Result<UserDTO>.Success(dto);
    }

}