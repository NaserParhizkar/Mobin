namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Defines the sort modes supported by Kendo UI Grid for ASP.NET MVC
    /// </summary>
    public enum GridSortMode
    {
        /// <summary>
        /// The user can sort only by one column at the same time
        /// </summary>
        SingleColumn,
        /// <summary>
        /// The user can sort by more than one column at the same time
        /// </summary>
        MultipleColumn
    }

    internal static class GridSortModeExtensions
    {
        internal static string Serialize(this GridSortMode value)
        {
            switch (value)
            {
                case GridSortMode.SingleColumn:
                    return "single";
                case GridSortMode.MultipleColumn:
                    return "multiple";
            }

            return value.ToString();
        }
    }
}

