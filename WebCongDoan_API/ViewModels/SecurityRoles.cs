using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace WebCongDoan_API.ViewModels
{
    public static class AppJwtClaimTypes
    {
        public const string Subject = "sub";
        public const string UserName = "username";
        public const string FullName = "full_name";
        public const string Roles = "roles";


    }


    public static class UserRole
    {
        public const string Admin = "Admin";
        public const string Manager = "Teach";
        public const string User = "User";

        public static readonly IList<string> Roles = new ReadOnlyCollection<string>
            (new List<string>
            {
                Admin,
                Manager,
                User
            });
    }

    public static class TokenHelper
    {


        public static string GenerateToken(string jwtSecret, string issuer, string audience
            , IList<string> userRoles, string id, string userName, string fullName)
        {
            List<Claim> authClaims = new();
            List<Claim> claimRoles = userRoles.Select(s => new Claim(AppJwtClaimTypes.Roles, s)).ToList();

            authClaims.AddRange(new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToLower()),
                new(AppJwtClaimTypes.Subject, id.ToLower()),
                new("id", id),
                new(AppJwtClaimTypes.UserName, userName),
                new(AppJwtClaimTypes.FullName, fullName)
            });

            authClaims.AddRange(claimRoles);

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(jwtSecret));

            JwtSecurityToken token = new(
                issuer,
                audience,
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static DateTime GetValidTo(string jwt)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken? jwtSecurityToken = handler.ReadJwtToken(jwt);
            return jwtSecurityToken.ValidTo;
        }
    }
}