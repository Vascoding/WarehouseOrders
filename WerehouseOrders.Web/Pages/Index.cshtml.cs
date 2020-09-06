using Microsoft.AspNetCore.Mvc.RazorPages;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;

namespace WerehouseOrders.Web.Pages
{
    public class IndexModel : ListingOrderModel
    {
        public IndexModel (IEntityService entityService, IMappingService mapper)
    : base(entityService, mapper) { }
    }
}
