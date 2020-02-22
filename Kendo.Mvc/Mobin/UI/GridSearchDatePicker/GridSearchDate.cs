using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mobin.Common;
using System.IO;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSearchDatePickerBuilder component
    /// </summary>
    public abstract partial class GridSearchDatePicker
    {
        public GridSearchDatePicker(ViewContext viewContext, string gridName) : base(viewContext)
        {
            if (!gridName.HasValue())
                throw new MobinException($"GridName must be specify for GridSearchDatePicker Component");

            GridName = gridName;
        }
    }

    public partial class GridSearchFromDatePicker : GridSearchDatePicker
    {
        public GridSearchFromDatePicker(ViewContext viewContext, string gridName) : base(viewContext, gridName)
        {
        }

        protected override void WriteHtml(TextWriter writer)
        {
            // Do custom rendering here
            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here			

            writer.Write(Initializer.Initialize(Selector, "GridSearchFromDatePicker", settings));
        }
    }

    public partial class GridSearchToDatePicker : GridSearchDatePicker
    {
        public GridSearchToDatePicker(ViewContext viewContext, string gridName) : base(viewContext, gridName)
        {
        }

        protected override void WriteHtml(TextWriter writer)
        {
            // Do custom rendering here
            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            // TODO: Manually serialized settings go here			

            writer.Write(Initializer.Initialize(Selector, "GridSearchToDatePicker", settings));
        }
    }
}