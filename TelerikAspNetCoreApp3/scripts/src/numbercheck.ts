
//import VehicleType = Home.VehicleType;


//interface Monument {
//    name: string;
//    heightInMeters: number;
//}
//var monuments: Monument[] = [];
//monuments.push({
//    name: 'Statue of Liberty',
//    heightInMeters: 46,
//    //location : 'USA'
//});

//monuments.push({
//    name: 'Peter the Great',
//    heightInMeters: 96
//});

//monuments.push({
//    name: 'Angel of the North',
//    heightInMeters: 20
//});

//function compareMonumentHeights(a: Monument, b: Monument) {
//    if (a.heightInMeters > b.heightInMeters)
//        return -1;
//    if (a.heightInMeters < b.heightInMeters)
//        return 1;
//    return 0;
//}

//var monumentsOrderedByHeight = monuments.sort(compareMonumentHeights);

//// Get the first element from the array, which is the tallest
//var tallestMonument = monumentsOrderedByHeight[0];
//console.log(tallestMonument.name);

//var vehicle = VehicleType.Van;

//interface House {
//    bedrooms: number;
//    bathrooms: number;
//}

//interface Mansion {
//    bedrooms: number;
//    bathrooms: number;
//    butlers: number;
//}

//var avenueRoad: House = {
//    bedrooms: 11,
//    bathrooms: 10
//}
//var mansion: Mansion = <Mansion>avenueRoad;

////function getAverage(...a: number[]) : string {
////    var total = 0, counter = 0;

////    for (var i = 0; i < a.length; i++) {
////        total += a[i];
////        counter++;
////    }

////    var avg = total / counter;
////    return 'The average is ' + avg;
////}

////var result = getAverage(2, undefined, 6, 8, 10);


////function getAverage(a: string, b: string, c: string): string;
////function getAverage(a: number, b: number, c: number): string;
////// Implementation signature

////function getAverage(a: any, b: any, c: any): string {
////    var total = parseInt(a, 10) + parseInt(b, 10) + parseInt(c, 10);
////    var average = total / 3;
////    return 'The average is ' + average;
////}

////var result = getAverage('4', 'a', '8');


//var ScopeLosingExample = {
//    text: "Property from lexical scope",
//    run: function () {
//        setTimeout(function () {
//            console.log(this.text);
//        }, 2000);
//    }
//};

//// alerts undefined
//ScopeLosingExample.run();

//interface Point {
//    // Properties
//    x: number;
//    y: number;
//}

//interface Passenger {
//    // Properties
//    name: string;
//}

//interface Vehicle {
//    // Constructor
//    new(): Vehicle;

//    // Properties
//    currentLocation: Point;

//    //// Methods
//    //travelTo(point: Point);
//    //addPassenger(passenger: Passenger);
//    //removePassenger(passenger: Passenger);
//}

//interface Audio {
//    play(): any;
//}


//class Song implements Audio {
//    constructor(private artist: string, private title: string) {

//    }

//    play() {
//        console.log('Playing ' + this.title + ' by ' + this.artist);
//    }

//    static Comparer(a: Song, b: Song) {
//        if (a.title === b.title)
//            return 0;

//        return a.title > b.title ? 1 : -1;
//    }
//}

//class Jukebox {
//    constructor(private songs: Song[]) {

//    }

//    play() {
//        var song = this.getRandomSong();
//        song.play();
//    }

//    private getRandomSong() {
//        var songCount = this.songs.length;
//        var songIndex = Math.floor(Math.random() * songCount);

//        return this.songs[songIndex];
//    }
//}


//class Person {
//    constructor(public fname: string, public lname: string) {
//    }

//    getFullName(): string {
//        return this.fname + " " + this.lname;
//    }
//}

//class Employee extends Person {
//    getFullName = () => super.getFullName() + "  Emp";
//}

//let p: Employee = new Person("Naser", "Parhizkar");

////var result = (p).getFullName();

//class PlayList {
//    constructor(public songs: Audio[]) {
//    }

//    play() {
//        var song = this.songs.pop();
//        song.play();
//    }

//    sort() {
//        this.songs.sort(Song.Comparer);
//    }
//}

//class RepeatingPlaylist extends PlayList {
//    private songIndex = 0;

//    constructor(songs: Song[]) {
//        super(songs);
//    }

//    play() {
//        this.songs[this.songIndex].play();

//        this.songIndex++;

//        if (this.songIndex >= this.songs.length) {
//            this.songIndex = 0;
//        }
//    }
//}

//class ClickCounter {
//    private count = 0;

//    registerClick() {
//        this.count++;
//        console.log(this.count);
//    }
//}


//const clickCounter = new ClickCounter();

//const clickHandler = clickCounter.registerClick.bind(clickCounter);
//document.getElementById('btn').onclick = clickHandler;

////document.getElementById('btn').onclick = (e) => {
////    const target = <Element>e.target || e.srcElement;
////    clickCounter.registerClick(target.id);
////}; 


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//const inputEl = document.getElementById('number-check');

//inputEl.addEventListener('keyup', function () {
//    const input = inputEl as HTMLInputElement;
//    console.log(input.value);
//});

//function reverse<T>(list: T[]): T[] {
//    const reversedList: T[] = [];

//    for (let i = list.length - 1; i >= 0; i--) {
//        reversedList.push(list[i]);
//    }

//    return reversedList;
//}

//function printList<T>(list: T[]) {
//    for (let i = 0; i <= list.length - 1; i++) {
//        console.log(list[i]);
//    }
//}

//const letters = ['a', 'b', 'c', 'd', 'e'];
//console.log('Original letters are : ');
//printList(letters);

//var reversedLetters = reverse<string>(letters);
//console.log('Reversed letters are : ');
//printList(reversedLetters);

//const numbers = [1, 2, 3, 4, 5];
//console.log('Original numbers are : ');
//printList(numbers);

//const reversedNumbers = reverse<number>(numbers);
//console.log('Reversed numbers are : ');
//printList(reversedNumbers);


//interface HasName {
//    name: string;
//}

//class Personalization {
//    static greet<T extends HasName>(obj: T) {
//        return 'Hello ' + obj.name;
//    }
//}


//namespace First {
//    export class Example {
//        log() {
//            console.log('Loggin from First.Example.log()');
//        }
//    }
//}

//namespace Second {
//    export class Example {
//        log() {
//            console.log('Loggin from Second.Example.log()');
//        }
//    }
//}


//const first = new First.Example();

//// Loggin from First.Example.log()
//first.log();

//const second = new Second.Example();

//// Loggin from Second.Example.log()
//second.log();


//export namespace Shipping {
//    // Available as Shipping.Ship
//    export interface Ship {
//        name: string;
//        port: string;
//        displacement: number;
//    }

//    // Available as Shipping.Ferry
//    export class Ferry implements Ship {
//        constructor(
//            public name: string,
//            public port: string,
//            public displacement: number) {

//        }
//    }

//    // Only available inside of the Shipping module
//    const defaultDisplacement = 4000;

//    class PrivateShip implements Ship {
//        constructor(
//            public name: string,
//            public port: string,
//            public displacement: number = defaultDisplacement
//        ) {

//        }
//    }

//    const ferry = new Shipping.Ferry('Assurance', 'London', 3220);
//}

//namespace Docking {
//    import Ship = Shipping.Ship;

//    export class Dock {
//        private dockedShips: Ship[] = [];

//        arrival(ship: Ship) {
//            this.dockedShips.push(ship);
//        }
//    }
//}

//const dock = new Docking.Dock();


//export enum Size {
//    S,
//    M,
//    L,
//    XL
//} 