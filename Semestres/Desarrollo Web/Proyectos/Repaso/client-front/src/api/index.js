import axios from "axios";
 
// const url = "http://localhost:8000/todos";
const url = "http://localhost:3000/"
 
export const getTodos = () => axios.get(url.require.body);
 
export const createTodo = (newTodo) => axios.post(url, newTodo);
 
