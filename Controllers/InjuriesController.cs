using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjuriesController : ControllerBase
    {
        private readonly DeglaContext _context;

        public InjuriesController(DeglaContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddInjury([FromBody] Injury injury)
        {
            try
            {
                //var member = await _context.Members.FindAsync(injury.memberId);
                //if (member == null)
                //    return NotFound("العضو غير موجود");

                _context.injuries.Add(injury);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"🔥 Error while adding injury: {ex.Message}");
                return StatusCode(500, $"Server Error: {ex.Message}");
            }
        }

        [HttpGet("get-by-member/{memberId}")]
        public async Task<IActionResult> GetInjuriesByMember(int memberId)
        {
            var injuries = await _context.injuries
                .Where(i => i.memberId == memberId)
                .OrderByDescending(i => i.date)
                .ToListAsync();

            return Ok(injuries);
        }
    }

}
