using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context) 
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")] //get one user
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
