namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartValueAxisMajorGridLinesSettings
    /// </summary>
    public partial class ChartValueAxisMajorGridLinesSettingsBuilder<T>
        where T : class
    {
        public ChartValueAxisMajorGridLinesSettingsBuilder(ChartValueAxisMajorGridLinesSettings<T> container)
        {
            Container = container;
        }

        protected ChartValueAxisMajorGridLinesSettings<T> Container
        {
            get;
            private set;
        }

        // Place custom settings here

        /// <summary>
        /// Makes the major grid lines visible.
        /// </summary>
        public ChartValueAxisMajorGridLinesSettingsBuilder<T> Visible()
        {
            Container.Visible = true;
            return this;
        }
    }
}
