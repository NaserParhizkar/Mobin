namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;

    /// <summary>
    /// Used for serializing <see cref="PanelBarItem"/> objects.
    /// </summary>
    public class PanelBarItemModel : IHierarchicalItem
    {
        public PanelBarItemModel()
        {
            this.Enabled = true;
            this.Encoded = true;
            this.Items = new List<PanelBarItemModel>();
            this.HtmlAttributes = new Dictionary<string, string>();
            this.ImageHtmlAttributes = new Dictionary<string, string>();
            this.LinkHtmlAttributes = new Dictionary<string, string>();
        }

        public bool Enabled { get; set; }

        public bool Expanded { get; set; }

        public bool Encoded { get; set; }

        public bool Selected { get; set; }

        public string Text { get; set; }

        public string SpriteCssClass { get; set; }

        public string Id { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public bool HasChildren { get; set; }

        public List<PanelBarItemModel> Items { get; set; }

        public IDictionary<string, string> HtmlAttributes { get; set; }

        public IDictionary<string, string> ImageHtmlAttributes { get; set; }

        public IDictionary<string, string> LinkHtmlAttributes { get; set; }
    }
}