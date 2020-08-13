"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Size = exports.Shipping = void 0;
var VehicleType = Home.VehicleType;
var monuments = [];
monuments.push({
    name: 'Statue of Liberty',
    heightInMeters: 46,
});
monuments.push({
    name: 'Peter the Great',
    heightInMeters: 96
});
monuments.push({
    name: 'Angel of the North',
    heightInMeters: 20
});
function compareMonumentHeights(a, b) {
    if (a.heightInMeters > b.heightInMeters)
        return -1;
    if (a.heightInMeters < b.heightInMeters)
        return 1;
    return 0;
}
var monumentsOrderedByHeight = monuments.sort(compareMonumentHeights);
var tallestMonument = monumentsOrderedByHeight[0];
console.log(tallestMonument.name);
var vehicle = VehicleType.Van;
var avenueRoad = {
    bedrooms: 11,
    bathrooms: 10
};
var mansion = avenueRoad;
var ScopeLosingExample = {
    text: "Property from lexical scope",
    run: function () {
        setTimeout(function () {
            console.log(this.text);
        }, 2000);
    }
};
ScopeLosingExample.run();
class Song {
    constructor(artist, title) {
        this.artist = artist;
        this.title = title;
    }
    play() {
        console.log('Playing ' + this.title + ' by ' + this.artist);
    }
    static Comparer(a, b) {
        if (a.title === b.title)
            return 0;
        return a.title > b.title ? 1 : -1;
    }
}
class Jukebox {
    constructor(songs) {
        this.songs = songs;
    }
    play() {
        var song = this.getRandomSong();
        song.play();
    }
    getRandomSong() {
        var songCount = this.songs.length;
        var songIndex = Math.floor(Math.random() * songCount);
        return this.songs[songIndex];
    }
}
class Person {
    constructor(fname, lname) {
        this.fname = fname;
        this.lname = lname;
    }
    getFullName() {
        return this.fname + " " + this.lname;
    }
}
class Employee extends Person {
    constructor() {
        super(...arguments);
        this.getFullName = () => super.getFullName() + "  Emp";
    }
}
let p = new Person("Naser", "Parhizkar");
class PlayList {
    constructor(songs) {
        this.songs = songs;
    }
    play() {
        var song = this.songs.pop();
        song.play();
    }
    sort() {
        this.songs.sort(Song.Comparer);
    }
}
class RepeatingPlaylist extends PlayList {
    constructor(songs) {
        super(songs);
        this.songIndex = 0;
    }
    play() {
        this.songs[this.songIndex].play();
        this.songIndex++;
        if (this.songIndex >= this.songs.length) {
            this.songIndex = 0;
        }
    }
}
class ClickCounter {
    constructor() {
        this.count = 0;
    }
    registerClick() {
        this.count++;
        console.log(this.count);
    }
}
const clickCounter = new ClickCounter();
const clickHandler = clickCounter.registerClick.bind(clickCounter);
document.getElementById('btn').onclick = clickHandler;
const inputEl = document.getElementById('number-check');
inputEl.addEventListener('keyup', function () {
    const input = inputEl;
    console.log(input.value);
});
function reverse(list) {
    const reversedList = [];
    for (let i = list.length - 1; i >= 0; i--) {
        reversedList.push(list[i]);
    }
    return reversedList;
}
function printList(list) {
    for (let i = 0; i <= list.length - 1; i++) {
        console.log(list[i]);
    }
}
const letters = ['a', 'b', 'c', 'd', 'e'];
console.log('Original letters are : ');
printList(letters);
var reversedLetters = reverse(letters);
console.log('Reversed letters are : ');
printList(reversedLetters);
const numbers = [1, 2, 3, 4, 5];
console.log('Original numbers are : ');
printList(numbers);
const reversedNumbers = reverse(numbers);
console.log('Reversed numbers are : ');
printList(reversedNumbers);
class Personalization {
    static greet(obj) {
        return 'Hello ' + obj.name;
    }
}
var First;
(function (First) {
    class Example {
        log() {
            console.log('Loggin from First.Example.log()');
        }
    }
    First.Example = Example;
})(First || (First = {}));
var Second;
(function (Second) {
    class Example {
        log() {
            console.log('Loggin from Second.Example.log()');
        }
    }
    Second.Example = Example;
})(Second || (Second = {}));
const first = new First.Example();
first.log();
const second = new Second.Example();
second.log();
var Shipping;
(function (Shipping) {
    class Ferry {
        constructor(name, port, displacement) {
            this.name = name;
            this.port = port;
            this.displacement = displacement;
        }
    }
    Shipping.Ferry = Ferry;
    const defaultDisplacement = 4000;
    class PrivateShip {
        constructor(name, port, displacement = defaultDisplacement) {
            this.name = name;
            this.port = port;
            this.displacement = displacement;
        }
    }
    const ferry = new Shipping.Ferry('Assurance', 'London', 3220);
})(Shipping = exports.Shipping || (exports.Shipping = {}));
var Docking;
(function (Docking) {
    class Dock {
        constructor() {
            this.dockedShips = [];
        }
        arrival(ship) {
            this.dockedShips.push(ship);
        }
    }
    Docking.Dock = Dock;
})(Docking || (Docking = {}));
const dock = new Docking.Dock();
var Size;
(function (Size) {
    Size[Size["S"] = 0] = "S";
    Size[Size["M"] = 1] = "M";
    Size[Size["L"] = 2] = "L";
    Size[Size["XL"] = 3] = "XL";
})(Size = exports.Size || (exports.Size = {}));
//# sourceMappingURL=numbercheck.js.map