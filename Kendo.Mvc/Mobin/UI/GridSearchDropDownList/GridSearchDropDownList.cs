using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mobin.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI GridSearchDropDownList component
    /// </summary>
    public partial class GridSearchDropDownList : DropDownList
    {
        private static readonly Regex EscapeRegex = new Regex(@"([;&,\.\+\*~'\:\""\!\^\$\[\]\(\)\|\/])", RegexOptions.Compiled);

        public GridSearchDropDownList(ViewContext viewContext,string gridName) : base(viewContext)
        {
            if (!gridName.HasValue())
                throw new MobinException($"GridName must be specify for GridSearchDropDownList Component");

            GridName = gridName;
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            if (DataSource.ServerFiltering && !DataSource.Transport.Read.Data.HasValue() &&
                DataSource.Type != DataSourceType.Custom && DataSource.Type != DataSourceType.Ajax)
            {
                DataSource.Transport.Read.Data = new ClientHandlerDescriptor
                {
                    HandlerName = "function() { return kendo.ui.GridSearchDropDownList.requestData(jQuery(\"" + EscapeRegex.Replace(Selector, @"\\$1") + "\")); }"
                };
            }

            var settings = SerializeSettings();

            var animation = Animation.ToJson();
            if (animation.Keys.Any())
            {
                settings["animation"] = animation["animation"];
            }

            if (!string.IsNullOrEmpty(DataSource.Transport.Read.Url) ||
                !string.IsNullOrEmpty(DataSource.Transport.Read.ActionName) ||
                DataSource.Type == DataSourceType.Custom)
            {
                settings["dataSource"] = DataSource.ToJson();
            }
            else if (DataSource.Data != null)
            {
                settings["dataSource"] = DataSource.Data;
            }

            if (SelectedIndex.HasValue && SelectedIndex > -1)
            {
                settings["index"] = SelectedIndex;
            }

            writer.Write(Initializer.Initialize(Selector, "GridSearchDropDownList", settings));
        }
    }
}

