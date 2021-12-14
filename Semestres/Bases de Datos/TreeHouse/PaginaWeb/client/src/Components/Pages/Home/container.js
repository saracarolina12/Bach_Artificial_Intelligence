import React from "react"
import Container from 'react-bootstrap/Container'
import './container.css';
import "bootstrap/dist/css/bootstrap.min.css"
import Button from 'react-bootstrap/Button'
// import Logo from './Logo.png'
import M from 'materialize-css'
import Swal from 'sweetalert2';
// import { Link } from 'react-router-dom';
import Nav from 'react-bootstrap/Nav'
import { BrowserRouter as Router, Link } from "react-router-dom";




function Cont() {

    const iconChange = (x) =>{
        console.log("funciona");
        Swal.fire({
            position: 'center',
            title: 'Misión',
            text: 'Nuestra misión es...',
            title: 'Visión',
            showConfirmButton: true,
            confirmButtonColor: '#467a39'
        })
    }

    return (
        
        <Container fluid className="container">
            <br/>
            <h1 className="Titulo">¡Bienvenid@!</h1>
            <br/><br/>
            <Link to="/Menu">
                <Button className="menueventos" variant="success">Menú</Button>
            </Link>
            <br/><br/>
                <Button className="menueventos" variant="success">Eventos</Button>

            {/* <button className="invisibleButton" onClick={correoChange}> */}
                {/* className="waves-effect waves-light btn"> */}
                <i class="small material-icons right iconColor" onClick={iconChange} >info_outline</i>
            {/* </button> */}
            <br/>
            <br/>
        </Container>
    )
}

export default Cont;