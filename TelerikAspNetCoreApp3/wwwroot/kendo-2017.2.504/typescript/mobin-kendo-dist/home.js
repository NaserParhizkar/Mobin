var Home;
(function (Home) {
    class Display {
    }
    class Television extends Display {
    }
    class HiFi {
    }
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
    class Describer {
        static getName(inputClass) {
            var funcNameRegex = /function (.{1,})\(/;
            var results = (funcNameRegex).exec(inputClass.constructor.toString());
            return (results && results.length > 1) ? results[1] : '';
        }
    }
    var tv = new Television();
    var radio = new HiFi();
    var tvType = Describer.getName(tv);
    console.log(tvType);
    var radioType = Describer.getName(radio);
    console.log(radioType);
    class ObjectFactory {
        static create(className) {
            var obj;
            eval("obj=new " + className + "()");
            obj.name = 'naser';
            return obj;
        }
    }
    var newClass = ObjectFactory.create(tvType);
    console.log(newClass instanceof Television);
    console.log('name' in newClass);
    console.log(newClass.name);
    let VehicleType;
    (function (VehicleType) {
        VehicleType[VehicleType["PedalCyle"] = 0] = "PedalCyle";
        VehicleType[VehicleType["MotorCyle"] = 1] = "MotorCyle";
        VehicleType[VehicleType["Car"] = 2] = "Car";
        VehicleType[VehicleType["Van"] = 3] = "Van";
        VehicleType[VehicleType["Bus"] = 4] = "Bus";
        VehicleType[VehicleType["Lorry"] = 5] = "Lorry";
    })(VehicleType = Home.VehicleType || (Home.VehicleType = {}));
    let a = VehicleType.Bus;
    let myTuple;
    myTuple = [1, 'a'];
    const opt1 = {
        backlight: true,
        material: 'plastic'
    };
    const opt2 = {};
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
        let total = a;
        let count = 1;
        total += b;
        count++;
        if (typeof c !== 'undefined') {
            total += c;
            count++;
        }
        const average = total / count;
        return 'The average is ' + average;
    }
    const result = getAverage(4, 6, NaN);
    console.log(result);
    const prepareDocument = function () {
        let doc = function (selector) {
            return document.getElementById(selector);
        };
        doc.notify = function (message) {
            alert(message);
        };
        return doc;
    };
    const aa = prepareDocument();
    const elem = aa('btn');
    aa.notify(elem.id);
    class Logger {
        getMessage(message) {
            return 'Information: ${new Date().toUTCString()} ${message}';
        }
    }
    class ConsoleLogger extends Logger {
        Notify(message) {
            console.log(this.getMessage(message));
        }
    }
    class InvasiveLogger extends Logger {
        Notify(message) {
            alert(this.getMessage(message));
        }
    }
    let logger;
    logger = new InvasiveLogger();
    logger.Notify('Hello Word');
    class CustomerId {
        constructor(customerIdValue) {
            this.customerIdValue = customerIdValue;
        }
        get Value() {
            return this.customerIdValue;
        }
    }
    class Customer {
        constructor(id, name) {
            this.id = id;
            this.name = name;
        }
    }
    class CustomerRepository {
        constructor(customers) {
            this.customers = customers;
        }
        getById(id) {
            return this.customers[id.Value];
        }
        persist(customer) {
            this.customers[customer.id.Value] = customer;
            return customer.id;
        }
    }
})(Home || (Home = {}));
//# sourceMappingURL=home.js.map