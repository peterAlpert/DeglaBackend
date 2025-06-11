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

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory([FromQuery] string name, [FromQuery] string membership)
        {
            var violations = await _context.violations
                .Where(v => v.MemberName == name && v.Membership == membership)
                .ToListAsync();

            return Ok(violations);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddViolation([FromBody] ViolationDto violation)
        {
            if (violation == null)
                return BadRequest("Invalid data");

            var newViolation = new Violation
            {
                MemberName = violation.MemberName,
                Membership = violation.Membership,
                Type = violation.Type,
                Note = violation.Note,
                Date = violation.Date,
                Time = violation.Time
            };

            _context.violations.Add(newViolation);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Violation saved" });
        }
    }
}
