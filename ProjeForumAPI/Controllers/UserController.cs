using DataAccessLayer.Concrete;
using EntityLayer.DTOs;
using EntityLayer.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _db;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO dto)
        {
            if(dto == null)
            {
                return BadRequest("Kullanıcı bilgilerini eksik girdiniz.");
            }
            User user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password) // Şifreyi hash'le
            };
            await _db.Users.AddAsync(user);
            return await _db.SaveChangesAsync() > 0 ? Ok("Kullanıcı başarıyla kayıt edildi.") : BadRequest("Kayıt başarısız.");
        }
    }
}