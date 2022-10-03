
INSERT INTO `payment_methods` VALUES (1,'Tarjeta de Credito');
INSERT INTO `payment_methods` VALUES (2,'Efectivo');
INSERT INTO `payment_methods` VALUES (3,'PayPal');
INSERT INTO `payment_methods` VALUES (4,'Transferencia');


INSERT INTO `clients` VALUES (1,'Alfredo Adame','Calle C. Trejo 123','Ciudad de México','CM','315-252-7305');
INSERT INTO `clients` VALUES (2,'Carlos Muñoz','Av. D. Ruzzarin 321','Monterrey','NL','304-659-1170');
INSERT INTO `clients` VALUES (3,'Luis Slobotzky','Blvd. R. Perez 987','Ciudad de México','CM','415-144-6037');
INSERT INTO `clients` VALUES (4,'Roberto Martinez','J. Wong 789','Sta. Catarina','NL','254-750-0784');
INSERT INTO `clients` VALUES (5,'Carlos Name','Risopus 666','Queretaro','QR','971-888-9129');


INSERT INTO `invoices` VALUES (1,'91-953-3396',2,101.79,0.00,'2020-03-09','2020-03-29',NULL);
INSERT INTO `invoices` VALUES (2,'03-898-6735',5,175.32,8.18,'2020-06-11','2020-07-01','2020-02-12');
INSERT INTO `invoices` VALUES (3,'20-228-0335',5,147.99,0.00,'2020-07-31','2020-08-20',NULL);
INSERT INTO `invoices` VALUES (4,'56-934-0748',3,152.21,0.00,'2020-03-08','2020-03-28',NULL);
INSERT INTO `invoices` VALUES (5,'87-052-3121',5,169.36,0.00,'2020-07-18','2020-08-07',NULL);
INSERT INTO `invoices` VALUES (6,'75-587-6626',1,157.78,74.55,'2020-01-29','2020-02-18','2020-01-03');
INSERT INTO `invoices` VALUES (7,'68-093-9863',3,133.87,0.00,'2020-09-04','2020-09-24',NULL);
INSERT INTO `invoices` VALUES (8,'78-145-1093',1,189.12,0.00,'2020-05-20','2020-06-09',NULL);
INSERT INTO `invoices` VALUES (9,'77-593-0081',5,172.17,0.00,'2020-07-09','2020-07-29',NULL);
INSERT INTO `invoices` VALUES (10,'48-266-1517',1,159.50,0.00,'2020-06-30','2020-07-20',NULL);
INSERT INTO `invoices` VALUES (11,'20-848-0181',3,126.15,0.03,'2020-01-07','2020-01-27','2020-01-11');
INSERT INTO `invoices` VALUES (13,'41-666-1035',5,135.01,87.44,'2020-06-25','2020-07-15','2020-01-26');
INSERT INTO `invoices` VALUES (15,'55-105-9605',3,167.29,80.31,'2020-11-25','2020-12-15','2020-01-15');
INSERT INTO `invoices` VALUES (16,'10-451-8824',1,162.02,0.00,'2020-03-30','2020-04-19',NULL);
INSERT INTO `invoices` VALUES (17,'33-615-4694',3,126.38,68.10,'2020-07-30','2020-08-19','2020-01-15');
INSERT INTO `invoices` VALUES (18,'52-269-9803',5,180.17,42.77,'2020-05-23','2020-06-12','2020-01-08');
INSERT INTO `invoices` VALUES (19,'83-559-4105',1,134.47,0.00,'2020-11-23','2020-12-13',NULL);


INSERT INTO `payments` VALUES (1,5,2,'2020-02-12',8.18,1);
INSERT INTO `payments` VALUES (2,1,6,'2020-01-03',74.55,1);
INSERT INTO `payments` VALUES (3,3,11,'2020-01-11',0.03,1);
INSERT INTO `payments` VALUES (4,5,13,'2020-01-26',87.44,1);
INSERT INTO `payments` VALUES (5,3,15,'2020-01-15',80.31,1);
INSERT INTO `payments` VALUES (6,3,17,'2020-01-15',68.10,1);
INSERT INTO `payments` VALUES (7,5,18,'2020-01-08',32.77,1);
INSERT INTO `payments` VALUES (8,5,18,'2020-01-08',10.00,2);


INSERT INTO `products` VALUES (1,'Tablet',70,8000.00);
INSERT INTO `products` VALUES (2,'Audifonos',49,1500.00);
INSERT INTO `products` VALUES (3,'Smartphone',38,12000.00);
INSERT INTO `products` VALUES (4,'Mouse ',90,600.00);
INSERT INTO `products` VALUES (5,'Teclado',94,800.00);
INSERT INTO `products` VALUES (6,'MousePad',14,200.00);
INSERT INTO `products` VALUES (7,'Lampara',98,500.00);
INSERT INTO `products` VALUES (8,'PC Gamer',26,14000.00);
INSERT INTO `products` VALUES (9,'Laptop',67,20000.00);
INSERT INTO `products` VALUES (10,'Smartwatch',6,4000.00);


INSERT INTO `shippers` VALUES (1,'DHL');
INSERT INTO `shippers` VALUES (2,'UPS');
INSERT INTO `shippers` VALUES (3,'FEDEX');
INSERT INTO `shippers` VALUES (4,'ESTAFETA');
INSERT INTO `shippers` VALUES (5,'AMAZON');


INSERT INTO `customers` VALUES (1,'Barbara','Lopez','1986-03-28','962-625-7744','CENTRAL PONIENTE NO 18','Aguascalientes','AG',2273);
INSERT INTO `customers` VALUES (2,'Ines','Gomez','1986-04-13','804-427-9456','CAMPANA NO. 1708','Baja California Nte','BC',947);
INSERT INTO `customers` VALUES (3,'Alfredo','Borges','1985-02-07','719-724-7869','RIO SALINAS NO. 1118','Baja California Sur','BS',2967);
INSERT INTO `customers` VALUES (4,'Amara','Limon','1974-04-14','407-231-8017',' AV AGUASCALIENTES SUR 217','Ciudad de México','CX',457);
INSERT INTO `customers` VALUES (5,'Clemente','Hernández','1973-11-07',NULL,'CIRCUITO ARCO SUR SN','Chihuahua','CH',3675);
INSERT INTO `customers` VALUES (6,'María ','García','1991-09-04','312-480-8498','REPUBLICA DE NICARAGUA Nº605','Puebla','PU',3073);
INSERT INTO `customers` VALUES (7,'Valeria','Martínez','1964-08-30','615-641-4759','50 Lillian Crossing','Queretaro','QT',1672);
INSERT INTO `customers` VALUES (8,'Sofia','Pérez','1993-07-17','941-527-3977','AZALEA NO. 709','San Luis','SL',205);
INSERT INTO `customers` VALUES (9,'Renata','Rodríguez','1992-05-23','559-181-3744',' RICARTE 580 INT 2','Sinaloa','SI',1486);
INSERT INTO `customers` VALUES (10,'Victoria','Sánchez','1969-10-13','404-246-3370','CALLE 3 NO. 41 NO. B','Zacatecas','ZA',796);



INSERT INTO `order_statuses` VALUES (1,'Procesada');
INSERT INTO `order_statuses` VALUES (2,'Enviada');
INSERT INTO `order_statuses` VALUES (3,'Entregada');



INSERT INTO `orders` VALUES (1,6,'2020-01-30',1,'Lorem Ipsum is simply dummy text of the printing and typesetting',NULL,NULL);
INSERT INTO `orders` VALUES (2,7,'2018-08-02',2,NULL,'2018-08-03',4);
INSERT INTO `orders` VALUES (3,8,'2017-12-01',1,NULL,NULL,NULL);
INSERT INTO `orders` VALUES (4,2,'2017-01-22',1,NULL,NULL,NULL);
INSERT INTO `orders` VALUES (5,5,'2017-08-25',2,'','2017-08-26',3);
INSERT INTO `orders` VALUES (6,10,'2018-11-18',1,'Aliquam erat volutpat. In congue.',NULL,NULL);
INSERT INTO `orders` VALUES (7,2,'2018-09-22',2,NULL,'2018-09-23',4);
INSERT INTO `orders` VALUES (8,5,'2018-06-08',1,'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.',NULL,NULL);
INSERT INTO `orders` VALUES (9,10,'2017-07-05',2,'Nulla mollis molestie lorem. Quisque ut erat.','2017-07-06',1);
INSERT INTO `orders` VALUES (10,6,'2018-04-22',2,NULL,'2018-04-23',2);


INSERT INTO `order_items` VALUES (1,4,4,600.00);
INSERT INTO `order_items` VALUES (2,1,2,8000.00);
INSERT INTO `order_items` VALUES (2,4,4,600.00);
INSERT INTO `order_items` VALUES (2,6,2,200.00);
INSERT INTO `order_items` VALUES (3,3,10,12000.00);
INSERT INTO `order_items` VALUES (4,3,7,12000.00);
INSERT INTO `order_items` VALUES (4,10,7,4000.00);
INSERT INTO `order_items` VALUES (5,2,3,1500.00);
INSERT INTO `order_items` VALUES (6,1,4,8000.00);
INSERT INTO `order_items` VALUES (6,2,4,1500.00);
INSERT INTO `order_items` VALUES (6,3,4,12000.00);
INSERT INTO `order_items` VALUES (6,5,1,800.00);
INSERT INTO `order_items` VALUES (7,3,7,12000.00);
INSERT INTO `order_items` VALUES (8,5,2,800.00);
INSERT INTO `order_items` VALUES (8,8,2,14000.00);
INSERT INTO `order_items` VALUES (9,6,5,200.00);
INSERT INTO `order_items` VALUES (10,1,10,8000.00);
INSERT INTO `order_items` VALUES (10,9,9,20000.00);


INSERT INTO `order_item_notes` (`note_id`, `order_Id`, `product_id`, `note`) VALUES ('1', '1', '2', 'nota ejemplo 1');
INSERT INTO `order_item_notes` (`note_id`, `order_Id`, `product_id`, `note`) VALUES ('2', '1', '2', 'nota ejemplo 2');


INSERT INTO `offices` VALUES (1,'NORTE 59 NO. 834-3, INDUSTRIAL VALLEJO, 02300','Baja California','BC');
INSERT INTO `offices` VALUES (2,'ALLENDE 307 NO. S/N, CIUDAD CAMARGO CENTRO, 33700','Baja California Sur','BS');
INSERT INTO `offices` VALUES (3,'PEDRO S VARELA NO. 3007 NO. 9, LA PLAYA, 32317','Campeche','CM');
INSERT INTO `offices` VALUES (4,'AV CAMELINAS NO. 2160, BOSQUE CAMELINAS, 58290','Chiapas','CS');
INSERT INTO `offices` VALUES (5,'AV. GUERRERO NO. 3500, SAN LUIS RIO COLORADO CENTRO, 83400','Chihuahua','CH');
INSERT INTO `offices` VALUES (6,'CALLE 13 SUR 2510 NO. 1 A, LOS VOLCANES, 72410','Ciudad de México','CX');
INSERT INTO `offices` VALUES (7,'HIDALGO NO. 43, ARAGON','Coahuila','CO');
INSERT INTO `offices` VALUES (8,'RAMON CORONA 307 OTE, CUAUHTEMOC, 50130','Colima','CL');
INSERT INTO `offices` VALUES (9,'OBREGON 239, CABORCA CENTRO, 83600','Durango','DG');
INSERT INTO `offices` VALUES (10,'ORIENTE 319, CENTRO, 75700','Aguascalientes','AG');


INSERT INTO `employees` VALUES (37270,'Oier','Pastor','Secretario Ejecutivo',63996,NULL,10);
INSERT INTO `employees` VALUES (33391,'María','Arias','Ejecutiva de Cuenta',62871,37270,1);
INSERT INTO `employees` VALUES (37851,'Daniel','Montero','Estadístico III',98926,37270,1);
INSERT INTO `employees` VALUES (40448,'Joaquin','Sanchez','Cientifico',94860,37270,1);
INSERT INTO `employees` VALUES (56274,'Rubén','Ortega','VP Mercadeo',110150,37270,1);
INSERT INTO `employees` VALUES (63196,'Josefina','García','Profesor Ayudante',32179,37270,2);
INSERT INTO `employees` VALUES (67009,'Valeria','Guerrero','VP Gestión de Producto',114257,37270,2);
INSERT INTO `employees` VALUES (67370,'Constanza','Hernández','Trabajadora Social',96767,37270,2);
INSERT INTO `employees` VALUES (68249,'Antonella','Herrera','Asesor Financiero',52832,37270,2);
INSERT INTO `employees` VALUES (72540,'Javier','Velásquez','Oficinista I',117690,37270,3);
INSERT INTO `employees` VALUES (72913,'Emiliano','Fernández','Analista de Sistemas Informáticos IV',96401,37270,3);
INSERT INTO `employees` VALUES (75900,'Alfredo','García','Gerente de Sistemas de Información',54578,37270,3);
INSERT INTO `employees` VALUES (76196,'Isabella','Guerrero','Contador de Costos',119241,37270,3);
INSERT INTO `employees` VALUES (80529,'Alejandro','Pastrana','Ejecutivo Junior',77182,37270,4);
INSERT INTO `employees` VALUES (80679,'Andrés','Sánchez','Geólogo II',67987,37270,4);
INSERT INTO `employees` VALUES (84791,'Isabella','Hernández','Gerente General',93760,37270,4);
INSERT INTO `employees` VALUES (95213,'Andrea','Ramírez','Farmacéutico',86119,37270,4);
INSERT INTO `employees` VALUES (96513,'Juan','Castro','Químico de Alimentos',47354,37270,5);
INSERT INTO `employees` VALUES (98374,'Estrellita','Daleman','Contador IV',70187,37270,5);
INSERT INTO `employees` VALUES (115357,'Luis','Medina','Ingeniero Estructural',92710,37270,5); 

INSERT INTO `products` VALUES (1,'Tablet',70,8000.00);
INSERT INTO `products` VALUES (2,'Audifonos',49,1500.00);
INSERT INTO `products` VALUES (3,'Smartphone',38,12000.00);
INSERT INTO `products` VALUES (4,'Mouse ',90,600.00);
INSERT INTO `products` VALUES (5,'Teclado',94,800.00);
INSERT INTO `products` VALUES (6,'MousePad',14,200.00);
INSERT INTO `products` VALUES (7,'Lampara',98,500.00);
INSERT INTO `products` VALUES (8,'PC Gamer',26,14000.00);
INSERT INTO `products` VALUES (9,'Laptop',67,20000.00);
INSERT INTO `products` VALUES (10,'Smartwatch',6,4000.00);
