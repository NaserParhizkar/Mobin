
$(function () {

    //<kendo.ui.AutoComplete>$(technologies).kendoAutoComplete({
    //    dataSource: data,
    //    filter: "startswith",
    //    placeholder: "Select technology...",
    //    separator: ", "
    //}).data("kendoAutoComplete");

    class Path {
        PathId: number;
        Name: string;
        Distance: number;
        Rent: number;
    }

    let cols: kendo.ui.GridColumn[] = [];
    let col: kendo.ui.GridColumn = {
    };
    cols.push(
        {
            title: 'کد',
            field: 'PathId',
            encoded: true
        },
        {
            title: 'نام مسیر',
            field: 'Name',
            encoded: true
        });

    let myGrid: HTMLDivElement = document.createElement('div');
    myGrid.id = 'myGrid';

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

    let pathGridOptions: kendo.ui.GridOptions =
    {
        columns: cols,
        selectable: "Single, Row",
        dataSource: ds
    };

    //let grd: kendo.ui.Grid = new kendo.ui.Grid(myGrid,
    //    {
    //        columns: cols,
    //        selectable: "Single, Row",
    //        dataSource : ds
    //    });

    var data =
        [
            { "FirstName": "ناصر", "LastName": "پرهیزکار" },
            { "FirstName": "نادر", "LastName": "پرهیزکار" },
            { "FirstName": "علی", "LastName": "پرهیزکار" },
            { "FirstName": "امیر", "LastName": "پرهیزکار" }];


    //let columns: Array<kendo.ui.GridColumn> = [];
    //columns.push({ field: "FirstName", title: "نام" });
    //columns.push({ field: "LastName", title: "نام خانوادگی" });




    //let gridOption: kendo.ui.GridOptions = {
    //    columns: columns,
    //    dataSource: data
    //};

    //var input = document.createElement("div");
    //input.style.position = 'relative';
    //input.id = "technologies";
    //var technologies = document.getElementById('test').appendChild(input);

    //let grid = <kendo.ui.Grid>$(technologies).kendoGrid(pathGridOptions).data("kendoGrid");
});


//class Person {
//    private _nationalCode: number;
//    private _firstName: string;
//    private _lastName: string;
//    private _birthDate: Date;

//    public get NationalCode() {
//        return this._nationalCode;
//    }

//    public set NationalCode(val) {
//        this._nationalCode = val;
//    }

//    public get FirstName() {
//        return this._firstName;
//    }

//    public set FirstName(val) {
//        this._firstName = val;
//    }

//    public get LastName() {
//        return this._lastName;
//    }

//    public set LastName(val) {
//        this._lastName = val;
//    }

//    public get BirthDate() {
//        return this._birthDate;
//    }

//    public set BirthDate(val) {
//        this._birthDate = val;
//    }
//}

//class Employee extends Person {
//    private _ssn: number;

//    public get Ssn() {
//        return this._ssn;
//    }

//    public set Ssn(val) {
//        this._ssn = val;
//    }
//}

//class MyGeneric<T>{
//    private _prop: T;

//    public get Prop() {
//        return this._prop;
//    }

//    public set Prop(val) {
//        this._prop = val;
//    }
//}


//let gen = new MyGeneric<Employee>();
//gen.Prop



//let emp = new Employee();
//emp.Ssn = 100;
//debugger;


module Ajax {
    export class Options {
        url: string;
        method: string;
        data: Object;
        constructor(url: string, method?: string, data?: Object) {
            this.url = url;
            this.method = method || "get";
            this.data = data || {};
        }
    }

    export class Service {
        public request = (options: Options, successCallback: Function, errorCallback?: Function): void => {
            var that = this;
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
        }
        public get = (url: string, successCallback: Function, errorCallback?: Function): void => {
            this.request(new Options(url), successCallback, errorCallback);
        }
        public getWithDataInput = (url: string, data: Object, successCallback: Function, errorCallback?: Function): void => {
            this.request(new Options(url, "get", data), successCallback, errorCallback);
        }
        public post = (url: string, successCallback: Function, errorCallback?: Function): void => {
            this.request(new Options(url, "post"), successCallback, errorCallback);
        }
        public postWithData = (url: string, data: Object, successCallback: Function, errorCallback?: Function): void => {
            this.request(new Options(url, "post", data), successCallback, errorCallback);
        }

        public showJqueryDialog = (message: string, title?: string, height?: number): void => {
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
        }
    }
}


function dataEntryPartialFormSubmit(ev) {

    // Initialize the Kendo UI Validator on your "form" container
    // (NOTE: Does NOT have to be a HTML form tag)

    var validator = $("#a").kendoValidator({
        validate: function () {
            $(".k-invalid:first").focus();
        }
    }).data("kendoValidator");


    // Validate the input when the Save button is clicked
    if (validator.validate()) {
        // If the form is valid, the Validator will return true
        //save();

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