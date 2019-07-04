/*
* Kendo UI v2015.3.930 (http://www.telerik.com/kendo-ui)
* Copyright 2015 Telerik AD. All rights reserved.
*
* Kendo UI commercial licenses may be obtained at
* http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
(function (f, define) {
    define(["./kendo.calendar", "./kendo.popup"], f);
})(function () {

    (function () {
        (function ($, undefined) {
            var kendo = window.kendo,
            ui = kendo.ui,
            Widget = ui.Widget,
            parse = kendo.parseDate,
            keys = kendo.keys,
            template = kendo.template,
            activeElement = kendo._activeElement,
            DIV = "<div />",
            SPAN = "<span />",
            ns = ".kendoDatePicker",
            CLICK = "click" + ns,
            OPEN = "open",
            CLOSE = "close",
            CHANGE = "change",
            DISABLED = "disabled",
            READONLY = "readonly",
            DEFAULT = "k-state-default",
            FOCUSED = "k-state-focused",
            SELECTED = "k-state-selected",
            STATEDISABLED = "k-state-disabled",
            HOVER = "k-state-hover",
            HOVEREVENTS = "mouseenter" + ns + " mouseleave" + ns,
            MOUSEDOWN = "mousedown" + ns,
            ID = "id",
            MIN = "min",
            MAX = "max",
            MONTH = "month",
            ARIA_DISABLED = "aria-disabled",
            ARIA_EXPANDED = "aria-expanded",
            ARIA_HIDDEN = "aria-hidden",
            ARIA_READONLY = "aria-readonly",
            calendar = kendo.calendar,
            isInRange = calendar.isInRange,
            restrictValue = calendar.restrictValue,
            isEqualDatePart = calendar.isEqualDatePart,
            extend = $.extend,
            proxy = $.proxy,
            DATE = kendo.DATE || pDate;

            function normalize(options) {
                var parseFormats = options.parseFormats,
                    format = options.format;

                calendar.normalize(options);


                parseFormats = $.isArray(parseFormats) ? parseFormats : [parseFormats];

                if (!parseFormats.length) {
                    parseFormats.push("yyyy-MM-dd");
                }

                if ($.inArray(format, parseFormats) === -1) {
                    parseFormats.splice(0, 0, options.format);
                }

                options.parseFormats = parseFormats;
            }

            function preventDefault(e) {
                e.preventDefault();
            }

            var DateView = function (options) {
                var that = this, id,
                    body = document.body,
                    div = $(DIV).attr(ARIA_HIDDEN, "true")
                                .addClass("k-calendar-container")
                                .appendTo(body);

                that.options = options = options || {};
                id = options.id;

                if (id) {
                    id += "_dateview";

                    div.attr(ID, id);
                    that._dateViewID = id;
                }

                that.popup = new ui.Popup(div, extend(options.popup, options, { name: "Popup", isRtl: kendo.support.isRtl(options.anchor) }));
                that.div = div;

                that.value(options.value);
            };

            DateView.prototype = {
                _calendar: function () {
                    var that = this;
                    var calendar = that.calendar;
                    var options = that.options;
                    var div;

                    if (!calendar) {
                        div = $(DIV).attr(ID, kendo.guid())
                                    .appendTo(that.popup.element)
                                    .on(MOUSEDOWN, preventDefault)
                                    .on(CLICK, "td:has(.k-link)", proxy(that._click, that));

                        that.calendar = calendar = new ui.Calendar(div, options);
                        if (options.min instanceof Date) {

                            that.calendar.min = options.min;
                            that.calendar.max = options.max;
                            calendar.max = options.max;
                            calendar.min = options.min;
                        }
                        that._setOptions(options);

                        kendo.calendar.makeUnselectable(calendar.element);

                        calendar.navigate(that._value || that._current, options.start);

                        that.value(that._value);
                    }
                },

                _setOptions: function (options) {
                    this.calendar.setOptions({
                        focusOnNav: false,
                        change: options.change,
                        culture: options.culture,
                        dates: options.dates,
                        depth: options.depth,
                        footer: options.footer,
                        format: options.format,
                        max: options.max,
                        min: options.min,
                        month: options.month,
                        start: options.start
                    });
                },

                setOptions: function (options) {
                    var old = this.options;

                    this.options = extend(old, options, {
                        change: old.change,
                        close: old.close,
                        open: old.open
                    });

                    if (this.calendar) {
                        this._setOptions(this.options);
                    }
                },

                destroy: function () {
                    this.popup.destroy();
                },

                open: function () {
                    var that = this;

                    that._calendar();
                    that.popup.open();
                },

                close: function () {
                    this.popup.close();
                },

                min: function (value) {
                    this._option(MIN, value);
                },

                max: function (value) {
                    this._option(MAX, value);
                },

                toggle: function () {
                    var that = this;

                    that[that.popup.visible() ? CLOSE : OPEN]();
                },

                move: function (e) {
                    var that = this,
                        key = e.keyCode,
                        calendar = that.calendar,
                        selectIsClicked = e.ctrlKey && key == keys.DOWN || key == keys.ENTER,
                        handled = false;

                    if (e.altKey) {
                        if (key == keys.DOWN) {
                            that.open();
                            e.preventDefault();
                            handled = true;
                        } else if (key == keys.UP) {
                            that.close();
                            e.preventDefault();
                            handled = true;
                        }

                    } else if (that.popup.visible()) {

                        if (key == keys.ESC || (selectIsClicked && calendar._cell.hasClass(SELECTED))) {
                            that.close();
                            e.preventDefault();
                            return true;
                        }

                        that._current = calendar._move(e);
                        handled = true;
                    }

                    return handled;
                },

                current: function (date) {
                    this._current = date;
                    this.calendar._focus(date);
                },

                value: function (value) {
                    var that = this,
                        calendar = that.calendar,
                        options = that.options;

                    that._value = value;
                    that._current = new DATE(+restrictValue(value, options.min, options.max));

                    if (calendar) {
                        calendar.value(value);
                    }
                },

                _click: function (e) {
                    if (e.currentTarget.className.indexOf(SELECTED) !== -1) {
                        this.close();
                    }
                },

                _option: function (option, value) {
                    var that = this;
                    var calendar = that.calendar;

                    that.options[option] = value;

                    if (calendar) {
                        calendar[option](value);
                    }
                }
            };

            DateView.normalize = normalize;

            kendo.DateView = DateView;

            var DatePicker = Widget.extend({
                init: function (element, options) {
                    var that = this,
                        disabled,
                        div;
                    if (options.culture == "en-US") {

                        DATE = Date;
                        this.options.min = options.min ? options.min : new DATE(1900, 0, 1);
                        this.options.max = options.max ? options.max : new DATE(2099, 11, 31);
                        options.min = this.options.min;
                        options.max = this.options.max;
                        options.culture = "en-US";
                        this.culture = "en-US";
                        this.options.culture = "en-US";
                    }
                    else {
                        DATE = pDate;
                        this.options.min = options.min ? options.min : new DATE(1300, 0, 1);
                        this.options.max = options.max ? options.max : new DATE(1499, 11, 29);
                        options.min = this.options.min;
                        options.max = this.options.max;
                        options.culture = "fa-IR";
                        this.culture = "fa-IR";
                        this.options.culture = "fa-IR";
                    }

                    Widget.fn.init.call(that, element, options);
                    element = that.element;
                    options = that.options;

                    options.min = parse(element.attr("min")) || parse(options.min);
                    options.max = parse(element.attr("max")) || parse(options.max);

                    normalize(options);

                    that._initialOptions = extend({}, options);

                    that._wrapper();

                    that.dateView = new DateView(extend({}, options, {
                        id: element.attr(ID),
                        anchor: that.wrapper,
                        change: function () {
                            // calendar is the current scope
                            that._change(this.value());
                            that.close();
                        },
                        close: function (e) {
                            if (that.trigger(CLOSE)) {
                                e.preventDefault();
                            } else {
                                element.attr(ARIA_EXPANDED, false);
                                div.attr(ARIA_HIDDEN, true);
                            }
                        },
                        open: function (e) {
                            var options = that.options,
                                date;

                            if (that.trigger(OPEN)) {
                                e.preventDefault();
                            } else {
                                if (that.element.val() !== that._oldText) {
                                    date = parse(element.val(), options.parseFormats, options.culture);

                                    that.dateView[date ? "current" : "value"](date);
                                }

                                element.attr(ARIA_EXPANDED, true);
                                div.attr(ARIA_HIDDEN, false);

                                that._updateARIA(date);

                            }
                        }
                    }));
                    div = that.dateView.div;

                    that._icon();

                    try {
                        element[0].setAttribute("type", "text");
                    } catch (e) {
                        element[0].type = "text";
                    }

                    element
                        .addClass("k-input")
                        .attr({
                            role: "combobox",
                            "aria-expanded": false,
                            "aria-owns": that.dateView._dateViewID
                        });

                    that._reset();
                    that._template();

                    disabled = element.is("[disabled]") || $(that.element).parents("fieldset").is(':disabled');
                    if (disabled) {
                        that.enable(false);
                    } else {
                        that.readonly(element.is("[readonly]"));
                    }

                    that._old = that._update(options.value || that.element.val());
                    that._oldText = element.val();

                    kendo.notify(that);

                    //this.maskFormat(element, options);

                },
                events: [
                OPEN,
                CLOSE,
                CHANGE],
                options: {
                    name: "DatePicker",
                    value: null,
                    footer: "",
                    format: "",
                    culture: "",
                    parseFormats: [],
                    min: new DATE(1300, 0, 1),
                    max: new DATE(1499, 11, 29),
                    start: MONTH,
                    depth: MONTH,
                    animation: {},
                    month: {},
                    dates: [],
                    ARIATemplate: 'Current focused date is #=kendo.toString(data.current, "D")#'
                },

                maskFormat: function (element, options) {
                    
                    var mask = '----/--/--';
                    if (options.format && options.format == 'yyyy/MM/dd') {
                        if (!this.value()) {
                            this.element.val(mask);
                        }
                    }
                },

                setOptions: function (options) {
                    var that = this;
                    var value = that._value;

                    Widget.fn.setOptions.call(that, options);

                    options = that.options;

                    options.min = parse(options.min);
                    options.max = parse(options.max);

                    normalize(options);

                    that.dateView.setOptions(options);

                    if (value) {
                        that.element.val(kendo.toString(value, options.format, options.culture));
                        that._updateARIA(value);
                    }
                },

                _editable: function (options) {
                    var that = this,
                        icon = that._dateIcon.off(ns),
                        element = that.element.off(ns),
                        wrapper = that._inputWrapper.off(ns),
                        readonly = options.readonly,
                        disable = options.disable;

                    if (!readonly && !disable) {
                        wrapper
                            .addClass(DEFAULT)
                            .removeClass(STATEDISABLED)
                            .on(HOVEREVENTS, that._toggleHover);
                        element.removeAttr(DISABLED)
                               .removeAttr(READONLY)
                               .attr(ARIA_DISABLED, false)
                               .attr(ARIA_READONLY, false)
                               .on("keydown" + ns, proxy(that._keydown, that))
                               //.on("keyup" + ns, proxy(that._keyup, that))
                               .on("focusout" + ns, proxy(that._blur, that))
                               .on("focus" + ns, function () {
                                   that._inputWrapper.addClass(FOCUSED);
                               });

                        icon.on(CLICK, proxy(that._click, that))
                            .on(MOUSEDOWN, preventDefault);
                    } else {
                        wrapper
                            .addClass(disable ? STATEDISABLED : DEFAULT)
                            .removeClass(disable ? DEFAULT : STATEDISABLED);

                        element.attr(DISABLED, disable)
                               .attr(READONLY, readonly)
                               .attr(ARIA_DISABLED, disable)
                               .attr(ARIA_READONLY, readonly);
                    }
                },

                readonly: function (readonly) {
                    this._editable({
                        readonly: readonly === undefined ? true : readonly,
                        disable: false
                    });
                },

                enable: function (enable) {
                    this._editable({
                        readonly: false,
                        disable: !(enable = enable === undefined ? true : enable)
                    });
                },

                destroy: function () {
                    var that = this;

                    Widget.fn.destroy.call(that);

                    that.dateView.destroy();

                    that.element.off(ns);
                    that._dateIcon.off(ns);
                    that._inputWrapper.off(ns);

                    if (that._form) {
                        that._form.off("reset", that._resetHandler);
                    }
                },

                open: function () {
                    this.dateView.open();
                },

                close: function () {
                    this.dateView.close();
                },

                min: function (value) {
                    return this._option(MIN, value);
                },

                max: function (value) {
                    return this._option(MAX, value);
                },

                value: function (value) {
                    var that = this;

                    if (value === undefined) {
                        return that._value;
                    }

                    that._old = that._update(value);

                    if (that._old === null) {
                        that.element.val("");
                    }

                    that._oldText = that.element.val();
                },

                _toggleHover: function (e) {
                    $(e.currentTarget).toggleClass(HOVER, e.type === "mouseenter");
                },

                _blur: function () {
                    var that = this,
                        value = that.element.val();

                    that.close();
                    if (value !== that._oldText) {
                        that._change(value);
                    }

                    that._inputWrapper.removeClass(FOCUSED);
                },

                _click: function () {
                    var that = this,
                        element = that.element;

                    that.dateView.toggle();

                    if (!kendo.support.touch && element[0] !== activeElement()) {
                        element.focus();
                    }
                },

                _change: function (value) {
                    var that = this;

                    value = that._update(value);

                    if (+that._old != +value) {
                        that._old = value;
                        that._oldText = that.element.val();

                        if (!that._typing) {
                            // trigger the DOM change event so any subscriber gets notified
                            that.element.trigger(CHANGE);
                        }

                        that.trigger(CHANGE);
                    }

                    that._typing = false;
                },
                dateSeparatedFormat: function (x) {
                    x = x.replace(/\//g, '');
                    if (x.length < 5){
                        return x.replace(/(\w\w\w\w)/, "$1/");
                    }
                    else if (x.length < 6) {
                        return x.replace(/(\w\w\w\w)(\w)/, "$1/$2");
                    }
                    else if (x.length < 7) {
                        return x.replace(/(\w\w\w\w)(\w\w)/, "$1/$2/");
                    }
                    else if (x.length < 8) {
                        return x.replace(/(\w\w\w\w)(\w\w)(\w)/, "$1/$2/$3");
                    }
                    return x.replace(/(\w\w\w\w)(\w\w)(\w\w)/, "$1/$2/$3");
                },
                _keydown: function (e) {
                    var that = this,
                        dateView = that.dateView,
                        value = that.element.val(),
                        handled = false;
                    var element = this.element;
                    var selection = kendo.caret(element);
                    var selectionStart = selection[0];
                    var selectionEnd = selection[1];

                    //allow num pad numerical key pressed and show correct format in input
                    if ((e.keyCode >= 96 && e.keyCode <= 105)) {
                        e.which = e.keyCode - 48;
                    }

                    var character = String.fromCharCode(e.which);
                    var replacedCharacter = '-';
                    var decrease = 0;

                    if (this._findSlashLocation().length > 1) {
                        if (e.keyCode == keys.BACKSPACE || e.keyCode == keys.DELETE) {
                            if (e.keyCode == keys.BACKSPACE)
                                decrease += 1;
                            if ((selectionStart == (this._findSlashLocation()[0] + 1) || selectionStart == (this._findSlashLocation()[1] + 1)) &&
                                (e.keyCode == kendo.keys.BACKSPACE)) {
                                replacedCharacter = '-/';
                                decrease += 1;
                            }
                            else if ((selectionStart == (this._findSlashLocation()[0]) || selectionStart == (this._findSlashLocation()[1]))
                                && (e.keyCode == kendo.keys.DELETE)) {
                                replacedCharacter = '-/';
                                decrease += 1;
                            }
                            value = value.substring(0, selectionStart - decrease) + replacedCharacter + value.substring(selectionEnd);
                            if (value.length <= this.options.format.length) {
                                that.element.val(value);
                                kendo.caret(this.element, selectionStart - decrease + (e.keyCode == kendo.keys.DELETE ?
                                    ((selectionStart == (this._findSlashLocation()[0]) || selectionStart == (this._findSlashLocation()[1])) ? 2 : 1) : 0));
                                e.preventDefault();
                            }
                        }

                        //dont allowed code
                        //naser edited
                        var multipleSelectionPattern = '';
                        if ((e.keyCode == kendo.keys.BACKSPACE || e.keyCode == kendo.keys.DELETE
                            || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) && selectionEnd > selectionStart) {
                            var flag = false;
                            for (var i = selectionStart; selectionEnd > i; i++) {
                                if ((i == (this._findSlashLocation()[0]) || i == (this._findSlashLocation()[1])) && ((i + 1) <= selectionEnd)) {
                                    multipleSelectionPattern += '/';
                                }
                                else if (((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) && !flag) {
                                    multipleSelectionPattern += character;
                                    flag = true;
                                    decrease++
                                }
                                else {
                                    multipleSelectionPattern += '-';
                                }
                            }
                            value = value.substring(0, selectionStart) + multipleSelectionPattern + value.substring(selectionEnd);
                            //e.preventDefault();
                            that.element.val(value);
                            kendo.caret(this.element, selectionStart + decrease);
                            if (e.keyCode == kendo.keys.DELETE || ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57))) {
                                e.preventDefault();
                            }
                        }
                        if (this.element.val().replace(/\//g, '').length >= (this.options.format.length - 2)
                            && e.keyCode != 8 && e.keyCode != 46 && !(e.keyCode >= 37 && e.keyCode <= 40)
                            && (e.keyCode != 9) && (e.keyCode != 17 && e.keyCode != 65 && !e.shiftKey && (selectionEnd - selectionStart <= 1))) {
                            if (value.length <= this.options.format.length && selectionStart < this.options.format.length) {
                                if (selectionStart == (this._findSlashLocation()[0]) || selectionStart == (this._findSlashLocation()[1])) {
                                    value = value.substring(0, selectionStart) + '/' + character + value.substring(selectionEnd + 2);
                                    that.element.val(value);
                                    kendo.caret(this.element, selectionStart + 2);
                                }
                                else {
                                    value = value.substring(0, selectionStart) + character + value.substring(selectionEnd + 1);
                                    that.element.val(value);
                                    kendo.caret(this.element, selectionStart + 1);
                                }
                            }
                            e.preventDefault();
                        }
                    }

                    if (!dateView.popup.visible() && e.keyCode == keys.ENTER && value !== that._oldText) {
                        that._change(value);
                    } else {
                        handled = dateView.move(e);
                        that._updateARIA(dateView._current);

                        if (!handled) {
                            that._typing = true;
                        }
                    }
                },
                _findSlashLocation: function () {
                    var that = this,
                        slashLocation = [];
                    for (var i = 0; i < this.options.format.length; i++) {
                        if (this.options.format[i] == '/') {
                            slashLocation.push(i);
                        }
                    }
                    return slashLocation;
                },
                _icon: function () {
                    var that = this,
                        element = that.element,
                        icon;

                    icon = element.next("span.k-select");

                    if (!icon[0]) {
                        icon = $('<span unselectable="on" class="k-select"><span unselectable="on" class="k-icon k-i-calendar">select</span></span>').insertAfter(element);
                    }

                    that._dateIcon = icon.attr({
                        "role": "button",
                        "aria-controls": that.dateView._dateViewID
                    });
                },

                _option: function (option, value) {
                    var that = this,
                        options = that.options;

                    if (value === undefined) {
                        return options[option];
                    }

                    value = parse(value, options.parseFormats, options.culture);

                    if (!value) {
                        return;
                    }

                    options[option] = new DATE(+value);
                    that.dateView[option](value);
                },

                _update: function (value) {
                    var that = this,
                        options = that.options,
                        min = options.min,
                        max = options.max,
                        current = that._value,
                        date = parse(value, options.parseFormats, options.culture),
                        isSameType = (date === null && current === null) || (date instanceof Date && current instanceof Date),
                        formattedValue;

                    if (+date === +current && isSameType) {
                        formattedValue = kendo.toString(date, options.format, options.culture);

                        if (formattedValue !== value) {
                            that.element.val(date === null ? value : formattedValue);
                        }

                        return date;
                    }

                    if (date !== null && isEqualDatePart(date, min)) {
                        date = restrictValue(date, min, max);
                    } else if (!isInRange(date, min, max)) {
                        date = null;
                    }

                    that._value = date;
                    that.dateView.value(date);
                    that.element.val(date ? (that.options.culture == "fa-IR" ? (new pDate(+date)).persianFormat() : kendo.toString(date, options.format, options.culture))
                        : value);
                    that._updateARIA(date);

                    return date;
                },

                _wrapper: function () {
                    var that = this,
                        element = that.element,
                        wrapper;

                    wrapper = element.parents(".k-datepicker");

                    if (!wrapper[0]) {
                        wrapper = element.wrap(SPAN).parent().addClass("k-picker-wrap k-state-default");
                        wrapper = wrapper.wrap(SPAN).parent();
                    }

                    wrapper[0].style.cssText = element[0].style.cssText;
                    element.css({
                        width: "100%",
                        height: element[0].style.height
                    });

                    that.wrapper = wrapper.addClass("k-widget k-datepicker k-header")
                                          .addClass(element[0].className);

                    that._inputWrapper = $(wrapper[0].firstChild);
                },

                _reset: function () {
                    var that = this,
                        element = that.element,
                        formId = element.attr("form"),
                        form = formId ? $("#" + formId) : element.closest("form");

                    if (form[0]) {
                        that._resetHandler = function () {
                            that.value(element[0].defaultValue);
                            that.max(that._initialOptions.max);
                            that.min(that._initialOptions.min);
                        };

                        that._form = form.on("reset", that._resetHandler);
                    }
                },

                _template: function () {
                    this._ariaTemplate = template(this.options.ARIATemplate);
                },

                _updateARIA: function (date) {
                    var cell;
                    var that = this;
                    var calendar = that.dateView.calendar;

                    that.element.removeAttr("aria-activedescendant");

                    if (calendar) {
                        cell = calendar._cell;
                        cell.attr("aria-label", that._ariaTemplate({ current: date || calendar.current() }));

                        that.element.attr("aria-activedescendant", cell.attr("id"));
                    }
                }
            });

            ui.plugin(DatePicker);

        })(window.kendo.jQuery);
    })();

    return window.kendo;

}, typeof define == 'function' && define.amd ? define : function (_, f) { f(); });


function pDate() {

    var pYear = undefined, pMonth = undefined, pDate = undefined, pDay, pHours = undefined, pMinutes = undefined,
    pSeconds = undefined, pMilliseconds = undefined, output = undefined, that = this;


    if (typeof arguments[0] !== "undefined" || typeof arguments[1] !== "undefined" || typeof arguments[2] !== "undefined"
        || typeof arguments[3] !== "undefined" || typeof arguments[4] !== "undefined" || typeof arguments[5] !== "undefined"
        || typeof arguments[6] !== "undefined") {

        if (typeof arguments[0] !== "undefined" && typeof arguments[1] !== "undefined" && typeof arguments[2] !== "undefined"
            && typeof arguments[3] !== "undefined" && arguments[4] !== "undefined"
            && arguments[5] !== "undefined" && arguments[6] !== "undefined") {

            if (typeof arguments[0] === "number" && typeof arguments[1] === "number" && typeof arguments[2] === "number") {

                pYear = arguments[0]; pMonth = arguments[1]; pDate = arguments[2];


                if (pDate <= 0) {
                    pMonth--;
                    if (pMonth < 0) {
                        if (pYearIsLeap(Number(--pYear))) {
                            pMonth = 11;
                            pDate = 30;
                        }
                        else {
                            pMonth = 11;
                            pDate = 29;
                        }
                    }
                    else {
                        if (pMonth <= 5 && pMonth >= 0) {
                            pDate += 31;
                        }
                        else if (pMonth > 5 && pMonth < 12) {
                            if (!pYearIsLeap(Number(pYear)) && pMonth == 11) {
                                pDate = 29;
                            }
                            else {
                                pDate = 30;
                            }
                        }
                    }
                }
                pHours = Number(arguments[3]);
                pMinutes = Number(arguments[4]);
                pSeconds = Number(arguments[5]);
                pMilliseconds = Number(arguments[6]);
            }
        }
        else if (typeof arguments[0] !== "undefined" && typeof arguments[1] !== "undefined" && typeof arguments[2] !== "undefined") {
            pYear = Number(arguments[0]); pMonth = Number(arguments[1]); pDate = Number(arguments[2]);

            if (pDate <= 0) {
                pMonth--;
                if (pMonth < 0) {
                    if (pYearIsLeap(Number(--pYear))) {
                        pMonth = 11;
                        pDate = 30;
                    }
                    else {
                        pMonth = 11;
                        pDate = 29;
                    }
                }
                else {
                    if (pMonth <= 5 && pMonth >= 0) {
                        pDate += 31;
                    }
                    else if (pMonth > 5 && pMonth < 12) {
                        if (!pYearIsLeap(Number(pYear)) && pMonth == 11) {
                            pDate = 29;
                        }
                        else {
                            pDate = 30;
                        }
                    }
                }
            }
        }
        else if (typeof arguments[0] !== "undefined" && typeof arguments[1] === "undefined") {
            if (typeof arguments[0] === "number") {
                var today = pGetToday(new Date(Number(arguments[0])));
                var y_m_d_Array = today.split('/');
                pYear = Number(y_m_d_Array[0]);
                pMonth = Number(y_m_d_Array[1]);
                pDate = Number(y_m_d_Array[2]);
            }
            else if (typeof arguments[0] === "pDate") {
                //var tmpDate = pGetToday(arguments[0]);
                //var y_m_d_Array = tmpDate.split('/');
                //pYear = Number(y_m_d_Array[0]);
                //pMonth = Number(y_m_d_Array[1]);
                //pDate = Number(y_m_d_Array[2]);
            }
        }
    }
    else {
        var today = pGetToday(new Date());
        var y_m_d_Array = today.split('/');
        pYear = Number(y_m_d_Array[0]);
        pMonth = Number(y_m_d_Array[1]);
        pDate = Number(y_m_d_Array[2]);
    }

    this.persianFormat = function () {
        var out = (pYear + "/" + (pMonth + 1) + "/" + pDate);
        out = out.replace(/(\/)(\d)(?!\d)/g, "/0$2");
        return out;
    }

    this.countDays = function (y, m, d) {
        var countD = 0;

        if (y != null && typeof y !== "undefined") {
            pYear = Number(y);
        }
        if (m != null && typeof m !== "undefined") {
            pMonth = Number(m);
        }
        if (d != null && typeof d !== "undefined")
            pDate = Number(d);


        var py = Math.floor(pMonth / 12);
        pYear += py;
        pMonth = pMonth % 12;

        //check if pmonth is set to negative number
        if (py < 0)
            if (pMonth < 0)
                pMonth = 12 + pMonth;

        countD = pMonth > 5 ? (pMonth < 11 ? (6 * 31) + (pMonth - 6) * 30 + pDate : (6 * 31) + (5 * 30) + pDate) : (pMonth * 31) + pDate;
        while (countD) {
            if (countD > 365) {
                if (pYearIsLeap(pYear)) {
                    //leap year condition
                    if (countD > 366) {
                        pYear++;
                        countD -= 366;
                    }
                        //leap year condition
                    else {
                        pMonth = 11;
                        pDate = 30;
                        countD -= 366;
                    }
                }
                else {
                    pYear++;
                    pMonth = 0;
                    pDate = 1;
                    countD -= 365;
                }
            }
            else {
                if (countD < (6 * 31 + 5 * 30)) {
                    if (countD > 6 * 31) {
                        pMonth = Math.floor((countD - (6 * 31) - 1) / 30) + 6;
                        pDate = ((countD - (6 * 31) - 1) % 30) + 1;
                        countD -= ((6 * 31) + (pMonth - 6) * 30 + pDate);
                    }
                    else {
                        pMonth = Math.floor((countD - 1) / 31);
                        pDate = ((countD - 1) % 31) + 1;
                        countD -= ((pMonth * 31) + pDate);
                    }
                }
                else {
                    pMonth = 11;
                    pDate = countD - ((6 * 31) + (5 * 30));
                    countD -= ((6 * 31 + 5 * 30) + pDate);
                }
            }
        }
    }

    //set date and time for persian calendar
    this.setFullYear = function (year, month, date) {
        var num_of_params = arguments.length;
        if (num_of_params == 1) {
            var py;
            py = Number(year);

            this.countDays(py, null, null);

        }
        else if (num_of_params == 2) {
            var py, pm;
            py = Number(year);
            pm = Number(month);

            this.countDays(py, pm, null);
        }
        else if (num_of_params == 3) {
            var py, pm, pd;
            py = Number(year);
            pm = Number(month);
            pd = Number(date);

            this.countDays(py, pm, pd);

            if (pDate <= 0) {
                pDate += ((--pMonth) >= 0 ? (pMonth > 5 ? 30 : 31) :
                    (((pMonth = 11) == 11) && pYearIsLeap(Number(--pYear)) ? 30 : 29));
            }
        }
    }

    this.setMonth = function (month) {
        this.countDays(null, Number(month), null);
    }

    this.setDate = function (date) {
        this.countDays(null, null, Number(date));
    }

    this.setTime = function (time) {
        //call function for a
        if (typeof time === "number") {
            var today = pGetToday(new Date(Number(time)));
            var y_m_d_Array = today.split('/');
            pYear = Number(y_m_d_Array[0]);
            pMonth = Number(y_m_d_Array[1]);
            pDate = Number(y_m_d_Array[2]);
            var asaa = 0;

        }
        else {
            if (typeof time === new Date()) {
                var today = pGetToday(time);
                var y_m_d_Array = today.split('/');
                pYear = Number(y_m_d_Array[0]);
                pMonth = Number(y_m_d_Array[1]);
                pDate = Number(y_m_d_Array[2]);
            }
        }
    }

    this.setHours = function (hour) {
        pHours = Number(hour);
    }

    this.setMinutes = function (min) {
        pMinutes = Number(min);
    }

    this.setSeconds = function (sec) {
        pSeconds = Number(sec);
    }

    this.setMilliseconds = function (ms) {
        pMilliseconds = Number(ms);
    }


    this.getFullYear = function () {

        return pYear;
    }

    this.getMonth = function () {

        return pMonth;
    }

    this.getDate = function () {

        return pDate;
    }

    this.getDay = function () {

        var md = this.pFirstDayOfCurrentMonth(Number(pYear), Number(pMonth));
        pDay = ((md + Number(pDate) - 1) % 7);
        return pDay;
    }

    this.getTime = function () {
        var time = this.valueOf();
        return time;
    }

    this.getHours = function () {
        if (pHours == null) {
            var gdate = new Date();
            pHours = gdate.getHours();
        }
        return pHours;
    }

    this.getMinutes = function () {
        var gToday = new Date();
        pMinutes = gToday.getMinutes();

        return pMinutes;
    }

    this.getSeconds = function () {
        var gToday = new Date();
        pSeconds = gToday.getSeconds();

        return pSeconds;
    }

    this.getMilliseconds = function () {
        var gToday = new Date();
        pMilliseconds = gToday.getMilliseconds();

        return pMilliseconds;
    }

    var calendars = {
        standard: {
            days: {
                names: ["یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"],
                namesAbbr: ["یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"],
                namesShort: ["ی", "د", "س", "چ", "پ", "ج", "ش"]
            },
            months: {
                names: ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"],
                namesAbbr: ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"]
            },
            AM: ["ق.ظ", "ق.ظ", "ق.ظ"],
            PM: ["ب.ظ", "ب.ظ", "ب.ظ"],
            patterns: {
                d: "yyyy/MM/dd",
                n: "yyyy/MM/dd",
                D: "yyyy/MM/dd",
                F: "dddd, MMMM dd, yyyy hh:mm:ss tt",
                g: "MM/dd/yyyy hh:mm tt",
                G: "MM/dd/yyyy hh:mm:ss tt",
                m: "MMMM dd",
                M: "MMMM dd",
                s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                t: "hh:mm tt",
                T: "hh:mm:ss tt",
                u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                y: "MMMM, yyyy",
                Y: "MMMM, yyyy"
            },
            "/": "/",
            ":": ":",
            firstDay: 6
        }
    };

    function gCountOfDaysToToday(month, day, typeOfYear) {
        var months = typeOfYear[1] == 28 ? gMonths() : gLeapMonths();
        var count = 0;
        months = months.slice(0, month);
        $.each(months, function (i, value) {
            count += value;
        });
        count += day - 1;
        return count;
    }

    function gMonths() { return [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31] }

    function gLeapMonths() { return [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31] }

    function pGetToday(date) {
        var gyear = date.getFullYear(), gmonth = date.getMonth(),
            gday = date.getDate(), gHours = date.getHours(), gMinutes = date.getMinutes(),
            gSeconds = date.getSeconds(), gMilliseconds = date.getMilliseconds(),
            pyear, pmonth, pday, leapFlag = false, persianLeapFlag = false;

        /////////
        //set value of hours and minutes and seconds and miliseconds to default value gdate 
        pHours = gHours;
        pMinutes = gMinutes;
        pSeconds = gSeconds;
        pMilliseconds = gMilliseconds;

        //621 355 104 000 000 000
        var diff = pHours >= 17 ? 0 : 17 - pHours;
        var ticks = ((date.getTime() * 10000) + 621355104000000000 + diff * 3600 * 10000 * 1000);

        pyear = GetDatePart(ticks, 0);
        pmonth = GetDatePart(ticks, 2);
        pday = GetDatePart(ticks, 3);


        var out = (pyear + "/" + (pmonth - 1) + "/" + pday);
        out = out.replace(/(\/)(\d)(?!\d)/g, "/0$2");
        return out;
    }

    function DaysUpToPersianYear(PersianYear) {
        var num2 = Math.floor((PersianYear - 1) / 33);
        var year = Math.floor((PersianYear - 1) % 33);
        var num = Math.floor((num2 * 12053) + 226894);
        while (year > 0) {
            num += 365;
            if (pYearIsLeap(year)) {
                num += 1;
            }
            year--;
        }
        return num;
    }

    function GetDatePart(ticks, part) {
        var DaysToMonth = [0, 31, 62, 93, 124, 155, 186, 216, 246, 276, 306, 336];

        //CheckTicksRange(ticks);
        var num4 = Math.floor((ticks / 864000000000) + 1);
        var persianYear = Math.floor((((num4 - 226894) * 33) / 12053) + 1);
        var num5 = DaysUpToPersianYear(persianYear);
        var daysInYear = pYearIsLeap(persianYear) ? 366 : 365;
        if (num4 < num5) {
            num5 -= daysInYear;
            persianYear--;
        }
        else if (num4 == num5) {
            persianYear--;
            num5 -= pYearIsLeap(persianYear) ? 366 : 365;
        }
        else if (num4 > (num5 + daysInYear)) {
            num5 += daysInYear;
            persianYear++;
        }
        if (part == 0) {
            return persianYear;
        }
        num4 -= num5;
        if (part == 1) {
            return num4;
        }
        var index = 0;
        while ((index < 12) && (num4 > DaysToMonth[index])) {
            index++;
        }
        if (part == 2) {
            return index;
        }
        var num3 = (num4) - DaysToMonth[index - 1];
        if (part != 3) {
            //throw new InvalidOperationException
        }
        return num3;
    }


    function pYearIsLeap(pyear) {
        var leapDays = [1, 5, 9, 13, 17, 22, 26, 30];
        var year = pyear;
        var flag = false;

        for (var i = 0; i < 8; i++) {
            if ((year % 33) == leapDays[i]) {
                flag = true;
            }
        }
        return flag;
    }


    this.toDateString = function () {
        return (this.calendars.standard.days.namesAbbr[this.getDay()] + " " + this.calendars.standard.months.namesAbbr[pMonth]
            + " " + pDate + " " + pYear);
    }


    this.toString = function () {
        return (calendars.standard.days.namesAbbr[this.getDay()] + " " + calendars.standard.months.namesAbbr[pMonth]
            + " " + pDate + " " + pYear + " " + (new Date()).toTimeString());
    }

    this.valueOf = function () {

        var countMS = -62135510400000;


        if (pYear != null && typeof pYear !== "undefined"
            && pMonth != null && typeof pMonth !== "undefined"
            && pDate != null && typeof pDate !== "undefined") {
            var py, pm, pd;
            py = Number(pYear); pm = Number(pMonth); pd = Number(pDate);


            countMS += Number(DaysUpToPersianYear(py) * 24 * 3600 * 1000);
            countMS += (pm > 5 ? (pm < 11 ? ((6 * 31) + (pm - 6) * 30 + (pd - 1)) * 24 * 3600 * 1000 :
                ((6 * 31) + (5 * 30) + (pd - 1)) * 24 * 3600 * 1000) : (pm * 31 + (pd - 1)) * 24 * 3600 * 1000);
        }
        return countMS;
    }


    this.pLeapDaysToCurrentYear = function (py) {

        var temp = Number(py) - 1;
        var counter = 0;
        while (temp !== 0) {
            if (pYearIsLeap(temp--))
                counter++;
        }
        return counter;
    }
    ///get array of 0 to 6 equal to shanbeh and yekshanbeh and .. to jome


    this.pFirstDayOfCurrentYear = function (pyear) {
        var year = Number(pyear);

        var _dayOfYear = ((year - 1) * 365 + 4 + this.pLeapDaysToCurrentYear(year));
        _dayOfYear = _dayOfYear % 7;

        return _dayOfYear;
    }


    this.pFirstDayOfCurrentMonth = function (pyear, pm) {
        var persianYear = Number(pyear);
        var month = Number(pm);
        var yearFirstDate = (this.pFirstDayOfCurrentYear(persianYear));

        var monthFirstDate = (month == 11 ? (6 * 31 + 5 * 30) :
            ((month > 5 && month < 11) ? 6 * 31 + (month - 6) * 30 : month * 31));
        monthFirstDate = monthFirstDate % 7;


        var result = (monthFirstDate + yearFirstDate) < 7
            ? (monthFirstDate + yearFirstDate)
            : (monthFirstDate + yearFirstDate) % 7;

        return result;
    }

    this.lastDayOfCurrentPersianMonth = function (date) {
        var persianYear = this.getCurrentPersianYear(date);
        var month = date.getMonth();
        var firstDayMonth = this.firstDayOfCurrentPersianMonth(date).getDay() + 1;
        firstDayMonth = firstDayMonth % 7;

        var daysPerMonth = (month == 11 && !this.persianYearisLeap(persianYear.getFullYear()) ? 29 : ((month <= 11 && month > 5) ? 30 : 31));
        var lastDay = (daysPerMonth % 7) - 1;

        var result = (lastDay + firstDayMonth) > 6 ? (lastDay + firstDayMonth) % 7 : (lastDay + firstDayMonth);
        result = result == 0 ? 6 : result - 1;

        var outDate = new Date(persianYear.getFullYear(), month, result,
        date.getHours(), date.getMinutes(), date.getSeconds(), date.getMilliseconds());
        return outDate;
    }
}
