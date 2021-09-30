using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyBlogProject.BusinessLayer.StringInfos;
using UdemyBlogProject.Entities.Concrete;

namespace UdemyBlogProject.BusinessLayer.Utilities.JwtTools
{
    public class JwtManager : IJwtService
    {
        public JwtToken GenerateToken(AppUser appuser)
        {

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTStrings.SecurityKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(issuer: JWTStrings.Issuer, audience: JWTStrings.Audience, claims: null, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JWTStrings.Expire), signingCredentials: credentials);
  
            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token=handler.WriteToken(securityToken);
            return jwtToken;

        }
       

        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,appUser.Id.ToString()));

            return claims;
        }
    }
}
