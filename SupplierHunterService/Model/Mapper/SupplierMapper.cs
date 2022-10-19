using SupplierHunterEntities;
using SupplierHunterService.Model.DTO;

namespace SupplierHunterService.Model.Mapper
{
    public class SupplierMapper
    {
        public static SupplierDTO Map(ProductSupplier s, int quantity, DateTime? orderDate)
        {
            var supplierDTO = SupplierMapper.Map(s);
            supplierDTO.Total = s.GetTotal(quantity, orderDate);

            return supplierDTO;
        }

        public static SupplierDTO Map(ProductSupplier s)
        {
            var supplier = s.RidSupplierNavigation;
            return new SupplierDTO()
            {
                IdSupplier = supplier.IdSupplier,
                BusinessName = supplier.BusinessName,
                Address = supplier.Address,
                DeliveryDay = "Delivery expected for the day " + DateTime.Today.AddDays(s.MinShippingDays).ToString("dd/MM/yyyy")
            };
        }
    }
}
