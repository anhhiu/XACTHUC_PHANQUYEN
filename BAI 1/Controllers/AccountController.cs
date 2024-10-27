using BAI_1.Models;
using BAI_1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BAI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRes res;

        public AccountController(IAccountRes res)
        {
            this.res = res;
        }
        
        [HttpPost("signUp")]

        public async Task<IActionResult> Register(SignnUpModel model)
        {
            var result = await res.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            try
            {
                var result = await res.SignInAsync(model);

                if (string.IsNullOrEmpty(result))
                {
                    return Unauthorized();
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
