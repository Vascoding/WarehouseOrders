using System.Collections.Generic;
using WerehouseOrders.Models.Data.Contracts;
using WerehouseOrders.Models.Data.Orders;

namespace WerehouseOrders.Models.Data.Users
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
