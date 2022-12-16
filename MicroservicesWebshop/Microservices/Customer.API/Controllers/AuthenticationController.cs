using Customer.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        
        public AuthenticationController(UserManager<IdentityUser> userManager                                       )
        {
            _userManager = userManager;          
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            //Check if the model is valid
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Model is not valid!" });
            }

            //Check if we already have an existing user
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if(userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    new Response { Status = "Error", Message = "User already exists!" });
            }

            //Creating and checking if the user was successfully created 
            IdentityUser newUser = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if(!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                  new Response { Status = "Error", 
                                                 Message = "User creation failed! Please check user details and try again." });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //Check if the model is valid
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Model is not valid!" });
            }

            //Check if the user exists and the password is correct
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "User or password does not exist!" });
            }

            //Set token requirements
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim("UserID", user.Id.ToString())    
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr")), 
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            //Creating and writing the token based on the received requirements
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { token });
        }
    }
}
