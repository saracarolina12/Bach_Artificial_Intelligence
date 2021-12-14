import { BrowserRouter as Router,Routes,Route } from "react-router-dom";
import Navb from "../NavBar/nav";
import Menu from "../Pages/Menu/menu";
import Eventos from "../Pages/Eventos/eventos";
import Cont from "../Pages/Home/container"

const Rutas = () => {
    return (
        <div>
            <Router>
                {/* <Navb />  */}
                <br/>
                <br/>   
                <Routes>
                    <Route path="/" element = {<Cont/>} />
                    <Route path="/Menu" element = {<Menu/>} />
                    <Route path="/Eventos" element = {<Eventos/>} />
                </Routes>    
            </Router>
             
        </div>      
    )
}

export default Rutas;