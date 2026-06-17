using Api_ITI.DTOs;
using Api_ITI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_ITI.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class AccountController : ControllerBase
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
     
        private readonly IConfiguration _config;

        public AccountController(
            UserManager<ApplicationUser> userManager,
        
            IConfiguration config)
        {
            _userManager = userManager;
        
            _config = config;
        }

       
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email 
            };

           
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "User registered successfully!" });
        }

       
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Unauthorized(new { Message = "Invalid Email or Password" });

           
            var isCorrect = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isCorrect)
                return Unauthorized(new { Message = "Invalid Email or Password" });

       
            var token = GenerateJwtToken(user);

            return Ok(new AuthResponseDTO
            {
                Token = token.TokenString,
                Expiration = token.Expiration,
                UserName = user.UserName ?? "",
                Email = user.Email ?? ""
            });
        }

   
        private (string TokenString, DateTime Expiration) GenerateJwtToken(ApplicationUser user)
        {
          
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email,          user.Email ?? ""),
                new Claim(ClaimTypes.Name,           user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

           
            // var roles = await _userManager.GetRolesAsync(user);
            // claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

           
            var secretKey = _config["JWT:SecretKey"]!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

         
            var duration = int.Parse(_config["JWT:DurationInMinutes"]!);
            var expiration = DateTime.UtcNow.AddMinutes(duration);

          
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return (tokenString, expiration);
        }
    }
}
