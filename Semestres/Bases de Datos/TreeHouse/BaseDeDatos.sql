--create database TreeHouse
--use TreeHouse

create Table Eventos(
	ID int identity(1,1) primary key,
	Nombre nvarchar(50),
	NumeroPersonas int,
	Fecha date,
	Precio float,
	Ubicacion nvarchar(100),
	Imagen nvarchar(150)
)

create Table Propiedades(
	Nombre nvarchar(50) primary key,
	Descripcion nvarchar(500)
)

create Table Categoria(
	Nombre nvarchar(50) primary key,
	Sabor nvarchar(50)
)

