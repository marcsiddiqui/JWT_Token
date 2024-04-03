using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace First_API.JwtToken
{
    public class JwtService
    {
        private readonly string _issuer;
        private readonly string _secret;
        private readonly int _expMinutes;

        public JwtService(IConfiguration config)
        {
            _issuer = config.GetSection("Jwt").GetSection("Issuer").Value;
            _secret = config.GetSection("Jwt").GetSection("Secret").Value;
            _expMinutes = Convert.ToInt32(config.GetSection("Jwt").GetSection("expInMinutes").Value);
        }

        public string GenerateSecurityToken(string email, int customerId, int roleId, bool isPersist = false)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("Email", email));
            permClaims.Add(new Claim("UserId", customerId.ToString()));
            permClaims.Add(new Claim("RoleId", roleId.ToString()));

            var token = new JwtSecurityToken(_issuer,
              _issuer,
              claims: permClaims,
              // for remember me working
              //expires: !isPersist ? DateTime.Now.AddHours(24) : DateTime.Now.AddMinutes(43200),
              expires: DateTime.Now.AddMinutes(_expMinutes),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
