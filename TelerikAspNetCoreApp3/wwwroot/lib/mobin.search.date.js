
(function (f, define) {
    define('kendo.gridsearchdate', ['kendo.datepicker'], f);
}(function () {
    var __meta__ = {
        id: 'gridsearchdate',
        name: 'GridSearchDate',
        category: 'web',
        description: 'The GridSearchDate widget can bind to a grid for searching contents related to the grid.',
        depends: ['datepicker']
    };
    (function ($, undefined) {
        var kendo = window.kendo,
            support = kendo.support,
            ui = kendo.ui,
            Widget = ui.Widget,
            keys = kendo.keys,
            parse = kendo.parseDate,
            adjustDST = kendo.date.adjustDST,
            getDate = kendo.date.getDate,
            weekInYear = kendo.date.weekInYear,
            extractFormat = kendo._extractFormat,
            template = kendo.template,
            getCulture = kendo.getCulture,
            transitions = kendo.support.transitions,
            transitionOrigin = transitions ? transitions.css + 'transform-origin' : '',
            cellTemplate = template('<td#=data.cssClass# role="gridcell"><a tabindex="-1" class="k-link" href="\\#" data-#=data.ns#value="#=data.dateString#">#=data.value#</a></td>',
                { useWithBlock: false }),
            emptyCellTemplate = template('<td role="gridcell">&nbsp;</td>',
                { useWithBlock: false }),
            weekNumberTemplate = template('<td class="k-alt">#= data.weekNumber #</td>',
                { useWithBlock: false }),
            browser = kendo.support.browser,
            isIE8 = browser.msie && browser.version < 9,
            outerHeight = kendo._outerHeight,
            outerWidth = kendo._outerWidth,
            ns = '.kendoGridSearchDatePicker',
            CLICK = 'click' + ns,
            KEYDOWN_NS = 'keydown' + ns,
            ID = 'id',
            MIN = 'min',
            LEFT = 'left',
            SLIDE = 'slideIn',
            MONTH = 'month',
            CENTURY = 'century',
            CHANGE = 'change',
            NAVIGATE = 'navigate',
            VALUE = 'value',
            HOVER = 'k-state-hover',
            DISABLED = 'k-state-disabled',
            FOCUSED = 'k-state-focused',
            OTHERMONTH = 'k-other-month',
            OTHERMONTHCLASS = ' class="' + OTHERMONTH + '"',
            TODAY = 'k-nav-today',
            CELLSELECTOR = 'td:has(.k-link)',
            BLUR = 'blur' + ns,
            FOCUS = 'focus',
            FOCUS_WITH_NS = FOCUS + ns,
            MOUSEENTER = support.touch ? 'touchstart' : 'mouseenter',
            MOUSEENTER_WITH_NS = support.touch ? 'touchstart' + ns : 'mouseenter' + ns,
            MOUSELEAVE = support.touch ? 'touchend' + ns + ' touchmove' + ns : 'mouseleave' + ns,
            MS_PER_MINUTE = 60000,
            MS_PER_DAY = 86400000,
            PREVARROW = '_prevArrow',
            NEXTARROW = '_nextArrow',
            ARIA_DISABLED = 'aria-disabled',
            ARIA_SELECTED = 'aria-selected',
            ARIA_LABEL = 'aria-label',
            CLASS_ICON = 'k-icon',
            STATE_INVALID = 'k-state-invalid',
            NULL = null,
            proxy = $.proxy,
            extend = $.extend;

        var GridSearchDate = Widget.extend({
            init: function (element, options) {
                var that = this, value, id;
                Widget.fn.init.call(that, element, options);
                element = that.wrapper = that.element;
                options = that.options;

               if (id) {
                    that._cellID = id + '_cell_selected';
                }

                that._initialOptions = extend({}, options);
                that._wrapper();

           
                kendo.notify(that);
            },
            options: {
                name: 'GridSearchDate',
                gridname: '',
                value: NULL,
                round: true,
                factor: 1
            },
            _wrapper: function () {
                var that = this, element = that.element, DOMElement = element[0], wrapper;
                wrapper = element;
                wrapper[0].style.cssText = DOMElement.style.cssText;
                DOMElement.style.width = '';
                that.wrapper = wrapper.addClass('k-widget k-textbox').addClass(DOMElement.className).css('display', '');
                that._inputWrapper = $(wrapper[0].firstChild);
            }
        });
        ui.plugin(GridSearchDate);
    }(window.kendo.jQuery));
    return window.kendo;
}, typeof define == 'function' && define.amd ? define : function (a1, a2, a3) {
    (a3 || a2)();
}));