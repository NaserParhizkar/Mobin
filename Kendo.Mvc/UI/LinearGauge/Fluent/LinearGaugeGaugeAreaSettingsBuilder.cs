using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring LinearGaugeGaugeAreaSettings
    /// </summary>
    public partial class LinearGaugeGaugeAreaSettingsBuilder

    {
        public LinearGaugeGaugeAreaSettingsBuilder(LinearGaugeGaugeAreaSettings container)
        {
            Container = container;
        }

        public LinearGaugeGaugeAreaSettingsBuilder Margin(int margin)
        {
            Container.Margin.All(margin);

            return this;
        }

        /// <summary>
        /// Sets the gauge area margin.
        /// </summary>
        /// <param name="top">The gauge area top margin.</param>
        /// <param name="right">The gauge area right margin.</param>
        /// <param name="bottom">The gauge area bottom margin.</param>
        /// <param name="left">The gauge area left margin.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;% Html.Kendo().LinearGauge()
        ///           .Name("linearGauge")
        ///           .GaugeArea(gaugeArea => gaugeArea.Margin(0, 5, 5, 0))
        ///           .Render();
        /// %&gt;
        /// </code>
        /// </example>        
        public LinearGaugeGaugeAreaSettingsBuilder Margin(int top, int right, int bottom, int left)
        {
            Container.Margin.Top = top;
            Container.Margin.Right = right;
            Container.Margin.Bottom = bottom;
            Container.Margin.Left = left;

            return this;
        }

        protected LinearGaugeGaugeAreaSettings Container
        {
            get;
            private set;
        }

        /// <summary>
        /// Sets the gauge area border.
        /// </summary>
        /// <param name="width">The border width.</param>
        /// <param name="color">The border color (CSS syntax).</param>
        /// <param name="dashType">The border dash type.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;% Html.Kendo().LinearGauge()
        ///           .Name("linearGauge")
        ///           .GaugeArea(gaugeArea => gaugeArea.Border(1, "#000", ChartDashType.Dot))
        ///           .Render();
        /// %&gt;
        /// </code>
        /// </example>        
        public LinearGaugeGaugeAreaSettingsBuilder Border(int width, string color, ChartDashType dashType)
        {
            Container.Border.Width = width;
            Container.Border.Color = color;
            Container.Border.DashType = dashType;

            return this;
        }
    }
}
