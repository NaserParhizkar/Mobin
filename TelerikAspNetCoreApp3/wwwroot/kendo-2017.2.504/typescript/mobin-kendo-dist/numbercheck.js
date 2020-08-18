"use strict";
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
var Song = (function () {
    function Song(artist, title) {
        this.artist = artist;
        this.title = title;
    }
    Song.prototype.play = function () {
        console.log('Playing ' + this.title + ' by ' + this.artist);
    };
    Song.Comparer = function (a, b) {
        if (a.title === b.title)
            return 0;
        return a.title > b.title ? 1 : -1;
    };
    return Song;
}());
var Jukebox = (function () {
    function Jukebox(songs) {
        this.songs = songs;
    }
    Jukebox.prototype.play = function () {
        var song = this.getRandomSong();
        song.play();
    };
    Jukebox.prototype.getRandomSong = function () {
        var songCount = this.songs.length;
        var songIndex = Math.floor(Math.random() * songCount);
        return this.songs[songIndex];
    };
    return Jukebox;
}());
var Person = (function () {
    function Person(fname, lname) {
        this.fname = fname;
        this.lname = lname;
    }
    Person.prototype.getFullName = function () {
        return this.fname + " " + this.lname;
    };
    return Person;
}());
var Employee = (function (_super) {
    __extends(Employee, _super);
    function Employee() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.getFullName = function () { return _super.prototype.getFullName.call(_this) + "  Emp"; };
        return _this;
    }
    return Employee;
}(Person));
var p = new Person("Naser", "Parhizkar");
var PlayList = (function () {
    function PlayList(songs) {
        this.songs = songs;
    }
    PlayList.prototype.play = function () {
        var song = this.songs.pop();
        song.play();
    };
    PlayList.prototype.sort = function () {
        this.songs.sort(Song.Comparer);
    };
    return PlayList;
}());
var RepeatingPlaylist = (function (_super) {
    __extends(RepeatingPlaylist, _super);
    function RepeatingPlaylist(songs) {
        var _this = _super.call(this, songs) || this;
        _this.songIndex = 0;
        return _this;
    }
    RepeatingPlaylist.prototype.play = function () {
        this.songs[this.songIndex].play();
        this.songIndex++;
        if (this.songIndex >= this.songs.length) {
            this.songIndex = 0;
        }
    };
    return RepeatingPlaylist;
}(PlayList));
var ClickCounter = (function () {
    function ClickCounter() {
        this.count = 0;
    }
    ClickCounter.prototype.registerClick = function () {
        this.count++;
        console.log(this.count);
    };
    return ClickCounter;
}());
var clickCounter = new ClickCounter();
var clickHandler = clickCounter.registerClick.bind(clickCounter);
document.getElementById('btn').onclick = clickHandler;
var inputEl = document.getElementById('number-check');
inputEl.addEventListener('keyup', function () {
    var input = inputEl;
    console.log(input.value);
});
function reverse(list) {
    var reversedList = [];
    for (var i = list.length - 1; i >= 0; i--) {
        reversedList.push(list[i]);
    }
    return reversedList;
}
function printList(list) {
    for (var i = 0; i <= list.length - 1; i++) {
        console.log(list[i]);
    }
}
var letters = ['a', 'b', 'c', 'd', 'e'];
console.log('Original letters are : ');
printList(letters);
var reversedLetters = reverse(letters);
console.log('Reversed letters are : ');
printList(reversedLetters);
var numbers = [1, 2, 3, 4, 5];
console.log('Original numbers are : ');
printList(numbers);
var reversedNumbers = reverse(numbers);
console.log('Reversed numbers are : ');
printList(reversedNumbers);
var Personalization = (function () {
    function Personalization() {
    }
    Personalization.greet = function (obj) {
        return 'Hello ' + obj.name;
    };
    return Personalization;
}());
var First;
(function (First) {
    var Example = (function () {
        function Example() {
        }
        Example.prototype.log = function () {
            console.log('Loggin from First.Example.log()');
        };
        return Example;
    }());
    First.Example = Example;
})(First || (First = {}));
var Second;
(function (Second) {
    var Example = (function () {
        function Example() {
        }
        Example.prototype.log = function () {
            console.log('Loggin from Second.Example.log()');
        };
        return Example;
    }());
    Second.Example = Example;
})(Second || (Second = {}));
var first = new First.Example();
first.log();
var second = new Second.Example();
second.log();
var Shipping;
(function (Shipping) {
    var Ferry = (function () {
        function Ferry(name, port, displacement) {
            this.name = name;
            this.port = port;
            this.displacement = displacement;
        }
        return Ferry;
    }());
    Shipping.Ferry = Ferry;
    var defaultDisplacement = 4000;
    var PrivateShip = (function () {
        function PrivateShip(name, port, displacement) {
            if (displacement === void 0) { displacement = defaultDisplacement; }
            this.name = name;
            this.port = port;
            this.displacement = displacement;
        }
        return PrivateShip;
    }());
    var ferry = new Shipping.Ferry('Assurance', 'London', 3220);
})(Shipping = exports.Shipping || (exports.Shipping = {}));
var Docking;
(function (Docking) {
    var Dock = (function () {
        function Dock() {
            this.dockedShips = [];
        }
        Dock.prototype.arrival = function (ship) {
            this.dockedShips.push(ship);
        };
        return Dock;
    }());
    Docking.Dock = Dock;
})(Docking || (Docking = {}));
var dock = new Docking.Dock();
var Size;
(function (Size) {
    Size[Size["S"] = 0] = "S";
    Size[Size["M"] = 1] = "M";
    Size[Size["L"] = 2] = "L";
    Size[Size["XL"] = 3] = "XL";
})(Size = exports.Size || (exports.Size = {}));
//# sourceMappingURL=numbercheck.js.map