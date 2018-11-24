using Mobin.Common;
using Mobin.Common.Expressions;
using Mobin.TestConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Mobin.TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Execute();
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {

            }
        }

        private static void Execute()
        {
            using (var db = new NorthwindContext())
            {

                Expression<Func<OrderDetail, int>> orderIDExpr = x => x.OrderId;
                Expression<Func<OrderDetail, int>> productIDExpr = x => x.ProductId;
                Expression<Func<OrderDetail, decimal>> UnitPriceExpr = x => x.UnitPrice;
                Expression<Func<OrderDetail, short>> QuantityExpr = x => x.Quantity;
                Expression<Func<OrderDetail, string>> CityCustomerExpr = x => x.Order.Customer.City;
                Expression<Func<OrderDetail, string>> CityEmpExpr = x => x.Order.Employee.City;
                Expression<Func<OrderDetail, DateTime?>> OrderDateExpr = x => x.Order.OrderDate;
                Expression<Func<OrderDetail, string>> ProductNameExpr = x => x.Product.ProductName;
                Expression<Func<OrderDetail, string>> CategoryNameExpr = x => x.Product.Category.CategoryName;
                Expression<Func<OrderDetail, string>> CountryExpr = x => x.Order.Customer.Country;

                var expressions = new List<Expression>
                {
                    orderIDExpr,
                    productIDExpr,
                    UnitPriceExpr,
                    QuantityExpr,
                    OrderDateExpr,
                    CityCustomerExpr,
                    CityEmpExpr,
                    ProductNameExpr,
                    CategoryNameExpr,
                    CountryExpr
                };

                var res1 = expressions.GetLambdaExpression<OrderDetail>();

                var jsonExpression = ExpressionJsonSerializer.JsonNetAdapter.Serialize(res1, typeof(OrderDetail).Assembly);

                var jsonExpDes = ExpressionJsonSerializer.JsonNetAdapter.Deserialize<Expression>
                    (jsonExpression, typeof(OrderDetail).Assembly);


                var queryMethod = typeof(Queryable).GetMethods().Where(x => x.Name == "Select")
                 .Select(x => new { M = x, P = x.GetParameters() })
               .Where(t => t.P.Length == 2
                   && t.P[0].ParameterType.IsGenericType
                             && t.P[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
                              .Select(t => new { t.M, A = t.P[1].ParameterType.GetGenericArguments() })
                 .Where(t => t.A[0].IsGenericType
                             && t.A[0].GetGenericTypeDefinition() == typeof(Func<,>))
                 .Select(x => new { x.M, A = x.A[0].GetGenericArguments() })
                 .Select(x => x.M)
                 .SingleOrDefault();
                var returnType = (Type)jsonExpDes.GetPropertyValue("ReturnType");
                var method = queryMethod.MakeGenericMethod(typeof(OrderDetail), returnType);

                MethodCallExpression selectCallExpression = Expression.Call(
                  method: method,
                  arg0: db.Set<OrderDetail>().AsQueryable().Expression,
                  arg1: Expression.Quote(jsonExpDes));

                var queryRes = db.Set<OrderDetail>().AsQueryable().Provider.CreateQuery<object>(selectCallExpression);

                var orderDetails = queryRes.ToList();
            }
        }

    }
}