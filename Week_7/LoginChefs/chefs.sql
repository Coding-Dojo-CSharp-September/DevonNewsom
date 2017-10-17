-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema EF
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema EF
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `chefsNdishes` DEFAULT CHARACTER SET utf8 ;
USE `chefsNdishes` ;

-- -----------------------------------------------------
-- Table `chefsNdishes`.`Chefs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chefsNdishes`.`Chefs` (
  `ChefId` INT(11) NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NULL DEFAULT NULL,
  `LastName` VARCHAR(45) NULL DEFAULT NULL,
  `Username` VARCHAR(45) NULL DEFAULT NULL,
  `Password` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`ChefId`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `chefsNdishes`.`Dishes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chefsNdishes`.`Dishes` (
  `DishId` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL DEFAULT NULL,
  `CreatedAt` DATETIME NULL DEFAULT NULL,
  `ChefId` INT(11) NOT NULL,
  PRIMARY KEY (`DishId`, `ChefId`),
  INDEX `fk_Dishes_Chefs_idx` (`ChefId` ASC),
  CONSTRAINT `fk_Dishes_Chefs`
    FOREIGN KEY (`ChefId`)
    REFERENCES `chefsNdishes`.`Chefs` (`ChefId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `chefsNdishes`.`Likes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chefsNdishes`.`Likes` (
  `LikeId` INT(11) NOT NULL AUTO_INCREMENT,
  `DishId` INT(11) NOT NULL,
  `ChefId` INT(11) NOT NULL,
  PRIMARY KEY (`LikeId`, `DishId`, `ChefId`),
  INDEX `fk_Likes_Dishes1_idx` (`DishId` ASC),
  INDEX `fk_Likes_Chefs1_idx` (`ChefId` ASC),
  CONSTRAINT `fk_Likes_Chefs1`
    FOREIGN KEY (`ChefId`)
    REFERENCES `chefsNdishes`.`Chefs` (`ChefId`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Likes_Dishes1`
    FOREIGN KEY (`DishId`)
    REFERENCES `chefsNdishes`.`Dishes` (`DishId`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
