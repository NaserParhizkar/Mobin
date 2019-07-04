/*
* Kendo UI v2015.3.930 (http://www.telerik.com/kendo-ui)
* Copyright 2015 Telerik AD. All rights reserved.
*
* Kendo UI commercial licenses may be obtained at
* http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
(function (f, define) {
    define(["./kendo.draganddrop"], f);
})(function () {

    (function () {
        (function ($, undefined) {
            var kendo = window.kendo,
                Widget = kendo.ui.Widget,
                Draggable = kendo.ui.Draggable,
                isPlainObject = $.isPlainObject,
                activeElement = kendo._activeElement,
                proxy = $.proxy,
                extend = $.extend,
                each = $.each,
                template = kendo.template,
                BODY = "body",
                templates,
                NS = ".kendoOrmForm",
                // classNames
                KWINDOW = ".k-window",
                KWINDOWTITLE = ".k-window-title",
                KWINDOWTITLEBAR = KWINDOWTITLE + "bar",
                KWINDOWCONTENT = ".k-window-content",
                KWINDOWRESIZEHANDLES = ".k-resize-handle",
                KOVERLAY = ".k-overlay",
                KCONTENTFRAME = "k-content-frame",
                LOADING = "k-loading",
                KHOVERSTATE = "k-state-hover",
                KFOCUSEDSTATE = "k-state-focused",
                MAXIMIZEDSTATE = "k-window-maximized",
                // constants
                VISIBLE = ":visible",
                HIDDEN = "hidden",
                CURSOR = "cursor",
                // events
                OPEN = "open",
                ACTIVATE = "activate",
                DEACTIVATE = "deactivate",
                CLOSE = "close",
                REFRESH = "refresh",
                RESIZE = "resize",
                RESIZEEND = "resizeEnd",
                DRAGSTART = "dragstart",
                DRAGEND = "dragend",
                ERROR = "error",
                OVERFLOW = "overflow",
                ZINDEX = "zIndex",
                MINIMIZE_MAXIMIZE = ".k-window-actions .k-i-minimize,.k-window-actions .k-i-maximize",
                KPIN = ".k-i-pin",
                KUNPIN = ".k-i-unpin",
                PIN_UNPIN = KPIN + "," + KUNPIN,
                TITLEBAR_BUTTONS = ".k-window-titlebar .k-window-action",
                REFRESHICON = ".k-window-titlebar .k-i-refresh",
                isLocalUrl = kendo.isLocalUrl;

            var OrmForm = Widget.extend({
                init: function (element, options) {
                    var that = this,
                     wrapper,
                     id;

                    Widget.fn.init.call(that, element, options);
                    options = that.options;
 
                    element = that.element;
                   
                    if (options.grid) {
                        this.actOnSelect();
                        var grd = $(element).kendoGrid(options.grid);
                    }
                },

                actOnSelect: function () {
                    var that = this,
                   wrapper,
                    options = that.options;

                    options.grid.change = function(e) {
                        var dataItem = null,
                        selectedRows = this.select();
                            for (var i = 0; i < selectedRows.length; i++) {
                                dataItem = this.dataItem(selectedRows[i]);
                            }
                            
                            // selectedDataItems contains all selected data items
                        }
                },

                setOptions: function (options) {
                    var that = this;
                    Widget.fn.setOptions.call(this, options);
                },

                options: {
                    name:"OrmForm",
                    grid: {}
                }
            });

            kendo.ui.plugin(OrmForm);

        })(window.kendo.jQuery);
        
    })();

    return window.kendo;

}, typeof define == 'function' && define.amd ? define : function (_, f) { f(); });