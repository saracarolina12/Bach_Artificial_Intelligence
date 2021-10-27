const math = {}; //exportar a math como objeto 

function add(a, b){
    return a + b;
}

const multiply = (a, b) => {
    return a * b;
}

const PI = 3.14159;

math.add = add;
math.multiply = multiply;
math.PI = PI;
//console.log(math.add(1,2));
module.exports.add = add;
module.exports.multiply = multiply;
module.exports.PI = PI;

module.exports.math = math; //exporta las 3 (add, multiply, PI)
