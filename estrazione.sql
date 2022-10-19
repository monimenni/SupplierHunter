select ps.IdProductSupplier, 
p.Name, 
s.BusinessName,  
ps.Availability, 
ps.UnitPrice, 
CASE
    WHEN d.Type = 0 THEN 'On Total'
    WHEN d.Type = 1 THEN 'On Quantity'
    WHEN d.Type = 2 THEN 'Seasonal'
    ELSE ''
END As DiscountType,
d.Percentage As DiscountPercentage, 
se.Name As SeasonName, 
q.Quantity As DiscountMinQuantity, 
q.Percentage As DiscountQuantityPercentage, 
ps.MinShippingDays
from dbo.ProductsSuppliers ps
inner join dbo.Products p on p.IdProduct = ps.RidProduct
inner join dbo.Suppliers s on s.IdSupplier = ps.RidSupplier
inner join dbo.Discounts d on d.IdDiscount = ps.RIdDiscount
left outer join dbo.Seasons se on se.IdSeason = d.RidSeason
left outer join dbo.Quantities q on q.RidDiscount = d.IdDiscount
order by p.Name, s.BusinessName
