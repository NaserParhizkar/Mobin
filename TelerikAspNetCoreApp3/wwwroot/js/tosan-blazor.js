window.Blazor = {
    kendoWindow(componentId, options) {
        kendo.syncReady(function () {
            jQuery("#componentId").kendoWindow({
                "draggable": true,
                "height": 400,
                "modal": true,
                "scrollable": true,
                "title": "Window Usually",
                "visible": true,
                "width": 400,
                "content": null,
                "actions": ["Maximize", "Close"]
            });
        })
    }
}