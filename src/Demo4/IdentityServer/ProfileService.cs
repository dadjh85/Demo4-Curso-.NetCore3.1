using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            ClaimsPrincipal principal = new ClaimsPrincipal();

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            claims.Add(new Claim(JwtClaimTypes.Email, context.Subject.Claims.FirstOrDefault<Claim>(c => c.Type == JwtClaimTypes.Email).Value));
            claims.Add(new Claim(JwtClaimTypes.Role, context.Subject.Claims.FirstOrDefault<Claim>(c => c.Type == JwtClaimTypes.Role).Value));
            claims.Add(new Claim(JwtClaimTypes.Name, context.Subject.Claims.FirstOrDefault<Claim>(c => c.Type == JwtClaimTypes.Name).Value));
            if (context.Subject.Claims.FirstOrDefault<Claim>((Func<Claim, bool>)(c => c.Type == "team")) != null)
                claims.Add(new Claim("team", context.Subject.Claims.FirstOrDefault<Claim>(c => c.Type == "team").Value));

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
