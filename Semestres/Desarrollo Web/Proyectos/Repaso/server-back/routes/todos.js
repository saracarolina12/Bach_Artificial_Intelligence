import express from "express";
import { getTodos, createTodo, deleteTodos } from "../controller/todos.js";

const router = express.Router();

router.get('/', getTodos);
router.post('/', createTodo);
router.delete('/:id', deleteTodos)
export default router;
