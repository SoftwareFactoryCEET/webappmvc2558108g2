namespace sena.cee.adso.WebApplicationMVC01.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }        
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
    }
}
