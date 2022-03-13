const express = require("express");
const path = require("path");

const app = express();

const fun = require("./fun");

app.use(express.json()); // for parsing application/json
app.use(express.urlencoded({ extended: true })); // for parsing application/x-www-form-urlencoded

app.set("views", path.join(__dirname, "views")); // for ejs
app.set("view engine", "ejs"); // for ejs


//GET
app.get('/isnum',function(req,res){
    // res.send("<body style='background-color:#B5DEFF;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#5C7AEA;'><i>Is this a number?</i></h1></center></div></body>");
    res.render("posts/isnum");
}); 
app.get('/tofloat',function(req,res){
    // res.send("<body style='background-color:#B5DEFF;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#5C7AEA;'><i>Convert this number to float</i></h1></center></div></body>");
    res.render("posts/tofloat");
});
app.get('/toMayus',function(req,res){
    // res.send("<body style='background-color:#B5DEFF;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#5C7AEA;'><i>Convert this number to float</i></h1></center></div></body>");
    res.render("posts/tomayus");
});


//POST
app.post("/resnum", (req, res) => {
   const { x } = req.body;
   console.log(x);
    if(fun.isnum(x)) res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>It is a number!</i></h1></center></div></body>");
    else res.send("<body style='background-color:#FFBCBC;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#8D2828;'><i>It is not a number!</i></h1></center></div></body>");
    // if(!isNaN(x)) res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>It is a number!</i></h1></center></div></body>");
    // else res.send("<body style='background-color:#FFBCBC;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#8D2828;'><i>It is not a number!</i></h1></center></div></body>");
});
app.post("/resfloat", (req, res) => {
    const { y } = req.body;
    const ans = fun.tofloat(y);
    console.log(ans);
    res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>Result: "+ ans +"</i></h1></center></div></body>");
});
app.post("/resmayus", (req, res) =>{
    console.log(fun.tomayus(req.body.y));
    const r = fun.tomayus(req.body.y);
    res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>Converted to uppercase:<br>"+ r +"</i></h1></center></div></body>");
});
app.listen(4000, () => {
  console.log("Server running...");
});

