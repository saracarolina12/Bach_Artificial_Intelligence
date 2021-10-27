const express = require("express");
const app = express();

app.get('/',function(request,response){
    //console.log("Hello, world :D",request)
    response.send("Hello, world :D",request);
});

app.get('/tofloat',function(request,response){
    response.send('<center><h1><i style="color: blue;">To float</i></h1></center>');
});

app.get('/toint',function(request,response){
    response.send('<center><h1><i style="color: blue;">To int</i></h1></center>');
});

app.get('/isnum',function(request,response){
    response.send('<center><h1><i style="color: blue;">Is this a number?</i></h1></center>');
}); 

app.listen(3000, function (){
    console.log("Servidor corriendo en el puerto 3000!");
})