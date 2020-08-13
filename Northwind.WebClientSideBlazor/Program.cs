using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Northwind.Repository;
using System.Linq.Expressions;
using System.Linq;

namespace Northwind.WebClientSideBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();


            List<OrderDetail> lst = new List<OrderDetail>();

            lst.Select(t => t.Discount);

        }
    }

    //public static class A
    //{
    //    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    //    {
    //        foreach (var item in source)
    //        {
    //            yield return selector(item);
    //        }
    //    }
    //}
}
