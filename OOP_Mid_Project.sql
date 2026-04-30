-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: localhost    Database: oop_project
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `CustomerID` varchar(50) NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `CustomerCNIC` varchar(20) NOT NULL,
  `NoOfOrder` int NOT NULL,
  `PhoneModel` varchar(100) NOT NULL,
  `EmployeeID` varchar(50) NOT NULL,
  PRIMARY KEY (`CustomerID`),
  KEY `customer_ibfk_1` (`EmployeeID`),
  CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`EmployeeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('CU001','Ali','4210112345671',1,'Samsung S23','EM001'),('CU002','Bilal','3520198765432',2,'iPhone 14','EM001'),('CU003','Mariam','4220187654321',0,'OnePlus 11','EM002');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `EmployeeID` varchar(50) NOT NULL,
  `EmployeeName` varchar(100) DEFAULT NULL,
  `EmpContact` varchar(50) DEFAULT NULL,
  `DateOfHired` date DEFAULT NULL,
  `Salary` int DEFAULT NULL,
  PRIMARY KEY (`EmployeeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES ('EM001','Ahmed','03001234567','2023-06-15',45000),('EM002','Zainab','03111234567','2022-03-01',50000);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `OrderID` varchar(50) NOT NULL,
  `OrderType` varchar(50) DEFAULT NULL,
  `OrderCondition` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Cost` int DEFAULT NULL,
  `CustomerID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `CustomerID` (`CustomerID`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('OR001','Repair','Cracked Screen','pending',5000,'CU001'),('OR002','Repair','Water Damage','completed',8000,'CU003'),('OR003','Checkup','Not Turning On','pending',2000,'CU003');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderservice`
--

DROP TABLE IF EXISTS `orderservice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderservice` (
  `OrderID` varchar(50) NOT NULL,
  `ServiceID` varchar(50) NOT NULL,
  PRIMARY KEY (`OrderID`,`ServiceID`),
  KEY `ServiceID` (`ServiceID`),
  CONSTRAINT `orderservice_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`),
  CONSTRAINT `orderservice_ibfk_2` FOREIGN KEY (`ServiceID`) REFERENCES `service` (`ServiceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderservice`
--

LOCK TABLES `orderservice` WRITE;
/*!40000 ALTER TABLE `orderservice` DISABLE KEYS */;
INSERT INTO `orderservice` VALUES ('OR001','SE001'),('OR002','SE002');
/*!40000 ALTER TABLE `orderservice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service` (
  `ServiceID` varchar(50) NOT NULL,
  `ServiceName` varchar(100) DEFAULT NULL,
  `Cost` int DEFAULT NULL,
  `TimeRequired` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ServiceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service` VALUES ('SE001','Screen Replacement',5000,'2 Hours'),('SE002','Water Damage Repair',7000,'5 Hours'),('SE003','Battery Replacement',2500,'1 Hour');
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicesparepart`
--

DROP TABLE IF EXISTS `servicesparepart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicesparepart` (
  `ServiceID` varchar(50) NOT NULL,
  `PartID` varchar(50) NOT NULL,
  PRIMARY KEY (`ServiceID`,`PartID`),
  KEY `PartID` (`PartID`),
  CONSTRAINT `servicesparepart_ibfk_1` FOREIGN KEY (`ServiceID`) REFERENCES `service` (`ServiceID`),
  CONSTRAINT `servicesparepart_ibfk_2` FOREIGN KEY (`PartID`) REFERENCES `sparepart` (`PartID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicesparepart`
--

LOCK TABLES `servicesparepart` WRITE;
/*!40000 ALTER TABLE `servicesparepart` DISABLE KEYS */;
INSERT INTO `servicesparepart` VALUES ('SE001','SP001'),('SE002','SP003');
/*!40000 ALTER TABLE `servicesparepart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sparepart`
--

DROP TABLE IF EXISTS `sparepart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sparepart` (
  `PartID` varchar(50) NOT NULL,
  `PartName` varchar(100) DEFAULT NULL,
  `Price` int DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  PRIMARY KEY (`PartID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sparepart`
--

LOCK TABLES `sparepart` WRITE;
/*!40000 ALTER TABLE `sparepart` DISABLE KEYS */;
INSERT INTO `sparepart` VALUES ('SP001','OLED Screen',4500,15),('SP002','Battery',1200,30),('SP003','Charging Port',800,20);
/*!40000 ALTER TABLE `sparepart` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-30  8:07:57
