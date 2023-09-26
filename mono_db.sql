-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 29, 2023 at 02:27 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: "mono_db"
--

-- --------------------------------------------------------

--
-- Table structure for table "vehiclemake"
--

DROP TABLE IF EXISTS `vehiclemake`;
CREATE TABLE `vehiclemake` (
  "Id" int NOT NULL,
  "Name" varchar(255) DEFAULT NULL,
  "Abrv" varchar(50) DEFAULT NULL,
  PRIMARY KEY ("Id")
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table "vehiclemake"
--

SET IDENTITY_INSERT "vehiclemake" ON ;
INSERT INTO "vehiclemake" ("Id", "Name", "Abrv") VALUES
(1, 'BMW', 'BMW'),
(2, 'FORD', 'FORD'),
(3, 'VOLKSWAGEN', 'VW');

SET IDENTITY_INSERT "vehiclemake" OFF;

-- --------------------------------------------------------

--
-- Table structure for table "vehiclemodel"
--

DROP TABLE IF EXISTS `vehiclemodel`;
CREATE TABLE `vehiclemodel` (
  "Id" int NOT NULL,
  "MakeId" int DEFAULT NULL,
  "Name" varchar(255) DEFAULT NULL,
  "Abrv" varchar(50) DEFAULT NULL,
  PRIMARY KEY ("Id"),
  KEY "MakeId" ("MakeId")
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table "vehiclemodel"
--

SET IDENTITY_INSERT "vehiclemodel" ON ;
INSERT INTO "vehiclemodel" ("Id", "MakeId", "Name", "Abrv") VALUES
(1, 1, '128', '128'),
(2, 1, '325', '325'),
(3, 1, 'X5', 'X5'),
(4, 2, 'FOCUS', 'FOCUS'),
(5, 2, 'MUSTANG', 'MUSTANG'),
(6, 3, 'GOLF', 'GOLF');

SET IDENTITY_INSERT "vehiclemodel" OFF;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
