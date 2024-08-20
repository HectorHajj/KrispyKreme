using System;
using System.ComponentModel.DataAnnotations;

namespace KrispyKreme1.Models
{
    [MetadataType(typeof(SaleMetadata))]
    public partial class Sale
    {
    }

    public class SaleMetadata
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int DonutId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }
}