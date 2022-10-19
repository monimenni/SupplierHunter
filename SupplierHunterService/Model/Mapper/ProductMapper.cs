using SupplierHunterEntities;
using SupplierHunterService.Model.DTO;

namespace SupplierHunterService.Model.Mapper
{
    public class ProductMapper
    {
        public static ProductDTO Map(Product p)
        {
            return new ProductDTO()
            {
                IdProduct = p.IdProduct,
                ProductCodeName = p.Code + " - " + p.Name
            };
        }
    }
}
