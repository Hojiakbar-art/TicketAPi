
using Domain.Filters;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Result<PagedResult<UserDTO>>> GetPagedAsync(UserFilter filter, CancellationToken ct);
    Task<Result<UserDTO>> GetByIdAsync(int id);
    Task<Result<UserDTO>> UpdateAsync(int id,  UpdateUserDTO user);
    Task<Result<bool>> DeleteAsync(int id);
}

