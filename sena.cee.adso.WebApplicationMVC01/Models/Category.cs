namespace sena.cee.adso.WebApplicationMVC01.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<BookCategory> 
            BookCategories { get; set; } //ojo esto cambia
    }
}
