using Dapper;
using Microsoft.AspNetCore.Mvc;
using api_sena.Models;
using api_sena.Services;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly Database database;

        public AuthController() {
            this.database = new Database();
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password) {
            var result = this.database.connection.QueryFirstOrDefault<User>($"SELECT * FROM users WHERE email = '{email}'");
            if(result == null) return BadRequest();
            if(result.Password != password) return BadRequest();
            var token = JwtService.Encode(new Dictionary<string, object>{
                { "sub", result.Email! },
                { "iat", DateTimeOffset.UtcNow },
                { "exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds() }
            });
            return Ok(token);
        }

        [HttpPost("signup")]
        public IActionResult Signup(User user) {
            var result = this.database.connection.QueryFirstOrDefault<User>($"SELECT * FROM users WHERE email = '{user.Email}'");
            if(result != null) return BadRequest();
            this.database.connection.Execute($"INSERT INTO users(name, lastName, email, password, cellphoneNumber) VALUES('{user.Name}', '{user.LastName}', '{user.Email}', '{user.Password}', '{user.CellphoneNumber}')");
            string token = JwtService.Encode(new Dictionary<string, object>{
                { "sub", user.Email! },
                { "iat", DateTimeOffset.UtcNow },
                { "exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds() }
            });
            return Accepted(token);
        }
    }
}