using WerehouseOrders.Models.Data.Contracts;
using WerehouseOrders.Models.Enums;
using System;

namespace WerehouseOrders.Models.Data.Orders
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public string OrderReference { get; set; }

        public string OrderedProducts { get; set; }

        public string OrderedProductsCount { get; set; }

        public string ProductsReferences { get; set; }

        public string UnitPrices { get; set; }

        public string StockQuantities { get; set; }

        public string CustomerName { get; set; }

        public string CustormerPhoneNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime? ShippingDate { get; set; }

        public Status Status { get; set; }

        public string DeliverySlip { get; set; }

        public string Comment { get; set; }

        public string Author { get; set; } = "bestauto.bg";

        public int UserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
