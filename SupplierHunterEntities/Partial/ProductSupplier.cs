using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierHunterEntities
{
    public enum DiscountType : byte
    {
        Total = 0,
        Quantity = 1,
        Season = 2,
    }

    public partial class ProductSupplier
    {
        public decimal GetTotal(int orderQuantity, DateTime? orderDate)
        {
            var total = this.UnitPrice * orderQuantity;

            int discountPercentage = 0;
            //se è presente uno sconto
            if (this.RidDiscountNavigation != null)
            {
                //devo valutare il tipo di sconto
                switch (this.RidDiscountNavigation.Type)
                {
                    case (byte)DiscountType.Total:
                        discountPercentage = this.RidDiscountNavigation.Percentage ?? 0;
                        break;
                    case (byte)DiscountType.Quantity:
                        //se è sconto basato sulla quantità devo prendere tutte le quantità (entity) che hanno 
                        //quantità <= a quella richiesta
                        var possibleQuantity = this.RidDiscountNavigation.Quantity.Where(q => q.Quantity1 <= orderQuantity);
                        if (possibleQuantity.Any())
                        {
                            discountPercentage = possibleQuantity.OrderByDescending(q => q.Quantity1).First().Percentage;
                        }
                        break;
                    case (byte)DiscountType.Season:
                        if (orderDate != null)
                        {
                            //esiste uno sconto di tipo stagionale e sto ordinando esattamente in quella stagione
                            var season = this.RidDiscountNavigation.RidSeasonNavigation;
                            if (season != null && (orderDate.Value >= season.StartDate || orderDate.Value <= season.EndDate))
                            {
                                discountPercentage = this.RidDiscountNavigation.Percentage ?? 0;
                            }
                        }
                        break;
                }
            }

            //rimuovo dal totale lo sconto calcolato a seconda del tipo
            total -= total * discountPercentage / 100;
            return total;
        }
    }
}
