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
                var first = Execute();

                var second = Execute();

                var third = Execute();


            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {

            }
        }

        private static List<object> Execute()
        {
            var lstResult = default(List<object>);
            using (var db = new NorthwindContext())
            {

                Expression<Func<OrderDetail, int>> orderIDExpr = x => x.OrderId;
                Expression<Func<OrderDetail, int>> productIDExpr = x => x.ProductId;
                Expression<Func<OrderDetail, decimal>> unitPriceExpr = x => x.UnitPrice;
                Expression<Func<OrderDetail, short>> quantityExpr = x => x.Quantity;
                Expression<Func<OrderDetail, string>> cityCustomerExpr = x => x.Order.Customer.City;
                Expression<Func<OrderDetail, string>> cityEmpExpr = x => x.Order.Employee.City;
                Expression<Func<OrderDetail, DateTime?>> orderDateExpr = x => x.Order.OrderDate;
                Expression<Func<OrderDetail, string>> productNameExpr = x => x.Product.ProductName;
                Expression<Func<OrderDetail, string>> categoryNameExpr = x => x.Product.Category.CategoryName;
                Expression<Func<OrderDetail, string>> countryExpr = x => x.Order.Customer.Country;
                Expression<Func<OrderDetail, float>> discountExpr = x => x.Discount;

                var expressions = new List<Expression>
                {
                    orderIDExpr,
                    productIDExpr,
                    unitPriceExpr,
                    quantityExpr,
                    orderDateExpr,
                    cityCustomerExpr,
                    cityEmpExpr,
                    productNameExpr,
                    categoryNameExpr,
                    countryExpr,
                    discountExpr
                };

                var lambdaExpression = expressions.GetLambdaExpression<OrderDetail>();

                //var jsonExpression = ExpressionJsonSerializer.JsonNetAdapter.Serialize(res1, typeof(OrderDetail).Assembly);

                ExpressionJsonSerializer.ExpressionSaver.SerialExpressionAsJson<OrderDetail>
                    ((Expression)lambdaExpression, @"C:\Users\Asus\Desktop\Mobin\TelerikAspNetCoreApp3\wwwroot\expressions\Customer\Index/grid.json",
                    typeof(OrderDetail).Assembly);

                var jsonExpression = ExpressionJsonSerializer.JsonNetAdapter.ReadDeserializedLambdaExpression<OrderDetail>(new Guid());

                var jsonExpDes = ExpressionJsonSerializer.JsonNetAdapter.ReadDeserializedLambdaExpression<OrderDetail>(new Guid());


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

                lstResult = orderDetails;
            }

            return lstResult;
        }

    }
}