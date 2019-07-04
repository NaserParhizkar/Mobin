/*
* Kendo UI v2015.3.930 (http://www.telerik.com/kendo-ui)
* Copyright 2015 Telerik AD. All rights reserved.
*
* Kendo UI commercial licenses may be obtained at
* http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
* If you do not own a commercial license, this file shall be governed by the trial license terms.
*/
(function(f, define){
    define([ "./kendo.core" ], f);
})(function(){

(function(){



(function($, undefined) {
    var kendo = window.kendo,
        support = kendo.support,
        ui = kendo.ui,
        Widget = ui.Widget,
        keys = kendo.keys,
        parse = kendo.parseDate,
        adjustDST = kendo.date.adjustDST,
        extractFormat = kendo._extractFormat,
        template = kendo.template,
        getCulture = kendo.getCulture,
        transitions = kendo.support.transitions,
        transitionOrigin = transitions ? transitions.css + "transform-origin" : "",
        cellTemplate = template('<td#=data.cssClass# role="gridcell"><a tabindex="-1" class="k-link" href="\\#" data-#=data.ns#value="#=data.dateString#">#=data.value#</a></td>', { useWithBlock: false }),
        emptyCellTemplate = template('<td role="gridcell">&nbsp;</td>', { useWithBlock: false }),
        browser = kendo.support.browser,
        isIE8 = browser.msie && browser.version < 9,
        ns = ".kendoCalendar",
        CLICK = "click" + ns,
        KEYDOWN_NS = "keydown" + ns,
        ID = "id",
        MIN = "min",
        LEFT = "left",
        SLIDE = "slideIn",
        MONTH = "month",
        CENTURY = "century",
        CHANGE = "change",
        NAVIGATE = "navigate",
        VALUE = "value",
        HOVER = "k-state-hover",
        DISABLED = "k-state-disabled",
        FOCUSED = "k-state-focused",
        OTHERMONTH = "k-other-month",
        OTHERMONTHCLASS = ' class="' + OTHERMONTH + '"',
        TODAY = "k-nav-today",
        CELLSELECTOR = "td:has(.k-link)",
        BLUR = "blur" + ns,
        FOCUS = "focus",
        FOCUS_WITH_NS = FOCUS + ns,
        MOUSEENTER = support.touch ? "touchstart" : "mouseenter",
        MOUSEENTER_WITH_NS = support.touch ? "touchstart" + ns : "mouseenter" + ns,
        MOUSELEAVE = support.touch ? "touchend" + ns + " touchmove" + ns : "mouseleave" + ns,
        MS_PER_MINUTE = 60000,
        MS_PER_DAY = 86400000,
        PREVARROW = "_prevArrow",
        NEXTARROW = "_nextArrow",
        ARIA_DISABLED = "aria-disabled",
        ARIA_SELECTED = "aria-selected",
        proxy = $.proxy,
        extend = $.extend,
        DATE = kendo.DATE || pDate,
        views = {
            month: 0,
            year: 1,
            decade: 2,
            century: 3
        };

    var Calendar = Widget.extend({
        init: function (element, options) {

            var that = this, value, id;
            if (options) {
                if ((options.value instanceof pDate || options.value == undefined) &&
                    (options.calendarType == "solarHejri" || options.culture == "fa-IR")) {
                    DATE = pDate;
                } else {
                    DATE = Date;
                    this.options.min = new DATE(1900, 0, 1);
                    this.options.max = new DATE(2099, 11, 31);
                    var that = this;
                    options.culture = null;
                }
            }
            //else {
            //    DATE = Date;
            //    this.options.min = new DATE(1900, 0, 1);
            //    this.options.max = new DATE(2099, 11, 31);
            //    var that = this;
            //    //options.culture = null;
            //}

            Widget.fn.init.call(that, element, options);

            element = that.wrapper = that.element;
            options = that.options;

            options.url = window.unescape(options.url);

            that._templates();

            that._header();

            that._footer(that.footer);

            id = element
                    .addClass("k-widget k-calendar")
                    .on(MOUSEENTER_WITH_NS + " " + MOUSELEAVE, CELLSELECTOR, mousetoggle)
                    .on(KEYDOWN_NS, "table.k-content", proxy(that._move, that))
                    .on(CLICK, CELLSELECTOR, function(e) {
                        var link = e.currentTarget.firstChild;

                        if (link.href.indexOf("#") != -1) {
                            e.preventDefault();
                        }

                        that._click($(link));
                    })
                    .on("mouseup" + ns, "table.k-content, .k-footer", function() {
                        that._focusView(that.options.focusOnNav !== false);
                    })
                    .attr(ID);

            if (id) {
                that._cellID = id + "_cell_selected";
            }

            normalize(options);
            value = parse(options.value, options.format, options.culture);

            that._index = views[options.start];
            that._current = new DATE(+restrictValue(value, options.min, options.max));

            that._addClassProxy = function() {
                that._active = true;
                that._cell.addClass(FOCUSED);
            };

            that._removeClassProxy = function() {
                that._active = false;
                that._cell.removeClass(FOCUSED);
            };

            that.value(value);

            kendo.notify(that);
        },

        options: {
            name: "Calendar",
            value: null,
            min: new DATE(1300, 0, 1),
            max: new DATE(1499, 11, 29),
            dates: [],
            url: "",
            calendarType: "",
            culture: "",
            footer : "",
            format : "",
            month : {},
            start: MONTH,
            depth: MONTH,
            animation: {
                horizontal: {
                    effects: SLIDE,
                    reverse: true,
                    duration: 500,
                    divisor: 2
                },
                vertical: {
                    effects: "zoomIn",
                    duration: 400
                }
            }
        },

        events: [
            CHANGE,
            NAVIGATE
        ],

        setOptions: function(options) {
            var that = this;

            normalize(options);

            if (!options.dates[0]) {
                options.dates = that.options.dates;
            }

            Widget.fn.setOptions.call(that, options);

            that._templates();

            that._footer(that.footer);
            that._index = views[that.options.start];

            that.navigate();
        },

        destroy: function() {
            var that = this,
                today = that._today;

            that.element.off(ns);
            that._title.off(ns);
            that[PREVARROW].off(ns);
            that[NEXTARROW].off(ns);

            kendo.destroy(that._table);

            if (today) {
                kendo.destroy(today.off(ns));
            }

            Widget.fn.destroy.call(that);
        },

        current: function() {
            return this._current;
        },

        view: function() {
            return this._view;
        },

        focus: function(table) {
            table = table || this._table;
            this._bindTable(table);
            table.focus();
        },

        min: function(value) {
            return this._option(MIN, value);
        },

        max: function(value) {
            return this._option("max", value);
        },

        navigateToPast: function() {
            this._navigate(PREVARROW, -1);
        },

        navigateToFuture: function() {
            this._navigate(NEXTARROW, 1);
        },

        navigateUp: function() {
            var that = this,
                index = that._index;

            if (that._title.hasClass(DISABLED)) {
                return;
            }

            that.navigate(that._current, ++index);
        },

        navigateDown: function(value) {
            var that = this,
            index = that._index,
            depth = that.options.depth;

            if (!value) {
                return;
            }

            if (index === views[depth]) {
                if (+that._value != +value) {
                    that.value(value);
                    that.trigger(CHANGE);
                }
                return;
            }

            that.navigate(value, --index);
        },

        navigate: function(value, view) {
            view = isNaN(view) ? views[view] : view;
            if (this._current instanceof pDate && this.options.culture != "" && this.options.culture != "en-US") {
                DATE = pDate;
                this.options.min = new DATE(1300, 0, 1);
                this.options.max = new DATE(1499, 11, 29);
                this.culture = "fa-IR";
                this.options.culture = "fa-IR";
            }
            else {
                DATE = Date;
                this.culture = "en-US";
                this.options.culture = "en-US";
                this.options.min = new DATE(1900, 0, 1);
                this.options.max = new DATE(2099, 11, 31);
            }
            var that = this,
                options = that.options,
                culture = options.culture,
                min = options.min,
                max = options.max,
                title = that._title,
                from = that._table,
                old = that._oldTable,
                selectedValue = that._value,
                currentValue = that._current,
                future = value && +value > +currentValue,
                vertical = view !== undefined && view !== that._index,
                to, currentView, compare,
                disabled;

            if (!value) {
                value = currentValue;
            }

            that._current = value = new DATE(+restrictValue(value, min, max));

            if (view === undefined) {
                view = that._index;
            } else {
                that._index = view;
            }

            that._view = currentView = calendar.views[view];
            compare = currentView.compare;

            disabled = view === views[CENTURY];
            title.toggleClass(DISABLED, disabled).attr(ARIA_DISABLED, disabled);

            disabled = compare(value, min) < 1;
            that[PREVARROW].toggleClass(DISABLED, disabled).attr(ARIA_DISABLED, disabled);

            disabled = compare(value, max) > -1;
            that[NEXTARROW].toggleClass(DISABLED, disabled).attr(ARIA_DISABLED, disabled);

            if (from && old && old.data("animating")) {
                old.kendoStop(true, true);
                from.kendoStop(true, true);
            }

            that._oldTable = from;

            if (!from || that._changeView) {
                title.html(currentView.title(value, min, max, culture));

                that._table = to = $(currentView.content(extend({
                    min: min,
                    max: max,
                    date: value,
                    url: options.url,
                    dates: options.dates,
                    format: options.format,
                    culture: culture
                }, that[currentView.name])));

                makeUnselectable(to);

                that._animate({
                    from: from,
                    to: to,
                    vertical: vertical,
                    future: future
                });

                that._focus(value);
                that.trigger(NAVIGATE);
            }

            if (view === views[options.depth] && selectedValue) {
                that._class("k-state-selected", currentView.toDateString(selectedValue));
            }

            that._class(FOCUSED, currentView.toDateString(value));

            if (!from && that._cell) {
                that._cell.removeClass(FOCUSED);
            }

            that._changeView = true;
        },

        value: function(value) {
            var that = this,
            view = that._view,
            options = that.options,
            old = that._view,
            min = options.min,
            max = options.max;

            if (value === undefined) {
                return that._value;
            }

            value = parse(value, options.format, options.culture);

            if (value !== null) {
                value = new DATE(+value);

                if (!isInRange(value, min, max)) {
                    value = null;
                }
            }

            that._value = value;

            if (old && value === null && that._cell) {
                that._cell.removeClass("k-state-selected");
            } else {
                that._changeView = !value || view && view.compare(value, that._current) !== 0;
                that.navigate(value);
            }
        },

        _move: function(e) {
            var that = this,
                options = that.options,
                key = e.keyCode,
                view = that._view,
                index = that._index,
                currentValue = new DATE(+that._current),
                isRtl = kendo.support.isRtl(that.wrapper),
                value, prevent, method, temp;

            if (e.target === that._table[0]) {
                that._active = true;
            }

            if (e.ctrlKey) {
                if (key == keys.RIGHT && !isRtl || key == keys.LEFT && isRtl) {
                    that.navigateToFuture();
                    prevent = true;
                } else if (key == keys.LEFT && !isRtl || key == keys.RIGHT && isRtl) {
                    that.navigateToPast();
                    prevent = true;
                } else if (key == keys.UP) {
                    that.navigateUp();
                    prevent = true;
                } else if (key == keys.DOWN) {
                    that._click($(that._cell[0].firstChild));
                    prevent = true;
                }
            } else {
                if (key == keys.RIGHT && !isRtl || key == keys.LEFT && isRtl) {
                    value = 1;
                    prevent = true;
                } else if (key == keys.LEFT && !isRtl || key == keys.RIGHT && isRtl) {
                    value = -1;
                    prevent = true;
                } else if (key == keys.UP) {
                    value = index === 0 ? -7 : -4;
                    prevent = true;
                } else if (key == keys.DOWN) {
                    value = index === 0 ? 7 : 4;
                    prevent = true;
                } else if (key == keys.ENTER) {
                    that._click($(that._cell[0].firstChild));
                    prevent = true;
                } else if (key == keys.HOME || key == keys.END) {
                    method = key == keys.HOME ? "first" : "last";
                    temp = view[method](currentValue);
                    currentValue = new DATE(temp.getFullYear(), temp.getMonth(), temp.getDate(), currentValue.getHours(), currentValue.getMinutes(), currentValue.getSeconds(), currentValue.getMilliseconds());
                    prevent = true;
                } else if (key == keys.PAGEUP) {
                    prevent = true;
                    that.navigateToPast();
                } else if (key == keys.PAGEDOWN) {
                    prevent = true;
                    that.navigateToFuture();
                }

                if (value || method) {
                    if (!method) {
                        view.setDate(currentValue, value);
                    }

                    that._focus(restrictValue(currentValue, options.min, options.max));
                }
            }

            if (prevent) {
                e.preventDefault();
            }

            return that._current;
        },

        _animate: function(options) {
            var that = this,
                from = options.from,
                to = options.to,
                active = that._active;

            if (!from) {
                to.insertAfter(that.element[0].firstChild);
                that._bindTable(to);
            } else if (from.parent().data("animating")) {
                from.off(ns);
                from.parent().kendoStop(true, true).remove();
                from.remove();

                to.insertAfter(that.element[0].firstChild);
                that._focusView(active);
            } else if (!from.is(":visible") || that.options.animation === false) {
                to.insertAfter(from);
                from.off(ns).remove();

                that._focusView(active);
            } else {
                that[options.vertical ? "_vertical" : "_horizontal"](from, to, options.future);
            }
        },

        _horizontal: function(from, to, future) {
            var that = this,
                active = that._active,
                horizontal = that.options.animation.horizontal,
                effects = horizontal.effects,
                viewWidth = from.outerWidth();

            if (effects && effects.indexOf(SLIDE) != -1) {
                from.add(to).css({ width: viewWidth });

                from.wrap("<div/>");

                that._focusView(active, from);

                from.parent()
                    .css({
                        position: "relative",
                        width: viewWidth * 2,
                        "float": LEFT,
                        "margin-left": future ? 0 : -viewWidth
                    });

                to[future ? "insertAfter" : "insertBefore"](from);

                extend(horizontal, {
                    effects: SLIDE + ":" + (future ? "right" : LEFT),
                    complete: function() {
                        from.off(ns).remove();
                        that._oldTable = null;

                        to.unwrap();

                        that._focusView(active);

                    }
                });

                from.parent().kendoStop(true, true).kendoAnimate(horizontal);
            }
        },

        _vertical: function(from, to) {
            var that = this,
                vertical = that.options.animation.vertical,
                effects = vertical.effects,
                active = that._active, //active state before from's blur
                cell, position;

            if (effects && effects.indexOf("zoom") != -1) {
                to.css({
                    position: "absolute",
                    top: from.prev().outerHeight(),
                    left: 0
                }).insertBefore(from);

                if (transitionOrigin) {
                    cell = that._cellByDate(that._view.toDateString(that._current));
                    position = cell.position();
                    position = (position.left + parseInt(cell.width() / 2, 10)) + "px" + " " + (position.top + parseInt(cell.height() / 2, 10) + "px");
                    to.css(transitionOrigin, position);
                }

                from.kendoStop(true, true).kendoAnimate({
                    effects: "fadeOut",
                    duration: 600,
                    complete: function() {
                        from.off(ns).remove();
                        that._oldTable = null;

                        to.css({
                            position: "static",
                            top: 0,
                            left: 0
                        });

                        that._focusView(active);
                    }
                });

                to.kendoStop(true, true).kendoAnimate(vertical);
            }
        },

        _cellByDate: function(value) {
            return this._table.find("td:not(." + OTHERMONTH + ")")
                       .filter(function() {
                           return $(this.firstChild).attr(kendo.attr(VALUE)) === value;
                       });
        },

        _class: function(className, value) {
            var that = this,
                id = that._cellID,
                cell = that._cell;

            if (cell) {
                cell.removeAttr(ARIA_SELECTED)
                    .removeAttr("aria-label")
                    .removeAttr(ID);
            }

            cell = that._table
                       .find("td:not(." + OTHERMONTH + ")")
                       .removeClass(className)
                       .filter(function() {
                          return $(this.firstChild).attr(kendo.attr(VALUE)) === value;
                       })
                       .attr(ARIA_SELECTED, true);

            if (className === FOCUSED && !that._active && that.options.focusOnNav !== false) {
                className = "";
            }

            cell.addClass(className);

            if (cell[0]) {
                that._cell = cell;
            }

            if (id) {
                cell.attr(ID, id);
                that._table.removeAttr("aria-activedescendant").attr("aria-activedescendant", id);
            }
        },

        _bindTable: function (table) {
            table
                .on(FOCUS_WITH_NS, this._addClassProxy)
                .on(BLUR, this._removeClassProxy);
        },

        _click: function (link) {
      
            var that = this,
                options = that.options,
                currentValue = new DATE(+that._current),
                value = link.attr(kendo.attr(VALUE)).split("/");

            //Safari cannot create correctly date from "1/1/2090"
            if ((options.culture = "en-US") || (options.min instanceof pDate && options.max instanceof pDate)) {
                DATE = pDate;
                options.culture = "fa-IR";
            }
            else {
                DATE = Date;
                options.culture = "en-US";
            }
            value = new DATE(value[0], value[1], value[2]);
            adjustDST(value, 0);

            that._view.setDate(currentValue, value);

            that.navigateDown(restrictValue(currentValue, options.min, options.max));
        },

        _focus: function(value) {
            var that = this,
                view = that._view;

            if (view.compare(value, that._current) !== 0) {
                that.navigate(value);
            } else {
                that._current = value;
                that._class(FOCUSED, view.toDateString(value));
            }
        },

        _focusView: function(active, table) {
            if (active) {
                this.focus(table);
            }
        },

        _footer: function(template) {
            var that = this,
                today = getToday(),
                element = that.element,
                footer = element.find(".k-footer");

            if (!template) {
                that._toggle(false);
                footer.hide();
                return;
            }

            if (!footer[0]) {
                footer = $('<div class="k-footer"><a href="#" class="k-link k-nav-today"></a></div>').appendTo(element);
            }
         
            var asdasdasd = kendo.toString(today, "n", that.options.culture);

            that._today = footer.show()
                                .find(".k-link")
                                .html(template(today))
                                .attr("title", kendo.toString(today, DATE === pDate ? "n":"D", that.options.culture));

            that._toggle();
        },

        _header: function() {
            var that = this,
            element = that.element,
            links;

            if (!element.find(".k-header")[0]) {
                element.html('<div class="k-header">' +
                             '<a href="#" role="button" class="k-link k-nav-prev"><span class="k-icon k-i-arrow-w"></span></a>' +
                             '<a href="#" role="button" aria-live="assertive" aria-atomic="true" class="k-link k-nav-fast"></a>' +
                             '<a href="#" role="button" class="k-link k-nav-next"><span class="k-icon k-i-arrow-e"></span></a>' +
                             '</div>');
            }

            links = element.find(".k-link")
                           .on(MOUSEENTER_WITH_NS + " " + MOUSELEAVE + " " + FOCUS_WITH_NS + " " + BLUR, mousetoggle)
                           .click(false);

            that._title = links.eq(1).on(CLICK, function() { that._active = that.options.focusOnNav !== false; that.navigateUp(); });
            that[PREVARROW] = links.eq(0).on(CLICK, function() { that._active = that.options.focusOnNav !== false; that.navigateToPast(); });
            that[NEXTARROW] = links.eq(2).on(CLICK, function() { that._active = that.options.focusOnNav !== false; that.navigateToFuture(); });
        },

        _navigate: function(arrow, modifier) {
            var that = this,
                index = that._index + 1,
                currentValue = new DATE(+that._current);

            arrow = that[arrow];

            if (!arrow.hasClass(DISABLED)) {
                if (index > 3) {
                    currentValue.setFullYear(currentValue.getFullYear() + 100 * modifier);
                } else {
                    calendar.views[index].setDate(currentValue, modifier);
                }

                that.navigate(currentValue);
            }
        },

        _option: function(option, value) {
            var that = this,
                options = that.options,
                currentValue = that._value || that._current,
                isBigger;

            if (value === undefined) {
                return options[option];
            }

            value = parse(value, options.format, options.culture);

            if (!value) {
                return;
            }

            options[option] = new DATE(+value);

            if (option === MIN) {
                isBigger = value > currentValue;
            } else {
                isBigger = currentValue > value;
            }

            if (isBigger || isEqualMonth(currentValue, value)) {
                if (isBigger) {
                    that._value = null;
                }
                that._changeView = true;
            }

            if (!that._changeView) {
                that._changeView = !!(options.month.content || options.month.empty);
            }

            that.navigate(that._value);

            that._toggle();
        },

        _toggle: function(toggle) {
            var that = this,
                options = that.options,
                link = that._today;

            if (toggle === undefined) {
                toggle = isInRange(getToday(), options.min, options.max);
            }

            if (link) {
                link.off(CLICK);

                if (toggle) {
                    link.addClass(TODAY)
                        .removeClass(DISABLED)
                        .on(CLICK, proxy(that._todayClick, that));
                } else {
                    link.removeClass(TODAY)
                        .addClass(DISABLED)
                        .on(CLICK, prevent);
                }
            }
        },

        _todayClick: function(e) {
            var that = this,
                depth = views[that.options.depth],
                today = getToday();

            e.preventDefault();

            if (that._view.compare(that._current, today) === 0 && that._index == depth) {
                that._changeView = false;
            }

            that._value = today;
            that.navigate(today, depth);

            that.trigger(CHANGE);
        },

        _templates: function() {
            var that = this,
                options = that.options,
                footer = options.footer,
                month = options.month,
                content = month.content,
                empty = month.empty;

            that.month = {
                content: template('<td#=data.cssClass# role="gridcell"><a tabindex="-1" class="k-link#=data.linkClass#" href="#=data.url#" ' + kendo.attr("value") + '="#=data.dateString#" title="#=data.title#">' + (content || "#=data.value#") + '</a></td>', { useWithBlock: !!content }),
                empty: template('<td role="gridcell">' + (empty || "&nbsp;") + "</td>", { useWithBlock: !!empty })
            };

            that.footer = footer !== false ? template(footer || (DATE === pDate ? '#= kendo.toString(data,"b","' : '#= kendo.toString(data,"D","' ) + options.culture +'") #', { useWithBlock: false }) : null;
        }
    });

    ui.plugin(Calendar);

    var calendar = {
        firstDayOfMonth: function (date) {
            return new DATE(
                date.getFullYear(),
                date.getMonth(),
                1
            );
        },

        firstVisibleDay: function (date, calendarInfo) {
            calendarInfo = calendarInfo || kendo.culture().calendar;

            var firstDay = calendarInfo.firstDay,
            firstVisibleDay = new DATE(date.getFullYear(), date.getMonth(), 0, date.getHours(), date.getMinutes(), date.getSeconds(), date.getMilliseconds());

            while (firstVisibleDay.getDay() != firstDay) {
                calendar.setTime(firstVisibleDay, -1 * MS_PER_DAY);
            }

            return firstVisibleDay;
        },

        setTime: function (date, time) {
            if (DATE == pDate) {
                var resultDATE = new DATE(date.getTime() + time);
                date.setTime(resultDATE.getTime());
            } else {
                var tzOffsetBefore = date.getTimezoneOffset(),
                resultDATE = new DATE(date.getTime() + time),
                tzOffsetDiff = resultDATE.getTimezoneOffset() - tzOffsetBefore;

                date.setTime(resultDATE.getTime() + tzOffsetDiff * MS_PER_MINUTE);
            }
        },
        views: [{
            name: MONTH,
            title: function(date, min, max, culture) {
                return getCalendarInfo(culture).months.names[date.getMonth()] + " " + date.getFullYear();
            },
            content: function(options) {
                var that = this,
                idx = 0,
                min = options.min,
                max = options.max,
                date = options.date,
                dates = options.dates,
                format = options.format,
                culture = options.culture,
                navigateUrl = options.url,
                hasUrl = navigateUrl && dates[0],
                currentCalendar = getCalendarInfo(culture),
                firstDayIdx = currentCalendar.firstDay,
                days = currentCalendar.days,
                names = shiftArray(days.names, firstDayIdx),
                shortNames = shiftArray(days.namesShort, firstDayIdx),
                start = calendar.firstVisibleDay(date, currentCalendar),
                firstDayOfMonth = that.first(date),
                lastDayOfMonth = that.last(date),
                toDateString = that.toDateString,
                today = new DATE(),
                html = '<table tabindex="0" role="grid" class="k-content" cellspacing="0"><thead><tr role="row">';

                for (; idx < 7; idx++) {
                    html += '<th scope="col" title="' + names[idx] + '">' + shortNames[idx] + '</th>';
                }

                today = new DATE(today.getFullYear(), today.getMonth(), today.getDate());
                adjustDST(today, 0);
                today = +today;

                start = new DATE(start.getFullYear(), start.getMonth(), start.getDate());
                adjustDST(start, 0);

                return view({
                    cells: 42,
                    perRow: 7,
                    html: html += '</tr></thead><tbody><tr role="row">',
                    start: start,
                    min: new DATE(min.getFullYear(), min.getMonth(), min.getDate()),
                    max: new DATE(max.getFullYear(), max.getMonth(), max.getDate()),
                    content: options.content,
                    empty: options.empty,
                    setter: that.setDate,
                    build: function(date) {
                        var cssClass = [],
                            day = date.getDay(),
                            linkClass = "",
                            url = "#";

                        if (date < firstDayOfMonth || date > lastDayOfMonth) {
                            cssClass.push(OTHERMONTH);
                        }

                        if (+date === today) {
                            cssClass.push("k-today");
                        }

                        if (day === 0 || day === 6) {
                            cssClass.push("k-weekend");
                        }

                        if (hasUrl && inArray(+date, dates)) {
                            url = navigateUrl.replace("{0}", kendo.toString(date, format, culture));
                            linkClass = " k-action-link";
                        }

                        return {
                            date: date,
                            dates: dates,
                            ns: kendo.ns,
                            title: kendo.toString(date, DATE === pDate ? "D": "b", culture),
                            value: date.getDate(),
                            dateString: toDateString(date),
                            cssClass: cssClass[0] ? ' class="' + cssClass.join(" ") + '"' : "",
                            linkClass: linkClass,
                            url: url
                        };
                    }
                });
            },
            first: function(date) {
                return calendar.firstDayOfMonth(date);
            },
            last: function(date) {
                var last = new DATE(date.getFullYear(), date.getMonth() + 1, 0),
                    first = calendar.firstDayOfMonth(date);
                if (DATE == Date) {
                    timeOffset = Math.abs(last.getTimezoneOffset() - first.getTimezoneOffset());

                    if (timeOffset) {
                        last.setHours(first.getHours() + (timeOffset / 60));
                    }
                }

                return last;
            },
            compare: function(date1, date2) {
                var result,
                month1 = date1.getMonth(),
                year1 = date1.getFullYear(),
                month2 = date2.getMonth(),
                year2 = date2.getFullYear();

                if (year1 > year2) {
                    result = 1;
                } else if (year1 < year2) {
                    result = -1;
                } else {
                    result = month1 == month2 ? 0 : month1 > month2 ? 1 : -1;
                }

                return result;
            },
            setDate: function(date, value) {
                var hours = date.getHours();
                if (value instanceof DATE) {
                    date.setFullYear(value.getFullYear(), value.getMonth(), value.getDate());
                } else {
                    calendar.setTime(date, value * MS_PER_DAY);
                }
                adjustDST(date, hours);
            },
            toDateString: function(date) {
                return date.getFullYear() + "/" + date.getMonth() + "/" + date.getDate();
            }
        },
        {
            name: "year",
            title: function(date) {
                return date.getFullYear();
            },
            content: function(options) {
                var namesAbbr = getCalendarInfo(options.culture).months.namesAbbr,
                toDateString = this.toDateString,
                min = options.min,
                max = options.max;

                return view({
                    min: new DATE(min.getFullYear(), min.getMonth(), 1),
                    max: new DATE(max.getFullYear(), max.getMonth(), 1),
                    start: new DATE(options.date.getFullYear(), 0, 1),
                    setter: this.setDate,
                    build: function(date) {
                        return {
                            value: namesAbbr[date.getMonth()],
                            ns: kendo.ns,
                            dateString: toDateString(date),
                            cssClass: ""
                        };
                    }
                });
            },
            first: function(date) {
                return new DATE(date.getFullYear(), 0, date.getDate());
            },
            last: function(date) {
                return new DATE(date.getFullYear(), 11, date.getDate());
            },
            compare: function(date1, date2){
                return compare(date1, date2);
            },
            setDate: function(date, value) {
                var month,
                    hours = date.getHours();

                if (value instanceof DATE) {
                    month = value.getMonth();

                    date.setFullYear(value.getFullYear(), month, date.getDate());

                    if (month !== date.getMonth()) {
                        date.setDate(0);
                    }
                } else {
                    month = date.getMonth() + value;

                    date.setMonth(month);

                    if (month > 11) {
                        month -= 12;
                    }

                    if (month > 0 && date.getMonth() != month) {
                        date.setDate(0);
                    }
                }

                adjustDST(date, hours);
            },
            toDateString: function(date) {
                return date.getFullYear() + "/" + date.getMonth() + "/1";
            }
        },
        {
            name: "decade",
            title: function(date, min, max) {
                return title(date, min, max, 10);
            },
            content: function(options) {
                var year = options.date.getFullYear(),
                toDateString = this.toDateString;

                return view({
                    start: new DATE(year - year % 10 - 1, 0, 1),
                    min: new DATE(options.min.getFullYear(), 0, 1),
                    max: new DATE(options.max.getFullYear(), 0, 1),
                    setter: this.setDate,
                    build: function(date, idx) {
                        return {
                            value: date.getFullYear(),
                            ns: kendo.ns,
                            dateString: toDateString(date),
                            cssClass: idx === 0 || idx == 11 ? OTHERMONTHCLASS : ""
                        };
                    }
                });
            },
            first: function(date) {
                var year = date.getFullYear();
                return new DATE(year - year % 10, date.getMonth(), date.getDate());
            },
            last: function(date) {
                var year = date.getFullYear();
                return new DATE(year - year % 10 + 9, date.getMonth(), date.getDate());
            },
            compare: function(date1, date2) {
                return compare(date1, date2, 10);
            },
            setDate: function(date, value) {
                setDate(date, value, 1);
            },
            toDateString: function(date) {
                return date.getFullYear() + "/0/1";
            }
        },
        {
            name: CENTURY,
            title: function(date, min, max) {
                return title(date, min, max, 100);
            },
            content: function(options) {
                var year = options.date.getFullYear(),
                min = options.min.getFullYear(),
                max = options.max.getFullYear(),
                toDateString = this.toDateString,
                minYear = min,
                maxYear = max;

                minYear = minYear - minYear % 10;
                maxYear = maxYear - maxYear % 10;

                if (maxYear - minYear < 10) {
                    maxYear = minYear + 9;
                }

                return view({
                    start: new DATE(year - year % 100 - 10, 0, 1),
                    min: new DATE(minYear, 0, 1),
                    max: new DATE(maxYear, 0, 1),
                    setter: this.setDate,
                    build: function(date, idx) {
                        var start = date.getFullYear(),
                            end = start + 9;

                        if (start < min) {
                            start = min;
                        }

                        if (end > max) {
                            end = max;
                        }

                        return {
                            ns: kendo.ns,
                            value: start + " - " + end,
                            dateString: toDateString(date),
                            cssClass: idx === 0 || idx == 11 ? OTHERMONTHCLASS : ""
                        };
                    }
                });
            },
            first: function(date) {
                var year = date.getFullYear();
                return new DATE(year - year % 100, date.getMonth(), date.getDate());
            },
            last: function(date) {
                var year = date.getFullYear();
                return new DATE(year - year % 100 + 99, date.getMonth(), date.getDate());
            },
            compare: function(date1, date2) {
                return compare(date1, date2, 100);
            },
            setDate: function(date, value) {
                setDate(date, value, 10);
            },
            toDateString: function(date) {
                var year = date.getFullYear();
                return (year - year % 10) + "/0/1";
            }
        }]
    };

    function title(date, min, max, modular) {
        var start = date.getFullYear(),
            minYear = min.getFullYear(),
            maxYear = max.getFullYear(),
            end;

        start = start - start % modular;
        end = start + (modular - 1);

        if (start < minYear) {
            start = minYear;
        }
        if (end > maxYear) {
            end = maxYear;
        }

        return start + "-" + end;
    }

    function view(options) {
        var idx = 0,
            data,
            min = options.min,
            max = options.max,
            start = options.start,
            setter = options.setter,
            build = options.build,
            length = options.cells || 12,
            cellsPerRow = options.perRow || (DATE === pDate ? 3 : 4),
            content = options.content || cellTemplate,
            empty = options.empty || emptyCellTemplate,
            html = options.html || '<table tabindex="0" role="grid" class="k-content k-meta-view" cellspacing="0"><tbody><tr role="row">';

        for(; idx < length; idx++) {
            if (idx > 0 && idx % cellsPerRow === 0) {
                html += '</tr><tr role="row">';
            }

            data = build(start, idx);

            html += isInRange(start, min, max) ? content(data) : empty(data);

            setter(start, 1);
        }

        return html + "</tr></tbody></table>";
    }

    function compare(date1, date2, modifier) {
        var year1 = date1.getFullYear(),
            start  = date2.getFullYear(),
            end = start,
            result = 0;

        if (modifier) {
            start = start - start % modifier;
            end = start - start % modifier + modifier - 1;
        }

        if (year1 > end) {
            result = 1;
        } else if (year1 < start) {
            result = -1;
        }

        return result;
    }

    function getToday() {
        var today = new DATE();
        return new DATE(today.getFullYear(), today.getMonth(), today.getDate());
    }

    function restrictValue(value, min, max) {
        if (min instanceof Date) {
            DATE = Date;
        }
        else
            DATE = pDate;
        var today = getToday();

        if (value) {
            today = new DATE(+value);
        }

        if (min > today) {
            today = new DATE(+min);
        } else if (max < today) {
            today = new DATE(+max);
        }
        return today;
    }

    function isInRange(date, min, max) {
        return +date >= +min && +date <= +max;
    }

    function shiftArray(array, idx) {
        return array.slice(idx).concat(array.slice(0, idx));
    }

    function setDate(date, value, multiplier) {
        value = value instanceof DATE ? value.getFullYear() : date.getFullYear() + multiplier * value;
        date.setFullYear(value);
    }

    function mousetoggle(e) {
        $(this).toggleClass(HOVER, MOUSEENTER.indexOf(e.type) > -1 || e.type == FOCUS);
    }

    function prevent (e) {
        e.preventDefault();
    }

    function getCalendarInfo(culture) {
        return getCulture(culture).calendars.standard;
    }

    function normalize(options) {
        var start = views[options.start],
            depth = views[options.depth],
            culture = getCulture(options.culture);

        options.format = extractFormat(options.format || culture.calendars.standard.patterns.d);

        if (isNaN(start)) {
            start = 0;
            options.start = MONTH;
        }

        if (depth === undefined || depth > start) {
            options.depth = MONTH;
        }

        if (!options.dates) {
            options.dates = [];
        }
    }

    function makeUnselectable(element) {
        if (isIE8) {
            element.find("*").attr("unselectable", "on");
        }
    }

    function inArray(date, dates) {
        for(var i = 0, length = dates.length; i < length; i++) {
            if (date === +dates[i]) {
                return true;
            }
        }
        return false;
    }

    function isEqualDatePart(value1, value2) {
        if (value1) {
            return value1.getFullYear() === value2.getFullYear() &&
                   value1.getMonth() === value2.getMonth() &&
                   value1.getDate() === value2.getDate();
        }

        return false;
    }

    function isEqualMonth(value1, value2) {
        if (value1) {
            return value1.getFullYear() === value2.getFullYear() &&
                   value1.getMonth() === value2.getMonth();
        }

        return false;
    }

    calendar.isEqualDatePart = isEqualDatePart;
    calendar.makeUnselectable =  makeUnselectable;
    calendar.restrictValue = restrictValue;
    calendar.isInRange = isInRange;
    calendar.normalize = normalize;
    calendar.viewsEnum = views;
    kendo.DATE = DATE;
    kendo.calendar = calendar;
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

