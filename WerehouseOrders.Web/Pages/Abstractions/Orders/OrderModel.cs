using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WerehouseOrders.Models.Enums;
using WerehouseOrders.Services.Contracts;
using System.ComponentModel.DataAnnotations;
using System;

namespace WerehouseOrders.Web.Pages.Abstractions.Orders
{
    [BindProperties]
    public abstract class OrderModel : PageModel
    {
        protected readonly IEntityService entityService;

        public OrderModel(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        public int Id { get; set; }

        public string OrderReference { get; set; }

        public string OrderedProducts { get; set; }

        public string ProductsReferences { get; set; }

        public string UnitPrices { get; set; }

        public string OrderedProductsCount { get; set; }

        public string StockQuantities { get; set; }

        public string CustomerName { get; set; }

        public string CustormerPhoneNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime? ShippingDate { get; set; }

        public Status Status { get; set; }

        public string DeliverySlip { get; set; }

        public string Comment { get; set; }
    }
}