import React from "react"
import Container from 'react-bootstrap/Container'
import './menu.css';
import Button from 'react-bootstrap/Button'
// import Logo from './Logo.png'
import M from 'materialize-css'
import Swal from 'sweetalert2';
import "bootstrap/dist/css/bootstrap.min.css"
import { Dropdown, DropdownItem, DropdownMenu, DropdowmToggle } from 'react-bootstrap'

function Menu() {

    const Change = (x) =>{
    
    }

    const options = [
        'one', 'two', 'three'
    ];
    const defaultOption = options[0];
    return (
        
        <Container fluid className="container">
            <br/><br/><br/>
            <h1 className="TituloMenu">MENÚ</h1>
            <br/><br/>

            {/* ¿QUÉ TENEMOS? */}
            <Dropdown className="Options" >
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    ¿Qué tenemos?
                </Dropdown.Toggle>

                <Dropdown.Menu >
                    <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                    <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                    <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>

            {/* ¿ALGO ESPECÍFICO? */}
            <br/><br/>
            <Dropdown className="Options" >
                <Dropdown.Toggle variant="success" id="dropdown-basic"> 
                    ¿Qué tenemos?
                </Dropdown.Toggle>

                <Dropdown.Menu className="Options" >
                    <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                    <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                    <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                
                </Dropdown.Menu>
            </Dropdown>
            <br/><br/>
            <br/><br/>
        </Container>
    )
}

export default Menu;