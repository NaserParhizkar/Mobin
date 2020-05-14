namespace Kendo.Mvc.Infrastructure
{
    using Microsoft.AspNetCore.Http;

    public interface INavigationItemAuthorization
    {
        bool IsAccessibleToUser(HttpContext requestContext, INavigatable navigationItem);
    }
}