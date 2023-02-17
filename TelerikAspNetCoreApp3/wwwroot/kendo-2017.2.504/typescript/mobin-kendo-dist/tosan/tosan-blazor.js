var _global = (window || globalThis);
_global.blazor = {
    mobinWindow: function (componentId, options) {
        var win = new kendo.ui.Window(componentId, options);
        win.open();
    },
    editForm: {
        validate: function (componentId) {
            var validator = new kendo.ui.Validator(componentId, {
                validate: function (ev) {
                    alert(ev);
                }
            });
            if (validator.validate()) {
                alert("validated");
            }
            else {
                alert("invalid");
            }
        }
    }
};
//# sourceMappingURL=tosan-blazor.js.map