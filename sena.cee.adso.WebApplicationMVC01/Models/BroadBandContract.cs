using System.ComponentModel.DataAnnotations.Schema;

namespace sena.cee.adso.WebApplicationMVC01.Models
{

    [Table("BroadBandContract")]
    public class BroadBandContract : Contract
    {
        public int DownloadSpeed { get; set; }
    }
}
