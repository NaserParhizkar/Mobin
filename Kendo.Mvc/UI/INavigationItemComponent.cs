namespace Kendo.Mvc.UI
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public interface INavigationItemComponent<TItem> : INavigationItemContainer<TItem>
        where TItem : NavigationItem<TItem>
    {
        IUrlGenerator UrlGenerator
        {
            get;
        }

        ViewContext ViewContext
        {
            get;
        }

        Action<TItem> ItemAction
        {
            get;
            set;
        }

        //INavigationItemAuthorization Authorization
        //{
        //    get;
        //}

        //SecurityTrimming SecurityTrimming
        //{
        //    get;
        //    set;
        //}
    }
}
