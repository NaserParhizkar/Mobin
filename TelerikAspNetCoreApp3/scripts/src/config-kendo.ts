
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


    let columns: Array<kendo.ui.GridColumn> = [];
    columns.push({ field: "FirstName", title: "نام" });
    columns.push({ field: "LastName", title: "نام خانوادگی" });




    let gridOption: kendo.ui.GridOptions = {
        columns: columns,
        dataSource: data
    };

    var input = document.createElement("div");
    input.style.position = 'relative';
    input.id = "technologies";
    var technologies = document.getElementById('test').appendChild(input);

    let grid = <kendo.ui.Grid>$(technologies).kendoGrid(pathGridOptions).data("kendoGrid");
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