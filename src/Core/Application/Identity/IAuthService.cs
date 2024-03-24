using Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<RegisterResponse> RegisterAdmin(RegisterRequest request);
        Task<string> Logout();

    }
}
