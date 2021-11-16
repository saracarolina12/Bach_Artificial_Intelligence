import React from "react";
function Titulo(props){
    const { texto } = props;
    console.log("Desde Titulo:", texto);
    return <h3>{texto}</h3>;
}

export default Titulo;