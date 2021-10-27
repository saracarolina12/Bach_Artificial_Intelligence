const tofloat = (x) => {
    return parseFloat(x);
}
const toint = (x) => {
    return parseInt(x);
}
const isnum = (x) => {
    if(!isNaN(x)){
        return true;
    }else{
        return false;
    }
}

console.log(tofloat('10.33'));
console.log(toint(50.55));
console.log(isnum('9.5'));
