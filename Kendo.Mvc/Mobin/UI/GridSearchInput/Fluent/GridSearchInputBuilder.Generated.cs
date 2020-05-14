using System;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI GridSearchInput
    /// </summary>
    public partial class GridSearchInputBuilder
    {
        /// <summary>
        /// Specifies the culture info used by the widget.
        /// </summary>
        /// <param name="value">The value for Culture</param>
        public GridSearchInputBuilder Culture(string value)
        {
            Container.Culture = value;
            return this;
        }

        /// <summary>
        /// Specifies the number format used when the widget is not focused. Any valid number format is allowed.Compare with the decimals property.
        /// </summary>
        /// <param name="value">The value for Format</param>
        public GridSearchInputBuilder Format(string value)
        {
            Container.Format = value;
            return this;
        }

        /// <summary>
        /// The hint displayed by the widget when it is empty. Not set by default.
        /// </summary>
        /// <param name="value">The value for Placeholder</param>
        public GridSearchInputBuilder Placeholder(string value)
        {
            Container.Placeholder = value;
            return this;
        }

        /// <summary>
        /// Specifies the value of the GridSearchInput widget.
        /// </summary>
        /// <param name="value">The value for Value</param>
        public GridSearchInputBuilder Value(string value)
        {
            Container.Value = value;
            return this;
        }

        /// <summary>
        /// Configures the client-side events.
        /// </summary>
        /// <param name="configurator">The client events action.</param>
        /// <example>
        /// <code lang="CS">
        /// @(Html.Kendo().GridSearchInput()
        ///       .Name("GridSearchInput")
        ///       .Events(events => events
        ///           .Change("onChange")
        ///       )
        /// )
        /// </code>
        /// </example>
        public GridSearchInputBuilder Events(Action<GridSearchInputEventBuilder> configurator)
        {
            configurator(new GridSearchInputEventBuilder(Container.Events));
            return this;
        }

    }
}

