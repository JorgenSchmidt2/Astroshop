using System.ComponentModel.DataAnnotations;

namespace Astroshop.Core.Entities
{
    public class UserCartElement
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string? OrderDate { get; set; }
    }
}