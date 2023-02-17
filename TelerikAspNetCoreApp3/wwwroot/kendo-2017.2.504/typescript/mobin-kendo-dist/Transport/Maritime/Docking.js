var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var MasterControlPanel = (function () {
    function MasterControlPanel() {
        this.sensors = [];
        this.sensors.push(new HeatSensor(this));
    }
    MasterControlPanel.prototype.start = function () {
        var _this = this;
        for (var _i = 0, _a = this.sensors; _i < _a.length; _i++) {
            var sensor = _a[_i];
            sensor.check();
        }
        window.setTimeout(function () { return _this.start(); }, 1000);
    };
    MasterControlPanel.prototype.startAlarm = function (message) {
        console.log('Alarm! ' + message);
    };
    return MasterControlPanel;
}());
var HeatSensor = (function () {
    function HeatSensor(controlPanel) {
        this.controlPanel = controlPanel;
        this.upperLimit = 38;
        this.sensor = {
            read: function () { return Math.floor(Math.random() * 100); }
        };
    }
    HeatSensor.prototype.check = function () {
        if (this.sensor.read() > this.upperLimit) {
            this.controlPanel.startAlarm('Overheating!');
        }
    };
    return HeatSensor;
}());
var controlPanel = new MasterControlPanel();
controlPanel.start();
var Car = (function () {
    function Car() {
    }
    Car.prototype.moveTo = function (x, y) {
        console.log('Driving to ' + x + ' ' + y);
    };
    return Car;
}());
var SportCar = (function (_super) {
    __extends(SportCar, _super);
    function SportCar() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return SportCar;
}(Car));
var Airplane = (function () {
    function Airplane() {
    }
    Airplane.prototype.moveTo = function (x, y) {
        console.log('Flying to ' + x + ' ' + y);
    };
    return Airplane;
}());
var Satellite = (function () {
    function Satellite() {
    }
    Satellite.prototype.moveTo = function (x) {
        console.log('Targeting ' + x);
    };
    return Satellite;
}());
function navigate(vehicle) {
    vehicle.moveTo(59.9436499, 10.7167959);
}
var car = new SportCar();
navigate(car);
var airplane = new Airplane();
navigate(airplane);
var satellite = new Satellite();
navigate(satellite);
var RewardPointsCalculator = (function () {
    function RewardPointsCalculator() {
    }
    RewardPointsCalculator.prototype.getPoints = function (transactionValue) {
        return Math.floor(transactionValue) * 4;
    };
    return RewardPointsCalculator;
}());
var DoublePointsCalculator = (function (_super) {
    __extends(DoublePointsCalculator, _super);
    function DoublePointsCalculator() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    DoublePointsCalculator.prototype.getPoints = function (transactionValue) {
        var standardPoints = _super.prototype.getPoints.call(this, transactionValue);
        return standardPoints * 2;
    };
    return DoublePointsCalculator;
}(RewardPointsCalculator));
var Light = (function () {
    function Light() {
    }
    Light.prototype.SwitchOn = function () {
    };
    Light.prototype.SwitchOff = function () {
    };
    return Light;
}());
var LightSwitch = (function () {
    function LightSwitch(light) {
        this.light = light;
        this.isOn = false;
    }
    LightSwitch.prototype.onPress = function () {
        if (this.isOn) {
            this.light.SwitchOff();
            this.isOn = false;
        }
        else {
            this.light.SwitchOn();
            this.isOn = true;
        }
    };
    return LightSwitch;
}());
var BasicWheelCleaning = (function () {
    function BasicWheelCleaning() {
    }
    BasicWheelCleaning.prototype.CleanWheels = function () {
        console.log('Soaping Wheel');
        console.log('Brushing Wheel');
    };
    return BasicWheelCleaning;
}());
var ExecutiveWheelCleaning = (function (_super) {
    __extends(ExecutiveWheelCleaning, _super);
    function ExecutiveWheelCleaning() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ExecutiveWheelCleaning.prototype.CleanWheels = function () {
        _super.prototype.CleanWheels.call(this);
        console.log('Waxing Wheel');
        console.log('Rinsing Wheel');
    };
    return ExecutiveWheelCleaning;
}(BasicWheelCleaning));
//# sourceMappingURL=Docking.js.map