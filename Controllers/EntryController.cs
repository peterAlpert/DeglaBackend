using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        public DeglaContext DeglaContext { get; }
        public EntryController(DeglaContext deglaContext)
        {
            DeglaContext = deglaContext;
        }

        [HttpGet("by-member/{memberId}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntriesByMember(int memberId)
        {
            var entries = await DeglaContext.entries
                .Where(e => e.MemberId == memberId)
                .OrderByDescending(e => e.Time)
                .ToListAsync();

            if (entries == null || entries.Count == 0)
            {
                return NotFound("لا توجد سجلات لهذا العضو");
            }

            return Ok(entries);
        }

        [HttpGet("first-entries")]
        public async Task<IActionResult> GetFirstEntryPerMember()
        {
            var data = await DeglaContext.Members
                .Include(m => m.Entries)
                .Select(m => new {
                    m.Id,
                    m.MemberName,
                    m.Membership,
                    FirstEntry = m.Entries.OrderBy(e => e.Time).FirstOrDefault()
                })
                .Where(m => m.FirstEntry != null)
                .ToListAsync();

            return Ok(data);
        }


        [HttpPost("register-entry")]
        public async Task<IActionResult> RegisterEntry([FromBody] StadiumLogDto dto)
        {
            var member = await DeglaContext.Members.FirstOrDefaultAsync(m => m.Membership == dto.Membership);
            bool isNewMember = false;

            if (member == null)
            {
                member = new Member
                {
                    MemberName = dto.MemberName,
                    Membership = dto.Membership
                };
                DeglaContext.Members.Add(member);
                await DeglaContext.SaveChangesAsync();
                isNewMember = true;
            }
            var entry = new Entry
            {
                Member = member,
                MemberId = member.Id,
                Date = DateOnly.Parse(dto.Date),
                Time = TimeOnly.Parse(dto.Time),
                StadeNo = dto.StadeNo,
                ControlName = dto.ControlName
            };

            DeglaContext.entries.Add(entry);
            await DeglaContext.SaveChangesAsync();

            return Ok(new
            {
                message = "تم تسجيل الدخول بنجاح",
                newMember = isNewMember
            });
        }

        [HttpGet("HasEnteredToday/{membership}")]
        public async Task<IActionResult> HasEnteredToday(int membership)
        {
            var member = await DeglaContext.Members
                .FirstOrDefaultAsync(m => m.Membership == membership);

            if (member == null)
                return Ok(false);

            var today = DateOnly.FromDateTime(DateTime.Today);

            var hasEntry = await DeglaContext.entries
                .AnyAsync(e => e.MemberId == member.Id && e.Date == today);

            return Ok(hasEntry);
        }


    }
}
