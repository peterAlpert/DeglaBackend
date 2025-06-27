namespace BackEnd.Models
{
    public class Member
    {
       
        public int Id { get; set; }
        public string? MemberName { get; set; }
        public int Membership { get; set; }
        public List<Entry>? Entries { get; set; }
        public List<Violation> violations { get; set; }
        public List<Injury> injuries { get; set; }

    }
}
