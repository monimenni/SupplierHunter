// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SupplierHunterEntities
{
    public partial class Discount
    {
        public Discount()
        {
            ProductSupplier = new HashSet<ProductSupplier>();
            Quantity = new HashSet<Quantity>();
        }

        public int IdDiscount { get; set; }
        public byte Type { get; set; }
        public int? Percentage { get; set; }
        public int? RidSeason { get; set; }

        public virtual Season RidSeasonNavigation { get; set; }
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
        public virtual ICollection<Quantity> Quantity { get; set; }
    }
}