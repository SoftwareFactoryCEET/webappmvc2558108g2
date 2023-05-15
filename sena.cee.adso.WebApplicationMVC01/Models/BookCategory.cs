using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sena.cee.adso.WebApplicationMVC01.Models
{

    [PrimaryKey(nameof(BookId), nameof(CategoryId))]
    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string User { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
