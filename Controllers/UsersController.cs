using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ShelfSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShelfSpaceContext _context;
        private readonly  IPasswordService _passwordService;

        public UsersController (ShelfSpaceContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService; 
        }

        

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([Bind("Id,Name,LastName,Email,Phone,Address,BirthDate,PasswordHash")] User user)
        { 
            var hashedPassword = _passwordService.HashPassword(user.PasswordHash);

            user.PasswordHash = hashedPassword;

            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
    
            if (existingUser != null)
            {
                // If a user with the same email exists, return a conflict response
                return BadRequest("Email is already in use.");
            
            }
            Console.WriteLine("user: " + user.Name, user.Address, user);
            if (ModelState.IsValid)
            {
                try {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return Ok("User Created");
                }
                catch{
                    return StatusCode(500);
                }
                
            }
            return BadRequest("Invalid User Data");
        }

        
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null || !_context.User.Any(u => u.Id == user.Id))
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = _context.User.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Address = user.Address;
            existingUser.Phone = user.Phone;
            existingUser.BirthDate = user.BirthDate;

            _context.SaveChanges();

            return Ok("User profile updated successfully.");
        }

        [HttpGet("{userId}")]
    public async Task<IActionResult> GetMediaByUserId(string userId)
    {
        var mediaItems = await _context.Media
            .Where(m => m.UserId == userId)
            .ToListAsync();

        return Ok(mediaItems);
    }
    }
}
