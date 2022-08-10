var fs = require('fs'),
    path = require('path');

function dashToSpace(text) {
    return text.replace(/-/g, " ");
}

function renameDir(dir) {
    var files = fs.readdirSync(dir),
        f,
        fileName,
        path,
        newPath,
        file;
    for (f = 0; f < files.length; f += 1) {
        fileName = files[f];
        path = dir + '/' + fileName;
        file = fs.statSync(path);
        newPath = dir + '/' + dashToSpace(fileName);
        fs.renameSync(path, newPath);
        if (file.isDirectory()) {
            renameDir(newPath);
        }
    }
}

renameDir(__dirname+"\\torename");