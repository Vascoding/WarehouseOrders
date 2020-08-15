using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;

namespace WerehouseOrders.Web.Pages.Orders
{
    public class AllModel : ListingOrderModel
    {
        public AllModel(IEntityService entityService, IMappingService mapper) 
            : base(entityService, mapper) { }
    }
}