using WerehouseOrders.Models.Enums;
using System.Collections.Generic;

namespace WerehouseOrders.Web.Helpers
{
    public static class HtmlHeleper
    {
        public static bool IsSelected(Status optionStatus, Status modelStatus) =>
            optionStatus == modelStatus;

        public static string GetClassByStatus(Status status)
        {
            var mapStatusToClass = new Dictionary<Status, string>()
            {
                { Status.Waiting, "bg-warning" },
                { Status.Stated, "bg-info" },
                { Status.Completed, "bg-success" },
                { Status.Refused, "bg-danger" }
            };

            return mapStatusToClass[status];
        }
    }
}
