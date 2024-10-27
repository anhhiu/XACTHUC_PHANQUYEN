using BAI_1.Models;
using Microsoft.AspNetCore.Identity;

namespace BAI_1.Repository
{
    public interface IAccountRes
    {
        public Task<IdentityResult> SignUpAsync(SignnUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
