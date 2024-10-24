using BAI_1.Data;
using BAI_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BAI_1.Repository
{
    public class AccountRes : IAccountRes
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountRes(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
        }
        public async Task<string> SignInAsaync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.PassWord, false, false);

            if(!result.Succeeded)
            {
                return string.Empty;
            }
            var newClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var newKeyc = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["ValidIssuer"],
                audience: configuration["ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(20),
                claims: newClaim,
                signingCredentials: new SigningCredentials(newKeyc, SecurityAlgorithms.HmacSha256Signature)
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignnUpModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };
            return await userManager.CreateAsync(user,model.PassWord);
        }
    }
}
