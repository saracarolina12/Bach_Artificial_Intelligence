import React from "react"
import {useEffect} from "react";
import { getTodos } from "../functions/index.js";
import "bootstrap/dist/css/bootstrap.min.css"
import Container from "react-bootstrap/esm/Container";
import Card from 'react-bootstrap/Card'

function Show(){
    const [state, setState] = React.useState();
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
        <center>
            <Card
                text='black'
                style={{ width: '18rem' }}
                className="mb-2 cardcolor"
                style={{width: '60%'}}
            >
                <Card.Header><h3>Posts:</h3></Card.Header>
                <Card.Body>
                <Card.Text>
                   //posts
                </Card.Text>
                </Card.Body>
            </Card>
        </center>
        </Container>

    )
    
}
export default Show;