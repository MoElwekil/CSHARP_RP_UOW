namespace Store.Web.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ProducedBy { get; set; }
        public string? Description { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime ProducedOn { get; set; }
    }
}
