using Mobin.Common;
using Mobin.Common.Expressions;
using Mobin.TestConsoleApplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mobin.TestConsoleApplication
{
    class Program
    {



        //static string url = "http://localhost:65061/OrderApi/Read";
        //private static readonly object Obj = new object();
        //static int counter = 0;
        //static void Main(string[] args)
        //{
        //    var display = Utility.ModelMetadata<Customer>.GetAttribute<DisplayAttribute>(t => t.City);
        //    var name = display.Name;

        //    try
        //    {
        //        var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(new
        //        {
        //            sort = "",
        //            page = 1,
        //            pageSize = 100,
        //            group = "",
        //            filter = "",
        //            widgetId = "26f520fa-715c-4a8b-8bb1-40f3264ee579",
        //            autoMakeQueryExpression = true
        //        });

        //        var json2 = Newtonsoft.Json.JsonConvert.SerializeObject(new
        //        {
        //            sort = "",
        //            page = 1,
        //            pageSize = 100,
        //            group = "",
        //            filter = "",
        //            widgetId = "610ed2e8-0a50-48e4-83c7-302bbaa39fdd",
        //            autoMakeQueryExpression = true
        //        });
        //        var json3 = Newtonsoft.Json.JsonConvert.SerializeObject(new
        //        {
        //            sort = "",
        //            page = 1,
        //            pageSize = 100,
        //            group = "",
        //            filter = "",
        //            widgetId = "45649c5c-2c6f-4e7b-abc4-841777502b91",
        //            autoMakeQueryExpression = true
        //        });

        //        var startTime = DateTime.Now.ToLongTimeString();
        //        Console.WriteLine("********************************************************");
        //        Console.WriteLine(startTime);
        //        Console.WriteLine("********************************************************");

        //        ThreadPerformanceChecker(json1);
        //        ThreadPerformanceChecker(json2);
        //        ThreadPerformanceChecker(json3);

        //        var endTime = DateTime.Now.ToLongTimeString();
        //        Console.WriteLine("********************************************************");
        //        Console.WriteLine(endTime);
        //        Console.WriteLine("********************************************************");

        //        int aaa = 0;


        //        //var first = Execute();

        //        //var second = Execute();

        //        //var third = Execute();


        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {

        //    }
        }

        //static void ThreadPerformanceChecker(object content)
        //{
        //    Thread[] threads = new Thread[100];
        //    for (int i = 0; i < 100; i++)
        //    {
        //        threads[i] = new Thread((object con) =>
        //        {
        //            PerformanceChecker(con).Wait();
        //        });
        //        threads[i].IsBackground = true;
        //        threads[i].Start(content);
        //    }

        //    for (int i = 0; i < 100; i++)
        //    {
        //        threads[i].Join();
        //    }
        //}

        //static async Task PerformanceChecker(object content)
        //{
        //    await PostStreamAsync(content, new System.Threading.CancellationToken());
        //}

        //public static async Task PostStreamAsync(object content, System.Threading.CancellationToken cancellationToken)
        //{
        //    using (var httpClient = new HttpClient())
        //    using (var request = new HttpRequestMessage(HttpMethod.Post, url))
        //    using (var httpContent = CreateContent(content))
        //    {
        //        request.Content = httpContent;
        //        using (var response = await httpClient
        //               .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
        //               .ConfigureAwait(false))
        //        {
        //            var res = response.EnsureSuccessStatusCode();

        //            Monitor.Enter(Obj);
        //            Console.WriteLine(counter++);
        //            Monitor.Exit(Obj);
        //        }
        //    }
        //}

        //public static void SerialJsonIntoStream(object value, Stream stream)
        //{
        //    using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
        //    using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
        //    {
        //        var js = new JsonSerializer();
        //        js.Serialize(jtw, value);
        //        jtw.Flush();
        //    }
        //}


        //public static HttpContent CreateContent(object content)
        //{
        //    HttpContent httpContent = null;

        //    if (httpContent != null)
        //    {
        //        var ms = new MemoryStream();
        //        SerialJsonIntoStream(content, ms);
        //        ms.Seek(0, SeekOrigin.Begin);
        //        httpContent = new StreamContent(ms);
        //        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    }

        //    return httpContent;
        //}



        //private static List<object> Execute()
        //{


        //    var lstResult = default(List<object>);
        //    using (var db = new NorthwindContext())
        //    {
        //        Expression<Func<OrderDetail, int>> orderIDExpr = x => x.OrderId;
        //        Expression<Func<OrderDetail, int>> productIDExpr = x => x.ProductId;
        //        Expression<Func<OrderDetail, decimal>> unitPriceExpr = x => x.UnitPrice;
        //        Expression<Func<OrderDetail, short>> quantityExpr = x => x.Quantity;
        //        Expression<Func<OrderDetail, string>> cityCustomerExpr = x => x.Order.Customer.City;
        //        Expression<Func<OrderDetail, string>> cityEmpExpr = x => x.Order.Employee.City;
        //        Expression<Func<OrderDetail, DateTime?>> orderDateExpr = x => x.Order.OrderDate;
        //        Expression<Func<OrderDetail, string>> productNameExpr = x => x.Product.ProductName;
        //        Expression<Func<OrderDetail, string>> categoryNameExpr = x => x.Product.Category.CategoryName;
        //        Expression<Func<OrderDetail, string>> countryExpr = x => x.Order.Customer.Country;
        //        Expression<Func<OrderDetail, float>> discountExpr = x => x.Discount;

        //        Expression<Func<OrderDetail, string>> x_Product_ProductName = x => x.Product.ProductName;
        //        Expression<Func<OrderDetail, decimal>> x_UnitPrice = x => x.UnitPrice;
        //        Expression<Func<OrderDetail, short>> x_Quantity = x => x.Quantity;
        //        Expression<Func<OrderDetail, float>> x_Discount = x => x.Discount;
        //        Expression<Func<OrderDetail, int>> x_Order_Employee_EmployeeId = x => x.Order.Employee.EmployeeId;
        //        Expression<Func<OrderDetail, string>> x_Order_Employee_FirstName = x => x.Order.Employee.FirstName;
        //        Expression<Func<OrderDetail, string>> x_Order_Employee_LastName = x => x.Order.Employee.LastName;
        //        Expression<Func<OrderDetail, string>> x_Product_Category_CategoryName = x => x.Product.Category.CategoryName;
        //        Expression<Func<OrderDetail, string>> x_Product_Supplier_CompanyName = x => x.Product.Supplier.CompanyName;
        //        Expression<Func<OrderDetail, string>> x_Product_Supplier_ContactTitle = x => x.Product.Supplier.ContactTitle;
        //        Expression<Func<OrderDetail, string>> x_Product_Supplier_Country = x => x.Product.Supplier.Country;
        //        Expression<Func<OrderDetail, string>> x_Order_ShipName = x => x.Order.ShipName;
        //        Expression<Func<OrderDetail, DateTime?>> x_Order_ShippedDate = x => x.Order.ShippedDate;
        //        Expression<Func<OrderDetail, int?>> x_Order_Employee_ReportsToNavigation_EmployeeId = x => x.Order.Employee.ReportsToNavigation.ReportsTo;
        //        Expression<Func<OrderDetail, string>> x_Order_Employee_ReportsToNavigation_FirstName = x => x.Order.Employee.ReportsToNavigation.FirstName;
        //        Expression<Func<OrderDetail, string>> x_Order_Employee_ReportsToNavigation_LastName = x => x.Order.Employee.ReportsToNavigation.LastName;


        //        var expressions = new List<Expression>
        //        {
        //            x_Product_ProductName,
        //            x_UnitPrice,
        //            x_Quantity,
        //            x_Discount,
        //            x_Order_Employee_EmployeeId,
        //            x_Order_Employee_FirstName,
        //            x_Order_Employee_LastName,
        //            x_Product_Category_CategoryName,
        //            x_Product_Supplier_CompanyName,
        //            x_Product_Supplier_ContactTitle,
        //            x_Product_Supplier_Country,
        //            x_Order_ShipName,
        //            x_Order_ShippedDate,
        //            x_Order_Employee_ReportsToNavigation_EmployeeId,
        //            x_Order_Employee_ReportsToNavigation_FirstName,
        //            x_Order_Employee_ReportsToNavigation_LastName,



        //            //orderIDExpr,
        //            //productIDExpr,
        //            //unitPriceExpr,
        //            //quantityExpr,
        //            //orderDateExpr,
        //            //cityCustomerExpr,
        //            //cityEmpExpr,
        //            //productNameExpr,
        //            //categoryNameExpr,
        //            //countryExpr,
        //            //discountExpr
        //        };

        //        var lambdaExpression = expressions.GetLambdaExpression<OrderDetail>();

        //        Guid? key = Guid.NewGuid();
        //        ExpressionJsonSerializer.ExpressionSaver.SerialExpressionAsJson<OrderDetail>
        //            ((Expression)lambdaExpression, @"C:\Users\Asus\Desktop\Mobin\TelerikAspNetCoreApp3\wwwroot\expressions\Customer\Index/grid.json",
        //            ref key,
        //            typeof(OrderDetail).Assembly);



        //        //var jsonExpression = ExpressionJsonSerializer.JsonNetAdapter.ReadDeserializedLambdaExpression<OrderDetail>("", Guid.Empty);

        //        var jsonExpDes = ExpressionJsonSerializer.JsonNetAdapter.ReadDeserializedLambdaExpression<OrderDetail>(key.Value);


        //        var queryMethod = typeof(Queryable).GetMethods().Where(x => x.Name == "Select")
        //         .Select(x => new { M = x, P = x.GetParameters() })
        //       .Where(t => t.P.Length == 2
        //           && t.P[0].ParameterType.IsGenericType
        //                     && t.P[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
        //                      .Select(t => new { t.M, A = t.P[1].ParameterType.GetGenericArguments() })
        //         .Where(t => t.A[0].IsGenericType
        //                     && t.A[0].GetGenericTypeDefinition() == typeof(Func<,>))
        //         .Select(x => new { x.M, A = x.A[0].GetGenericArguments() })
        //         .Select(x => x.M)
        //         .SingleOrDefault();
        //        var returnType = (Type)jsonExpDes.GetPropertyValue("ReturnType");
        //        var method = queryMethod.MakeGenericMethod(typeof(OrderDetail), returnType);

        //        MethodCallExpression selectCallExpression = Expression.Call(
        //          method: method,
        //          arg0: db.Set<OrderDetail>().AsQueryable().Expression,
        //          arg1: Expression.Quote(jsonExpDes));

        //        var queryRes = db.Set<OrderDetail>().AsQueryable().Provider.CreateQuery<object>(selectCallExpression);

        //        var orderDetails = queryRes.ToList();

        //        lstResult = orderDetails;
        //    }

        //    return lstResult;
        //}

    }
}