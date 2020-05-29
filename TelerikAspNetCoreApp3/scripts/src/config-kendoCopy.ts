declare module kendo.data {
    interface MobinDataSourceSchemaModelField<TModel> {
        field?: string;
        from?: string;
        defaultValue?: any;
        editable?: boolean;
        nullable?: boolean;
        parse?: Function;
        type?: string;
        validation?: DataSourceSchemaModelFieldValidation;
    }

    class MobinModel extends ObservableObject {
        idField: string;
        _defaultId: any;
        fields: DataSourceSchemaModelFields;
        defaults: {
            [field: string]: any;
        };
        constructor(data?: any);
        init(data?: any): void;
        dirty: boolean;
        id: any;
        editable(field: string): boolean;
        isNew(): boolean;
        static idField: string;
        static fields: DataSourceSchemaModelFields;
        static define(options: DataSourceSchemaModelWithFieldsObject): typeof Model;
        static define(options: DataSourceSchemaModelWithFieldsArray): typeof Model;
    }
}





class Path {
    PathId: number;
    Name: string;
    Distance: number;
    Rent: number;
}



let ds: kendo.data.DataSource = new kendo.data.DataSource({
    transport: {
        read: { url: "Path/Read" } as kendo.data.DataSourceTransportRead
    },
    serverPaging: true,
    serverSorting: true,
    serverFiltering: true,
    serverGrouping: true,
    serverAggregates: true,
    schema: {
        data: "Data", total: "Total", errors: "Errors",
        model: {
            fields:
                [{ field: "ID", type: 'number' },
                { field: "PathId", type: 'number' },
                { field: "Name", type: 'string' },
                { field: "Distance", type: 'number' },
                { field: "Rent", type: 'number' },
                { field: "PathDetails", type: 'object' },
                { field: "Buses", type: 'object' }] as kendo.data.DataSourceSchemaModelField[]
        } as kendo.data.DataSourceSchemaModel,
    }
});

class Ajax {
    private readonly READY_STATUS_CODE = 4;
    private isCompleted(request: XMLHttpRequest) {
        return request.readyState === this.READY_STATUS_CODE;
    }
    httpGet(url: string) {
        return new Promise<XMLHttpRequest>((resolve, reject) => {
            // Create a request
            const request = new XMLHttpRequest();
            // Attach an event listener
            request.onreadystatechange = () => {
                if (this.isCompleted(request)) {
                    resolve(request);
                }
            };
            // Specify the HTTP verb and URL
            request.open('GET', url, true);
            // Send the request
            request.send();
        });
    }

    httpPost(url: string, data: string) {
        return new Promise<XMLHttpRequest>((resolve, reject) => {
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

    // Validate the input when the Save button is clicked
    if (validator.validate()) {
        // If the form is valid, the Validator will return true
        //save();
        const aj: Ajax = new Ajax();
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