import React from "react"
import {useEffect} from "react";
import {getTodos} from "../functions/index.js";
import "bootstrap/dist/css/bootstrap.min.css"
import Container from "react-bootstrap/esm/Container";
import Card from 'react-bootstrap/Card'
import './Todo.css';

function ShowInfo(){
    const [state, setState] = React.useState();
    function Changing(x){
        const {value} = x.target;
        console.log(value);
        setState(value);
    }
    useEffect(() => {
        console.log("Todos");
        const fetchData = async() => {
            const result = await getTodos();
            setState(result);                       //guardo el fetch
            console.log('Fetched data', result);
        };
        fetchData();
    }, []);
    return( 
        <Container>
        <div className="askfor">
            <div className="row">
                <form className="col s12">
                    <div className="row">
                        <div className="input-field col s6">
                            <i className="material-icons prefix">account_circle</i>
                            <input id="icon_prefix" type="text" className="validate" onChange={Changing}/>
                            <label className="titulo" htmlFor="icon_prefix">Usuario</label>
                        </div>
                        <div className="input-field col s6">
                            <i className="material-icons prefix">Description</i>
                            <input id="icon_telephone" type="tel" className="validate" onChange={Changing}/>
                            <label className="titulo" htmlFor="icon_telephone">¿Qué estás pensando?</label>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <center>
            <Card
                text='black'
                // style={{ width: '18rem' }}
                className="mb-2 cardcolor"
                style={{width: '60%'}}
            >
                <Card.Header><h3>Posts:</h3></Card.Header>
                <Card.Body>
                <Card.Text>
                {state && state.map((post) => {                     //siempre y cuando exista state, recorremos con map la promesa
                    return(
                        <p><i>{post.title}: {post.content}</i></p>
                    )
                })}
                </Card.Text>
                </Card.Body>
            </Card>
        </center>
        </Container>

    )
    
}
export default ShowInfo;