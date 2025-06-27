using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BackEnd.Models
{
    public class DeglaContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Entry> entries { get; set; }
        public DbSet<StadeData> stadeDatas { get; set; }
        public DbSet<Violation> violations { get; set; }
        public DbSet<Injury> injuries { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<User> users { get; set; }

        public DeglaContext(DbContextOptions<DeglaContext> options):base(options) 
        {
            
        }
        
    }
}
