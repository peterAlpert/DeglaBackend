namespace BackEnd.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int StadiumNo { get; set; }
        public string TimeSlot { get; set; } // زي "18:30"
        public string Type { get; set; } // "full" or "half"
        public DateOnly Date { get; set; } // يتسجل تلقائي بتاريخ اليوم
    }
}
