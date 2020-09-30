using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WerehouseOrders.Models.Data.Orders;
using WerehouseOrders.Models.View.Filter;

namespace WerehouseOrders.Web.Helpers
{
    public class FilterBuilder
    {
        private OrdersFilterModel filter;
        private IDictionary<string, Func<ParameterExpression, Expression>> mapPropertyToFilter;

        public FilterBuilder(OrdersFilterModel filter)
        {
            this.filter = filter;
            this.mapPropertyToFilter = new Dictionary<string, Func<ParameterExpression, Expression>>
            {
                { "Status", new Func<ParameterExpression, Expression>(this.StatusFilter) },
                { "From", new Func<ParameterExpression, Expression>(this.FromFilter) },
                { "To", new Func<ParameterExpression, Expression>(this.ToFilter) },
                { "Author", new Func<ParameterExpression, Expression>(this.AuthorFilter) },
                { "OrderedProducts", new Func<ParameterExpression, Expression>(this.OrderedProductsFilter) },
                { "Comment", new Func<ParameterExpression, Expression>(this.CommentFilter) },
                { "PhoneNumber", new Func<ParameterExpression, Expression>(this.PhoneNumberFilter) },
                { "CustomerName", new Func<ParameterExpression, Expression>(this.CustomerNameFilter) },
                { "OrderReference", new Func<ParameterExpression, Expression>(this.OrderReferenceFilter) }
            };
        }

        public Expression<Func<Order, bool>> CreateFilterDelegate()
        {
            var parameter = ExpressionBuilder.CreateParameter<Order>();

            var expression = this.filter.GetType().GetProperties().Aggregate(ExpressionBuilder.BuildDefault(), (expr, prop) =>
            {
                if (prop.GetValue(this.filter) != null)
                {
                    var include = this.mapPropertyToFilter[prop.Name](parameter);
                    expr = ExpressionBuilder.AndAlso(expr, include);
                }

                return expr;
            });

            return Expression.Lambda<Func<Order, bool>>(expression, new[] { parameter });
        }

        private Expression StatusFilter(ParameterExpression parameter) =>
            ExpressionBuilder.Equal(parameter, "Status", this.filter.Status);

        private Expression FromFilter(ParameterExpression parameter) =>
            ExpressionBuilder.GreaterThanOrEqual(parameter, "ShippingDate", this.filter.From);

        private Expression ToFilter(ParameterExpression parameter) =>
            ExpressionBuilder.LessThanOrEqual(parameter, "ShippingDate", this.filter.To.Value.AddDays(1));

        private Expression AuthorFilter(ParameterExpression parameter) =>
            ExpressionBuilder.Equal(parameter, "Author", this.filter.Author);

        private Expression OrderedProductsFilter(ParameterExpression parameter) =>
            ExpressionBuilder.CaseInsensitiveCompare(parameter, "OrderedProducts", this.filter.OrderedProducts);

        private Expression CommentFilter(ParameterExpression parameter) =>
            ExpressionBuilder.CaseInsensitiveCompare(parameter, "Comment", this.filter.Comment);

        private Expression PhoneNumberFilter(ParameterExpression parameter) =>
            ExpressionBuilder.CaseInsensitiveCompare(parameter, "CustormerPhoneNumber", this.filter.PhoneNumber);

        private Expression CustomerNameFilter(ParameterExpression parameter) =>
            ExpressionBuilder.CaseInsensitiveCompare(parameter, "CustomerName", filter.CustomerName);

        private Expression OrderReferenceFilter(ParameterExpression parameter) =>
           ExpressionBuilder.CaseInsensitiveCompare(parameter, "OrderReference", filter.OrderReference);
    }
}