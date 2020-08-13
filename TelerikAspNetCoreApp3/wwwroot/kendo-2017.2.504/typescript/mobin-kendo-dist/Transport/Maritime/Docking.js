class MasterControlPanel {
    constructor() {
        this.sensors = [];
        this.sensors.push(new HeatSensor(this));
    }
    start() {
        for (let sensor of this.sensors) {
            sensor.check();
        }
        window.setTimeout(() => this.start(), 1000);
    }
    startAlarm(message) {
        console.log('Alarm! ' + message);
    }
}
class HeatSensor {
    constructor(controlPanel) {
        this.controlPanel = controlPanel;
        this.upperLimit = 38;
        this.sensor = {
            read: function () { return Math.floor(Math.random() * 100); }
        };
    }
    check() {
        if (this.sensor.read() > this.upperLimit) {
            this.controlPanel.startAlarm('Overheating!');
        }
    }
}
const controlPanel = new MasterControlPanel();
controlPanel.start();
class Car {
    moveTo(x, y) {
        console.log('Driving to ' + x + ' ' + y);
    }
}
class SportCar extends Car {
}
class Airplane {
    moveTo(x, y) {
        console.log('Flying to ' + x + ' ' + y);
    }
}
class Satellite {
    moveTo(x) {
        console.log('Targeting ' + x);
    }
}
function navigate(vehicle) {
    vehicle.moveTo(59.9436499, 10.7167959);
}
const car = new SportCar();
navigate(car);
const airplane = new Airplane();
navigate(airplane);
const satellite = new Satellite();
navigate(satellite);
class RewardPointsCalculator {
    getPoints(transactionValue) {
        return Math.floor(transactionValue) * 4;
    }
}
class DoublePointsCalculator extends RewardPointsCalculator {
    getPoints(transactionValue) {
        const standardPoints = super.getPoints(transactionValue);
        return standardPoints * 2;
    }
}
class Light {
    SwitchOn() {
    }
    SwitchOff() {
    }
}
class LightSwitch {
    constructor(light) {
        this.light = light;
        this.isOn = false;
    }
    onPress() {
        if (this.isOn) {
            this.light.SwitchOff();
            this.isOn = false;
        }
        else {
            this.light.SwitchOn();
            this.isOn = true;
        }
    }
}
class BasicWheelCleaning {
    CleanWheels() {
        console.log('Soaping Wheel');
        console.log('Brushing Wheel');
    }
}
class ExecutiveWheelCleaning extends BasicWheelCleaning {
    CleanWheels() {
        super.CleanWheels();
        console.log('Waxing Wheel');
        console.log('Rinsing Wheel');
    }
}
//# sourceMappingURL=Docking.js.map