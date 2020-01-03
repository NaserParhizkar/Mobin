using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI ContextMenuItem class
    /// </summary>
    public partial class ContextMenuItem : NavigationItem<ContextMenuItem>, INavigationItemContainer<ContextMenuItem>
    {
        public ContextMenuItem()
        {
            Items = new List<ContextMenuItem>();
        }

        public IList<ContextMenuItem> Items
        {
            get;
            private set;
        }

        public bool Separator { get; set; }

        public ContextMenu ContextMenu { get; set; }
    }
}
