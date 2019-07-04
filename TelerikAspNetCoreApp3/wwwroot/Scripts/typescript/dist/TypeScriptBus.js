/// <reference path="common.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />
$(function () {
    var input = document.getElementById("bb");
    var technologies = document.body.appendChild(input);
    $(technologies).kendoDatePicker({
        value: new pDate(),
        culture: "fa-IR",
        format: "yyyy/MM/dd",
        min: new pDate(1358, 0, 1, 0, 0, 0, 0),
        max: new pDate(1399, 11, 29, 0, 0, 0, 0)
    });
});
//# sourceMappingURL=TypeScriptBus.js.map