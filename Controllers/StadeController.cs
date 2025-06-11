using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadeController : ControllerBase
    {

        public DeglaContext context { get; }
        public StadeController(DeglaContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult getStadesData()
        {
            List<StadeData> stads = context.stadeDatas.ToList();
            return Ok(stads);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult getById(int id)
        {
            List<StadeData> stades = context.stadeDatas
                .Where(s => s.Id == id).ToList();
            return Ok(stades);
        }

        [HttpGet]
        [Route("byStadeNo")]
        public IActionResult getStade(int stadeNo)
        {
            List<StadeData> stades = context.stadeDatas
                .Where(s => s.stadeNo == stadeNo).ToList();
            return Ok(stades);
        }

        [HttpGet("ByDate")]
        public IActionResult GetByDate(string date)
        {
            if (!DateOnly.TryParse(date, out var parsedDate))
                return BadRequest("Invalid date format");

            var records = context.stadeDatas
                .Where(r => r.date == parsedDate)
                .ToList();

            return Ok(records);
        }

        
        [HttpPost("addStadeData")]
        public IActionResult addStadeData(StadeData stadeData)
        {
            context.stadeDatas.Add(stadeData);
            context.SaveChanges();
            return CreatedAtAction("getById", stadeData);
        }


        [HttpPost("add-insult/{id}")]
        public async Task<IActionResult> AddInsult(int id)
        {
            var item = await context.stadeDatas.FindAsync(id);
            if (item == null)
                return NotFound();

            item.insult += 1;
            await context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPost("add-joke/{id}")]
        public async Task<IActionResult> AddJoke(int id)
        {
            var item = await context.stadeDatas.FindAsync(id);
            if (item == null)
                return NotFound();

            item.joke += 1;
            await context.SaveChangesAsync();

            return Ok(item);
        }


        [HttpPost("add-fight/{id}")]
        public async Task<IActionResult> AddFight(int id)
        {
            var item = await context.stadeDatas.FindAsync(id);
            if (item == null)
                return NotFound();

            item.fight += 1;
            await context.SaveChangesAsync();

            return Ok(item);
        }



    }
}
