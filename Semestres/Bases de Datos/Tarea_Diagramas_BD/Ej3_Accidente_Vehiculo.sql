create table Persona(
	ine nvarchar(100) primary key not null,
	nombre nvarchar(100) not null,
	apellido nvarchar(100) not null,
	direccion nvarchar(100) not null,
	poblacion nvarchar(100),
	telefono int, 
)

create table Vehiculo(
	matricula nvarchar(100) primary key not null,
	marca nvarchar(100) not null,
	modelo nvarchar(100) not null,
	--referencias
	ine_veh nvarchar(100) not null,
	foreign key (ine_veh) references Persona(ine),
)

create table Deducible(
	num_ref int identity(1,1) primary key not null,
	fecha date not null,
	hora time not null,
	lugar nvarchar(100) not null,
	monto money not null,
	--referencias
	mat_ded nvarchar(100) not null,
	foreign key (mat_ded) references Vehiculo(matricula),
)

create table Accidente(
	num_ref int identity(1,1) primary key not null,
	fecha date not null,
	lugar nvarchar(100) not null,
	hora time not null,
	--referencias
	mat nvarchar(100) not null,
	foreign key (mat) references Vehiculo(matricula),
)