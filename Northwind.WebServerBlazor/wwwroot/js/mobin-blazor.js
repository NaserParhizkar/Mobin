window.blazor = {
    kendoWindow: function (componentId) {
        kendo.syncReady(function () {
            jQuery(componentId).kendoWindow({
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
        });
    }
};


window.exampleJsFunctions = {
    showPrompt: function (text) {
        return prompt(text, 'Type your name here');
    },
    displayWelcome: function (welcomeMessage) {
        document.getElementById('welcome').innerText = welcomeMessage;
    },
    returnArrayAsyncJs: function () {
        DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
            .then(data => {
                data.push(4);
                console.log(data);
            });
    },
    sayHello: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync('SayHello')
            .then(r => console.log(r));
    }
};