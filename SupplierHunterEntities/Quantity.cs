// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SupplierHunterEntities
{
    public partial class Quantity
    {
        public int IdQuantity { get; set; }
        public int RidDiscount { get; set; }
        public int Quantity1 { get; set; }
        public int Percentage { get; set; }

        public virtual Discount RidDiscountNavigation { get; set; }
    }
}