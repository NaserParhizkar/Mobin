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
var GridSearchInput = (function (_super) {
    __extends(GridSearchInput, _super);
    function GridSearchInput(element, options) {
        return _super.call(this, element, options) || this;
    }
    GridSearchInput.extend = function (proto) {
        proto.init = function () {
            var that = this;
            var element = that.element;
            var options = that.options;
            kendo.ui.Widget.fn.init.call(that, element, options);
            options = that.options;
            if (!that.checkGridState(options.gridname))
                throw new Error('error');
        };
        return proto;
    };
    GridSearchInput.prototype.enable = function (enable) {
    };
    GridSearchInput.prototype.readonly = function (readonly) {
    };
    GridSearchInput.prototype.focus = function () {
    };
    Object.defineProperty(GridSearchInput.prototype, "value", {
        get: function () {
            if (typeof this.options.value === 'number')
                return this.options.value;
            return -1;
        },
        set: function (value) {
            if (typeof value === 'number')
                this.options.value = value;
            else
                this.options.value = value;
        },
        enumerable: false,
        configurable: true
    });
    return GridSearchInput;
}(kendo.ui.Widget));
//# sourceMappingURL=mobin.search.input.js.map