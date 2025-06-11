using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public DeglaContext context { get; }
        public MemberController(DeglaContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult getMembers()
        {
            List<Member> members = context.Members.ToList();
            return Ok(members);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getMember(int id) {
            Member member = context.Members.FirstOrDefault(mem => mem.ID == id);
            return Ok(member);
        }

        [HttpGet]
        [Route("name")]
        public IActionResult getMemberByName(string name)
        {
            Member member = context.Members.FirstOrDefault(mem => mem.Name.Contains(name));
            return Ok(member);
        }

        [HttpGet]
        [Route("{MemberNo:int}")]
        public IActionResult getMemberByMemberNo(int membership)
        {
            Member member = context.Members.FirstOrDefault(mem => mem.membership == membership);
            return Ok(member);
        }

        [HttpPost]
        public IActionResult addMember(Member member) { 
            context.Members.Add(member);
            context.SaveChanges();
            return CreatedAtAction("getMember",member);
        }

    }
}
