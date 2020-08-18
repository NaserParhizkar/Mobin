var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Home;
(function (Home) {
    var Display = (function () {
        function Display() {
        }
        return Display;
    }());
    var Television = (function (_super) {
        __extends(Television, _super);
        function Television() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        return Television;
    }(Display));
    var HiFi = (function () {
        function HiFi() {
        }
        return HiFi;
    }());
    var display = new Display();
    display.name = '';
    var television = new Television();
    var hifi = new HiFi();
    var isDisplay;
    isDisplay = display instanceof Display;
    console.log('display ' + (isDisplay ? 'is ' : 'is not ') + 'instance of Display');
    isDisplay = television instanceof Display;
    console.log('television ' + (isDisplay ? 'is ' : 'is not ') + 'instance of Display');
    isDisplay = hifi instanceof Display;
    console.log('hifi ' + (isDisplay ? 'is ' : 'is not ') + 'instance of Display');
    var hasName;
    hasName = 'name' in display;
    console.log('name ' + (hasName ? 'is ' : 'is not ') + 'in ' + display);
    hasName = 'name' in television;
    console.log('name ' + (hasName ? 'is ' : 'is not ') + 'in ' + television);
    hasName = 'name' in hifi;
    console.log('name ' + (hasName ? 'is ' : 'is not ') + 'in ' + hifi);
    var Describer = (function () {
        function Describer() {
        }
        Describer.getName = function (inputClass) {
            var funcNameRegex = /function (.{1,})\(/;
            var results = (funcNameRegex).exec(inputClass.constructor.toString());
            return (results && results.length > 1) ? results[1] : '';
        };
        return Describer;
    }());
    var tv = new Television();
    var radio = new HiFi();
    var tvType = Describer.getName(tv);
    console.log(tvType);
    var radioType = Describer.getName(radio);
    console.log(radioType);
    var ObjectFactory = (function () {
        function ObjectFactory() {
        }
        ObjectFactory.create = function (className) {
            var obj;
            eval("obj=new " + className + "()");
            obj.name = 'naser';
            return obj;
        };
        return ObjectFactory;
    }());
    var newClass = ObjectFactory.create(tvType);
    console.log(newClass instanceof Television);
    console.log('name' in newClass);
    console.log(newClass.name);
    var VehicleType;
    (function (VehicleType) {
        VehicleType[VehicleType["PedalCyle"] = 0] = "PedalCyle";
        VehicleType[VehicleType["MotorCyle"] = 1] = "MotorCyle";
        VehicleType[VehicleType["Car"] = 2] = "Car";
        VehicleType[VehicleType["Van"] = 3] = "Van";
        VehicleType[VehicleType["Bus"] = 4] = "Bus";
        VehicleType[VehicleType["Lorry"] = 5] = "Lorry";
    })(VehicleType = Home.VehicleType || (Home.VehicleType = {}));
    var a = VehicleType.Bus;
    var myTuple;
    myTuple = [1, 'a'];
    var opt1 = {
        backlight: true,
        material: 'plastic'
    };
    var opt2 = {};
    function isSpeedControllable(treadmill) {
        if (treadmill.increaseSpeed
            && treadmill.decreaseSpeed
            && treadmill.stop) {
            return true;
        }
        return false;
    }
    function customTypeGuardExample(treadmill) {
        if (isSpeedControllable(treadmill)) {
            treadmill.increaseSpeed();
        }
        else {
            treadmill.lift();
        }
    }
    function getAverage(a, b, c) {
        var total = a;
        var count = 1;
        total += b;
        count++;
        if (typeof c !== 'undefined') {
            total += c;
            count++;
        }
        var average = total / count;
        return 'The average is ' + average;
    }
    var result = getAverage(4, 6, NaN);
    console.log(result);
    var prepareDocument = function () {
        var doc = function (selector) {
            return document.getElementById(selector);
        };
        doc.notify = function (message) {
            alert(message);
        };
        return doc;
    };
    var aa = prepareDocument();
    var elem = aa('btn');
    aa.notify(elem.id);
    var Logger = (function () {
        function Logger() {
        }
        Logger.prototype.getMessage = function (message) {
            return 'Information: ${new Date().toUTCString()} ${message}';
        };
        return Logger;
    }());
    var ConsoleLogger = (function (_super) {
        __extends(ConsoleLogger, _super);
        function ConsoleLogger() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        ConsoleLogger.prototype.Notify = function (message) {
            console.log(this.getMessage(message));
        };
        return ConsoleLogger;
    }(Logger));
    var InvasiveLogger = (function (_super) {
        __extends(InvasiveLogger, _super);
        function InvasiveLogger() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        InvasiveLogger.prototype.Notify = function (message) {
            alert(this.getMessage(message));
        };
        return InvasiveLogger;
    }(Logger));
    var logger;
    logger = new InvasiveLogger();
    logger.Notify('Hello Word');
    var CustomerId = (function () {
        function CustomerId(customerIdValue) {
            this.customerIdValue = customerIdValue;
        }
        Object.defineProperty(CustomerId.prototype, "Value", {
            get: function () {
                return this.customerIdValue;
            },
            enumerable: false,
            configurable: true
        });
        return CustomerId;
    }());
    var Customer = (function () {
        function Customer(id, name) {
            this.id = id;
            this.name = name;
        }
        return Customer;
    }());
    var CustomerRepository = (function () {
        function CustomerRepository(customers) {
            this.customers = customers;
        }
        CustomerRepository.prototype.getById = function (id) {
            return this.customers[id.Value];
        };
        CustomerRepository.prototype.persist = function (customer) {
            this.customers[customer.id.Value] = customer;
            return customer.id;
        };
        return CustomerRepository;
    }());
})(Home || (Home = {}));
//# sourceMappingURL=home.js.map