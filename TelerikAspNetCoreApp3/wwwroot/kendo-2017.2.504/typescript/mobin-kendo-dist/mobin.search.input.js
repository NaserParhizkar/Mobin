class GridSearchInput extends kendo.ui.Widget {
    constructor(element, options) {
        super(element, options);
    }
    static extend(proto) {
        proto.init = function () {
            let that = this;
            let element = that.element;
            let options = that.options;
            kendo.ui.Widget.fn.init.call(that, element, options);
            options = that.options;
            if (!that.checkGridState(options.gridname))
                throw new Error('error');
        };
        return proto;
    }
    enable(enable) {
    }
    readonly(readonly) {
    }
    focus() {
    }
    get value() {
        if (typeof this.options.value === 'number')
            return this.options.value;
        return -1;
    }
    set value(value) {
        if (typeof value === 'number')
            this.options.value = value;
        else
            this.options.value = value;
    }
}
//# sourceMappingURL=mobin.search.input.js.map