using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProjeForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenServices _tokenServices;
        private readonly IUserApiServices _userApiService;

        public TokenController(IConfiguration configuration, ITokenServices tokenServices, IUserApiServices userService)
        {
            _configuration = configuration;
            _tokenServices = tokenServices;
            _userApiService = userService;
        }

        [HttpPost("getToken")]
        public async Task<IActionResult> GetToken([FromBody] LoginRequestDTO loginRequest)
        {
            try
            {
                var user = await _userApiService.ValidateUser(loginRequest.Username, loginRequest.Password);
                if (user == null)
                {
                    return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
                }

                var token = _tokenServices.CreateToken(
                    _configuration,
                    user.Id,
                    user.Username,
                    user.Role
                );

                return Ok(new LoginResponseDTO
                {
                    Token = token,
                    Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(_configuration["Token:Expiration"])),
                    User = new UserLoginDTO
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        Role = user.Role
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Token oluşturulurken bir hata oluştu", error = ex.Message });
            }
        }
    }
}
