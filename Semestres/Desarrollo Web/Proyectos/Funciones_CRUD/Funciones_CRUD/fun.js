const fun = {};

const tofloat = (x) => {
    return parseFloat(x);
}

const isnum = (x) => {
    if(!isNaN(x)){
        return true;
    }else{
        return false;
    }
}

const tomayus = (x) => {
    return x.toUpperCase();
}


fun.isnum= isnum;
fun.tofloat = tofloat;
fun.tomayus = tomayus;

// console.log(tofloat('10.33'));
// console.log(isnum('9.5'));
//console.log(tomayus('sara'));

module.exports.tofloat = tofloat;
module.exports.isnum = isnum;
module.exports.tomayus = tomayus;

module.exports.fun = fun;
