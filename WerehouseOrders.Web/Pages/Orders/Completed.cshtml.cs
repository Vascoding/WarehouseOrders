using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Models.View.Filter;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Helpers;
using WerehouseOrders.Web.Pages.Abstractions.Orders;

namespace WerehouseOrders.Web.Pages.Orders
{
    [BindProperties]
    public class CompletedModel : ListingOrderModel
    {
        public CompletedModel(IEntityService entityService, IMappingService mapper)
            : base(entityService, mapper) { }

        public override async Task OnGet(OrdersFilterModel filter, int currentPage = 1)
        {

            filter.Status = (Models.Enums.Status?)2;
            await base.OnGet(filter, currentPage);
        }
    }
}