import express from "express";
import dotenv from "dotenv";
import mongoose from "mongoose";
import cors from "cors";
import todoRoutes from "./routes/todos.js"

const app = express();
dotenv.config();

app.use(express.json({limit: "30mb", extended: true}));
app.use(express.urlencoded({limit: "30mb", extended: true}));

const MONGO_URL = `mongodb+srv://${process.env.mongousername}:${process.env.mongopassword}@miprimercluster.ozjrf.mongodb.net/myFirstDatabase?retryWrites=true&w=majority`
//console.log(MONGO_URL);
const PORT = process.env.PORT || 5000;      //si no existe el de la derecha, toma el de la izquierda

console.log(PORT);
app.use(cors());

app.get("/", (req, res) => {
    res.send("<p>Servidor corriendo...</p>")
});

app.use("/todos", todoRoutes);

mongoose
  .connect(MONGO_URL, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  })
  .then(
    () => app.listen(PORT),
    () => console.log(`Server running on ${PORT}`)
  )
  .catch((error) => console.log(error));

//app.use(cors());
