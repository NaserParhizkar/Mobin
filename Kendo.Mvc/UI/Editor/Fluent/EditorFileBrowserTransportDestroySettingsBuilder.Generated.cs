using System;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring EditorFileBrowserTransportDestroySettings
    /// </summary>
    public partial class EditorFileBrowserTransportDestroySettingsBuilder
        
    {
        /// <summary>
        /// The content-type HTTP header sent to the server. Default is "application/x-www-form-urlencoded". Use "application/json" if the content is JSON.
		/// Refer to the jQuery.ajax documentation for further info.
        /// </summary>
        /// <param name="value">The value for ContentType</param>
        public EditorFileBrowserTransportDestroySettingsBuilder ContentType(string value)
        {
            Container.ContentType = value;
            return this;
        }

        /// <summary>
        /// The type of data that you're expecting back from the server. Commonly used values are "json" and "jsonp".
		/// Refer to the jQuery.ajax documentation for further info.
        /// </summary>
        /// <param name="value">The value for DataType</param>
        public EditorFileBrowserTransportDestroySettingsBuilder DataType(string value)
        {
            Container.DataType = value;
            return this;
        }

        /// <summary>
        /// The type of request to make ("POST", "GET", "PUT" or "DELETE"), default is "POST".
		/// Refer to the jQuery.ajax documentation for further info.
        /// </summary>
        /// <param name="value">The value for Type</param>
        public EditorFileBrowserTransportDestroySettingsBuilder Type(string value)
        {
            Container.Type = value;
            return this;
        }

        /// <summary>
        /// The remote url to call when creating a new record.
        /// </summary>
        /// <param name="value">The value for Url</param>
        public EditorFileBrowserTransportDestroySettingsBuilder Url(string value)
        {
            Container.UrlHandler = null;
            Container.Url = value;
            return this;
        }
        /// <summary>
        /// The remote url to call when creating a new record.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will be evaluated.</param>
        public EditorFileBrowserTransportDestroySettingsBuilder UrlHandler(string handler)
        {
            Container.Url = null;
            Container.UrlHandler = new ClientHandlerDescriptor { HandlerName = handler };
            return this;
        }

        /// <summary>
        /// The remote url to call when creating a new record.
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag.</param>
        public EditorFileBrowserTransportDestroySettingsBuilder UrlHandler(Func<object, object> handler)
        {
            Container.Url = null;
            Container.UrlHandler = new ClientHandlerDescriptor { TemplateDelegate = handler };
            return this;
        }

    }
}
