const express = require("express");
const path = require("path");
const app = express();
const mongoose = require('mongoose'); //Data base

app.use(express.json()); // for parsing application/json
app.use(express.urlencoded({ extended: true })); // for parsing application/x-www-form-urlencoded
app.use('/public/images/', express.static('./public/images')); //forimages

app.set("views", path.join(__dirname, "views")); // for ejs
app.set("view engine", "ejs"); // for ejs

mongoose
.connect('mongodb://localhost:27017/daw') //127.0.0.1 = localhost
.then(() => console.log("conectado a mongoose!"))
.catch((err) => console.log("error: ", err));

const musicianSchema = new mongoose.Schema({
    name: String,
    music_genre: String,
    height: Number,
    year_birth: Number,
})
const Musician = mongoose.model("Musician", musicianSchema);
// const JohnLennon = new Musician({
//     name: "John Lennon",
//     music_genre: "rock",
//     height: 1.79,
//     year_birth: 1940,
// })

const posts = [
]; 

//GET
app.get("/posts", (req, res) => { 
    Musician.count({}, function( err, count){ //para contar # objeto en la BD
        if(count == 0  || count < 0){
            res.render("posts/index_empty");
        }else{
            Musician.find({}, function(err,posts){
              res.render("posts/index", {posts});
            });
        }
    })
});
app.get("/posts/create", (req, res) => {
  res.render("posts/create");
});
app.get("/posts/update", (req, res) => {
  res.render("posts/update");
});
app.get("/posts/delete/:id", (req, res) => {
  const { id } = req.params; //req.params obtiene el id dado en /:id
  if(id <= posts.length && id > 0){
    res.send("<body style='background-color:#005A3F;'><div style='margin:20%;'><center><h1 style='font-size:320%; color:#3b7866;'><i>Deleted successfully!!</i></h1></center></div></body>");
    posts.splice(req.params['id']-1,1); //si existe, borro el post
  }
  else res.send("<body style='background-color:#7E3511;'> <script>alert('ERROR!!');</script><center><h1 style='color:#d56730; margin:25%; font-size:400%;'>This position does not exist!!</h1></center></body>");
  console.log("Restantes: ", posts);
});
app.get("/posts/delete", (req,   res) => { 
  res.render("posts/delete");
});

// POST
app.post("/posts", (req, res) => {
  const {name, music_genre, height, year_birth} = req.body;
  posts.push({name, music_genre, height, year_birth});
  if(posts.length==0) res.send("<body style='background-color:#7E3511;'> <script>alert('ERROR!!');</script><center><h1 style='color:#d56730; margin:25%; font-size:400%;'>Musicians are empty!!!</h1></center></body>");
  else{
    Musician.create({name:req.body.name, music_genre:req.body.music_genre, height:req.body.height, year_birth:req.body.year_birth}); //mongoose [no existe insertOne()]
    res.send("<body style='background-color:#005A3F;'><div style='margin:20%;'><center><h1 style='font-size:320%; color:#3b7866;'><i>Posted successfully!!</i></h1></center></div></body>");
  }
});
app.post("/posts/delete", (req, res) => {
  Musician.count({}, function( err, count){
    if(count == 0|| count < 0)res.send("<body style='background-color:#7E3511;'> <script>alert('ERROR!!');</script><center><h1 style='color:#d56730; margin:25%; font-size:400%;'>Musicians are empty!!!</h1></center></body>");
    else{
      const {namee} = req.body;
      console.log("to search: ", namee);
      Musician.exists({name: namee}, function(err2, result){
        if(err2) console.log("error looking for this name (exists())");
        else{ //si no hay error en exists()
          if(result == null){ //si NO lo encuentra
            res.send("<body style='background-color:#7E3511;'> <script>alert('ERROR!!');</script><center><h1 style='color:#d56730; margin:25%; font-size:400%;'>This musician does not exist!!</h1></center></body>");
          }else{ //si SÍ lo encuentra
            res.send("<body style='background-color:#005A3F;'><div style='margin:20%;'><center><h1 style='font-size:320%; color:#3b7866;'><i>Deleted successfully!!</i></h1></center></div></body>");
            Musician.findOneAndRemove({name: namee}, function(err3, finded){
              if(err3) console.log("error deleting (findOneAndRemove())"); //si hay error en finOne...
              else console.log("You just deleted this musician: ",finded); //ver a quién eliminamos
            });  
          }
        }
      })
    } 
  })
});

// LISTEN PORT
app.listen(3000, () => {
  console.log("Server running...");
});