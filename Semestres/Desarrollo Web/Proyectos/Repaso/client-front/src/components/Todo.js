import React from "react"
import {useEffect} from "react";
import {getTodos, deleteTodos} from "../functions/index.js";
import "bootstrap/dist/css/bootstrap.min.css"
// import Container from "react-bootstrap/esm/Container";
// import Card from 'react-bootstrap/Card'
import './Todo.css';
import { createTodo } from "../api/index.js";

function ShowInfo(){
    const [state, setState] = React.useState();
    const [title, setTitle] = React.useState();
    const [content, setContent] = React.useState();

    const TitleChanging = (x) =>{
        // const {value} = x.target;
        // console.log(value);
        setTitle(x.target.value);
    };
    const DescChanging = (x) =>{
        setContent(x.target.value);
    }
    const onSubmitHandler = async () => {
        await createTodo({title:title, content:content})
    };
    const removeTodos = async (id) => {
        //  console.log(id);
        await deleteTodos(id);
        // console.log("hola:D");
    }

    useEffect(() => {
        // console.log("Todos");
        const fetchData = async() => {
            const result = await getTodos();
            setState(result);                       //guardo el fetch
            // console.log('Fetched data', result);
        };
        fetchData();
    }, [state]);
    return (
        <div className="row">
        <form className="col s12" onSubmit={onSubmitHandler}>
            <div className="row">
                <div className="input-field col s6">
                    <i className="material-icons prefix">account_circle</i>
                    <input id="icon_prefix" type="text" className="validate" onChange={TitleChanging}/>
                    <label htmlFor="icon_prefix">Titulo</label>
                </div>
            <div className="input-field col s6">
                <i className="material-icons prefix">Descripcion</i>
                <input id="icon_telephone" type="tel" className="validate" onChange={DescChanging}/>
                <label htmlFor="icon_telephone">Descripcion</label>
            </div>
            </div>
                <div className="row right-align">
                    <button class="waves-effect waves-light btn">
                        <i class="material-icons left">send</i>Publicar
                    </button>
                </div>
        </form>
        <div>
            <ul class="collection with-header">
            <li class="collection-header"><h4>Tareas por hacer</h4></li>
            {state && state.map((todo) => (
                    <li class="collection-item" key={todo._id}>
                        <div>{todo?.title}
                            <a href="#!" 
                               class="secondary-content"
                               onClick= {() => removeTodos(todo._id)}>
                               <i class="material-icons">delete</i>
                            </a>
                        </div>
                    </li>
                )
            )} 
            </ul>
        </div>
        </div>
        )
    
}
export default ShowInfo;