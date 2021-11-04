// Resuelve las preguntas a continuación:

// # 1) Crea una promesa que se resuelve en 4 segundos y devuelva una cadena de "éxito"
let promesa = new Promise(function(resolve){
  setTimeout(() => {
    resolve('Éxito');
  }, 4000);
});

promesa
.then((promesa))


// # 2) Ejecute la promesa anterior e imprimala en console.log como: "éxito"
let promesa = new Promise(function(resolve){
  setTimeout(() => {
    resolve('Éxito');
  }, 4000);
});

promesa
.then((promesa) => console.log(promesa))

// # 3) Detecte este error y registre la consola 'Ooops, algo salió mal'
Promise.reject("falló!"); //Ejemplo...

let error = new Promise(function(resolve, reject){
  setTimeout(() => {
    reject('Ooops, algo salió mal');
  }, 4000);
});

error
.catch((error) => console.log(error))

// # 4) Usa Promise.all para buscar a algunas personas de Star Wars al mismo tiempo.
// Console.log para la salida y asegúrese de que también tenga un bloque catch.
const urls = [
  "http://swapi.dev/api/people/1",
  "http://swapi.dev/api/people/2",
  "http://swapi.dev/api/people/3",
  "http://swapi.dev/api/people/4",
];

// # 5) Cambie una de las URL's anteriores para que sea incorrecta y no cumpla la promesa
// ¿Su bloque de captura lo maneja?
