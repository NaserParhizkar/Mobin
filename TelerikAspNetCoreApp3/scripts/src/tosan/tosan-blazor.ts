let _global = (window || globalThis) as any;
_global.blazor = {
    mobinWindow: (componentId: Element, options: kendo.ui.WindowOptions) => {
        let win: kendo.ui.Window = new kendo.ui.Window(componentId, options);
        win.open();
    },
    editForm : {
        validate: (componentId: Element) => {
            let validator: kendo.ui.Validator = new kendo.ui.Validator(componentId,
                {
                    validate: (ev) => {
                        alert(ev);
                    }
                }
            );

            if (validator.validate()) {
                alert("validated");
            }
            else {
                alert("invalid");
            }
        }
    }
}