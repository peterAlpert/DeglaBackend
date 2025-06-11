using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class DeglaContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<StadeData> stadeDatas { get; set; }
        public DbSet<Violation> violations { get; set; }

        public DeglaContext(DbContextOptions<DeglaContext> options):base(options) { }
        
    }
}
