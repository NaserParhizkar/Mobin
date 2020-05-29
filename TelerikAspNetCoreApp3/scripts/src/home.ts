
//class ClickCounter {
//    private count = 0;

//    registerClick = function() {
//        this.count++;
//        console.log(this.count);
//    }
//}

//var clickCounter = new ClickCounter();

//var clickHandler = clickCounter.registerClick.bind(clickCounter);


//document.getElementById('btn').onclick = clickHandler;

namespace Home {

    class Display {
        name: string;
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
        static getName(inputClass: any) {
            // RegEx to get the class name
            var funcNameRegex = /function (.{1,})\(/;

            var results = (funcNameRegex).exec((inputClass as any).constructor.toString());

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
        static create(className: string) {
            var obj : { name: string };
            eval("obj=new " + className + "()");
            obj.name = 'naser';
            return obj;
        }
    }

    var newClass: any = ObjectFactory.create(tvType)

    console.log(newClass instanceof Television);
    console.log('name' in newClass);
    console.log(newClass.name);



    export enum VehicleType {
        PedalCyle,
        MotorCyle,
        Car,
        Van,
        Bus,
        Lorry
    }


    let a = VehicleType.Bus;



    let myTuple: [number, string];

    myTuple = [1, 'a'];

    interface Options {
        readonly material: string;
        backlight: boolean;
    }

    type ReadOnly<T> = { readonly [K in keyof T]: T[K] };
    type Optional<T> = { [K in keyof T]?: T[K] };
    type Nullable<T> = { [K in keyof T]: T[K] | null; };

    // Read-only type
    const opt1: ReadOnly<Options> = {
        backlight: true,
        material: 'plastic'
    };

    // Optional type
    const opt2: Optional<Options> = {
        // All members are optional
    };

    interface SpeedControllable {
        increaseSpeed(): void;
        decreaseSpeed(): void;
        stop(): void;
    }
    interface InclineControllable {
        lift(): void;
        drop(): void;
    }
    function isSpeedControllable(treadmill: SpeedControllable | any)
        : treadmill is SpeedControllable {
        if (treadmill.increaseSpeed
            && treadmill.decreaseSpeed
            && treadmill.stop) {
            return true;
        }
        return false;
    }
     
    function customTypeGuardExample(treadmill: SpeedControllable | InclineControllable) {
        // Type guard
        if (isSpeedControllable(treadmill)) {
            // OK
            treadmill.increaseSpeed();
        } else {
            // OK
            treadmill.lift();
        }
    }

    function getAverage(a: number, b: number, c?: number): string {
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

    // 'The average is 5'
    const result = getAverage(4, 6, NaN);
    console.log(result);


    // Hybrid type
    interface SimpleDocument {
        (selector: string): HTMLElement;
        notify(message: string): void;
    }

    // Implementation
    const prepareDocument = function (): SimpleDocument {
        let doc = <SimpleDocument>function (selector: string) {
            return document.getElementById(selector);
        };

        doc.notify = function (message: string) {
            alert(message);
        }

        return doc;
    }

    const aa = prepareDocument();

    // Call aa as a function
    const elem = aa('btn');

    // Use aa as an object
    aa.notify(elem.id);


    // Abstract class
    abstract class Logger {
        abstract Notify(message: string): void;

        getMessage(message: string): string {
            return 'Information: ${new Date().toUTCString()} ${message}';
        }
    }

    class ConsoleLogger extends Logger {
        Notify(message: string): void {
            console.log(this.getMessage(message));
        }
    }

    class InvasiveLogger extends Logger {
        Notify(message: string): void {
            alert(this.getMessage(message));
        }
    }


    let logger: Logger;

    // Error. Cannot create an instance of an abstract class
    //logger = new Logger();

    // Create an instance of sub-class 
    logger = new InvasiveLogger();

    logger.Notify('Hello Word');

    interface Repository<T, TId> {
        getById(id: TId): T;
        persist(model: T): TId;
    }

    //interface Controller<TModel> {
    //    read(): TModel[];
    //    insert(model: TModel);
    //    update(model: TModel);
    //    delete(model: TModel);
    //}


    //class CustomerController implements Controller<Customer> {
    //    constructor(private customers: Customer[]) {
    //    }

    //    read(): Customer[] {
    //        return this.customers;
    //    }

    //    insert(customer: Customer) {
    //        this.customers[customer.id.Value] = customer;
    //    }

    //    update(customer: Customer) {
    //        this.customers[customer.id.Value] = customer;
    //    }

    //    delete(customer: Customer) {
    //        delete this.customers[customer.id.Value];
    //    }
    //}

    //class Url<TModel> {
    //    getUrl(controller: Controller<TModel>) {
    //    }
    //}


    //let url: Url<CustomerController> = new Url<CustomerController>();
    //url.getUrl



    class CustomerId {
        constructor(private customerIdValue: number) {
        }

        get Value() {
            return this.customerIdValue;
        }
    }

    class Customer {
        constructor(public id: CustomerId, public name: string) {
        }
    }

    class CustomerRepository implements Repository<Customer, CustomerId>{
        constructor(private customers: Customer[]) {
        }

        getById(id: CustomerId): Customer {
            return this.customers[id.Value];
        }
        persist(customer: Customer): CustomerId {
            this.customers[customer.id.Value] = customer;
            return customer.id;
        }
    }
}