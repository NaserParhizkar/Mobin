using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI GridSearchDropDownListBuilder
    /// </summary>
    public partial class GridSearchDropDownListBuilder : DropDownListBuilder
    {
        public GridSearchDropDownListBuilder(GridSearchDropDownList component) : base(component)
        {
        }
    }
}