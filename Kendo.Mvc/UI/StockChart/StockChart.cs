using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI StockChart component
    /// </summary>
    public partial class StockChart<T> : Chart<T>
        where T : class
    {
        public StockChart(ViewContext viewContext) : base(viewContext)
        {
            Navigator = new StockChartNavigatorSettings<T>(this, viewContext);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here

            SerializeCustomSettings(settings);

            writer.Write(Initializer.Initialize(Selector, "StockChart", settings));
        }

        protected override void SerializeCustomSettings(IDictionary<string, object> settings)
        {
            base.SerializeCustomSettings(settings);
        }
    }
}

