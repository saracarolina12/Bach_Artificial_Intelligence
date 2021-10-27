const { render } = require("ejs");
const express = require("express");
const path = require('path');
const app = express();

app.use(express.json()); // for parsing application/json
app.use(express.urlencoded({ extended: true })); // for parsing application/x-www-form-urlencoded

app.set('views', path.join(__dirname, 'views'))
app.set('view engine', 'ejs');

const posts = [
    {username: "sarita", post: "Ya casi es viernes"},
    {username: "vanesita", post: "Hola crayola"}
];

app.get('/posts/create',(req, res) =>{
    res.render('posts/index',{posts: posts})
})
app.post('/posts/create',(req, res) =>{
    res.render('posts/',{posts: posts})
})
app.listen(3000,()=>{
    console.log('Server running...');
});