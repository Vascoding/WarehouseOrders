using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Models.Data.Orders;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;
using System.Globalization;
using System.Threading.Tasks;

namespace WerehouseOrders.Web.Pages.Orders
{
    public class EditModel : OrderModel
    {
        public EditModel(IEntityService entityService) 
            : base(entityService) { }

        public async Task OnGet(int id)
        {
            var order = await this.entityService.GetBy<Order>(o => o.Id == id);

            this.Id = order.Id;
            this.OrderReference = order.OrderReference;
            this.OrderedProducts = order.OrderedProducts;
            this.ProductsReferences = order.ProductsReferences;
            this.UnitPrices = order.UnitPrices;
            this.OrderedProductsCount = order.OrderedProductsCount;
            this.StockQuantities = order.StockQuantities;
            this.CustomerName = order.CustomerName;
            this.CustormerPhoneNumber = order.CustormerPhoneNumber;
            this.TotalAmount = order.TotalAmount.ToString(CultureInfo.InvariantCulture);
            this.DeliverySlip = order.DeliverySlip;
            this.Comment = order.Comment;
            this.Status = order.Status;
            this.ShippingDate = order.ShippingDate;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "You need to login first";

                return RedirectToPage(new { id = this.Id });
            }

            var order = await this.entityService.GetBy<Order>(o => o.Id == this.Id);

            decimal.TryParse(this.TotalAmount.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalAmount);

            order.OrderReference = this.OrderReference;
            order.OrderedProducts = this.OrderedProducts;
            order.ProductsReferences = this.ProductsReferences;
            order.UnitPrices = this.UnitPrices;
            order.OrderedProductsCount = this.OrderedProductsCount;
            order.StockQuantities = this.StockQuantities;
            order.CustomerName = this.CustomerName;
            order.CustormerPhoneNumber = this.CustormerPhoneNumber;
            order.TotalAmount = totalAmount;
            order.DeliverySlip = this.DeliverySlip;
            order.Comment = this.Comment;
            order.Status = this.Status;
            order.ShippingDate = this.ShippingDate;

            await this.entityService.AddOrUpdate(order);

            return RedirectToPage("All");
        }
    }
}