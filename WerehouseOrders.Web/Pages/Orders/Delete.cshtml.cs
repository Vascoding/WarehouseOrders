using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WerehouseOrders.Models.Data.Orders;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Web.Pages.Abstractions.Orders;
using System.Threading.Tasks;

namespace WerehouseOrders.Web.Pages.Orders
{
    public class DeleteModel : OrderModel
    {
        public DeleteModel(IEntityService entityService)
            : base(entityService) { }

        public async Task OnGet(int id)
        {
            var order = await this.entityService.GetBy<Order>(o => o.Id == id);

            this.Id = order.Id;
            this.ProductName = order.ProductName;
            this.Comment = order.Comment;
            this.CustomerName = order.CustomerName;
            this.CustormerPhoneNumber = order.CustormerPhoneNumber;
            this.Status = order.Status;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "You need to login first";

                return RedirectToPage(new { id = this.Id });
            }

            await this.entityService.DeleteBy<Order>(o => o.Id == this.Id);

            return RedirectToPage("All");
        }
    }
}