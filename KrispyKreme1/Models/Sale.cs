//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KrispyKreme1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int Id { get; set; }
        public System.DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public int DonutId { get; set; }
        public int Quantity { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Donut Donut { get; set; }
    }
}
