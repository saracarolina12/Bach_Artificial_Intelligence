--use Ejercicio1

create table Paciente(
	codigo int identity(1,1) primary key not null, --identity(en qué número inicio, saltos de incremento)
	direccion nvarchar(100) not null,
	apellido nvarchar(100) not null,
	nombre nvarchar(100) not null,
	ciudad nvarchar(100),
	estado nvarchar(100),
	cp nvarchar(100),
	telefono nvarchar(100),
	fecha_nacimiento  nvarchar(100),
)

create table Medico(
	codigo int identity(1,1) primary key not null,
	nombre nvarchar(100) not null,
	apellido nvarchar(100) not null,
	telefono nvarchar(100),
)
create table Ingreso(
	codigo int identity(1,1) primary key not null,
	num_hab int not null,
	num_cama int not null,
	f_ingreso date not null,
	f_alta date not null,
	-- crear campos de referencia a paciente y medico
	CodigoPaciente int not null,
	CodigoMedico int not null,
	--Crear llaves foraneas
	foreign key (CodigoPaciente) references Paciente(Codigo),
	foreign key (CodigoMedico) references Medico(Codigo),
)

create table Especialidades(
	codigo int identity(1,1) primary key not null,
	tipo nvarchar(100) not null,
)

--relación médico-especialidad m:m
create Table MedicoEspecialidad
(
	-- crear campos de referencia a especialidad y medico
	CodigoMedico int not null,
	CodigoEspecialidad int not null,
	--Crear llaves foraneas
	foreign key (CodigoMedico) references Medico(Codigo),
	foreign key (CodigoEspecialidad) references Especialidades(Codigo),
)

