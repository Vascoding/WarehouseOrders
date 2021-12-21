using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Models.View.Filter;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;
using WerehouseOrders.Models.Enums;

namespace WerehouseOrders.Web.Pages.Orders
{
    [BindProperties]
    public class ReservedModel : ListingOrderModel
    {
        public ReservedModel(IEntityService entityService, IMappingService mapper) 
            : base(entityService, mapper) { }

        public override async Task OnGet(OrdersFilterModel filter, int currentPage = 1)
        {
            filter.Status = Status.Reserved;

            await base.OnGet(filter, currentPage);
        }
    }
}