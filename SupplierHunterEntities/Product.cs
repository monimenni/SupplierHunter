// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SupplierHunterEntities
{
    public partial class Product
    {
        public Product()
        {
            ProductSupplier = new HashSet<ProductSupplier>();
        }

        public int IdProduct { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}