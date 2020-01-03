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
var fs = require("fs");
var MyModule;
(function (MyModule) {
    var SyncFileReader = (function () {
        function SyncFileReader() {
        }
        SyncFileReader.prototype.getFiles = function (path, depth) {
            if (depth === void 0) { depth = 0; }
            var fileTree = [];
            var files = fs.readdirSync(path);
            for (var _i = 0, files_1 = files; _i < files_1.length; _i++) {
                var file = files_1[_i];
                var stats = fs.statSync(file);
                var fileItem = void 0;
                if (stats.isDirectory()) {
                    fileItem = {
                        path: file,
                        contents: this.getFiles(file, (depth + 1))
                    };
                }
                else {
                    fileItem = {
                        path: file,
                        contents: []
                    };
                }
                fileTree.push(fileItem);
            }
            return fileTree;
        };
        return SyncFileReader;
    }());
    var LimitFileReader = (function (_super) {
        __extends(LimitFileReader, _super);
        function LimitFileReader(maxDepth) {
            var _this = _super.call(this) || this;
            _this.maxDepth = maxDepth;
            return _this;
        }
        LimitFileReader.prototype.getFiles = function (path, depth) {
            if (depth === void 0) { depth = 0; }
            if (depth > this.maxDepth)
                return [];
            return _super.prototype.getFiles.call(this, path, depth);
        };
        return LimitFileReader;
    }(SyncFileReader));
    MyModule.LimitFileReader = LimitFileReader;
})(MyModule || (MyModule = {}));
//# sourceMappingURL=Shipping.js.map