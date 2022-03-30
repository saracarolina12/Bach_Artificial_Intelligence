CREATE TABLE `orders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `order_date` date NOT NULL,
  `status` int NOT NULL,
  `comments` varchar(60) DEFAULT NULL,
  `shipped_date` date DEFAULT NULL,
  `shipped_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `customer_id_idx` (`customer_id`),
  KEY `status_idx` (`status`),
  KEY `shipper_id_idx` (`shipped_id`),
  CONSTRAINT `customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`),
  CONSTRAINT `shipper_id` FOREIGN KEY (`shipped_id`) REFERENCES `shippers` (`id`),
  CONSTRAINT `status` FOREIGN KEY (`status`) REFERENCES `order_statuses` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `order_items` (
  `id_order_items` int NOT NULL AUTO_INCREMENT,
  `product_id` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `unit_price` float DEFAULT NULL,
  PRIMARY KEY (`id_order_items`),
  KEY `product_id_idx` (`product_id`),
  CONSTRAINT `product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `store`.`order_item_notes` (
  `idorder_item_notes` VARCHAR(50) NOT NULL,
  `order_id` VARCHAR(45) NOT NULL,
  `product_id` VARCHAR(45) NOT NULL,
  `note` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idorder_item_notes`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

ALTER TABLE `store`.`order_item_notes` 
CHANGE COLUMN `idorder_item_notes` `note_id` VARCHAR(50) NOT NULL ,
CHANGE COLUMN `order_id` `order_Id` VARCHAR(45) NOT NULL ;

ALTER TABLE `store`.`order_items` 
CHANGE COLUMN `id_order_items` `id_order_items` INT NOT NULL ;

ALTER TABLE `store`.`orders` 
CHANGE COLUMN `comments` `comments` VARCHAR(100) NULL DEFAULT NULL ;
