//@CodeCopy
//MdStart
using System.ComponentModel.DataAnnotations;

namespace QTDrugPrescription.WebApi.Models
{
    public abstract partial class VersionModel : IdentityModel, Logic.IVersionable
    {
        /// <summary>
        /// Row version of the entity.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
//MdEnd
