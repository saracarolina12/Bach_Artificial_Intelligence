import mongoose from "mongoose";
import Todo from "../models/todos.js";

export const getTodos = async(req, res) => {
    try{
        const Todos = await Todo.find();
        res.status(200).json(Todos);
    }catch(error){
        res.status(400).json({message: error.message});
    }
};

export const createTodo = async(req, res) => {
    console.log(req.body);
    const todo = new Todo(req.body);
    try {
        await todo.save();
        res.status(200).json(todo);
    }catch(error) {
        res.status(400).json({message: error.message});
    }
};