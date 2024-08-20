using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KrispyKreme1.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
    }

    public class CustomerMetadata
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}