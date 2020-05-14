namespace Kendo.Mvc.UI
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public interface IGridForeignKeyColumn : IGridBoundColumn
    {
        SelectList Data
        {
            get;
            set;
        }

        Action<IDictionary<string, object>, object> SerializeSelectList
        {
            get;
        }
    }
}
