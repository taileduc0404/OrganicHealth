using Application.Identity;
using Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AuthServices : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterResponse> Register(RegisterResponse request)
        {
            throw new NotImplementedException();
        }
    }
}
