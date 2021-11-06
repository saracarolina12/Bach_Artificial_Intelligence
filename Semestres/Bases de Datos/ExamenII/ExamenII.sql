--EXAMEN PARCIAL 2--
--create database ExamenII
--use ExamenII
--------------------------

----CREAR TABLAS
--create table TablaCliente(
--	ID_cliente int identity(1,1) primary key,
--	curp nvarchar(50), 
--	Nombre nvarchar(50) not null,
--	Apellido nvarchar(50) not null,
--	Direccion nvarchar(50) ,						--Dirección
--	TelefonoPropio nvarchar(50),
--	FechaNac datetime,								
--	DireccionTrabajo nvarchar(50), 
--	TelefonoTrabajo nvarchar(50),
--)

--create table TablaCredito(
--	ID_cred int identity(1,1) primary key,
--	Tipo_cred nvarchar(50),
--	NumSemanas int,								--14,28,36
--	MontoPrestado money,
--	Abono money,									--monto de cada pago
--	FechaEntrega datetime,
--	Estatus nvarchar(50),							--Activo, cancelado, finalizado
--	--M:1 un cliente puede tener varios créditos
--	IDCliente_1m int,
--	foreign key (IDCliente_1m) references TablaCliente(ID_Cliente)
--)

--create table TablaAval(
--	ID_Aval int identity(1,1) primary key,
--	curp nvarchar(50), 
--	Nombre nvarchar(50) not null,
--	Apellido nvarchar(50) not null,
--	Direccion nvarchar(50),						--Dirección
--	TelefonoPropio nvarchar(50),
--	FechaNac datetime,								
--	DireccionTrabajo nvarchar(50), 
--	TelefonoTrabajo nvarchar(50),
--)

--create table CreditoAval(
--	--campos de referencia	a crédito y aval
--	IDCredito_mm int,													
--	ID_mm int,
--	foreign key (IDCredito_mm) references TablaCredito(ID_cred),
--	foreign key (ID_mm) references TablaAval(ID_Aval),
--)

------------------------------------
--TablaCredito(ID_cred, Tipo_cred, NumSemanas, MontoPrestado, Abono, FechaEntrega, Estatus, IDCliente_1m)
--TablaCliente(ID_cliente, curp, nombre, apellido, direccion, TelefonoPropio, FechaNac, DireccionTrabajo, TelefonoTrabajo)
--TablaAval(ID_Aval, curp, Nombre, Apellido, Direccion, TelefonoPropio, FechaNac, DireccionTrabajo, TelefonoTrabajo)
--CreditoAval(IDCredito_mm, ID_mm)
------------------------------------
--ID's clientes
	--José Velarde: 2

--ID'S avales
	--Sergio Velarde: 1
	--Mariblel Velarde: 2

------------------------------------
	--select * from TablaCredito
	--select * from TablaCliente
	--select * from TablaAval
	--select * from CreditoAval
------------------------------------
--Ejercicios

--a.	Crédito Personal 14 semanas 5000 A nombre de José Velarde (Abono 357.14).
	--insert into TablaCliente(Nombre, Apellido)
	--values ('José','Velarde')

	--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
	--values('Efectivo', 14, 5000, 357.14, 'activo', 2)


--b.	Crédito Personal 28 semanas 10,000 A nombre de José Velarde, aval Sergio Velarde (Abono 357.14).
		--credito: tipo, semanas, monto, abono
		--aval: nombre, apellido
	--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
	--values('Efectivo',28,10000,357.14, 'activo', 2)
	--insert into TablaAval(Nombre, Apellido)
	--values('Sergio', 'Velarde')
	--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval
	--values(4,1)
		
--c.	Crédito Personal 36 semanas 15,000 A nombre de José Velarde, aval Sergio Velarde, Maribel Velarde (Abono 416.66).
		--credito: tipo, semanas, monto, abono, estatus, IDCliente_1m
		--aval1:nombre, apellido
		--aval2: ""       ""
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Efectivo', 36, 15000, 416.66, 'activo',2)
		--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval SERGIO VELARDE
		--values (5, 1)
		--insert into TablaAval(Nombre,Apellido)
		--values('Maribel', 'Velarde')
		--insert into CreditoAval(IDCredito_mm, ID_mm)
		--values(5,2)

--d.	Cambiar el estatus a cancelado del crédito personal de 14 semanas del cliente José Velarde.
		--update TablaCredito set Estatus='cancelado' where ID_cred=3  --afecta sólo al crédito de $5000 de 14 semanas con ID 3

--e.	Insertar 3 Créditos Personales a 14 semanas por 5000 a nombre de nuevos clientes (Abono 357.14).
		--insert TablaCliente(Nombre, Apellido)
		--values('Sara', 'Carolina')
		--insert TablaCliente(Nombre, Apellido)
		--values('Luis', 'Robles')
		--insert TablaCliente(Nombre, Apellido)
		--values('Alondra', 'Vanessa')

		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)--Sara
		--values('Efectivo', 14, 5000, 357.14, 'activo', 3)
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)--Luis
		--values('Efectivo', 14, 5000, 357.14, 'activo', 4)
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)--Vane
		--values('Efectivo', 14, 5000, 357.14, 'activo', 5)

--f.	Insertar 2 Créditos Personales por 10000 a 28 semanas a nombre de nuevos clientes y nuevos avales (Abono 357.14).
		--insert into TablaAval(Nombre, Apellido)
		--values('Sara', 'Delgado')
		--insert into TablaAval(Nombre, Apellido)
		--values('Gustavo', 'Gomez')

		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Efectivo', 28, 10000, 357.14, 'activo', 3)	--Sara
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Efectivo', 28, 10000, 357.14, 'activo', 4)	--Luis

--g.	(5%) Insertar 3 Créditos de Línea Blanca a 14 semanas por 5000 a nombre de nuevos clientes (Abono 357.14).
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Línea Blanca', 14, 5000, 357.14, 'activo', 3)	--Sara
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Línea Blanca', 14, 5000, 357.14, 'activo', 4)	--Luis
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Línea Blanca', 14, 5000, 357.14, 'activo', 5)	--Vane


--h.	(5%) Insertar 2 Créditos Línea Blanca por 30000 a 14 semanas a nombre de nuevos clientes y nuevos avales (cabe mencionar que se requieren 2 avales en estos préstamos) (Abono 2142.85).
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Línea Blanca', 14, 30000, 2142.85, 'activo', 3)	--Sara
		--insert into TablaCredito(Tipo_cred, NumSemanas, MontoPrestado, Abono, Estatus, IDCliente_1m)
		--values('Línea Blanca', 14, 30000, 2142.85, 'activo', 4)	--Luis

		----Aval 1 de Sara Carolina, Sara D
		--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval
		--values(14,3)
		----Aval 2 de Sara Carolina, Gustavo G
		--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval
		--values(14,4)

		----Aval 1 de Luis, Sara D
		--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval
		--values(15,3)
		------Aval 2 de Luis, Gustavo G
		--insert into CreditoAval(IDCredito_mm, ID_mm) --IDCredito,IDAval
		--values(15,4)

----c.	(10%) Generar un listado que incluya el folio del crédito, monto del crédito, nombre completo del cliente y nombre completo del aval de los créditos activos.
		--ID_cred, MontoPrestado, Nombre+Apellido Cliente, Nombre+Apellido Aval, SOLO ACTIVOS
		---Credito: ID_cred, monto
		---Cliente: nombre+apell
		---Aval: nombre+apell

		--select * from TablaCredito where Estatus like '%activo%'
		
----d.	(10%) Generar un listado que incluya el id del cliente, el nombre del cliente y total de créditos que ha tenido dentro de la empresa.
		--id_cliente, nombre cliente, total creditos
		---Cliente: id_cliente, nombre
		---Creditos: suma de creditos basados en el id
		--select tc.ID_cliente, tc.Nombre, count(1) Creditos from TablaCredito c
		--join TablaCliente tc on tc.ID_cliente = c.IDCliente_1m
		--group by tc.ID_cliente, tc.Nombre

----e.	(10%) Generar un listado que contenga los avales y el total de créditos avalados, el reporte mostrara el id del aval, el nombre del aval y total de créditos avalados.
		--avales, total de créditos avalados: id_aval, nombre_aval, suma créditos avalados
		--select ta.ID_Aval, Nombre, count(1) Total_Avalados from TablaAval ta
		--join CreditoAval ca on ca.ID_mm = ta.ID_Aval
		--group by ID_Aval, Nombre


----f.	(10%) Generar el total prestado para los créditos de tipo línea blanca y créditos personales, agrupados por tipo de crédito y numero de semanas y que actualmente se encuentran activos.
		--suma total créditos línea blanca, suma total créditos efectivo, GROUP BY tipoCredito, GROUP BY numero de semanas, where Estatus like '%activo%'
		--select cr.Tipo_cred, cr.NumSemanas, cr.Estatus, sum(cr.MontoPrestado) TotalPrestado from TablaCredito cr where cr.Estatus like '%activo%'
		--group by cr.Tipo_cred, cr.NumSemanas, cr.Estatus


	--select * from TablaCredito
	--select * from TablaCliente
	--select * from TablaAval
	--select * from CreditoAval