

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using ShelfSpace.Models;
using ShelfSpace.Services;


namespace ShelfSpace;


[ApiController]
[Route("auth")]

public class AuthController : ControllerBase
    {   
        private readonly  IPasswordService _passwordService;
        private readonly ShelfSpaceContext _dbContext;
        private readonly JwtSettings jwtSettings;

        public AuthController(ShelfSpaceContext shelfSpaceContex, IOptions<JwtSettings> options, IPasswordService passwordService)
        {
            this._dbContext=shelfSpaceContex;
            this.jwtSettings=options.Value;
            this._passwordService = passwordService;
        }

        [HttpPost("authenticate")]   
        public async Task<IActionResult> Authenticate(UserCred userCred)
        {
            var user = await this._dbContext.User.FirstOrDefaultAsync(item=>item.Email==userCred.Email);

        if(user==null)
            return Unauthorized();
            // Generate Token 
        if(userCred.Password == null)
            return Unauthorized();

            bool isPasswordValid = _passwordService.VerifyPassword(userCred.Password, user.PasswordHash);
        var tokenhandler = new JwtSecurityTokenHandler();
        var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
        var tokendesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[] { new Claim(ClaimTypes.Name, user.Id)}
    ),      NotBefore = DateTime.UtcNow,
            Expires=DateTime.UtcNow.AddMinutes(30), 
            SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256)
        }; 
        var token=tokenhandler.CreateToken(tokendesc);
        string finaltoken=tokenhandler.WriteToken(token);

        return Ok(new
    {
        Token = finaltoken,
        ExpiresIn = tokendesc.Expires,
        User = new
        {
            user.Id,
            user.Email,
            user.Name,
            user.LastName,
            user.Phone,
            user.Address,
            user.BirthDate,
            user.PasswordHash
        }
    });
    }
    }

