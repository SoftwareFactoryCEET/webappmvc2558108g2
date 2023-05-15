namespace sena.cee.adso.WebApplicationMVC01.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public ICollection<Author> Author { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } //ojo: esto cambia
    }
}
