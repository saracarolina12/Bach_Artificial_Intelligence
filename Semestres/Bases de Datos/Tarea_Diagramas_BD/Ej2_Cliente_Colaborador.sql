create table Proyecto(
	codigo int identity(1,1) primary key not null,
	f_inicio date not null,
	f_fin date not null,
	descrip text not null,
	costo money not null,
)

create table Colaboradores(
	num_cuenta int identity(1,1) primary key not null,
	banco nvarchar(100) not null,
	ine text not null,
	nombre nvarchar(100) not null,
	domicilio nvarchar(100) not null,
	telefono int,
	--referencias
	proy_name int not null,
	foreign key (proy_name) references Proyecto(codigo),
)

create table Cliente(
	codigo int identity(1,1) primary key not null,
	telefono int,
	domicilio nvarchar(100) not null,
	r_social nvarchar(100) not null,
	rfc nvarchar(100) not null,
	--referencias
	proy_name int not null,
	foreign key (proy_name) references Proyecto(codigo),
)

create table Pagos(
	num_pago int identity(1,1) primary key not null,
	concepto text not null,
	cantidad money not null,
	f_pago date not null,
	--referencias
	who_paid int not null,
	foreign key (who_paid) references Cliente(codigo),
	colab_recibe int not null,
	foreign key (colab_recibe) references Colaboradores(num_cuenta),
)

create table Tipos(
	codigo int identity(1,1) primary key not null,
	descripcion text not null,
	tipo nvarchar(100) not null,
	--referencias
	pago int not null,
	foreign key (pago) references Pagos(num_pago),
)