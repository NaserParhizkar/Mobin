"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.tosanWindow = void 0;
var tosanWindow = (function () {
    function tosanWindow() {
    }
    tosanWindow.prototype.blazorKendoWindow = function (componentId, options) {
        var win = new kendo.ui.Window(componentId, options);
        return win;
    };
    return tosanWindow;
}());
exports.tosanWindow = tosanWindow;
//# sourceMappingURL=tosan-blazor.js.map