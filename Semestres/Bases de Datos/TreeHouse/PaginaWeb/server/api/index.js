const express = require("express");
const app = express();
app.get('/', function(requets, response){
    response.send("API desde NodeJS")
});
app.listen(3000, () => {
    console.log("Servidor iniciado en puerto 3000");
});