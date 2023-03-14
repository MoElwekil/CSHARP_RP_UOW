using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? ProducedBy { get; set; }
        public string? Description { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime ProducedOn { get; set; }
        public DateTime InsertedOn { get; set; } = DateTime.Now;
    }
}
