--insert into Producto (Categoria) select Categoria from CategoriaSabor group by Categoria
--select * from Producto
insert into Sabor (Nombre, IDCategoria) select cs.Sabor, p.ID from CategoriaSabor cs, Producto p where cs.Categoria = p.Categoria
select * from Sabor
