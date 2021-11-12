import React, {useState, useEffect} from "react";
function ComponenteChido(){
    const [info, setInfo] = useState();
    const  handleAsync = async() => {
        const user = await fetch("https://api.github.com/users/saracarolina12");
        const userJson = await user.json();
        console.log("Mi user es: ", userJson);
        setInfo(userJson)
    }
    useEffect(() => {
        console.log("Bienvenido");
        handleAsync();
    }, []);
    return(
        <>
            <center>
                <img src = {info?.avatar_url}/>
                <p>{info?.name}</p>
                <p>@{info?.login}</p>
            </center>
        </>
    );
}
export default ComponenteChido;