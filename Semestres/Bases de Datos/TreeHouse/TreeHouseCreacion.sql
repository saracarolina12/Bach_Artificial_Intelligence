create database TreeHouse
use TreeHouse

create Table Propiedades(
	Nombre nvarchar(50) primary key,
	Descripcion nvarchar(500)
)

create Table Eventos(
	ID int identity(1,1) primary key,
	Nombre nvarchar(50),
	NumeroPersonas int,
	Fecha date,
	Precio float,
	Ubicacion nvarchar(100),
	Imagen nvarchar(150)
)

create Table Extra(
	ID int identity(1,1) primary key, 
	Nombre nvarchar(50) not null,
	Precio float
)

create Table Producto(
	ID int identity(1,1) primary key,
	Categoria nvarchar(50),
	Beneficio nvarchar(500),
)

create Table Sabor(
	Nombre nvarchar(50),
	IDCategoria int,
	foreign key(IDCategoria) references Producto(ID)
)

create Table EventosProducto(
	idEvento int,
	idProducto int,
	foreign key (idEvento) references Eventos(ID),
	foreign key (idProducto) references Producto(ID)
)

create Table ProductoExtra(
	idProducto int,
	idExtra int,
	foreign key (idProducto) references Producto(ID),
	foreign key (idExtra) references Extra(ID)
)
