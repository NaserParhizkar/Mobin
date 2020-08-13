var KendoWidgets;
(function (KendoWidgets) {
    class GridSearchFromDatePicker extends kendo.ui.DatePicker {
        constructor(element, options) {
            super(element, options);
        }
        checkGridState(gridname) {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');
            return true;
        }
    }
    KendoWidgets.GridSearchFromDatePicker = GridSearchFromDatePicker;
    class GridSearchToDatePicker extends kendo.ui.DatePicker {
        constructor(element, options) {
            super(element, options);
        }
        checkGridState(gridname) {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');
            return true;
        }
    }
    KendoWidgets.GridSearchToDatePicker = GridSearchToDatePicker;
    GridSearchFromDatePicker.fn = GridSearchFromDatePicker.prototype;
    GridSearchToDatePicker.fn = GridSearchToDatePicker.prototype;
    GridSearchFromDatePicker.fn.options = $.extend(true, {
        change(e) {
            const sender = e.sender;
            const options = sender.options;
            const gridname = options.gridname;
            const grid = $("#" + gridname).data('kendoGrid');
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
            }
            else {
                if (value)
                    grid.dataSource.filter({ field: bindedpropertyname, operator: 'gte', value: value });
            }
        }
    }, kendo.ui.DatePicker.fn.options);
    GridSearchToDatePicker.fn.options = $.extend(true, {
        change(e) {
            const sender = e.sender;
            const options = sender.options;
            const gridname = options.gridname;
            const grid = $("#" + gridname).data('kendoGrid');
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
            }
            else {
                if (value)
                    grid.dataSource.filter({ field: bindedpropertyname, operator: 'lte', value: value });
            }
        }
    }, kendo.ui.DatePicker.fn.options);
    GridSearchFromDatePicker.fn.options.name = "GridSearchFromDatePicker";
    GridSearchToDatePicker.fn.options.name = "GridSearchToDatePicker";
    kendo.ui.plugin(GridSearchFromDatePicker);
    kendo.ui.plugin(GridSearchToDatePicker);
})(KendoWidgets || (KendoWidgets = {}));
//# sourceMappingURL=mobin.search.date.js.map