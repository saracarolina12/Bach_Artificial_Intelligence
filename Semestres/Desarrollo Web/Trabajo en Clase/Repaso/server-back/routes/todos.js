import express from "express";
import { getTodos, createTodo } from "../controller/todos.js";

const router = express.Router();

router.get('/', getTodos);
router.post('/', createTodo);

export default router;
