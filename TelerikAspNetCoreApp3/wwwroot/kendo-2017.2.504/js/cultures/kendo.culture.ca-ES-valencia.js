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
    kendo.cultures["ca-ES-valencia"] = {
        name: "ca-ES-valencia",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ".",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "Euro",
                abbr: "EUR",
                pattern: ["-n $","n $"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "€"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["diumenge","dilluns","dimarts","dimecres","dijous","divendres","dissabte"],
                    namesAbbr: ["dg.","dl.","dt.","dc.","dj.","dv.","ds."],
                    namesShort: ["dg","dl","dt","dc","dj","dv","ds"]
                },
                months: {
                    names: ["gener","febrer","març","abril","maig","juny","juliol","agost","setembre","octubre","novembre","desembre"],
                    namesAbbr: ["gen.","febr.","març","abr.","maig","juny","jul.","ag.","set.","oct.","nov.","des."]
                },
                AM: [""],
                PM: [""],
                patterns: {
                    d: "dd/MM/yy",
                    D: "dddd, d MMMM' del 'yyyy",
                    F: "dddd, d MMMM' del 'yyyy HH:mm:ss",
                    g: "dd/MM/yy HH:mm",
                    G: "dd/MM/yy HH:mm:ss",
                    m: "d MMMM",
                    M: "d MMMM",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "MM/yy",
                    Y: "MM/yy"
                },
                "/": "/",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));