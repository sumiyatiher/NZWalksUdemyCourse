using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalkz.API.Models.DTOs.Login;
using NZWalkz.API.Models.DTOs.Register;
using NZWalkz.API.Repo.TokenJWTRepo;

namespace NZWalkz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IToken tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager, IToken tokenRepo)
        {
            this.userManager = userManager;
            this.tokenRepo = tokenRepo;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto regist)
        {

            var identityUser = new IdentityUser
            {
                UserName = regist.Username,
                Email = regist.Username
            };

            var identityResult =  await userManager.CreateAsync(identityUser, regist.Password);

            if (identityResult.Succeeded)
            {
                //Add role to the user
                if(regist.Role != null && regist.Role.Any())
                {
                    var identityRole = await userManager.AddToRolesAsync(identityUser, regist.Role);

                    if (identityRole.Succeeded)
                    {
                        return Ok("User was registered!");
                    }
                }
            }

            throw new Exception("User sudah ada!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Username);

            if (user != null)
            {
                var isValidPass = await userManager.CheckPasswordAsync(user, login.Password);

                if (isValidPass) 
                {
                    //Get role for this user
                    var role = await userManager.GetRolesAsync(user);

                    if (role != null)
                    {
                        //create token
                        var jwtToken =  tokenRepo.CreateToken(user, role.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or Password incorrect!");
        }
    }
}
