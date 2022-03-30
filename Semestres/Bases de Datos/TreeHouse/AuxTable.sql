-- Auxiliar Table

create table CategoriaSabor 
(
	ID int primary key identity(1, 1), 
	Categoria nvarchar(50), 
	Sabor nvarchar(50)
)
insert into CategoriaSabor (Categoria, Sabor) values ('Smoothies','Fresa'), ('Smoothies','Mango'), ('Smoothies','Frutos rojos'), ('Smoothies','Plátano'), ('Smoothies','Sandía'), ('Smoothies','Melón'), ('Chamoyada','Fresa'), ('Chamoyada','Mango'), ('Jugo','Verde'), ('Jugo','Antigripal'), ('Jugo','Energético'), ('Jugo','Tropical'), ('Jugo','Orange'), ('Licuado','Fresa'), ('Licuado','Mango'), ('Licuado','Plátano'), ('Licuado','Fruta de la Temporada'), ('Fruta','Suprema con miel'), ('Fruta','con yogurt'), ('Fruta','con limón'), ('Fruta','entera'), ('Galleta','Chía'), ('Galleta','Avena'), ('Agua','Sandía con menta'), ('Agua','Piña naranja'), ('Agua','Pepino con chía'), ('Agua','Apio con limón'), ('Ensalada','Tree-Tuna Salad'), ('Ensalada','Tree-Ham Cheese Salad'), ('Ensalada','Tree-Green Salad'), ('Ensalada','Tree-Fruit Salad'), ('Ensalada','Peras con Salami Salad'), ('Baguette','Ham Cheese Gouda'), ('Baguette','Tuna Cheese Gouda'), ('Baguette','Chicken Cheese Gouda'), ('Baguette','Serrano'), ('Panini','Green'), ('Panini','Crimimi'), ('Panini','Salami'), ('Ciabatta','Jamón'), ('Ciabatta','Atún'), ('Sandwich','Jamón'), ('Sandwich','Atún'), ('Tortas','Jamón'), ('Tortas','Pollo'), ('Bagel','Queso Crema con frutos'), ('Bagel','Crema de cacao'), ('Bagel','Crema de cacahuate'), ('Bagel','Jamón de pavo'), ('Bagel','Jamón de pierna'), ('Bagel','Pechuga de pollo'), ('Bagel','Pepperoni'), ('Bagel','Veggie')
select * from CategoriaSabor