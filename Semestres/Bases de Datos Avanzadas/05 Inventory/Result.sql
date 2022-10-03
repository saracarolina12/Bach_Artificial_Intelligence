CREATE SCHEMA `inventory` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;

CREATE TABLE `inventory`.`products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `quantity_in_stock` INT NULL,
  `unity_price` FLOAT NULL,
  PRIMARY KEY (`id`));

ALTER TABLE `hr`.`employees` 
DROP FOREIGN KEY `reports_to`;
ALTER TABLE `hr`.`employees` 
ADD INDEX `reports_to_idx` (`reports_to` ASC) VISIBLE,
DROP INDEX `reports_to_idx` ;
;
ALTER TABLE `hr`.`employees` 
ADD CONSTRAINT `reports_to`
  FOREIGN KEY (`reports_to`)
  REFERENCES `hr`.`employees` (`id_employees`);

ALTER TABLE `hr`.`office` 
RENAME TO  `hr`.`offices` ;

ALTER TABLE `hr`.`offices` 
CHANGE COLUMN `address` `address` VARCHAR(100) NULL DEFAULT NULL ;
