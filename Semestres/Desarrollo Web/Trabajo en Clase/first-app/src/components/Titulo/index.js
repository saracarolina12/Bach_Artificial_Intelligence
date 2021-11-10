import React from "react";

function Titulo(props) {
  console.log("props", props);
  const { texto } = props;
  return <h3>{texto}</h3>;
}

export default Titulo;
