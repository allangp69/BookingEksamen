using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingEksamenDataManager.Data;
using BookingEksamenDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookingEksamenDataManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : Controller
{
    private readonly DatabaseContext _databaseContext;
    private readonly IConfiguration _configuration;
    
    public TokenController(IConfiguration config, DatabaseContext context)
    {
        _configuration = config;
        _databaseContext = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserInfo _userData)
    {
        if (_userData is null || string.IsNullOrEmpty(_userData.Email) || string.IsNullOrEmpty(_userData.Password))
        {
            return BadRequest();
        }
        var user = await GetUser(_userData.Email, _userData.Password);
        if (user is null)
        {
            return BadRequest("Invalid credentials");
        }
        var token = GenerateToken(user);
        return Ok(token);
    }

    private async Task<UserInfo> GetUser(string email, string password)
    {
        return await _databaseContext.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }

    //private async Task<string> GenerateToken(UserInfo user)
    private async Task<dynamic> GenerateToken(UserInfo user)
    {
        //create claims details based on the user information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("DisplayName", user.DisplayName),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);
        
        var output = new
        {
            Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
            UserName = user.UserName
        };
        return output;
        // return new JwtSecurityTokenHandler().WriteToken(token);
    }
}