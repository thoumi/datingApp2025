using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembersAsync()
        {
            var members = await context.Users.ToListAsync();
            if (members == null) { return NotFound(); };
            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMemberAsync(string id)
        {
            var member = await context.Users.FindAsync(id);
            if (member == null) { return NotFound(); };
            return member;
        }

    }
}
