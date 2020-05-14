/** 
 * Kendo UI v2017.2.504 (http://www.telerik.com/kendo-ui)                                                                                                                                               
 * Copyright 2017 Telerik AD. All rights reserved.                                                                                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/
(function (f, define) {
    define('kendo.gridsearchdropdownlist', [
        'kendo.core',
        'kendo.dropdownlist'
    ], f);
}(function () {
    var __meta__ = {
        id: 'gridsearchdropdownlist',
        name: 'GridSearchDropDownList',
        category: 'web',
        description: 'The GridSearchDropDownList widget displays a list of values and allows the selection of a single value from the list.',
        depends: ['dropdownlist']
    };
    (function ($, undefined) {
        var kendo = window.kendo, ui = kendo.ui, DropDownList = ui.DropDownList;
        var GridSearchDropDownList = DropDownList.extend({
            init: function (element, options) {
                var that = this;
                DropDownList.fn.init.call(that, element, options);
                options = that.options;
                if (!that.checkGridState(options.gridname))
                    throw new Error('error');
            },
            select: function (a,b,c,d) {
                debugger;
            },
            options: {
                name: 'GridSearchDropDownList',
                gridname: ''
            },
            checkGridState: function (gridname) {
                if (gridname === undefined || gridname === '')
                    throw new Error('You must specify grid name which this search is for it');

                //var grid = $('#'+gridname).data('kendoGrid');

                //if (!grid)
                //    throw new Error('Grid name specified "' + gridname + '" is not any grid name in this form')

                return true;
            },
        });
        ui.plugin(GridSearchDropDownList);
    }(window.kendo.jQuery));
    return window.kendo;
}, typeof define == 'function' && define.amd ? define : function (a1, a2, a3) {
    (a3 || a2)();
}));