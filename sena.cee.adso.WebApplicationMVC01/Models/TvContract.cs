using NuGet.Packaging.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace sena.cee.adso.WebApplicationMVC01.Models
{
    [Table("TvContract")]
    public class TvContract : Contract
    {
        public PackageType PackageType { get; set; }
    }

    public enum PackageType
    {
        S, M, L, XL
    }
}
