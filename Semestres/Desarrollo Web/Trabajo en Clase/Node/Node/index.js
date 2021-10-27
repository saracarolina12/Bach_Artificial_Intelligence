/*
const fs = require("fs");
fs.copyFileSync('math.js', 'copia_math.js'); //crea un archivo y crea una copia de math.js en copia_math.js
//console.log("que es fs", fs);
*/

//llamar al archivo math
const math = require("./math");
console.log("math node", math);

console.log(math.add(4,6));

console.log(fun.tofloat(y));
