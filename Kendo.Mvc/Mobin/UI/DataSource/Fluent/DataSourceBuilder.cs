using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="DataSource"/> component.
    /// </summary>
    public partial class AjaxDataSourceBuilder<TModel>
    {
        public AjaxDataSourceBuilder<TModel> AutoMakeQueryExpression(bool autoRead = true)
        {
            dataSource.AutoMakeQueryExpression = autoRead;

            return this;
        }
    }
    /// <summary>
    /// Defines the fluent API for configuring a readon-only AJAX data source.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class ReadOnlyAjaxDataSourceBuilder<TModel> : AjaxDataSourceBuilderBase<TModel, ReadOnlyAjaxDataSourceBuilder<TModel>>
        where TModel : class
    {
        public ReadOnlyAjaxDataSourceBuilder<TModel> AutoMakeQueryExpression(bool autoRead = true)
        {
            dataSource.AutoMakeQueryExpression = autoRead;

            return this;
        }
    }
}