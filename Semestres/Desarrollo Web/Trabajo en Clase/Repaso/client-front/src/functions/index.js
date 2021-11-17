import * as api from "../api/index.js";

export const getTodos = async() => {
    try {
        const {data} = await api.getTodos();
        return data;
    }
    catch(error) {
        console.log(error);
    }
}

export const createTodos = async() => {
    try {
        const {data} = await api.createTodo();
        return data;
    }
    catch(error) {
        console.log(error);
    }
}