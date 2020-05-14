namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="ModelFieldDescriptor"/>.
    /// </summary>
    public class DataSourceModelFieldDescriptorBuilder<T> : DataSourceModelFieldDescriptorBuilderBase<T, DataSourceModelFieldDescriptorBuilder<T>>
    {
        public DataSourceModelFieldDescriptorBuilder(ModelFieldDescriptor descriptor)
            : base(descriptor)
        {
        }
    }
}
