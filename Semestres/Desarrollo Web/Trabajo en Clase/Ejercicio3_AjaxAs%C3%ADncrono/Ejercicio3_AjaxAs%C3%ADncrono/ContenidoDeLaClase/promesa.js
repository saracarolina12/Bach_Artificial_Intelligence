let promesa = new Promise(function (resolve, reject) {
  const paquete = "📦";
  setTimeout(() => {
    let aleatorio = Math.random();
    if (aleatorio <= 0.49) {
      resolve(paquete);
    } else {
      reject("🚫 NO SE ENTREGÓ A TIEMPO!!!");
    }
  }, 2000);
});

promesa
  .then((pqt) => console.log(pqt))
  .catch((error) => console.log("error: ", error))
  .finally(() => console.log("promesa terminada..."));
