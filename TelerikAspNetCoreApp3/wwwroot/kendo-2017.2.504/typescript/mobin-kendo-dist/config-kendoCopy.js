var Path = (function () {
    function Path() {
    }
    return Path;
}());
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
var Ajax = (function () {
    function Ajax() {
        this.READY_STATUS_CODE = 4;
    }
    Ajax.prototype.isCompleted = function (request) {
        return request.readyState === this.READY_STATUS_CODE;
    };
    Ajax.prototype.httpGet = function (url) {
        var _this = this;
        return new Promise(function (resolve, reject) {
            var request = new XMLHttpRequest();
            request.onreadystatechange = function () {
                if (_this.isCompleted(request)) {
                    resolve(request);
                }
            };
            request.open('GET', url, true);
            request.send();
        });
    };
    Ajax.prototype.httpPost = function (url, data) {
        var _this = this;
        return new Promise(function (resolve, reject) {
            var request = new XMLHttpRequest();
            request.onreadystatechange = function () {
                if (_this.isCompleted(request)) {
                    resolve(request);
                }
            };
            request.open('POST', url, true);
            request.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
            request.send(data);
        });
    };
    return Ajax;
}());
function submitPartialEntryForm(ev) {
    var validator = $('#a').kendoValidator({
        validate: function () {
            $(".k-invalid:first").focus();
        }
    }).data("kendoValidator");
    if (validator.validate()) {
        var aj = new Ajax();
        var frm = $(ev).closest('form');
        if (frm) {
            var submitData = frm.serializeArray();
            aj.httpPost('PathApi/Insert', submitData.toString());
        }
    }
    else {
        return false;
    }
}
//# sourceMappingURL=config-kendoCopy.js.map