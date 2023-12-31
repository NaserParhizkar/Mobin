namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring TreeListSelectableSettings
    /// </summary>
    public partial class TreeListSelectableSettingsBuilder<T>

    {
        public TreeListSelectableSettingsBuilder(TreeListSelectableSettings<T> container)
        {
            Container = container;
        }

        protected TreeListSelectableSettings<T> Container
        {
            get;
            private set;
        }

        // Place custom settings here
    }
}
