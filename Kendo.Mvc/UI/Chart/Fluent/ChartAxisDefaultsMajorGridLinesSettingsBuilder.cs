namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartAxisDefaultsMajorGridLinesSettings
    /// </summary>
    public partial class ChartAxisDefaultsMajorGridLinesSettingsBuilder<T>
        where T : class
    {
        public ChartAxisDefaultsMajorGridLinesSettingsBuilder(ChartAxisDefaultsMajorGridLinesSettings<T> container)
        {
            Container = container;
        }

        protected ChartAxisDefaultsMajorGridLinesSettings<T> Container
        {
            get;
            private set;
        }

        // Place custom settings here

        /// <summary>
        /// Makes the major grid lines visible.
        /// </summary>
        public ChartAxisDefaultsMajorGridLinesSettingsBuilder<T> Visible()
        {
            Container.Visible = true;
            return this;
        }
    }
}
