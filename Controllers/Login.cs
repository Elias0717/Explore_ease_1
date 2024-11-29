using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExploreEase.Context;
using Explore_ease.Models;

namespace Explore_ease.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ExploreEaseContext _context;

		public AuthController(IConfiguration configuration, ExploreEaseContext context)
		{
			_configuration = configuration;
			_context = context;
		}

		[HttpPost("Login")]
		public IActionResult Login([FromBody] LoginRequest login)
		{
			if (login == null || string.IsNullOrEmpty(login.Email))
			{
				return BadRequest("Invalid request");
			}

			// Validar si el correo existe en la tabla Person
			var user = _context.Person.FirstOrDefault(p => p.Correo == login.Email);

			if (user == null)
			{
				return Unauthorized("Invalid credentials");
			}

			// Generar el token JWT
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Nombre), // Usar el nombre de la persona
                new Claim(ClaimTypes.Email, user.Correo), // Agregar el correo como claim
            };

			var tokenOptions = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddHours(12),
				signingCredentials: signinCredentials
			);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return Ok(new { Token = tokenString });
		}
	}

	public class LoginRequest
	{
		public string Email { get; set; }
	}
}
