using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly DeglaContext _context;

        public BookingController(DeglaContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBooking([FromBody] BookingDTO dto)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var existing = await _context.bookings
        .FirstOrDefaultAsync(b =>
            b.Date == today &&
            b.StadiumNo == dto.StadiumNo &&
            b.TimeSlot == dto.TimeSlot);

            if (existing != null)
            {
                return BadRequest("⚠️ هذا التوقيت محجوز بالفعل لهذا الملعب");
            }


            var booking = new Booking
            {
                PlayerName = dto.PlayerName,
                StadiumNo = dto.StadiumNo,
                TimeSlot = dto.TimeSlot,
                Type = dto.Type,
                Date = today
            };

            _context.bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تم تسجيل الحجز بنجاح" });
        }

        // لو حابب تعرض الحجوزات كمان بعدين
        [HttpGet("by-date/{date}")]
        public async Task<IActionResult> GetBookingsByDate(string date)
        {
            if (!DateOnly.TryParse(date, out var parsedDate))
                return BadRequest("صيغة التاريخ غير صحيحة");

            var bookings = await _context.bookings
                .Where(b => b.Date == parsedDate)
                .ToListAsync();

            return Ok(bookings);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.bookings.FindAsync(id);
            if (booking == null)
                return NotFound("لم يتم العثور على الحجز");

            _context.bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تم حذف الحجز" });
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayBookings()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var bookings = await _context.bookings
                .Where(b => b.Date == today)
                .OrderBy(b => b.StadiumNo)
                .ThenBy(b => b.TimeSlot)
                .ToListAsync();

            return Ok(bookings);
        }

    }
}
