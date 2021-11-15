import React, {useState, useEffect} from "react";
import Image from 'react-bootstrap/Image'
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Card from 'react-bootstrap/Card'
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
           

            <div className="bg">
                <center>
                    <br/>
                    <h1 className="titulo"><i><b>- U s u a r i o -</b></i></h1>
                    <hr className="linea"/>
                    <Card bg="dark" text="white" style={{ width: '29rem' }} className="mb-2">
                        <Card.Header><p><i>@{info?.login}</i></p></Card.Header>
                        <Card.Body>
                        <Card.Title><p className="nombre"><b>{info?.name}</b></p></Card.Title>
                        <Card.Text>
                             <img src = {info?.avatar_url}/>
                        </Card.Text>
                        </Card.Body>
                    </Card>
                </center>
                
            </div>
            
            

        </>
    );
}
export default ComponenteChido;