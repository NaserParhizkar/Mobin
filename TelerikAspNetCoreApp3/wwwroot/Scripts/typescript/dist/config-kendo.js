/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
$(function () {
    //<kendo.ui.AutoComplete>$(technologies).kendoAutoComplete({
    //    dataSource: data,
    //    filter: "startswith",
    //    placeholder: "Select technology...",
    //    separator: ", "
    //}).data("kendoAutoComplete");
    var data = [
        { "FirstName": "ناصر", "LastName": "پرهیزکار" },
        { "FirstName": "نادر", "LastName": "پرهیزکار" },
        { "FirstName": "علی", "LastName": "پرهیزکار" },
        { "FirstName": "امیر", "LastName": "پرهیزکار" }
    ];
    var columns = [];
    columns.push({ field: "FirstName", title: "نام" });
    columns.push({ field: "LastName", title: "نام خانوادگی" });
    var gridOption = {
        columns: columns,
        dataSource: data
    };
    var input = document.createElement("div");
    input.id = "technologies";
    var technologies = document.body.appendChild(input);
    var grid = $(technologies).kendoGrid(gridOption).data("kendoGrid");
});
var Person = /** @class */ (function () {
    function Person() {
    }
    Object.defineProperty(Person.prototype, "NationalCode", {
        get: function () {
            return this._nationalCode;
        },
        set: function (val) {
            this._nationalCode = val;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Person.prototype, "FirstName", {
        get: function () {
            return this._firstName;
        },
        set: function (val) {
            this._firstName = val;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Person.prototype, "LastName", {
        get: function () {
            return this._lastName;
        },
        set: function (val) {
            this._lastName = val;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Person.prototype, "BirthDate", {
        get: function () {
            return this._birthDate;
        },
        set: function (val) {
            this._birthDate = val;
        },
        enumerable: true,
        configurable: true
    });
    return Person;
}());
var Employee = /** @class */ (function (_super) {
    __extends(Employee, _super);
    function Employee() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Object.defineProperty(Employee.prototype, "Ssn", {
        get: function () {
            return this._ssn;
        },
        set: function (val) {
            this._ssn = val;
        },
        enumerable: true,
        configurable: true
    });
    return Employee;
}(Person));
var MyGeneric = /** @class */ (function () {
    function MyGeneric() {
    }
    Object.defineProperty(MyGeneric.prototype, "Prop", {
        get: function () {
            return this._prop;
        },
        set: function (val) {
            this._prop = val;
        },
        enumerable: true,
        configurable: true
    });
    return MyGeneric;
}());
//let gen = new MyGeneric<Employee>();
//gen.Prop
//let emp = new Employee();
//emp.Ssn = 100;
//debugger;
//# sourceMappingURL=config-kendo.js.map