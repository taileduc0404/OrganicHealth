using Application.Exceptions;
using Application.Identity;
using Application.Models.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Services
{
    public class AuthServices : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;


        public AuthServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Username!);

            if (user == null)
            {
                throw new NotFoundException($"User with '{request.Username}' not found.", request.Username!);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password!, false);

            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Credentials for '{request.Username}' aren't valid.");
            }

            //JwtSecurityToken jwtSecurityToken = await GenerateTokenAsync(user);   cách 1
            var jwtSecurityToken = await GenerateTokenAsync(user);         //cách 2

            var response = new AuthResponse
            {
                Id = user.Id,
                //Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Token = jwtSecurityToken,
                Email = user.Email,
                Username = user.UserName

            };

            return response;
        }

        public async Task<string> Logout()
        {
            // Đăng xuất người dùng
            await _signInManager.SignOutAsync();

            // Xóa cookie hiện tại
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return "Đăng xuất thành công";
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
            };

            //var result = await _userManager.CreateAsync(user, request.Password!);
            var result = await _userManager.CreateAsync(user, request.Password!);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(WebsiteRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.User));
                }
                await _userManager.AddToRoleAsync(user, WebsiteRoles.User);
                return new RegisterResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        public async Task<RegisterResponse> RegisterAdmin(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
            };

            //var result = await _userManager.CreateAsync(user, request.Password!);
            var result = await _userManager.CreateAsync(user, request.Password!);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(WebsiteRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Admin));


                await _userManager.AddToRoleAsync(user, WebsiteRoles.Admin);
                return new RegisterResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        //private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            
            //var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                //tạo 1 claim mới với kiểu là Role, giá trị là role
                var claim = new Claim(ClaimTypes.Role, role);
                //Add các claim vừa tạo có trong danh sách rols vào roleClaims
                roleClaims.Add(claim);  
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("User Id", user.Id),
                new Claim("First Name", user.FirstName!),
                new Claim("Last Name", user.LastName!)

            }
            //.Union(userClaims)
            .Union(roleClaims); // dùng onion để kết hợp roleClaims vào mảng claims


            // khóa bảo mật được lấy trong config (appsettings.cs)
            var key_JWTSettings = _jwtSettings.Key;

            // chuyển đổi khóa bảo mật thành marng byte, dùng mã háo utf8
            var key = Encoding.UTF8.GetBytes(key_JWTSettings!);

            // tạo 1 đối tượng SymmetricSecurityKey mới từ mã bảo mật để cấu hình cho xác thực
            var symmetricSecurityKey = new SymmetricSecurityKey(key);

            // tạo chữ ký với cấu hình symmetricSecurityKey và thuật toán HmacSha256
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //tạo biến lưu trữ các thông tin token
            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddHours(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);

            var response= new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return response;
        }
	}
}
