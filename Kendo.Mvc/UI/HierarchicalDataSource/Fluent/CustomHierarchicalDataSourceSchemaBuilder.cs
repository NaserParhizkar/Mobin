﻿namespace Kendo.Mvc.UI.Fluent
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;


    /// <summary>    
    /// Defines the fluent interface for configuring the <see cref="Schema"/> options.
    /// </summary>
    public class CustomHierarchicalDataSourceSchemaBuilder<TModel> : CustomDataSourceSchemaBuilderBase<CustomHierarchicalDataSourceSchemaBuilder<TModel>>
        where TModel : class
    {
        private readonly IUrlGenerator urlGenerator;
        private readonly ViewContext viewContext;

        public CustomHierarchicalDataSourceSchemaBuilder(DataSourceSchema schema, ViewContext viewContext, IUrlGenerator urlGenerator)
            : base(schema)
        {
            this.viewContext = viewContext;
            this.urlGenerator = urlGenerator;
        }

        /// <summary>
        /// Configures Model properties
        /// </summary>
        public virtual CustomHierarchicalDataSourceSchemaBuilder<TModel> Model(Action<CustomHierarchicalDataSourceModelDescriptorFactory<TModel>> configurator)
        {
            configurator(new CustomHierarchicalDataSourceModelDescriptorFactory<TModel>(schema.Model, viewContext, urlGenerator));

            return this;
        }
    }
}