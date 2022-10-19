using SupplierHunterEntities;

namespace SupplierHunterService.Model.DTO
{
    public class SupplierDTO
    {
        public int IdSupplier { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }
        public string DeliveryDay  { get; set; }
    }
}
