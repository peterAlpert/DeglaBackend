namespace BackEnd.Models
{
    public class Violation
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string Membership { get; set; }
        public string Type { get; set; }     // تلفظ - هزار - مشادة
        public string Note { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
