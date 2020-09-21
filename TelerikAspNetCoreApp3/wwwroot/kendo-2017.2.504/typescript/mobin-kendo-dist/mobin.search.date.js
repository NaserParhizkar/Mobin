var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var KendoWidgets;
(function (KendoWidgets) {
    var GridSearchFromDatePicker = (function (_super) {
        __extends(GridSearchFromDatePicker, _super);
        function GridSearchFromDatePicker(element, options) {
            return _super.call(this, element, options) || this;
        }
        GridSearchFromDatePicker.prototype.checkGridState = function (gridname) {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');
            return true;
        };
        return GridSearchFromDatePicker;
    }(kendo.ui.DatePicker));
    KendoWidgets.GridSearchFromDatePicker = GridSearchFromDatePicker;
    var GridSearchToDatePicker = (function (_super) {
        __extends(GridSearchToDatePicker, _super);
        function GridSearchToDatePicker(element, options) {
            return _super.call(this, element, options) || this;
        }
        GridSearchToDatePicker.prototype.checkGridState = function (gridname) {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');
            return true;
        };
        return GridSearchToDatePicker;
    }(kendo.ui.DatePicker));
    KendoWidgets.GridSearchToDatePicker = GridSearchToDatePicker;
    GridSearchFromDatePicker.fn = GridSearchFromDatePicker.prototype;
    GridSearchToDatePicker.fn = GridSearchToDatePicker.prototype;
    GridSearchFromDatePicker.fn.options = $.extend(true, {
        change: function (e) {
            var sender = e.sender;
            var options = sender.options;
            var gridname = options.gridname;
            var grid = $("#" + gridname).data('kendoGrid');
            var value = sender.value();
            var filter = grid.dataSource.filter();
            var bindedpropertyname = options.bindedpropertyname;
            if (filter && filter.filters) {
                var preFilters = {
                    filters: [],
                    logic: 'and'
                };
                preFilters.filters = filter.filters;
                var uniqueFilters = [];
                uniqueFilters = $.grep(preFilters.filters, function (item) {
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
        change: function (e) {
            var sender = e.sender;
            var options = sender.options;
            var gridname = options.gridname;
            var grid = $("#" + gridname).data('kendoGrid');
            var value = sender.value();
            var filter = grid.dataSource.filter();
            var bindedpropertyname = options.bindedpropertyname;
            if (filter && filter.filters) {
                var preFilters = {
                    filters: [],
                    logic: 'and'
                };
                preFilters.filters = filter.filters;
                var uniqueFilters = [];
                uniqueFilters = $.grep(preFilters.filters, function (item) {
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