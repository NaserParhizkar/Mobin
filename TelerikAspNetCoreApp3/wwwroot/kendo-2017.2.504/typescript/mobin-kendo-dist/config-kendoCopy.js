class Path {
}
let ds = new kendo.data.DataSource({
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
class Ajax {
    constructor() {
        this.READY_STATUS_CODE = 4;
    }
    isCompleted(request) {
        return request.readyState === this.READY_STATUS_CODE;
    }
    httpGet(url) {
        return new Promise((resolve, reject) => {
            const request = new XMLHttpRequest();
            request.onreadystatechange = () => {
                if (this.isCompleted(request)) {
                    resolve(request);
                }
            };
            request.open('GET', url, true);
            request.send();
        });
    }
    httpPost(url, data) {
        return new Promise((resolve, reject) => {
            const request = new XMLHttpRequest();
            request.onreadystatechange = () => {
                if (this.isCompleted(request)) {
                    resolve(request);
                }
            };
            request.open('POST', url, true);
            request.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
            request.send(data);
        });
    }
}
function submitPartialEntryForm(ev) {
    var validator = $('#a').kendoValidator({
        validate: function () {
            $(".k-invalid:first").focus();
        }
    }).data("kendoValidator");
    if (validator.validate()) {
        const aj = new Ajax();
        const frm = $(ev).closest('form');
        if (frm) {
            const submitData = frm.serializeArray();
            aj.httpPost('PathApi/Insert', submitData.toString());
        }
    }
    else {
        return false;
    }
}
//# sourceMappingURL=config-kendoCopy.js.map