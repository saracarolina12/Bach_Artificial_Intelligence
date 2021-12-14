import React from "react"
import Container from 'react-bootstrap/Container'
import './nav.css';
import "bootstrap/dist/css/bootstrap.min.css"
import Logo from './Logo.png'

function Navb() {
    return (
        <Container  fluid className="navcolor">
            <br/>
            <img src={Logo} alt="logo" className="imgLogo"/>
            <br/>
            <p></p>
            <br/>
        </Container>
    )
}

export default Navb;