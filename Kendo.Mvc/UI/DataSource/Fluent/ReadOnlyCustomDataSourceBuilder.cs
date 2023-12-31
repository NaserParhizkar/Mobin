﻿namespace Kendo.Mvc.UI.Fluent
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public class ReadOnlyCustomDataSourceBuilder : CustomDataSourceBuilderBase<ReadOnlyCustomDataSourceBuilder>
    {
        public ReadOnlyCustomDataSourceBuilder(DataSource dataSource, ViewContext viewContext, IUrlGenerator urlGenerator)
            : base(dataSource, viewContext, urlGenerator)
        {
        }

        /// <summary>
        /// Configures the initial group.
        /// </summary>
        public virtual ReadOnlyCustomDataSourceBuilder Group(Action<ReadOnlyCustomDataSourceGroupDescriptorFactory> configurator)
        {
            configurator(new ReadOnlyCustomDataSourceGroupDescriptorFactory(dataSource.Groups));

            return this;
        }

        /// <summary>
        /// Configures the transport of the DataSource
        /// </summary>                
        public ReadOnlyCustomDataSourceBuilder Transport(Action<ReadOnlyCustomDataSourceTransportBuilder> configurator)
        {
            configurator(new ReadOnlyCustomDataSourceTransportBuilder(dataSource.Transport, viewContext, urlGenerator));

            return this;
        }

        /// <summary>
        /// Configures Schema properties
        /// </summary>
        public ReadOnlyCustomDataSourceBuilder Schema(Action<ReadOnlyCustomDataSourceSchemaBuilder<object>> configurator)
        {
            configurator(new ReadOnlyCustomDataSourceSchemaBuilder<object>(dataSource.Schema, dataSource.ModelMetaDataProvider));

            return this;
        }

        /// <summary>
        /// Configures the initial filter.
        /// </summary>
        public virtual ReadOnlyCustomDataSourceBuilder Filter(Action<ReadOnlyCustomDataSourceFilterDescriptorFactory> configurator)
        {
            configurator(new ReadOnlyCustomDataSourceFilterDescriptorFactory(dataSource.Filters));

            return this;
        }

        /// <summary>
        /// Configures the initial sort.
        /// </summary>
        public virtual ReadOnlyCustomDataSourceBuilder Sort(Action<ReadOnlyCustomDataSourceSortDescriptorFactory> configurator)
        {
            configurator(new ReadOnlyCustomDataSourceSortDescriptorFactory(dataSource.OrderBy));

            return this;
        }
    }
}
