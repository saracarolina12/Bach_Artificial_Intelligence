import {useEffect} from "react";
import { getTodos } from "../functions/index.js";

function Todo(){
    useEffect(() => {
        console.log("Todos");
        const fetchData = async() => {
            const result = await getTodos();
            console.log('Fetched data', result);
        };
        fetchData();
    }, []);
    return(
        <div>
            <div className="row">
                <form className="col s12">
                    <div className="row">
                        <div className="input-field col s6">
                            <i className="material-icons prefix">account_circle</i>
                            <input id="icon_prefix" type="text" className="validate" />
                            <label htmlFor="icon_prefix">Titulo</label>
                        </div>
                        <div className="input-field col s6">
                            <i className="material-icons prefix">Description</i>
                            <input id="icon_telephone" type="tel" className="validate" />
                            <label htmlFor="icon_telephone">Description</label>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    )
}
export default Todo;