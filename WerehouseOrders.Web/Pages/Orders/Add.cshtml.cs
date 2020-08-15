using Microsoft.AspNetCore.Mvc;
using WerehouseOrders.Services.Contracts;
using System.Threading.Tasks;
using WerehouseOrders.Models.Data.Users;
using WerehouseOrders.Models.Data.Orders;
using System;
using WerehouseOrders.Web.Pages.Abstractions.Orders;
using System.Globalization;

namespace WerehouseOrders.Web.Pages.Orders
{
    [BindProperties]
    public class AddModel : OrderModel
    {
        public AddModel(IEntityService entityService) 
            : base(entityService) { }

        public void OnGet() { }

        public async Task<IActionResult> OnPost()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Моля логнете се!";

                return RedirectToPage();
            }

            var user = await this.entityService.GetBy<User>(u => u.Name == this.User.Identity.Name);

            var model = new Order
            {
                OrderReference = this.OrderReference,
                OrderedProducts = this.OrderedProducts,
                ProductsReferences = this.ProductsReferences,
                UnitPrices = this.UnitPrices,
                StockQuantities = this.StockQuantities,
                CustomerName = this.CustomerName,
                CustormerPhoneNumber = this.CustormerPhoneNumber,
                TotalAmount = this.TotalAmount,
                DeliverySlip = this.DeliverySlip,
                Comment = this.Comment,
                UserId = user.Id,
                Author = user.Name,
                Status = this.Status
            };

            await this.entityService.AddOrUpdate(model);

            return RedirectToPage("All");
        }
    }
}