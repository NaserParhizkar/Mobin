/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />

$(function () {

    //<kendo.ui.AutoComplete>$(technologies).kendoAutoComplete({
    //    dataSource: data,
    //    filter: "startswith",
    //    placeholder: "Select technology...",
    //    separator: ", "
    //}).data("kendoAutoComplete");


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
    input.id = "technologies";
    var technologies = document.body.appendChild(input);

    let grid = <kendo.ui.Grid>$(technologies).kendoGrid(gridOption).data("kendoGrid");
});


class Person
{
    private _nationalCode: number;
    private _firstName: string;
    private _lastName: string;
    private _birthDate: Date;

    public get NationalCode() {
        return this._nationalCode;
    }

    public set NationalCode(val) {
        this._nationalCode = val;
    }

    public get FirstName() {
        return this._firstName;
    }

    public set FirstName(val) {
        this._firstName = val;
    }

    public get LastName() {
        return this._lastName;
    }

    public set LastName(val) {
        this._lastName = val;
    }

    public get BirthDate() {
        return this._birthDate;
    }

    public set BirthDate(val) {
        this._birthDate = val;
    }
}

class Employee extends Person {
    private _ssn: number;

    public get Ssn() {
        return this._ssn;
    }

    public set Ssn(val) {
        this._ssn = val;
    }
}

class MyGeneric<T>{
    private _prop: T;

    public get Prop() {
        return this._prop;
    }

    public set Prop(val) {
        this._prop = val;
    }
}


//let gen = new MyGeneric<Employee>();
//gen.Prop



//let emp = new Employee();
//emp.Ssn = 100;
//debugger;