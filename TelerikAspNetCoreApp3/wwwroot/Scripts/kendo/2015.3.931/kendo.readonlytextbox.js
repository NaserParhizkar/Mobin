/*
* Kendo UI v2015.3.930 (http://www.telerik.com/kendo-ui)
* Copyright 2015 Telerik AD. All rights reserved.
*
* Kendo UI commercial licenses may be obtained at
* http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
(function (f, define) {
    define(["./kendo.core", "./kendo.userevents"], f);
})(function () {

    (function () {



        (function ($, undefined) {
            var kendo = window.kendo,
                caret = kendo.caret,
                keys = kendo.keys,
                ui = kendo.ui,
                Widget = ui.Widget,
                activeElement = kendo._activeElement,
                extractFormat = kendo._extractFormat,
                parse = kendo.parseFloat,
                placeholderSupported = kendo.support.placeholder,
                getCulture = kendo.getCulture,
                round = kendo._round,
                CHANGE = "change",
                DISABLED = "disabled",
                READONLY = "readonly",
                INPUT = "k-input",
                ns = ".kendoReadonlyTextBox",
                TOUCHEND = "touchend",
                MOUSELEAVE = "mouseleave" + ns,
                HOVEREVENTS = "mouseenter" + ns + " " + MOUSELEAVE,
                DEFAULT = "k-state-default",
                FOCUSED = "k-state-focused",
                HOVER = "k-state-hover",
                FOCUS = "focus",
                POINT = ".",
                SELECTED = "k-state-selected",
                STATEDISABLED = "k-state-disabled",
                ARIA_DISABLED = "aria-disabled",
                ARIA_READONLY = "aria-readonly",
                INTEGER_REGEXP = /^(-)?(\d*)$/,
                NULL = null,
                proxy = $.proxy,
                extend = $.extend;

            var ReadonlyTextBox = Widget.extend({
                init: function (element, options) {
                    var that = this, value, disabled;

                    Widget.fn.init.call(that, element, options);

                    options = that.options;
                    element = that.element
                                  .on("focusout" + ns, proxy(that._focusout, that));

                    options.placeholder = options.placeholder || element.attr("placeholder");

                    that._initialOptions = extend({}, options);

                    that._reset();
                    that._wrapper();

                    that._input();

                    options.format = extractFormat(options.format);

                    value = options.value;
                    that.value(value !== NULL ? value : element.val());

                    disabled = element.is("[disabled]") || $(that.element).parents("fieldset").is(':disabled');

                    if (options.readonly === "true") {
                        that.readonly(true);
                    }
                    else
                        that.readonly(false);

                    kendo.notify(that);
                },

                options: {
                    name: "ReadonlyTextBox",
                    decimals: NULL,
                    value: NULL,
                    culture: "",
                    format: "n",
                    placeholder: ""
                },
                events: [
                    CHANGE
                ],

                _editable: function (options) {
                    var that = this,
                        element = that.element,
                        disable = options.disable,
                        readonly = options.readonly,
                        text = that.element.add(element),
                        wrapper = that.element.off(HOVEREVENTS);

                    //that._toggleText(true);
                    element.off("keydown" + ns).off("keypress" + ns).off("paste" + ns);

                    if (!readonly && !disable) {
                        wrapper
                            .addClass(DEFAULT)
                            .removeClass(STATEDISABLED)
                            .on(HOVEREVENTS, that._toggleHover);

                        text.removeAttr(DISABLED)
                            .attr(ARIA_DISABLED, false)
                            .attr(ARIA_READONLY, false);

                        that.element
                            .on("keydown" + ns, proxy(that._keydown, that))
                            .on("keypress" + ns, proxy(that._keypress, that))
                            .on("keyup" + ns, proxy(that._keyup, that))
                            .on("paste" + ns, proxy(that._paste, that));

                    } else {
                        wrapper
                            .addClass(disable ? STATEDISABLED : DEFAULT)
                            .removeClass(disable ? DEFAULT : STATEDISABLED);

                        text.attr(DISABLED, disable)
                            .attr(ARIA_DISABLED, disable);
                    }
                },

                readonly: function (readonly) {
                    if (readonly) {
                        $(this.element).bind('focusin', this.ReadOnlyInfocusin);
                        $(this.element).bind('focusout', this.NoReadOnlyInfocuout);
                    }
                    //this._editable({
                    //    readonly: readonly === undefined ? true : readonly,
                    //    disable: false
                    //});
                },

                enable: function (enable) {
                    this._editable({
                        readonly: false,
                        disable: !(enable = enable === undefined ? true : enable)
                    });
                },

                ReadOnlyInfocusin: function (e) {
                    $(this).attr('readonly', 'readonly')
                },

                NoReadOnlyInfocuout: function (e) {
                    $(this).removeAttr('readonly')
                },

                destroy: function () {
                    var that = this;

                    that.element
                        .add(that._text)
                        .add(that._upArrow)
                        .add(that._downArrow)
                        .add(that._inputWrapper)
                        .off(ns);

                    if (that._form) {
                        that._form.off("reset", that._resetHandler);
                    }

                    Widget.fn.destroy.call(that);
                },

                value: function (value) {
                    var that = this, adjusted;

                    if (value === undefined) {
                        return that._value;
                    }

                    value = that._parse(value);
                    adjusted = that._adjust(value);

                    if (value !== adjusted) {
                        return;
                    }

                    that._update(value);
                    that._old = that._value;
                },

                focus: function () {
                    this._focusin();
                },

                _adjust: function (value) {
                    var that = this,
                    options = that.options;

                    if (value === NULL) {
                        return value;
                    }

                    return value;
                },

                _blur: function () {
                    var that = this;

                    //that._toggleText(true);
                    that._change(that.element.val());
                },

                _click: function (e) {
                    var that = this;

                    clearTimeout(that._focusing);
                    that._focusing = setTimeout(function () {
                        var input = e.target,
                            idx = caret(input)[0],
                            value = input.value.substring(0, idx),
                            format = that._format(that.options.format),
                            group = format[","],
                            result, groupRegExp, extractRegExp,
                            caretPosition = 0;

                        if (group) {
                            groupRegExp = new RegExp("\\" + group, "g");
                            extractRegExp = new RegExp("([\\d\\" + group + "]+)(\\" + format[POINT] + ")?(\\d+)?");
                        }

                        if (extractRegExp) {
                            result = extractRegExp.exec(value);
                        }

                        if (result) {
                            caretPosition = result[0].replace(groupRegExp, "").length;

                            if (value.indexOf("(") != -1 && that._value < 0) {
                                caretPosition++;
                            }
                        }

                        that._focusin();

                        caret(that.element[0], caretPosition);
                    });
                },

                _change: function (value) {
                    var that = this;

                    //that._update(value);
                    value = that._value;

                    if (that._old != value) {
                        that._old = value;

                        if (!that._typing) {
                            // trigger the DOM change event so any subscriber gets notified
                            that.element.trigger(CHANGE);
                        }

                        that.trigger(CHANGE);
                    }

                    that._typing = false;
                },

                commaSeparatedNumber: function (x) {
                    x = x.replace(/,/g, '');
                    var parts = x.split(".");
                    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                    return parts.join(".");
                },

                _culture: function (culture) {
                    return culture || getCulture(this.options.culture);
                },

                _focusin: function () {
                    var that = this;
                    that._inputWrapper.addClass(FOCUSED);
                    //that._toggleText(false);
                    that.element[0].focus();
                },

                _focusout: function () {
                    var that = this;

                    clearTimeout(that._focusing);
                    //that._inputWrapper.removeClass(FOCUSED).removeClass(HOVER);

                    that._blur();
                },

                _format: function (format, culture) {
                    var numberFormat = this._culture(culture).numberFormat;

                    format = format.toLowerCase();

                    if (format.indexOf("c") > -1) {
                        numberFormat = numberFormat.currency;
                    } else if (format.indexOf("p") > -1) {
                        numberFormat = numberFormat.percent;
                    }

                    return numberFormat;
                },

                _input: function () {
                    var that = this,
                        CLASSNAME = "k-formatted-value",
                        READONLY = "readonly",
                        element = that.element.is(':visible') ? that.element.addClass(INPUT).show()[0] : that.element.addClass(INPUT)[0],
                        accessKey = element.accessKey,
                        wrapper = that.wrapper,
                        text;

                    text = wrapper.find(POINT + CLASSNAME);

                    if (!text[0]) {
                        text = $(element).addClass(CLASSNAME);
                    }
                    //element.setAttribute(READONLY, READONLY);

                    try {
                        element.setAttribute("type", "text");
                    } catch (e) {
                        element.type = "text";
                    }

                    text[0].tabIndex = element.tabIndex;
                    text[0].style.cssText = element.style.cssText;
                    text[0].title = element.title;
                    text.prop("placeholder", that.options.placeholder);

                    if (accessKey) {
                        text.attr("accesskey", accessKey);
                        element.accessKey = "";
                    }

                    //that._text = text.addClass(element.className);
                },

                _keydown: function (e) {
                    var that = this,
                        key = e.keyCode;

                    that._key = key;

                    if (key == keys.DOWN) {
                        that._step(-1);
                    } else if (key == keys.UP) {
                        that._step(1);
                    } else if (key == keys.ENTER) {
                        that._change(that.element.val());
                    } else {
                        that._typing = true;
                    }

                },

                _keypress: function (e) {
                    if (e.which === 0 || e.metaKey || e.ctrlKey || e.keyCode === keys.BACKSPACE || e.keyCode === keys.ENTER) {
                        return;
                    }

                    var that = this;
                    var element = that.element;
                    var selection = caret(element);
                    var selectionStart = selection[0];
                    var selectionEnd = selection[1];
                    var character = String.fromCharCode(e.which);
                    var numberFormat = that._format(that.options.format);
                    var isNumPadDecimal = that._key === keys.NUMPAD_DOT;
                    var value = element.val();
                    var isValid;

                    if (isNumPadDecimal) {
                        character = numberFormat[POINT];
                    }

                    value = value.substring(0, selectionStart) + character + value.substring(selectionEnd);
                    isValid = that._numericRegex(numberFormat).test(value);

                    //if (isValid && isNumPadDecimal) {
                    //    element.val(value);
                    //    caret(element, selectionStart + character.length);

                    //    e.preventDefault();
                    //} else if ((min !== null && min >= 0 && value.charAt(0) === "-") || !isValid) {
                    //    e.preventDefault();
                    //}

                    ////////////
                    //if (that._numericRegex(numberFormat).test(value.replace(/,/g, ''))) {
                    //    if (that.options.format === "n0" || that.options.format === "c") {
                    //        element.val(that.commaSeparatedNumber(kendo.toString(value, that.options.format, that.options.culture)));
                    //        that._text.val(that.commaSeparatedNumber(kendo.toString(value, that.options.format, that.options.culture)));
                    //        e.preventDefault();
                    //    }
                    //}
                    ////////////

                    //that._key = 0;
                },

                _keyup: function (e) {
                    //if (e.keyCode == keys.BACKSPACE || e.keyCode == keys.DELETE) {
                    //    if (this._numericRegex(this._format(this.options.format)).test(this.element.val().replace(/,/g, ''))) {
                    //        if (this.options.format === "n0" || this.options.format === "c") {
                    //            this.element.val(this.commaSeparatedNumber(kendo.toString(this.element.val(), this.options.format, this.options.culture)));
                    //            this._text.val(this.commaSeparatedNumber(kendo.toString(this.element.val(), this.options.format, this.options.culture)));
                    //            e.preventDefault();
                    //        }
                    //    }
                    //}
                },

                _numericRegex: function (numberFormat) {
                    var that = this;
                    var separator = numberFormat[POINT];
                    var precision = that.options.decimals;

                    if (separator === POINT) {
                        separator = "\\" + separator;
                    }

                    if (precision === NULL) {
                        precision = numberFormat.decimals;
                    }

                    if (precision === 0) {
                        return INTEGER_REGEXP;
                    }

                    if (that._separator !== separator) {
                        that._separator = separator;
                        that._floatRegExp = new RegExp("^(-)?(((\\d+(" + separator + "\\d*)?)|(" + separator + "\\d*)))?$");
                    }

                    return that._floatRegExp;
                },

                _paste: function (e) {
                    var that = this,
                        element = e.target,
                        value = element.value;

                    setTimeout(function () {
                        if (that._parse(element.value) === NULL) {
                            that._update(value);
                        }
                    });
                },

                _option: function (option, value) {
                    var that = this,
                        options = that.options;

                    if (value === undefined) {
                        return options[option];
                    }

                    value = that._parse(value);

                    options[option] = value;
                    that.element
                        .attr("aria-value" + option, value)
                        .attr(option, value);
                },

                _toggleHover: function (e) {
                    $(e.currentTarget).toggleClass(HOVER, e.type === "mouseenter");
                },

                _parse: function (value, culture) {
                    return parse(value, this._culture(culture), this.options.format);
                },

                _update: function (value) {
                    var that = this,
                        options = that.options,
                        format = options.format,
                        decimals = options.decimals,
                        culture = that._culture(),
                        numberFormat = that._format(format, culture),
                        isNotNull;

                    if (decimals === NULL) {
                        decimals = numberFormat.decimals;
                    }

                    value = that._parse(value, culture);

                    isNotNull = value !== NULL;

                    if (isNotNull) {
                        value = parseFloat(round(value, decimals));
                    }

                    that._value = value = that._adjust(value);
                    that._placeholder(kendo.toString(value, format, culture));

                    if (isNotNull) {
                        value = value.toString();
                        if (value.indexOf("e") !== -1) {
                            value = round(+value, decimals);
                        }
                        value = value.replace(POINT, numberFormat[POINT]);
                    } else {
                        value = "";
                    }

                    that.element.val(value).attr("aria-valuenow", value);
                },

                _placeholder: function (value) {
                    this.element.val(value);
                    if (!placeholderSupported && !value) {
                        this.element.val(this.options.placeholder);
                    }
                },

                _wrapper: function () {
                    var that = this,
                        element = that.element,
                        DOMElement = element[0],
                        wrapper;

                    wrapper = element;

                    //DOMElement.style.width = "";
                    that.wrapper = wrapper.addClass("k-textbox").css('padding-left', '5px');
                    wrapper[0].style.cssText = DOMElement.style.cssText;

                    //that._inputWrapper = $(wrapper[0].firstChild);
                },

                _reset: function () {
                    var that = this,
                        element = that.element,
                        formId = element.attr("form"),
                        form = formId ? $("#" + formId) : element.closest("form");

                    if (form[0]) {
                        that._resetHandler = function () {
                            setTimeout(function () {
                                that.value(element[0].value);
                            });
                        };

                        that._form = form.on("reset", that._resetHandler);
                    }
                }
            });

            ui.plugin(ReadonlyTextBox);
        })(window.kendo.jQuery);
    })();

    return window.kendo;

}, typeof define == 'function' && define.amd ? define : function (_, f) { f(); });