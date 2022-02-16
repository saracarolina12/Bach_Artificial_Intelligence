CREATE SCHEMA `hr` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;

CREATE TABLE `hr`.`office` (
  `id_office` INT NOT NULL,
  `address` VARCHAR(45) NULL,
  `city` VARCHAR(45) NULL,
  `state` VARCHAR(45) NULL,
  PRIMARY KEY (`id_office`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE `hr`.`employees` (
  `id_employees` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NULL,
  `last_name` VARCHAR(45) NULL,
  `job_title` VARCHAR(45) NULL,
  `salary` FLOAT NULL,
  `reports_to` INT NULL,
  `office_id` INT NULL,
  PRIMARY KEY (`id_employees`),
  INDEX `reports_to_idx` (`reports_to` ASC) VISIBLE,
  INDEX `office_id_idx` (`office_id` ASC) VISIBLE,
  CONSTRAINT `reports_to`
    FOREIGN KEY (`reports_to`)
    REFERENCES `hr`.`office` (`id_office`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `office_id`
    FOREIGN KEY (`office_id`)
    REFERENCES `hr`.`office` (`id_office`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

