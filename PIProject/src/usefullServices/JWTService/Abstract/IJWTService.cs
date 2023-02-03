using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTService.Abstract
{
    public interface IJWTService
    {
        string GenerateToken(string tokenKey, List<Claim> claims, int durationDay);
        bool VerifyToken(string token);
        Claim DegenerateToken(string token, string claimType);
    }
}
