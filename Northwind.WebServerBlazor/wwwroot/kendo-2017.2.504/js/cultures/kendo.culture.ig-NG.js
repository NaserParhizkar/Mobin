/** 
 * Kendo UI v2017.2.504 (http://www.telerik.com/kendo-ui)                                                                                                                                               
 * Copyright 2017 Telerik AD. All rights reserved.                                                                                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/

(function(f){
    if (typeof define === 'function' && define.amd) {
        define(["kendo.core"], f);
    } else {
        f();
    }
}(function(){
(function( window, undefined ) {
    kendo.cultures["ig-NG"] = {
        name: "ig-NG",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ",",
            ".": ".",
            groupSize: [3],
            percent: {
                pattern: ["-n %","n %"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Naira",
                abbr: "NGN",
                pattern: ["$-n","$ n"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "₦"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["Sọnde","Mọnde","Tuzde","Wednesde","Tọsde","Fraịde","Satọde"],
                    namesAbbr: ["Sọn","Mọn","Tuz","Ojo","Tọs","Fra","Sat"],
                    namesShort: ["Sọ","Mọ","Tu","We","Tọs","Fra","Sa"]
                },
                months: {
                    names: ["Jenụwarị","Febụwarị","Machị","Eprelu","Mey","Juun","Julaị","Ọgọst","Septemba","Ọcktọba","Nọvemba","Disemba"],
                    namesAbbr: ["Jen","Feb","Mac","Epr","Mey","Jun","Jul","Ọgọ","Sep","Ọkt","Nọv","Dis"]
                },
                AM: ["Ụtụtụ","ụtụtụ","ỤTỤTỤ"],
                PM: ["Ehihie","ehihie","EHIHIE"],
                patterns: {
                    d: "d/M/yyyy",
                    D: "dddd, MMMM dd, yyyy",
                    F: "dddd, MMMM dd, yyyy h.mm.ss tt",
                    g: "d/M/yyyy h.mm tt",
                    G: "d/M/yyyy h.mm.ss tt",
                    m: "d MMMM",
                    M: "d MMMM",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "h.mm tt",
                    T: "h.mm.ss tt",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "MMMM, yyyy",
                    Y: "MMMM, yyyy"
                },
                "/": "/",
                ":": ".",
                firstDay: 0
            }
        }
    }
})(this);
}));