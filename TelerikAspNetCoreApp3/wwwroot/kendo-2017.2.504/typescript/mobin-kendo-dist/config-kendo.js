$(function () {
    class Path {
    }
    let cols = [];
    let col = {};
    cols.push({
        title: 'کد',
        field: 'PathId',
        encoded: true
    }, {
        title: 'نام مسیر',
        field: 'Name',
        encoded: true
    });
    let myGrid = document.createElement('div');
    myGrid.id = 'myGrid';
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
    let pathGridOptions = {
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
    let columns = [];
    columns.push({ field: "FirstName", title: "نام" });
    columns.push({ field: "LastName", title: "نام خانوادگی" });
    let gridOption = {
        columns: columns,
        dataSource: data
    };
    var input = document.createElement("div");
    input.style.position = 'relative';
    input.id = "technologies";
    var technologies = document.getElementById('test').appendChild(input);
    let grid = $(technologies).kendoGrid(pathGridOptions).data("kendoGrid");
});
//# sourceMappingURL=config-kendo.js.map