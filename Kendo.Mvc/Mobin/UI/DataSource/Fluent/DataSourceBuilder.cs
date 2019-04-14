using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="DataSource"/> component.
    /// </summary>
    public partial class DataSourceBuilder<TModel>
    {
        public DataSourceBuilder<TModel> AutoReadData(bool autoRead = true)
        {
            dataSource.AutoReadData = true;

            return this;
        }
    }
}