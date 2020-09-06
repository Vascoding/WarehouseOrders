using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Models.Data.Orders;
using WerehouseOrders.Models.View.Filter;
using WerehouseOrders.Models.View.Orders;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Caches;
using WerehouseOrders.Web.Helpers;
using WerehouseOrders.Web.Pages.Abstractions.Orders;

namespace WerehouseOrders.Web.Pages.Orders
{
    [BindProperties]
    public class ForPrintModel : ListingOrderModel
    {
        public ForPrintModel(IEntityService entityService, IMappingService mapper)
            : base(entityService, mapper) { }

        public override async Task OnGet(OrdersFilterModel filter, int currentPage = 1)
        {
            this.CurrentPage = currentPage;
            var orders = await entityService.GetAll<Order>(e => e.DeliverySlip != null && e.Status != (Models.Enums.Status?)2);
            OrdersCache.Items = orders.Select(this.mapper.Map<OrderViewModel>).ToList();
 
        }
    }
}