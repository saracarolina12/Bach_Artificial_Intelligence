const express = require("express");

const app = express();

app.use(express.json()); // for parsing application/json
app.use(express.urlencoded({ extended: true })); // for parsing application/x-www-form-urlencoded

app.get("/", function (req, res) {
  res.sendFile(__dirname + "/calculator.html");
});

app.post("/", function (req, res) {
  // res.send("<h1>Thanks for posting!</h1>");
  //console.log(req.body);
  //console.log((Number(req.body.num1 ) + Number(req.body.num2))); ---> esto funciona para sumbar
  //const resu = Number(req.body.num1 ) + Number(req.body.num2);
  const { num1, num2} = req.body;
  res.send(`<h1>El resultado es: ${num1}</h1> <br> <h1>El resultado es: ${num2}</h1>`);
});

app.listen(3000, function () {
  console.log("Servidor corriendo!");
});