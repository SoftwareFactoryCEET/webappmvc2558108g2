using System.ComponentModel.DataAnnotations;

namespace sena.cee.adso.WebApplicationMVC01.Models;


public class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name ="Nombres")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A name must be between five and twenty characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Display(Name ="Apellidos")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "A name must be between five and twenty characters.")]
   public string LastName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }


    //Ejemplo de otros Scafold
    [Required(ErrorMessage ="El campo {0} es obligatorio")]
    [EmailAddress(ErrorMessage ="Ingrese una dirección de correo electronico válida")]
    public string Email { get; set; }

    
    [Range(minimum:18, maximum:100, ErrorMessage ="El valor debe estar en el rango {1} a {2}")]
    public int Age { get; set; }

    
    [Url(ErrorMessage ="Ingrese una URL válida")]
    public string URL { get; set; }

    [CreditCard(ErrorMessage ="número de tarjeta de Crédito no válido")]
    [Display(Name ="Tarjeta de Crédito")]
    public string CreditCard { get; set; }

}