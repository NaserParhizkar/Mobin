using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class PanelBarItem : NavigationItem<PanelBarItem>, INavigationItemContainer<PanelBarItem>, IAsyncContentContainer
    {
        private string loadContentFromUrl;

        public PanelBarItem()
        {
            Items = new List<PanelBarItem>();
        }

        public string Id { get; set; }

        public bool Expanded
        {
            get;
            set;
        }

        public string ContentUrl
        {
            get
            {
                return loadContentFromUrl;
            }

            set
            {
                loadContentFromUrl = value;
                ContentHtmlAttributes.Clear();
                Content = null;
            }
        }

        public IList<PanelBarItem> Items
        {
            get;
            private set;
        }
    }
}
