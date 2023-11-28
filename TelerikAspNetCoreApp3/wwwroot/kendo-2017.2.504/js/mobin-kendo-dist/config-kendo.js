$(function () {
    var Path = (function () {
        function Path() {
        }
        return Path;
    }());
    var cols = [];
    var col = {};
    cols.push({
        title: 'کد',
        field: 'PathId',
        encoded: true
    }, {
        title: 'نام مسیر',
        field: 'Name',
        encoded: true
    });
    var myGrid = document.createElement('div');
    myGrid.id = 'myGrid';
    var ds = new kendo.data.DataSource({
        transport: {
            read: { url: "Path/Read" }
        },
        serverPaging: true,
        serverSorting: true,
        serverFiltering: true,
        serverGrouping: true,
        serverAggregates: true,
        schema: {
            data: "Data", total: "Total", errors: "Errors",
            model: {
                fields: [{ field: "ID", type: 'number' },
                    { field: "PathId", type: 'number' },
                    { field: "Name", type: 'string' },
                    { field: "Distance", type: 'number' },
                    { field: "Rent", type: 'number' },
                    { field: "PathDetails", type: 'object' },
                    { field: "Buses", type: 'object' }]
            },
        }
    });
    var pathGridOptions = {
        columns: cols,
        selectable: "Single, Row",
        dataSource: ds
    };
    var data = [
        { "FirstName": "ناصر", "LastName": "پرهیزکار" },
        { "FirstName": "نادر", "LastName": "پرهیزکار" },
        { "FirstName": "علی", "LastName": "پرهیزکار" },
        { "FirstName": "امیر", "LastName": "پرهیزکار" }
    ];
});
var Ajax;
(function (Ajax) {
    var Options = (function () {
        function Options(url, method, data) {
            this.url = url;
            this.method = method || "get";
            this.data = data || {};
        }
        return Options;
    }());
    Ajax.Options = Options;
    var Service = (function () {
        function Service() {
            var _this = this;
            this.request = function (options, successCallback, errorCallback) {
                var that = _this;
                $.ajax({
                    url: options.url,
                    type: options.method,
                    data: options.data,
                    cache: false,
                    success: function (d) {
                        successCallback(d);
                    },
                    error: function (d) {
                        if (errorCallback) {
                            errorCallback(d);
                            return;
                        }
                        var errorTitle = "Error in (" + options.url + ")";
                        var fullError = JSON.stringify(d);
                        console.log(errorTitle);
                        console.log(fullError);
                        that.showJqueryDialog(fullError, errorTitle);
                    }
                });
            };
            this.get = function (url, successCallback, errorCallback) {
                _this.request(new Options(url), successCallback, errorCallback);
            };
            this.getWithDataInput = function (url, data, successCallback, errorCallback) {
                _this.request(new Options(url, "get", data), successCallback, errorCallback);
            };
            this.post = function (url, successCallback, errorCallback) {
                _this.request(new Options(url, "post"), successCallback, errorCallback);
            };
            this.postWithData = function (url, data, successCallback, errorCallback) {
                _this.request(new Options(url, "post", data), successCallback, errorCallback);
            };
            this.showJqueryDialog = function (message, title, height) {
                alert(title + "\n" + message);
                title = title || "Info";
                height = height || 120;
                message = message.replace("\r", "").replace("\n", "<br/>");
                $("<div title='" + title + "'><p>" + message + "</p></div>").dialog({
                    minHeight: height,
                    minWidth: 400,
                    maxHeight: 500,
                    modal: true,
                    buttons: {
                        Ok: function () { $(this).dialog('close'); }
                    }
                });
            };
        }
        return Service;
    }());
    Ajax.Service = Service;
})(Ajax || (Ajax = {}));
function dataEntryPartialFormSubmit(ev) {
    var validator = $("#a").kendoValidator({
        validate: function () {
            $(".k-invalid:first").focus();
        }
    }).data("kendoValidator");
    if (validator.validate()) {
        var customerUrl = "https://localhost:5001/api/PathApi/Insert";
        var service = new Ajax.Service();
        var partialFormElement = $(ev).closest('form');
        if (partialFormElement) {
            var partialFormdata = partialFormElement.serializeArray();
            debugger;
            service.postWithData(customerUrl, partialFormdata, function (d) {
                console.log('success');
            }, function () {
                console.log('fail');
            });
        }
    }
    else {
        return false;
    }
}
//# sourceMappingURL=config-kendo.js.map