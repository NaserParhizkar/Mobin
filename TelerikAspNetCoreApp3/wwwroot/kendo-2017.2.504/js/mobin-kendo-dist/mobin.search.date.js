var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
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
        return GridSearchFromDatePicker;
    }(kendo.ui.DatePicker));
    KendoWidgets.GridSearchFromDatePicker = GridSearchFromDatePicker;
    GridSearchFromDatePicker.fn = GridSearchFromDatePicker.prototype;
    GridSearchFromDatePicker.fn.options = $.extend(true, {
        change: function (e) {
            console.log("change has been called");
        }
    }, kendo.ui.DatePicker.fn.options);
    GridSearchFromDatePicker.fn.options.name = "GridSearchFromDatePicker";
    kendo.ui.plugin(GridSearchFromDatePicker);
})(KendoWidgets || (KendoWidgets = {}));
//# sourceMappingURL=mobin.search.date.js.map