

public interface IAuthService
{
    Task<Result<UserDTO>> RegisterAsync(RegisterDTO dto);
    Task<Result<AuthResponse>> LoginAsync(LoginDTO dto);
    Task<Result<string>> ForgotPasswordAsync(ForgotPasswordDTO dto);
    Task<Result<string>> ResetPasswordAsync(ResetPasswordDTO dto);
}