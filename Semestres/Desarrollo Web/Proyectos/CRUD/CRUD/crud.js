const express = require("express");
const path = require("path");
const app = express();

app.use(express.json()); // for parsing application/json
app.use(express.urlencoded({ extended: true })); // for parsing application/x-www-form-urlencoded
app.use('/static', express.static(__dirname + 'public')); //forimages

app.set("views", path.join(__dirname, "views")); // for ejs
app.set("view engine", "ejs"); // for ejs

const posts = [
  {username:'usuario1'},
  // {username:'usuario2'},
  // {username:'usuario3'},
  // {username:'usuario4'},
]; 

//GET
app.get("/posts", (req, res) => { 
  if(posts.length===0) res.render("posts/index_empty");
  else res.render("posts/index", { posts });
});
app.get("/posts/create", (req, res) => {
  res.render("posts/create", { posts });
});
app.get("/posts/delete/:id", (req, res) => {
  const { id } = req.params; //req.params obtiene el id dado en /:id
  if(id <= posts.length && id > 0){
    res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>Deleted successfully!!</i></h1></center></div></body>");
    posts.splice(req.params['id']-1,1); //si existe, borro el post
  }
  else res.send("<body style='background-color:#FFC1AE;'> <script>alert('ERROR!!');</script><center><h1 style='color:#610001; margin:25%; font-size:400%;'>This position does not exist!!</h1></center></body>");
  console.log("Usernames restantes: ", posts);
});

app.get("/posts/delete", (req, res) => { 
  res.render("posts/delete");
});


// POST
app.post("/posts", (req, res) => {
  const {username} = req.body;
  posts.push({username});
  res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>Posted successfully!!</i></h1></center></div></body>");
 //res.render('/views/posts/posted');
});

app.post("/posts/delete", (req, res) => {
  const {num_id} = req.body;
  console.log(num_id);
  if(num_id <= posts.length && num_id > 0){
    res.send("<body style='background-color:#99D28E;'><div style='margin:20%;'><center><h1 style='font-size:270%; color:#284822;'><i>Deleted successfully!!</i></h1></center></div></body>");
    posts.splice(num_id-1,1); //si existe, borro el post
  } 
  else res.send("<body style='background-color:#FFC1AE;'> <script>alert('ERROR!!');</script><center><h1 style='color:#610001; margin:25%; font-size:400%;'>This position does not exist!!</h1></center></body>");
  console.log("Usernames restantes: ", posts);
});


// LISTEN PORT
app.listen(3000, () => {
  console.log("Server running...");
});






