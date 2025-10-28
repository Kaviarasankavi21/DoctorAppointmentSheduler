using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoctorAppointmentScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuth authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] Authdto authDto)
        {
            if (authDto == null || string.IsNullOrWhiteSpace(authDto.Username) || string.IsNullOrWhiteSpace(authDto.Hashedpassword))
            {
                return BadRequest("Invalid login request.");
            }

            // 1. Validate the user
            // This method should now use a secure hashing library to compare passwords.
            var user = _authRepository.ValidateUser(authDto.Username, authDto.Hashedpassword);

            if (user == null)
            {
                // Return Unauthorized if the user is not found or password validation fails.
                return Unauthorized("Invalid username or password.");
            }

            // 2. JWT settings from appsettings.json
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Create claims from the validated user object
            var claims = new[]
            {
                new Claim("Userid", user.Userid.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            Console.WriteLine("User authenticated: " + user.Username);

            // 4. Create the JWT token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresMinutes"])),
                signingCredentials: creds
            );

            // 5. Return the token in a JSON response
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) , userId = user.Userid.ToString(), });
        }
    }
}