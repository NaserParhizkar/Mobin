//import { LimitFileReader } from './Shipping';

//function log(target: any, key: string, descriptor: any) {
//    const original = descriptor.value;
//    descriptor.value = function (...args: any[]) {
//        // Call the original method
//        const result = original.apply(this, args);
//        // Log the call, and the result
//        console.log(`${key} with args ${JSON.stringify(args)} returned  ${JSON.stringify(result)}`);
//        // Return the result
//        if (1 == 1) {
//            return false;
//        }

//        return result;
//    }
//    return descriptor;
//}
//class Calculator {
//    // Using the decorator
//    @log
//    square(num: number) {
//        return num * num;
//    }
//}
//const calculator = new Calculator();

//// square with args [2] returned 4
//calculator.square(2);
//// square with args [3] returned 9
//calculator.square(3);



//class OrderedArray<T> {
//    private items: T[] = [];

//    constructor(private comparer?: (a: T, b: T) => number) {
//    }

//    add(item: T): void {
//        this.items.push(item);
//        this.items.sort(this.comparer);
//    }

//    getItem(index: number): T {
//        if (this.items.length > index) {
//            return this.items[index];
//        }
//        return null;
//    }
//}

//var orderedArray: OrderedArray<number> = new OrderedArray<number>();

//orderedArray.add(5);
//orderedArray.add(1);
//orderedArray.add(3);

//var firstItem: number = orderedArray.getItem(0);

//alert(firstItem);


//function add(a: number, b: number) {
//    // The return value is used to determine the return type of function 
//    return a * b;
//}

//interface CallsFunction {
//    (cb: (result: string) => any): void;
//}

//var callsFunction: CallsFunction = function (cb) {
//    cb('Done');

//    //cb(1);
//}


//callsFunction(function (result) {
//    return result;
//});

//window.onclick = function (event) {
//    var button = event.button;
//}

//interface DeviceMotionEvent {
//    motionDescription: string;
//}

//// The existing DeviceMotionEvent has all of its existing properties
//// plus our additional motionDescription property
////function handleMotionEvent(e: DeviceMotionEvent) {
////    var acceleration = e.acceleration;
////    var description = e.motionDescription
////}


//function acceptNumber(input: number) {
//    return input;
//}

//// number
//acceptNumber(1);


////// enum
////acceptNumber(Utilities.Size.XL);

//// null
//acceptNumber(null);



//class C1 {
//    name: string;

//    show(hint?: string) {
//        return 1;
//    }
//}


//class C2 {
//    constructor(public name: string) {

//    }

//    show(hint: string = 'default') {
//        return Math.floor(Math.random() * 10);
//    }
//}

//class C3 {
//    name: string;

//    show() {
//        return <any>'Dynamic';
//    }
//}


//var T4 = {
//    name: '',
//    show() {
//        return 1;
//    }
//}

//var c1 = new C1();
//var c2 = new C2('A name');
//var c3 = new C3();


//// c1, c2, c3 and T4 are equivalent
//var arr: C1[] = [c1, c2, c3, T4];


//for (var i = 0; i < arr.length; i++) {
//    arr[i].show();
//}


//declare class JQuery {
//    html(html: string): void;
//}

//declare function $(query: string): JQuery;


//import http = require('http');

//import { ClientHttp2Stream } from 'http2';
//import Mod = require('Mod');


//declare module "Mod" {
//    interface IPerson {
//        email: string;
//    }
//}


//let aa: ClientHttp2Stream;


//let a: Mod.Person;

//a.birthDate = new Date();



interface ControlPanel {
    startAlarm(message: string): any;
}

interface Sensor {
    check(): any;
}

class MasterControlPanel {
    private sensors: Sensor[] = [];

    constructor() {
        // Instantiating the delegate HeatSensor
        this.sensors.push(new HeatSensor(this));
    }

    start() {
        for (let sensor of this.sensors) {
            sensor.check();
        }

        window.setTimeout(() => this.start(), 1000);
    }

    startAlarm(message: string) {
        console.log('Alarm! ' + message);
    }
}

class HeatSensor {
    private upperLimit = 38;
    private sensor = {
        read: function () { return Math.floor(Math.random() * 100); }
    }

    constructor(private controlPanel: ControlPanel) {
    }

    check() {
        if (this.sensor.read() > this.upperLimit) {
            // Calling back to the wrapper
            this.controlPanel.startAlarm('Overheating!');
        }
    }
}

const controlPanel = new MasterControlPanel();
controlPanel.start();



interface Vehicle {
    moveTo(x: number, y: number);
}

// Explicit interface implementation
class Car implements Vehicle {
    moveTo(x: number, y: number) {
        console.log('Driving to ' + x + ' ' + y);
    }
}

class SportCar extends Car {

}

// Doesn't explicitly implement the vehicle interface 
class Airplane {
    moveTo(x: number, y: number) {
        console.log('Flying to ' + x + ' ' + y);
    }
}

class Satellite {
    moveTo(x: number) {
        console.log('Targeting ' + x);
    }
}

function navigate(vehicle: Vehicle) {
    vehicle.moveTo(59.9436499, 10.7167959);
}

const car = new SportCar();
navigate(car);

const airplane = new Airplane();
navigate(airplane);

const satellite = new Satellite();
navigate(satellite);


class RewardPointsCalculator {
    getPoints(transactionValue: number) {
        // 4 points per whole dollar spent 
        return Math.floor(transactionValue) * 4;
    }
}

class DoublePointsCalculator extends RewardPointsCalculator {
    getPoints(transactionValue: number) {
        const standardPoints = super.getPoints(transactionValue);
        return standardPoints * 2;
    }
}

interface LightSource {
    SwitchOn();
    SwitchOff();
}

class Light implements LightSource {
    SwitchOn() {
        //throw new Error("Method not implemented.");
    }
    SwitchOff() {
        //throw new Error("Method not implemented.");
    }
}

class LightSwitch {
    private isOn = false;

    constructor(private light: LightSource) {

    }

    onPress() {
        if (this.isOn) {
            this.light.SwitchOff();
            this.isOn = false;
        } else {
            this.light.SwitchOn();
            this.isOn = true;
        }
    }
}

//let light = new Light();
//let lightSwitch = new LightSwitch(light);
//lightSwitch.onPress();


interface WheelCleaning {
    CleanWheels(): void;
}

class BasicWheelCleaning implements WheelCleaning {
    CleanWheels(): void {
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


