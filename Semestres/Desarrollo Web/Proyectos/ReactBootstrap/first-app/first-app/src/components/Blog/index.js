import React from "react";
import Contenido from "../../Contenido";
import Titulo from "../Titulo"
function Blog(props){
    console.log("Desde App", props);
    const {textoContenido = "default", textoTitulo} = props;
    return (
        <div>
            <Titulo texto = {textoTitulo}/>
            <Contenido texto = {textoContenido}/>
        </div>
    );
}

export default Blog;
