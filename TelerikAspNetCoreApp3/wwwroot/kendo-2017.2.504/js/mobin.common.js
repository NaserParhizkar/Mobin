$(document).ajaxError(function myErrorHandler(event, xhr, ajaxOptions, thrownError) {
    if (xhr.status != 200) {
        var un200StatusElement = document.createElement('div');
        $(un200StatusElement).css("direction", "ltr");
        un200StatusElement.innerHTML = xhr.responseText;
        document.body.appendChild(un200StatusElement);
        var myWindow = $(un200StatusElement);
        myWindow.kendoWindow({
            width: "600px",
            title: "Exception",
            visible: false,
            modal: true,
            actions: [
                "Pin",
                "Minimize",
                "Maximize",
                "Close"
            ]
        }).data("kendoWindow").center().open().maximize();

    }
});

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
        var diff = 0;
        var ticks = ((date.getTime() * 10000) +
            //621355104000000000
            //621672315440000000
            621356094000000000
            + diff * 3600 * 10000 * 1000);

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
        return (calendars.standard.days.namesAbbr[this.getDay()] + " " + calendars.standard.months.namesAbbr[pMonth]
            + " " + pDate + " " + pYear);
    }

    this.toString = function () {
        return (calendars.standard.days.namesAbbr[this.getDay()] + " " + calendars.standard.months.namesAbbr[pMonth]
            + " " + pDate + " " + pYear + " " + (new Date()).toTimeString());
    }

    this.valueOf = function () {

        var countMS = -62135609400000;


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



