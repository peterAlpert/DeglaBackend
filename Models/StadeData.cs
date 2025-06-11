namespace BackEnd.Models
{
    public class StadeData
    {
        public int Id { get; set; }
        public string? memberName { get; set; }
        public int membership { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }

        public int insult { get; set; }
        public int joke { get; set; }
        public int fight { get; set; }

        public string? controlName { get; set; }
        public int stadeNo { get; set; }
    }
}
