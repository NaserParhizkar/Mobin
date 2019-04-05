
(function (f, define) {
    define('kendo.gridsearchtextbox', [
        'kendo.core',
        'kendo.userevents'
    ], f);
}(function () {
    var __meta__ = {
        id: 'gridsearchtextbox',
        name: 'GridSearchTextBox',
        category: 'web',
        description: 'The GridSearchTextbox widget can bind to a grid for searching contents related to the grid.',
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
            ns = '.kendoGridSearchTextBox',
            MOUSELEAVE = 'mouseleave' + ns,
            HOVEREVENTS = 'mouseenter' + ns + ' ' + MOUSELEAVE,
            FOCUSED = 'k-state-focused',
            HOVER = 'k-state-hover',
            POINT = '.',
            CLASS_ICON = 'k-icon',
            STATE_INVALID = 'k-state-invalid',
            NULL = null,
            proxy = $.proxy,
            extend = $.extend;
        var GridSearchTextBox = Widget.extend({
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
                that._reset();
                that._wrapper();
                that._validation();
                value = options.value;
          
                kendo.notify(that);
            },
            options: {
                name: 'GridSearchTextBox',
                gridname:'',
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
            destroy: function () {
                var that = this;
                that.element.add(that._text).add(that._inputWrapper).off(ns);
                if (that._form) {
                    that._form.off('reset', that._resetHandler);
                }
                Widget.fn.destroy.call(that);
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
            _click: function (e) {
                var that = this;
                clearTimeout(that._focusing);
                that._focusing = setTimeout(function () {
                    var input = e.target, idx = caret(input)[0], value = input.value.substring(0, idx),
                        result, caretPosition = 0;
                    if (extractRegExp) {
                        result = extractRegExp.exec(value);
                    }
                    if (result) {
                        caretPosition = result[0].replace(groupRegExp, '').length;
                        if (value.indexOf('(') != -1 && that._value < 0) {
                            caretPosition++;
                        }
                    }
                    that._focusin();
                    caret(that.element[0], caretPosition);
                });
            },
            _focusin: function () {
                var that = this;
                that._inputWrapper.addClass(FOCUSED);
                that._toggleText(false);
                that.element[0].focus();
            },
            _focusout: function () {
                var that = this;
                clearTimeout(that._focusing);
                that._inputWrapper.removeClass(FOCUSED).removeClass(HOVER);
                that._blur();
                that._removeInvalidState();
            },

            _keydown: function (e) {
                var that = this;
                var options = that.options;
            },
            _keypress: function (e) {
                if (e.which === 0 || e.metaKey || e.ctrlKey || e.keyCode === keys.BACKSPACE || e.keyCode === keys.ENTER) {
                    return;
                }
                var that = this;
                var options = that.options;
                var element = that.element;
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
                if (value) {
                    grid.dataSource.filter({ field: "CustomerId", operator: "contains", value: value });
                    grid.dataSource.read();
                } else {
                    grid.dataSource.filter({});
                }

            },
            _keyup: function (e) {
                this._removeInvalidState();
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
                value = that._parse(value);
                if (!value && option === 'step') {
                    return;
                }
                options[option] = value;
                element.add(that._text).attr('aria-value' + option, value);
                element.attr(option, value);
            },
            _toggleHover: function (e) {
                $(e.currentTarget).toggleClass(HOVER, e.type === 'mouseenter');
            },
            _wrapper: function () {
                var that = this, element = that.element, DOMElement = element[0], wrapper;
                wrapper = element;
                wrapper[0].style.cssText = DOMElement.style.cssText;
                DOMElement.style.width = '';
                that.wrapper = wrapper.addClass('k-widget k-textbox').addClass(DOMElement.className).css('display', '');
                that._inputWrapper = $(wrapper[0].firstChild);
            },
            _reset: function () {
                var that = this, element = that.element, formId = element.attr('form'), form = formId ? $('#' + formId) : element.closest('form');
                if (form[0]) {
                    that._resetHandler = function () {
                        setTimeout(function () {
                            that.value(element[0].value);
                            that.max(that._initialOptions.max);
                            that.min(that._initialOptions.min);
                        });
                    };
                    that._form = form.on('reset', that._resetHandler);
                }
            }
        });
        ui.plugin(GridSearchTextBox);
    }(window.kendo.jQuery));
    return window.kendo;
}, typeof define == 'function' && define.amd ? define : function (a1, a2, a3) {
    (a3 || a2)();
}));