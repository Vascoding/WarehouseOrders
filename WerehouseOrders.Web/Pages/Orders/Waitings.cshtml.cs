﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Models.Enums;
using WerehouseOrders.Models.View.Filter;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;

namespace WerehouseOrders.Web.Pages.Orders
{
    [BindProperties]
    public class WaitingModel : ListingOrderModel
    {
        public WaitingModel(IEntityService entityService, IMappingService mapper)
            : base(entityService, mapper) { }

        public override async Task OnGet(OrdersFilterModel filter, int currentPage = 1)
        {
            filter.Status = Status.Waiting;

            await base.OnGet(filter, currentPage);
        }
    }
}