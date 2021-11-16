import React from "react";
function Contenido(props){
    console.log("Desde contenido:", props);
    return <p>{props.texto}</p>
}

export default Contenido;