using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace sena.cee.adso.WebApplicationMVC01.Models;


public class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name ="Nombres")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A {0} must be between {2} and {1} characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name ="Apellidos")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A {0} must be between {2} and {1} characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name = "Ciudad")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A {0} must be between {2} and {1} characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name = "País")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A {0} must be between {2} and {1} characters.")]
    public string Country { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name = "Teléfono")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "The size of the phone field is 11 characters.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "The {0} format is invalid.")]
    public string Phone { get; set; }

    public ICollection<Order> Orders { get; set; }
    
}