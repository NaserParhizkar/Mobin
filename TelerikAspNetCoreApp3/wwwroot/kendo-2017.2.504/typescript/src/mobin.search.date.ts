///// <reference path="kendo.all.d.ts" />

//let kendoJquery: JQuery;


//(function (f, define) {
//    define('kendo.gridsearchdate', ['kendo.datepicker'], f);
//}(function () {
//    var __meta__ = {
//        id: 'gridsearchdate',
//        name: 'GridSearchDate',
//        category: 'web',
//        description: 'The GridSearchDate widget can bind to a grid for searching contents related to the grid.',
//        depends: ['datepicker']
//    };


//    (function ($, undefined) {
//        class GridSearchDate extends kendo.ui.DatePicker {
//            init(element, options) {
//                var that = this, value, id;
//                super.init.call(that, element, options);
//            }
//            options: {
//                name: 'GridSearchDate',
//                gridname: '',
//                value: null,
//                round: true,
//                factor: 1
//            }
//        }
//        kendo.ui.plugin(GridSearchDate);
//    }(kendoJquery));



//    return window.kendo;
//},
//    //typeof define == 'function' && define.amd ? define :
//    function (a1, a2, a3) {
//    (a3 || a2)();
//}));

/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />

module KendoWidgets {
    // (Optional) Extend the default widget options.
    export interface IGridDatePickerOptions extends kendo.ui.DatePickerOptions {
        gridname: '',
    }

    // Create a class which inherits from the Kendo UI widget.
    export class GridSearchFromDatePicker extends kendo.ui.DatePicker {
        constructor(element: Element, options?: IGridDatePickerOptions) {
            super(element, options);
        }

        checkGridState(gridname: string): boolean {
            if (gridname === undefined || gridname === '')
                throw new Error('You must specify grid name which this search is for it');

            return true;
        }
    }

    // Create an alias of the prototype (required by kendo.ui.plugin).
    GridSearchFromDatePicker.fn = GridSearchFromDatePicker.prototype;

    // Deep clone the widget default options.
    GridSearchFromDatePicker.fn.options = $.extend(true, {
        change(e: kendo.ui.DatePickerEvent) {
            const sender = <GridSearchFromDatePicker>e.sender;
            const options = <IGridDatePickerOptions>sender.options;

            console.log("change has been called");
        }
    }, kendo.ui.DatePicker.fn.options);

    // Specify the name of your Kendo UI widget. Used to create the corresponding jQuery plugin.
    GridSearchFromDatePicker.fn.options.name = "GridSearchFromDatePicker";

    // Create a jQuery plugin.
    kendo.ui.plugin(GridSearchFromDatePicker);
}
// Expose the newly created jQuery plugin to TypeScript.
interface JQuery {
    kendoGridSearchFromDatePicker(options: kendo.ui.DatePickerOptions): JQuery;
}
//$(function () {
//    // Initialize your custom widget.
//    $("#datepicker").kendoGridSearchFromDatePicker({ culture: "fa-IR" });
//    // Get a reference to the widget instance.
//    //var myDatePicker = <KendoWidgets.MyDatePicker>$("#datepicker").data("kendoMyDatePicker");
//    //myDatePicker.options.culture = "fa-IR";
//    //// Call a widget method.
//    //myDatePicker.open();

//})

