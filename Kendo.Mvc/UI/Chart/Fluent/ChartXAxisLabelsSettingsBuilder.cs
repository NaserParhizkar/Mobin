namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring ChartXAxisLabelsSettings
    /// </summary>
    public partial class ChartXAxisLabelsSettingsBuilder<T>
        where T : class
    {
        public ChartXAxisLabelsSettingsBuilder(ChartXAxisLabelsSettings<T> container)
        {
            Container = container;
        }

        protected ChartXAxisLabelsSettings<T> Container
        {
            get;
            private set;
        }

        // Place custom settings here

        /// <summary>
        /// Sets the labels margin.
        /// </summary>        
        public ChartXAxisLabelsSettingsBuilder<T> Margin(int top, int right, int bottom, int left)
        {
            Container.Margin.Top = top;
            Container.Margin.Right = right;
            Container.Margin.Bottom = bottom;
            Container.Margin.Left = left;
            return this;
        }

        /// <summary>
        /// Sets the labels padding.
        /// </summary>       
        public ChartXAxisLabelsSettingsBuilder<T> Padding(int top, int right, int bottom, int left)
        {
            Container.Padding.Top = top;
            Container.Padding.Right = right;
            Container.Padding.Bottom = bottom;
            Container.Padding.Left = left;
            return this;
        }

        /// <summary>
        /// The rotation angle of the labels. By default the labels are not rotated.
        /// </summary>
        /// <param name="value">The value for Rotation</param>
        public ChartXAxisLabelsSettingsBuilder<T> Rotation(double value)
        {
            Container.Rotation.Angle = value;
            return this;
        }
    }
}
