using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class Violation
    {
        public int Id { get; set; }
        public int memberId { get; set; }         // مفتاح أجنبي
        public virtual Member? member { get; set; }
  
        public string type { get; set; }     // تلفظ - هزار - مشادة
        
        public string note { get; set; }
        
        public string date { get; set; }
        
    }
}
