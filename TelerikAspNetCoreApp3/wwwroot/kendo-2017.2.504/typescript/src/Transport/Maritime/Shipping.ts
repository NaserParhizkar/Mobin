import * as fs from 'fs';

module MyModule {

export interface FileItem {
    path: string;
    contents: FileItem[]
}

class SyncFileReader {
    getFiles(path: string, depth: number = 0) {
        const fileTree = [];

        const files = fs.readdirSync(path);

        for (let file of files) {
            const stats = fs.statSync(file);

            let fileItem: FileItem;

            if (stats.isDirectory()) {
                // Add directory and contents 
                fileItem = {
                    path: file,
                    contents: this.getFiles(file, (depth + 1))
                };
            } else {
                // Add file 
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


    export class LimitFileReader extends SyncFileReader {
        constructor(public maxDepth: number) {
            super();
        }

        getFiles(path: string, depth = 0) {
            if (depth > this.maxDepth)
                return [];

            return super.getFiles(path, depth);
        }
    }
}


