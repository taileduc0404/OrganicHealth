using Application.Models.Identity;

namespace Application.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<RegisterResponse> RegisterAdmin(RegisterRequest request);
        //Task<ForgotPasswordResponse> ForgotPasswordByEmail(ForgotPasswordRequest request);
        Task<string> Logout();

    }
}
