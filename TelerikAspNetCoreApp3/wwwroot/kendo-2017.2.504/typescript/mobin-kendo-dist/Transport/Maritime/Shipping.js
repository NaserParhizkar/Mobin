"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
var MyModule;
(function (MyModule) {
    class SyncFileReader {
        getFiles(path, depth = 0) {
            const fileTree = [];
            const files = fs.readdirSync(path);
            for (let file of files) {
                const stats = fs.statSync(file);
                let fileItem;
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
        }
    }
    class LimitFileReader extends SyncFileReader {
        constructor(maxDepth) {
            super();
            this.maxDepth = maxDepth;
        }
        getFiles(path, depth = 0) {
            if (depth > this.maxDepth)
                return [];
            return super.getFiles(path, depth);
        }
    }
    MyModule.LimitFileReader = LimitFileReader;
})(MyModule || (MyModule = {}));
//# sourceMappingURL=Shipping.js.map