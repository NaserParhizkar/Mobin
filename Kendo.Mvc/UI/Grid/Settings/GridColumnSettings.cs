namespace Kendo.Mvc.UI
{
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Collections.Generic;
    using System.Net;

    public class GridColumnSettings<T> : GridColumnSettings
        where T : class
    {
        public Action<T> Template
        {
            get;
            set;
        }
    }

    public class GridColumnSettings
    {
        private string member;
        private string clientTemplate;

        public GridColumnSettings()
        {
            Sortable = true;
            Encoded = true;
            Filterable = true;
            Groupable = true;
            Visible = true;
            IncludeInMenu = true;
            Lockable = true;
            HeaderHtmlAttributes = new RouteValueDictionary();
            HtmlAttributes = new RouteValueDictionary();
            FooterHtmlAttributes = new RouteValueDictionary();
        }

        public string ClientHeaderTemplate
        {
            get;
            set;
        }

        public string ClientTemplate
        {
            get
            {
                return clientTemplate;
            }
            set
            {
                clientTemplate = WebUtility.HtmlDecode(value);
            }
        }

        public string ClientGroupHeaderTemplate
        {
            get;
            set;
        }

        public string ClientGroupFooterTemplate
        {
            get;
            set;
        }

        public string ClientFooterTemplate
        {
            get;
            set;
        }

        public bool Encoded
        {
            get;
            set;
        }

        public bool Locked
        {
            get;
            set;
        }

        public bool Lockable
        {
            get;
            set;
        }

        public bool Filterable
        {
            get;
            set;
        }

        public string Format
        {
            get;
            set;
        }

        public bool Groupable
        {
            get;
            set;
        }


        public IDictionary<string, object> HeaderHtmlAttributes
        {
            get;
            private set;
        }

        public IDictionary<string, object> FooterHtmlAttributes
        {
            get;
            private set;
        }

        public bool Hidden
        {
            get;
            set;
        }

        public bool IncludeInMenu
        {
            get;
            set;
        }

        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

        public string Member
        {
            get
            {
                return member;
            }
            set
            {
                member = value;

                if (!Title.HasValue())
                {
                    Title = member.AsTitle();
                }
            }
        }

        public Type MemberType
        {
            get;
            set;
        }

        public bool ReadOnly
        {
            get;
            set;
        }

        public bool Sortable
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public string Width
        {
            get;
            set;
        }
        public int MinScreenWidth
        {
            get;
            set;
        }

        public int MinResizableWidth
        {
            get;
            set;
        }

        public GridFilterUIRole FilterUIRole
        {
            get;
            set;
        }
    }
}
