using BusinessLayer.Interfaces;
using BusinessLayer.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Services.TokenServices
{
    public class TokenServices : ITokenServices
    {
        public string CreateToken(IConfiguration configuration, int userId, string username, string role)
        {
            try
            {
                // Configuration kontrolleri
                var securityKey = configuration["Token:SecurityKey"];
                var issuer = configuration["Token:Issuer"];
                var audience = configuration["Token:Audience"];
                var expirationMinutes = configuration["Token:Expiration"];

                if (string.IsNullOrEmpty(securityKey) || string.IsNullOrEmpty(issuer) || 
                    string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(expirationMinutes))
                {
                    throw new InvalidOperationException("Token yapılandırma değerleri eksik.");
                }

                // Token oluşturma
                var token = new Token();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                
                // Token süresi
                var expiration = DateTime.Now.AddMinutes(Convert.ToInt16(expirationMinutes));
                token.Expiration = expiration;

                // Token claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
                };

                // JWT token oluşturma
                var jwtToken = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: expiration,
                    notBefore: DateTime.Now,
                    signingCredentials: credentials
                );

                // Token'ı string'e çevirme
                var tokenHandler = new JwtSecurityTokenHandler();
                token.AccessToken = tokenHandler.WriteToken(jwtToken);

                return token.AccessToken;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Token oluşturulurken bir hata oluştu.", ex);
            }
        }

        public int GetUserIdFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                
                var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    throw new InvalidOperationException("Token içinde kullanıcı ID'si bulunamadı.");
                }

                return Convert.ToInt32(userIdClaim.Value);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Token'dan kullanıcı ID'si alınırken bir hata oluştu.", ex);
            }
        }
    }
}
