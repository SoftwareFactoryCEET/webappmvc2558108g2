using System.ComponentModel.DataAnnotations.Schema;

namespace sena.cee.adso.WebApplicationMVC01.Models
{
    [Table("MobileContract")]
    public class MobileContract : Contract
    {
        public string MobileNumber { get; set; }
    }
}
