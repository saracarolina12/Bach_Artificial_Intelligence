let compras = "🛒";

function hacerUnaCompra(callback) {
  setTimeout(function () {
    compras += "📦";
    callback();
  }, 2000);
}

hacerUnaCompra(function () {
  console.log(compras);
  hacerUnaCompra(function () {
    console.log(compras);
    hacerUnaCompra(function () {
      console.log(compras);
      hacerUnaCompra(function () {
        console.log(compras);
      });
    });
  });
});

setTimeout(function () {
  console.log("last", compras);
}, 3000);

console.log("compras", compras);
