let compras = "🛒";

function promesaCompra() {
  return new Promise(function (resolve) {
    setTimeout(function () {
      compras += "📦";
      console.log(compras);
      resolve();
    }, 2000);
  });
}

promesaCompra()
  .then(() => promesaCompra())
  .then(() => promesaCompra())
  .then(() => promesaCompra());
