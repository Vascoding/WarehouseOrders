﻿using WerehouseOrders.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace WerehouseOrders.Models.View.Filter
{
    public class OrdersFilterModel
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public Status? Status { get; set; }

        public string Author { get; set; }

        public string OrderedProducts { get; set; }

        public string Comment { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerName { get; set; }

        public string DeliverySlip { get; set; }
    }
}
