/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />


module KendoWidgets {
    // (Optional) Extend the default widget options.
    export interface IGridDatePickerOptions extends kendo.ui.DatePickerOptions {
        gridname: '',
        bindedpropertyname: ''
    }

    // Create a class which inherits from the Kendo UI widget.
    export class GridSearchFromDatePicker extends kendo.ui.DatePicker {
        constructor(element: Element, options?: IGridDatePickerOptions) {
            super(element, options);
        }

        checkGridState(gridname: string): boolean {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');

            return true;
        }
    }

    // Create a class which inherits from the Kendo UI widget.
    export class GridSearchToDatePicker extends kendo.ui.DatePicker {
        constructor(element: Element, options?: IGridDatePickerOptions) {
            super(element, options);
        }

        checkGridState(gridname: string): boolean {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');

            return true;
        }
    }

    // Create an alias of the prototype (required by kendo.ui.plugin).
    GridSearchFromDatePicker.fn = GridSearchFromDatePicker.prototype;

    // Create an alias of the prototype (required by kendo.ui.plugin).
    GridSearchToDatePicker.fn = GridSearchToDatePicker.prototype;

    // Deep clone the widget default options.
    GridSearchFromDatePicker.fn.options = $.extend(true, {
        change(e: kendo.ui.DatePickerEvent) {
            const sender = <GridSearchFromDatePicker>e.sender;
            const options = <IGridDatePickerOptions>sender.options;
            const gridname = options.gridname;
            const grid = <kendo.ui.Grid>$("#" + gridname).data('kendoGrid');
            const value = sender.value();
            const filter = grid.dataSource.filter();
            const bindedpropertyname = options.bindedpropertyname;

            if (filter && filter.filters) {
                let preFilters = {
                    filters: [],
                    logic: 'and'
                };
                preFilters.filters = filter.filters;
                let uniqueFilters = [];
                uniqueFilters = $.grep(preFilters.filters, (item) => {
                    return item.field != bindedpropertyname || (item.field == bindedpropertyname && item.operator != 'gte');
                });
                preFilters.filters = uniqueFilters;
                if (value)
                    preFilters.filters.push({ field: bindedpropertyname, operator: 'gte', value: value });
                grid.dataSource.filter(preFilters);
            } else {
                if (value)
                    grid.dataSource.filter({ field: bindedpropertyname, operator: 'gte', value: value });
            }
        }
    }, kendo.ui.DatePicker.fn.options);

    // Deep clone the widget default options.
    GridSearchToDatePicker.fn.options = $.extend(true, {
        change(e: kendo.ui.DatePickerEvent) {
            const sender = <GridSearchFromDatePicker>e.sender;
            const options = <IGridDatePickerOptions>sender.options;
            const gridname = options.gridname;
            const grid = <kendo.ui.Grid>$("#" + gridname).data('kendoGrid');
            const value = sender.value();
            const filter = grid.dataSource.filter();
            const bindedpropertyname = options.bindedpropertyname;

            if (filter && filter.filters) {
                let preFilters = {
                    filters: [],
                    logic: 'and'
                };
                preFilters.filters = filter.filters;
                let uniqueFilters = [];
                uniqueFilters = $.grep(preFilters.filters, (item) => {
                    return item.field != bindedpropertyname || (item.field == bindedpropertyname && item.operator != 'lte');
                });

                preFilters.filters = uniqueFilters;
                if (value)
                    preFilters.filters.push({ field: bindedpropertyname, operator: 'lte', value: value });
                grid.dataSource.filter(preFilters);
            } else {
                if (value)
                    grid.dataSource.filter({ field: bindedpropertyname, operator: 'lte', value: value });
            }
        }
    }, kendo.ui.DatePicker.fn.options);

    // Specify the name of your Kendo UI widget. Used to create the corresponding jQuery plugin.
    GridSearchFromDatePicker.fn.options.name = "GridSearchFromDatePicker";

    // Specify the name of your Kendo UI widget. Used to create the corresponding jQuery plugin.
    GridSearchToDatePicker.fn.options.name = "GridSearchToDatePicker";

    // Create a jQuery plugin.
    kendo.ui.plugin(GridSearchFromDatePicker);

    // Create a jQuery plugin.
    kendo.ui.plugin(GridSearchToDatePicker);
}
// Expose the newly created jQuery plugin to TypeScript.
interface JQuery {
    kendoGridSearchFromDatePicker(options: kendo.ui.DatePickerOptions): JQuery;
    kendoGridSearchToDatePicker(options: kendo.ui.DatePickerOptions): JQuery;
}
