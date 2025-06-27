using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly DeglaContext _context;

        public ViolationController(DeglaContext context)
        {
            _context = context;
            
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddViolation([FromBody] Violation violation)
        {
            //var member = await _context.Members.FindAsync(violation.memberId);
            //if (member == null)
            //    return NotFound("العضو غير موجود");

            _context.violations.Add(violation);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("get-by-member/{memberId}")]
        public async Task<IActionResult> GetViolationsByMember(int memberId)
        {
            var violations = await _context.violations
                .Where(v => v.memberId == memberId)
                .OrderByDescending(v => v.date)
                .ToListAsync();

            return Ok(violations);
        }
    }
}
