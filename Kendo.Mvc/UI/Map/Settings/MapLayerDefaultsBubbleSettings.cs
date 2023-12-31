using Kendo.Mvc.Extensions;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI MapLayerDefaultsBubbleSettings class
    /// </summary>
    public partial class MapLayerDefaultsBubbleSettings
    {
        public string SymbolName { get; set; }

        public ClientHandlerDescriptor SymbolHandler { get; set; }

        public Dictionary<string, object> Serialize()
        {
            var settings = SerializeSettings();

            if (SymbolHandler != null)
            {
                settings["symbol"] = SymbolHandler;
            }
            else if (SymbolName.HasValue())
            {
                settings["symbol"] = SymbolName;
            }
            else if (Symbol.HasValue)
            {
                settings["symbol"] = Symbol.ToString().ToLowerInvariant();
            }

            return settings;
        }
    }
}
