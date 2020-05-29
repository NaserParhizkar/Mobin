/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />


//module KendoWidgets {
//    // (Optional) Extend the default widget options.
//    interface IGridInputChangeEvent {
//        sender: GridSearchInputPicker;
//        isDefaultPrevented(): boolean;
//        preventDefault: Function;
//    }

//    export interface IGridInputOptions {
//        gridname: string;
//        name?: string;
//        culture?: string;
//        placeholder?: string;
//        value?: number;
//        change?(e: IGridInputChangeEvent): void;
//    }


//    // Create a class which inherits from the Kendo UI widget.
//    export class GridSearchInputPicker extends kendo.ui.Widget {
//        constructor(element: Element, options?: IGridInputOptions) {
//            super(element, options);
//        }

//        checkGridState(gridname: string): boolean {
//            if (gridname === undefined || gridname === '')
//                throw new Error('You must specify grid name which this search is for it');

//            return true;
//        }

//        public value(): number {
//            return this.element.val();
//        }
//    }

//    // Create an alias of the prototype (required by kendo.ui.plugin).
//    GridSearchInputPicker.fn = GridSearchInputPicker.prototype;

//    // Deep clone the widget default options.
//    GridSearchInputPicker.fn.options = $.extend(true, {
//        change(e: IGridInputChangeEvent) {
//            const sender = <GridSearchInputPicker>e.sender;
//            const options = <IGridInputOptions>sender.options;
//            const gridname = options.gridname;
//            const grid = <kendo.ui.Grid>$("#" + gridname).data('kendoGrid');
//            const value = sender.value();
//            const filter = grid.dataSource.filter();

//            if (value) {
//                if (filter && filter.filters) {
//                    let preFilters = {
//                        filters: [],
//                        logic: 'and'
//                    };
//                    preFilters.filters = filter.filters;
//                    let uniqueFilters = [];
//                    uniqueFilters = $.grep(preFilters.filters, (item) => {
//                        return item.field != value || (item.field == value && item.operator != 'gte');
//                    });
//                    preFilters.filters = uniqueFilters;
//                    preFilters.filters.push({ field: value, operator: 'gte', value: value });
//                    grid.dataSource.filter(preFilters);
//                } else {
//                    //grid.dataSource.filter({ field: value, operator: 'gte', value: value });
//                }
//            } else {
//                grid.dataSource.filter({});
//            }
//        }
//    }, GridSearchInputPicker.fn.options);

//    //// Specify the name of your Kendo UI widget. Used to create the corresponding jQuery plugin.
//    //GridSearchInputPicker.name = "GridSearchFromDatePicker";

//    // Create a jQuery plugin.
//    kendo.ui.plugin(GridSearchInputPicker);
//}
//// Expose the newly created jQuery plugin to TypeScript.
//interface JQuery {
//    kendoGridSearchInputPicker(options: KendoWidgets.IGridInputOptions): JQuery;
//}





class GridSearchInput extends kendo.ui.Widget {
    static fn: GridSearchInput;
    static extend(proto: GridSearchInput): GridSearchInput {
        proto.init = function () {
            let that = this;
            let element = that.element;
            let options = that.options;
            kendo.ui.Widget.fn.init.call(that, element, options);
            options = that.options;
            if (!that.checkGridState(options.gridname))
                throw new Error('error');
            //    element = that.element.on('focusout' + ns, proxy(that._focusout, that))
            //        .on('keydown' + ns, proxy(that._keydown, that))
            //        .on('keypress' + ns, proxy(that._keypress, that))
            //        .on('keyup' + ns, proxy(that._keyup, that));

            //    that._initialOptions = extend({}, options);
            //    that._wrapper();
            //    that._validation();
            //    value = options.value;
            //    kendo.notify(that);
            //}
        }

        return proto;
    }

    element: JQuery;
    wrapper: JQuery;
    constructor(element: Element, options?: IGridSearchInputOptions) {
        super(element, options);
    }
    options: IGridSearchInputOptions;
    enable(enable: boolean): void {

    }
    readonly(readonly: boolean): void {

    }
    focus(): void {

    }
    get value(): number | string {
        if (typeof this.options.value === 'number')
            return (<number>this.options.value);
        return <number>-1;
    }
    set value(value: number | string) {
        if (typeof value === 'number')
            this.options.value = <number>value;
        else
            this.options.value = <string>value;
    }
}

interface IGridSearchInputOptions {
    name?: string;
    gridname: string,
    culture?: string;
    decimals?: number;
    value?: number | string;
    change?(e: GridSearchInput): {

    }
}
interface GridSearchInputEvent {
    sender: GridSearchInput;
    isDefaultPrevented(): boolean;
    preventDefault: Function;
}

interface GridSearchInputChangeEvent extends GridSearchInputEvent {
}

