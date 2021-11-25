import * as api from "../api/index.js";

export const getTodos = async() => {
    try {
        const {data} = await api.getTodos();
        // console.log("dataaa: ",data);
        return data;
    }
    catch(error) {
        console.log(error);
    }
}

export const createTodo = async({title, content}) => {
    try {
        const {data} = await api.createTodo({title, content});
        return data;
    }
    catch(error) {
        console.log(error);
    }
}

export const deleteTodos = async(id) => {
    try {
        await api.deleteTodos(id);
        return `${id} deleted successfully`;
    }catch (error) {
        console.log(error)
    }
}
