namespace BackEnd.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateOnly DateOB { get; set; }
        public int membership { get; set; }
        public int family { get; set; }

    }
}
