namespace BackEnd.Models
{
    public class Injury
    {
        public int Id { get; set; }

        public int memberId { get; set; }         // مفتاح أجنبي
        public Member? member { get; set; }

        public string type { get; set; }     // كدمة، جرح، ...
        public string location { get; set; } // الركبة، الكتف، ...
        public string actionTaken { get; set; }    // الإجراء المتخذ
        public int stadeNo { get; set; }           // رقم الملعب
        public string date { get; set; }
    }
}
