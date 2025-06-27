namespace BackEnd.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int StadeNo { get; set; }
        public string ControlName { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
