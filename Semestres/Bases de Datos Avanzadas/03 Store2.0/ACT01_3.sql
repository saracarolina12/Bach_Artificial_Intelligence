
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

