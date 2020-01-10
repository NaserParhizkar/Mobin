namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI NumericTextBox
    /// </summary>
    public abstract partial class GridSearchDatePickerBuilder : DatePickerBuilder
    {
        public GridSearchDatePickerBuilder(GridSearchDatePicker component) : base(component)
        {
        }

        // Place custom settings here
    }

    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI NumericTextBox
    /// </summary>
    public partial class GridSearchFromDatePickerBuilder : GridSearchDatePickerBuilder
    {
        // Place custom settings here
        public GridSearchFromDatePickerBuilder(GridSearchDatePicker component) : base(component)
        {
        }
    }


    /// <summary>
    /// Defines the fluent API for configuring the Kendo UI NumericTextBox
    /// </summary>
    public partial class GridSearchToDatePickerBuilder : GridSearchDatePickerBuilder
    {
        // Place custom settings here
        public GridSearchToDatePickerBuilder(GridSearchDatePicker component) : base(component)
        {
        }
    }
}

