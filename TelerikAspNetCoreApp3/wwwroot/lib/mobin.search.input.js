
(function (f, define) {
    define('kendo.gridsearchinput', [
        'kendo.core',
        'kendo.userevents'
    ], f);
}(function () {
    var __meta__ = {
        id: 'gridsearchinput',
        name: 'GridSearchInput',
        category: 'web',
        description: 'The GridSearchInput widget can bind to a grid for searching contents related to the grid.',
        depends: [
            'core',
            'userevents'
        ]
    };
    (function ($, undefined) {
        var kendo = window.kendo,
            caret = kendo.caret,
            keys = kendo.keys,
            ui = kendo.ui,
            Widget = ui.Widget,
            CHANGE = 'change',
            ns = '.kendoGridSearchInput',
            MOUSELEAVE = 'mouseleave' + ns,
            CLASS_ICON = 'k-icon',
            STATE_INVALID = 'k-state-invalid',
            NULL = null,
            proxy = $.proxy,
            extend = $.extend;
        var GridSearchInput = Widget.extend({
            init: function (element, options) {
                var that = this;
                Widget.fn.init.call(that, element, options);
                options = that.options;
                if (!that.checkGridState(options.gridname))
                    throw new Error('error');
                element = that.element.on('focusout' + ns, proxy(that._focusout, that))
                    .on('keydown' + ns, proxy(that._keydown, that))
                    .on('keypress' + ns, proxy(that._keypress, that))
                    .on('keyup' + ns, proxy(that._keyup, that));

                that._initialOptions = extend({}, options);
                that._wrapper();
                that._validation();
                value = options.value;
                kendo.notify(that);
            },
            options: {
                name: 'GridSearchInput',
                gridname: '',
                value: NULL,
                round: true,
                factor: 1
            },
            events: [
                CHANGE
            ],
            checkGridState: function (gridname) {
                if (gridname === undefined || gridname === '')
                    throw new Error('You must specify grid name which this search is for it');

                //var grid = $('#'+gridname).data('kendoGrid');

                //if (!grid)
                //    throw new Error('Grid name specified "' + gridname + '" is not any grid name in this form')

                return true;
            },
            focus: function () {
                this._focusin();
            },
            _validation: function () {
                var that = this;
                var element = that.element;
                that._validationIcon = $('<span class=\'' + CLASS_ICON + ' k-i-warning\'></span>').hide().insertAfter(element);
            },
            _blur: function () {
                var that = this;
            },
            _keydown: function (e) {
                //var that = this;
                //var options = that.options;
                //var element = that.element;
                //var value = element.val();
                //var field = element.attr('name');
                //if (e.keyCode === keys.BACKSPACE) {
                //    var grid = $('#' + options.gridname).data('kendoGrid');
                //    if (value) {
                //        grid.dataSource.filter({ field: field, operator: "contains", value: value });
                //        grid.dataSource.read();
                //    } else {
                //        grid.dataSource.filter({});
                //    }
                //}
            },
            _keypress: function (e) {
                if (e.which === 0 || e.metaKey || e.ctrlKey || e.keyCode === keys.BACKSPACE || e.keyCode === keys.ENTER) {
                    return;
                }
                var that = this;
                var options = that.options;
                var element = that.element;
                var field = element.attr('name');
                var selection = caret(element);
                var selectionStart = selection[0];
                var selectionEnd = selection[1];
                var character = String.fromCharCode(e.which);

                var isNumPadDecimal = that._key === keys.NUMPAD_DOT;
                var value = element.val();

                value = value.substring(0, selectionStart) + character + value.substring(selectionEnd);
                //isValid = that._numericRegex(numberFormat).test(value);
                //if (isValid && isNumPadDecimal) {
                //    element.val(value);
                //    caret(element, selectionStart + character.length);
                //    e.preventDefault();
                //} else if (min !== null && min >= 0 && value.charAt(0) === '-' || !isValid) {
                //    that._addInvalidState();
                //    e.preventDefault();
                //}
                //that._key = 0;
                var grid = $('#' + options.gridname).data('kendoGrid');
                var filter = grid.dataSource.filter();
                if (value) {
                    if (filter && filter.filters) {
                        var preFilters = {
                            filters: [],
                            logic: 'and'
                        };
                        preFilters.filters = filter.filters;
                        grid.dataSource._filter = {};
                        //grid.dataSource.trigger('reset');
                        var isFieldExist = false;
                        preFilters.filters.forEach(function (v,i,that) {
                            debugger;
                        });
                        preFilters.filters.push({ field: field, operator: "contains", value: value });
                        grid.dataSource.filter(preFilters);
                    } else {
                        grid.dataSource.filter({ field: field, operator: "contains", value: value });
                        grid.dataSource.read();
                    }
                } else {
                    grid.dataSource.filter({});
                }
            },
            _keyup: function (e) {
                var that = this;
                var options = that.options;
                var element = that.element;
                var value = element.val();
                var field = element.attr('name');
                if (e.keyCode === keys.BACKSPACE) {
                    var grid = $('#' + options.gridname).data('kendoGrid');
                    var filter = grid.dataSource._filter;
                    if (value) {
                        if (filter && filter.filters) {
                            var preFilters = {
                                filters: [],
                                logic: 'and'
                            };
                            preFilters.filters = filter.filters;
                            grid.dataSource._filter = {};
                            //grid.dataSource.trigger('reset');
                            preFilters.filters.push({ field: field, operator: "contains", value: value });
                            grid.dataSource.filter(preFilters);
                        } else {
                            grid.dataSource.filter({ field: field, operator: "contains", value: value });
                            grid.dataSource.read();
                        }
                    } else {
                        grid.dataSource.filter({});
                    }
                }
                //this._removeInvalidState();
            },
            _merge: function (expression) {
                var that = this, logic = expression.logic || 'and', filters = expression.filters, filter, result = that.dataSource.filter() || {
                    filters: [],
                    logic: 'and'
                }, idx, length;
                removeFiltersForField(result, that.options.field);
                for (idx = 0, length = filters.length; idx < length; idx++) {
                    filter = filters[idx];
                    filter.value = that._parse(filter.value);
                }
                filters = $.grep(filters, function (filter) {
                    return filter.value !== '' && filter.value !== null || isNonValueFilter(filter);
                });
                if (filters.length) {
                    if (result.filters.length) {
                        expression.filters = filters;
                        if (result.logic !== 'and') {
                            result.filters = [{
                                logic: result.logic,
                                filters: result.filters
                            }];
                            result.logic = 'and';
                        }
                        if (filters.length > 1) {
                            result.filters.push(expression);
                        } else {
                            result.filters.push(filters[0]);
                        }
                    } else {
                        result.filters = filters;
                        result.logic = logic;
                    }
                }
                return result;
            },

            _addInvalidState: function () {
                var that = this;
                that._inputWrapper.addClass(STATE_INVALID);
                that._validationIcon.show();
            },
            _removeInvalidState: function () {
                var that = this;
                that._inputWrapper.removeClass(STATE_INVALID);
                that._validationIcon.hide();
            },
            _paste: function (e) {
                var that = this;
                var element = e.target;
                var value = element.value;
                var numberFormat = that._format(that.options.format);
                setTimeout(function () {
                    var result = that._parse(element.value);
                    var isValid = that._numericRegex(numberFormat).test(element.value);
                    if (result === NULL || !isValid) {
                        that._update(value);
                    }
                });
            },
            _option: function (option, value) {
                var that = this, element = that.element, options = that.options;
                if (value === undefined) {
                    return options[option];
                }
                options[option] = value;
                element.add(that._text).attr('aria-value' + option, value);
                element.attr(option, value);
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
        ui.plugin(GridSearchInput);
    }(window.kendo.jQuery));
    return window.kendo;
}, typeof define == 'function' && define.amd ? define : function (a1, a2, a3) {
    (a3 || a2)();
}));