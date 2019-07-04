$(document).ajaxError(function (event, jqxhr, request, settings) {
    debugger;
    if (jqxhr.status != 200) {
        var errorElement = $('<div id=""></div>').appendTo('body');
        var notification = new kendo.ui.Notification(errorElement);
        notification.setOptions({
            "position": { "top": 10, "right": 5 }, "autoHideAfter": 5000,
            "stacking": "down",
            "animation": { "close": { "effects": "zoom:out", "duration": 400 } },
            "templates": [{ "type": "error", "templateId": "errorTemplate" }]
        });
        notification.show({
            title: "وضیعت عملیات",
            message: jqxhr.responseText
        }, "error");
    }
});