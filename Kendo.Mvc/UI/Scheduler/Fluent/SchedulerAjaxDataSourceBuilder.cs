﻿namespace Kendo.Mvc.UI.Fluent
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public class SchedulerAjaxDataSourceBuilder<TModel> : FilterableAjaxDataSourceBuilder<TModel, SchedulerAjaxDataSourceBuilder<TModel>>
         where TModel : class
    {
        public SchedulerAjaxDataSourceBuilder(DataSource dataSource, ViewContext viewContext, IUrlGenerator urlGenerator)
            : base(dataSource, viewContext, urlGenerator)
        {
        }

        /// <summary>
        /// Configures Model properties
        /// </summary>
        public SchedulerAjaxDataSourceBuilder<TModel> Model(Action<DataSourceSchedulerModelDescriptorFactory<TModel>> configurator)
        {
            configurator(new DataSourceSchedulerModelDescriptorFactory<TModel>((SchedulerModelDescriptor)dataSource.Schema.Model));

            return (SchedulerAjaxDataSourceBuilder<TModel>)this;
        }
    }
}
