using System.ComponentModel.DataAnnotations;

namespace KrispyKreme1.Models.ViewModels
{
    public class SaleViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Display(Name = "Donut")]
        public int DonutId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
