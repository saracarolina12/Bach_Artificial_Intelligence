import React from "react";
import Blog from "./components/Blog"
function App() {
  const [state, setState] = React.useState();
  function handleChange(e){
    const {value} = e.target;
    console.log(value);

    setState(value);
  }
  return (
    <>
      <Blog />
      <p style = {{ paddingLeft: 10 }} >Ingresa algooo</p>
      <input style = {{paddingLeft: 10}} onChange = {handleChange} name = "inputReact"/>
      <Blog textoContenido = {state} textoTitulo = {state}/>
      <Blog textoTitulo = "Título 1" textoContenido = "Contenido 1"/>
      <Blog textoTitulo = "Título 2" textoContenido = "Contenido 2"/>
      <Blog textoTitulo = "Título 3" textoContenido = "Contenido 3"/>
      <Blog />
    </>
  );
}

export default App;
