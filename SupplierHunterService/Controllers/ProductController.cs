using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierHunterEntities;
using SupplierHunterService.Model.DTO;
using SupplierHunterService.Model.Mapper;

namespace SupplierHunterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private SupplierHunterContext context;
        public ProductController(SupplierHunterContext context)
        {
            this.context = context;
        }
        #region Methods

        [HttpGet]
        [Route("")]
        public IActionResult getProducts()
        {
            var result = this.context.Product.ToList();
            return Ok(result.Select(p => ProductMapper.Map(p)));
        }

        [HttpGet]
        [Route("{idProduct}/suppliers")]
        public IActionResult getFilteredSupplier(int idProduct, int? quantity, DateTime? limitDate)
        {
            var result = new List<ProductSupplier>();
            List<SupplierDTO> filteredSuppliers = new List<SupplierDTO>();
            IQueryable<ProductSupplier> productSuppliers = context.ProductSupplier.Where(ps => ps.RidProduct == idProduct)
                                                                                  .Include(ps => ps.RidSupplierNavigation)
                                                                                  .Include(ps => ps.RidDiscountNavigation)
                                                                                    .ThenInclude(d => d.RidSeasonNavigation);

            if (quantity.HasValue)
            {
                productSuppliers = productSuppliers.Where(ps => ps.Availability >= quantity.Value);
            }

            if (limitDate.HasValue)
            {
                productSuppliers = productSuppliers.Where(ps => DateTime.Today.AddDays(ps.MinShippingDays) <= limitDate);
            }

            result = productSuppliers.ToList();

            if (quantity.HasValue)
            {
                return Ok(result.Select(s => SupplierMapper.Map(s, quantity.Value, limitDate))
                                .OrderBy(s => s.Total)
                                .ThenBy(s => s.BusinessName));
            }
            else
            {
                return Ok(result.Select(s => SupplierMapper.Map(s))
                                .OrderBy(s => s.Total)
                                .ThenBy(s => s.BusinessName));
            }
        }
        #endregion
    }
}
