-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: infosys
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Temporary view structure for view `active_borrowers`
--

DROP TABLE IF EXISTS `active_borrowers`;
/*!50001 DROP VIEW IF EXISTS `active_borrowers`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `active_borrowers` AS SELECT 
 1 AS `ID`,
 1 AS `Name`,
 1 AS `Email`,
 1 AS `Status`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `admin_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `email_address` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `secOne` varchar(255) DEFAULT '',
  `secTwo` varchar(255) DEFAULT '',
  `secThree` varchar(255) DEFAULT '',
  PRIMARY KEY (`admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES (1,'dee','daniela.it@gmail.com','asdf','Jocelyn','Ela','Manila'),(2,'yes-102','jessai@live.nl','1234','Yukiko','Yes','Zwolle'),(3,'test12345','test@gmail.com','daniela','Bembo','Hello','Albay');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `author_id` int NOT NULL AUTO_INCREMENT,
  `author_name` varchar(100) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `nationality` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`author_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'Harper Lee','1926-04-28','American'),(2,'George Orwell','1903-06-25','British'),(3,'F. Scott Fitzgerald','1896-09-24','American'),(4,'Jane Austen','1775-12-16','British'),(5,'Virginia Woolf','1882-01-25','British'),(6,'J.D. Salinger','1919-01-01','American'),(7,'Herman Melville','1819-08-01','American'),(8,'Charlotte Bronte','1816-04-21','British'),(9,'J.R.R. Tolkien','1892-01-03','British'),(10,'Emily Bronte','1818-07-30','British');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `available_books`
--

DROP TABLE IF EXISTS `available_books`;
/*!50001 DROP VIEW IF EXISTS `available_books`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `available_books` AS SELECT 
 1 AS `Book ID`,
 1 AS `Title`,
 1 AS `Author`,
 1 AS `Publication Year`,
 1 AS `ISBN`,
 1 AS `Genre`,
 1 AS `Availability`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `book_inventory`
--

DROP TABLE IF EXISTS `book_inventory`;
/*!50001 DROP VIEW IF EXISTS `book_inventory`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `book_inventory` AS SELECT 
 1 AS `Book ID`,
 1 AS `Title`,
 1 AS `Author`,
 1 AS `ISBN`,
 1 AS `Genre`,
 1 AS `Availability`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `bookavailability`
--

DROP TABLE IF EXISTS `bookavailability`;
/*!50001 DROP VIEW IF EXISTS `bookavailability`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `bookavailability` AS SELECT 
 1 AS `Book ID`,
 1 AS `Book Title`,
 1 AS `Availability`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `book_id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `author_id` int DEFAULT NULL,
  `publication_year` int DEFAULT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `genre_id` int DEFAULT NULL,
  `availability` enum('Available','Unavailable') DEFAULT 'Available',
  PRIMARY KEY (`book_id`),
  KEY `author_id` (`author_id`),
  KEY `genre_id` (`genre_id`),
  CONSTRAINT `books_ibfk_1` FOREIGN KEY (`author_id`) REFERENCES `authors` (`author_id`),
  CONSTRAINT `books_ibfk_2` FOREIGN KEY (`genre_id`) REFERENCES `genres` (`genre_id`)
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'To Kill a Mockingbird',1,1960,'978-0-06-112008-4',1,'Unavailable'),(2,'1984',2,1949,'978-0-452-28423-4',2,'Unavailable'),(3,'The Great Gatsby',3,1925,'978-0-7432-7356-5',1,'Unavailable'),(4,'Pride and Prejudice',4,1813,'978-0-19-953556-9',3,'Available'),(5,'To the Lighthouse',5,1927,'978-0-15-690739-2',4,'Available'),(6,'The Catcher in the Rye',6,1951,'978-0-316-76948-0',1,'Available'),(7,'Moby-Dick',7,1851,'978-0-553-21235-4',5,'Available'),(8,'Jane Eyre',8,1847,'978-0-19-953559-0',6,'Available'),(9,'The Hobbit',9,1937,'978-0-618-00221-4',7,'Available'),(10,'The Lord of the Rings',9,1954,'978-0-00-711711-6',7,'Available'),(68,'The Hall',6,2001,'978-0-00-711411-6',2,'Available'),(69,'The Dawn',5,2003,'978-0-452-24563-4',7,'Available'),(70,'The Book',10,2021,'978-0-67-112008-4',2,'Available');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `borrowers`
--

DROP TABLE IF EXISTS `borrowers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `borrowers` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrowers`
--

LOCK TABLES `borrowers` WRITE;
/*!40000 ALTER TABLE `borrowers` DISABLE KEYS */;
INSERT INTO `borrowers` VALUES (1,'Alice Johnsonsmith','123 Main St, Anytown, USA','alice@gmail.com','Active'),(2,'Bob Smithen','456 Elm St, Anycity, USA','bob@yahoo.com','Active'),(3,'Charlie Brownies','789 Oak St, Anyville, USA','charlie@outlook.com','Inactive'),(4,'David Lee Smith','101 Pine St, Anytown, USA','david@gmail.com','Inactive'),(5,'Emma Garcia','202 Cedar St, Anycity, USA','emma@yahoo.com','Active'),(6,'Frank Wilson','303 Maple St, Anyville, USA','frank@outlook.com','Inactive'),(7,'Grace Clark','404 Spruce St, Anytown, USA','grace@gmail.com','Active'),(8,'Hannah White','505 Birch St, Anycity, USA','hannah@yahoo.com','Inactive'),(9,'Isabella Martinez','606 Pine St, Anyville, USA','isabella@outlook.com','Active'),(10,'James Thompson','707 Elm St, Anytown, USA','james@gmail.com','Active'),(11,'Emma Garcia','202 Cedar St, Anycity, USA','emma@yahoo.com','Inactive'),(12,'Daniela Cantillo','Zone 8 Lbanig, Malinao, Albay','danielamcantillo@gmail.com','Active'),(13,'Cheska mae','Malinao, Alabay','cheska@gmail.com','Active'),(14,'Ava Johnson','123 Maple St, Cityville','ava.johnson@email.com','Inactive'),(15,'Liam Patel','456 Oak St, Townsville','liam.patel@gmail.com','Inactive'),(16,'Mia Garcia','789 Elm St, Villagetown','mia.garcia@email.com','Active'),(17,'Noah Smith','101 Pine St, Hamletville','noah.smith@email.com','Active'),(18,'Emma Brown','234 Cedar St, Boroughburg','emma.brown@email.com','Active'),(19,'Ethan Nguyen','567 Birch St, Villageburg','ethan.nguyen@email.com','Inactive'),(20,'Oliver Lee','789 Pine St, Villagetown','oliver.lee@email.com','Active'),(21,'Dee Santos','Legazpi, Albay','dee@outlook.com','Active');
/*!40000 ALTER TABLE `borrowers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `borrowers_list`
--

DROP TABLE IF EXISTS `borrowers_list`;
/*!50001 DROP VIEW IF EXISTS `borrowers_list`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `borrowers_list` AS SELECT 
 1 AS `ID`,
 1 AS `Name`,
 1 AS `Borrowed Book`,
 1 AS `Transaction Date`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `genre_id` int NOT NULL AUTO_INCREMENT,
  `genre_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`genre_id`),
  UNIQUE KEY `genre_name` (`genre_name`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (5,'Adventure'),(2,'Dystopian'),(7,'Fantasy'),(1,'Fiction'),(6,'Gothic'),(10,'Historical Fiction'),(4,'Modernist'),(8,'Mystery'),(3,'Romance'),(9,'Science Fiction');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `late_fees`
--

DROP TABLE IF EXISTS `late_fees`;
/*!50001 DROP VIEW IF EXISTS `late_fees`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `late_fees` AS SELECT 
 1 AS `Transaction ID`,
 1 AS `Name`,
 1 AS `Due Date`,
 1 AS `Return Date`,
 1 AS `Late Fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `overduebooks`
--

DROP TABLE IF EXISTS `overduebooks`;
/*!50001 DROP VIEW IF EXISTS `overduebooks`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `overduebooks` AS SELECT 
 1 AS `transaction_id`,
 1 AS `book_id`,
 1 AS `book_title`,
 1 AS `borrower_id`,
 1 AS `borrower_name`,
 1 AS `borrow_date`,
 1 AS `due_date`,
 1 AS `return_date`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `pending_transactions`
--

DROP TABLE IF EXISTS `pending_transactions`;
/*!50001 DROP VIEW IF EXISTS `pending_transactions`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `pending_transactions` AS SELECT 
 1 AS `Transaction ID`,
 1 AS `Title`,
 1 AS `Name`,
 1 AS `Borrow Date`,
 1 AS `Due Date`,
 1 AS `Return Date`,
 1 AS `Late Fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `transactionhistory`
--

DROP TABLE IF EXISTS `transactionhistory`;
/*!50001 DROP VIEW IF EXISTS `transactionhistory`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `transactionhistory` AS SELECT 
 1 AS `Transaction ID`,
 1 AS `Book Title`,
 1 AS `Borrower`,
 1 AS `Borrow Date`,
 1 AS `Due Date`,
 1 AS `Return Date`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `transaction_id` int NOT NULL AUTO_INCREMENT,
  `book_id` int DEFAULT NULL,
  `borrower_id` int DEFAULT NULL,
  `borrow_date` date DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `return_date` date DEFAULT NULL,
  `late_fee` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`transaction_id`),
  KEY `book_id` (`book_id`),
  KEY `borrower_id` (`borrower_id`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `books` (`book_id`),
  CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`borrower_id`) REFERENCES `borrowers` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,1,'2024-01-20','2024-02-03','2024-02-09',120.00),(2,2,1,'2024-01-21','2024-02-04','2024-02-08',80.00),(3,3,1,'2024-01-22','2024-02-05','2024-02-02',0.00),(4,4,2,'2024-01-23','2024-02-06','2024-02-07',20.00),(6,6,3,'2024-01-25','2024-02-08','2024-02-08',0.00),(8,8,3,'2024-01-27','2024-02-10','2024-02-03',0.00),(9,9,4,'2024-01-28','2024-02-11','2024-02-18',140.00),(10,1,5,'2024-04-15','2024-04-29','2024-04-30',20.00),(11,5,12,'2024-04-15','2024-04-29','2024-04-18',0.00),(12,6,3,'2024-04-15','2024-04-29','2024-04-20',0.00),(26,1,21,'2024-04-15','2024-04-29',NULL,NULL),(27,2,2,'2024-04-15','2024-04-29',NULL,NULL),(28,3,12,'2024-04-15','2024-04-29',NULL,NULL),(29,4,5,'2024-04-15','2024-04-29','2024-04-30',20.00);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `set_BORROWDATE_DUEDATE` BEFORE INSERT ON `transactions` FOR EACH ROW BEGIN
SET NEW.borrow_date = CURDATE();
SET NEW.due_date = DATE_ADD(NEW.borrow_date, INTERVAL 14 DAY);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_BOOK_AVAILABILITY_AFTER_INSERT` AFTER INSERT ON `transactions` FOR EACH ROW BEGIN
UPDATE Books SET availability = 'Unavailable' WHERE book_id = NEW.book_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `set_LATE_FEE` BEFORE UPDATE ON `transactions` FOR EACH ROW BEGIN
IF NEW.return_date <= NEW.due_date THEN
      SET NEW.late_fee = 0.00;
   ELSE
      SET NEW.late_fee = DATEDIFF(NEW.return_date, NEW.due_date) * 20;
   END IF;

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `transactions_AFTER_UPDATE` AFTER UPDATE ON `transactions` FOR EACH ROW BEGIN
UPDATE Books SET availability = 'Available' WHERE book_id = NEW.book_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_BOOK_AVAILABILITY_AFTER_DELETE` AFTER DELETE ON `transactions` FOR EACH ROW BEGIN
UPDATE Books SET availability = 'Available' WHERE book_id = OLD.book_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `transactions_list`
--

DROP TABLE IF EXISTS `transactions_list`;
/*!50001 DROP VIEW IF EXISTS `transactions_list`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `transactions_list` AS SELECT 
 1 AS `Transaction ID`,
 1 AS `Title`,
 1 AS `Name`,
 1 AS `Transaction Date`,
 1 AS `Due Date`,
 1 AS `Return Date`,
 1 AS `Late Fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'infosys'
--

--
-- Dumping routines for database 'infosys'
--
/*!50003 DROP FUNCTION IF EXISTS `CalculateLateFee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateLateFee`(transactionId INT) RETURNS decimal(10,2)
    DETERMINISTIC
BEGIN
    DECLARE lateFee DECIMAL(10, 2);
	DECLARE daysOverdue INT;
    -- Get borrow date, due date, and return date for the given transaction
    DECLARE borrowDate DATE;
    DECLARE dueDate DATE;
    DECLARE returnDate DATE;
    
    SELECT borrow_date, due_date, IFNULL(return_date, CURDATE()) INTO borrowDate, dueDate, returnDate
    FROM Transactions
    WHERE transaction_id = transactionId;
    
    -- Calculate late fee only if the book is overdue
    IF returnDate > dueDate THEN
        
        -- Calculate the number of days the book is overdue
        SET daysOverdue = DATEDIFF(returnDate, dueDate);
        
        -- Assume late fee is Php 20 per day overdue
        SET lateFee = daysOverdue * 20;
    ELSE
        -- If the book is returned on time or before due date, late fee is 0
        SET lateFee = 0;
    END IF;

    RETURN lateFee;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GenerateTransactionReport` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerateTransactionReport`(IN startDate DATE, IN endDate DATE)
BEGIN
SELECT 
        t.transaction_id,
        b.title AS book_title,
        br.Name,
        t.borrow_date,
        t.due_date,
        t.return_date
    FROM 
        Transactions t
    JOIN 
        Books b ON t.book_id = b.book_id
    JOIN 
        Borrowers br ON t.borrower_id = br.ID
    WHERE 
        t.borrow_date BETWEEN startDate AND endDate -- Filter transactions within the specified date range
    ORDER BY 
        t.borrow_date; -- Order the report by the borrow date
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `active_borrowers`
--

/*!50001 DROP VIEW IF EXISTS `active_borrowers`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `active_borrowers` AS select `b`.`ID` AS `ID`,`b`.`Name` AS `Name`,`b`.`Email` AS `Email`,`b`.`Status` AS `Status` from `borrowers` `b` where (`b`.`Status` = 'Active') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `available_books`
--

/*!50001 DROP VIEW IF EXISTS `available_books`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `available_books` AS select `b`.`book_id` AS `Book ID`,`b`.`title` AS `Title`,`a`.`author_name` AS `Author`,`b`.`publication_year` AS `Publication Year`,`b`.`ISBN` AS `ISBN`,`g`.`genre_name` AS `Genre`,`b`.`availability` AS `Availability` from ((`books` `b` join `authors` `a` on((`b`.`author_id` = `a`.`author_id`))) join `genres` `g` on((`b`.`genre_id` = `g`.`genre_id`))) where (`b`.`availability` = 'Available') */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `book_inventory`
--

/*!50001 DROP VIEW IF EXISTS `book_inventory`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `book_inventory` AS select `b`.`book_id` AS `Book ID`,`b`.`title` AS `Title`,`a`.`author_name` AS `Author`,`b`.`ISBN` AS `ISBN`,`g`.`genre_name` AS `Genre`,`b`.`availability` AS `Availability` from ((`books` `b` join `authors` `a` on((`b`.`author_id` = `a`.`author_id`))) join `genres` `g` on((`b`.`genre_id` = `g`.`genre_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `bookavailability`
--

/*!50001 DROP VIEW IF EXISTS `bookavailability`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `bookavailability` AS select `b`.`book_id` AS `Book ID`,`b`.`title` AS `Book Title`,(case when (`t`.`return_date` is null) then 'Unavailable' else 'Available' end) AS `Availability` from (`books` `b` left join `transactions` `t` on((`b`.`book_id` = `t`.`book_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `borrowers_list`
--

/*!50001 DROP VIEW IF EXISTS `borrowers_list`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `borrowers_list` AS select `t`.`borrower_id` AS `ID`,`b`.`Name` AS `Name`,`bo`.`title` AS `Borrowed Book`,`t`.`borrow_date` AS `Transaction Date` from ((`transactions` `t` join `borrowers` `b` on((`t`.`borrower_id` = `b`.`ID`))) join `books` `bo` on((`t`.`book_id` = `bo`.`book_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `late_fees`
--

/*!50001 DROP VIEW IF EXISTS `late_fees`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `late_fees` AS select `t`.`transaction_id` AS `Transaction ID`,`b`.`Name` AS `Name`,`t`.`due_date` AS `Due Date`,`t`.`return_date` AS `Return Date`,`t`.`late_fee` AS `Late Fee` from (`transactions` `t` join `borrowers` `b` on((`t`.`borrower_id` = `b`.`ID`))) where ((`t`.`return_date` is not null) and (`t`.`late_fee` > 0)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `overduebooks`
--

/*!50001 DROP VIEW IF EXISTS `overduebooks`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `overduebooks` AS select `t`.`transaction_id` AS `transaction_id`,`t`.`book_id` AS `book_id`,`b`.`title` AS `book_title`,`t`.`borrower_id` AS `borrower_id`,`br`.`Name` AS `borrower_name`,`t`.`borrow_date` AS `borrow_date`,`t`.`due_date` AS `due_date`,`t`.`return_date` AS `return_date` from ((`transactions` `t` join `books` `b` on((`t`.`book_id` = `b`.`book_id`))) join `borrowers` `br` on((`t`.`borrower_id` = `br`.`ID`))) where (((`t`.`return_date` is not null) and (`t`.`return_date` > `t`.`due_date`)) or ((`t`.`return_date` is null) and (curdate() > `t`.`due_date`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `pending_transactions`
--

/*!50001 DROP VIEW IF EXISTS `pending_transactions`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `pending_transactions` AS select `t`.`transaction_id` AS `Transaction ID`,`b`.`title` AS `Title`,`bo`.`Name` AS `Name`,`t`.`borrow_date` AS `Borrow Date`,`t`.`due_date` AS `Due Date`,`t`.`return_date` AS `Return Date`,`t`.`late_fee` AS `Late Fee` from ((`transactions` `t` join `books` `b` on((`t`.`book_id` = `b`.`book_id`))) join `borrowers` `bo` on((`t`.`borrower_id` = `bo`.`ID`))) where (`t`.`return_date` is null) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `transactionhistory`
--

/*!50001 DROP VIEW IF EXISTS `transactionhistory`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `transactionhistory` AS select `t`.`transaction_id` AS `Transaction ID`,`b`.`title` AS `Book Title`,`br`.`Name` AS `Borrower`,`t`.`borrow_date` AS `Borrow Date`,`t`.`due_date` AS `Due Date`,`t`.`return_date` AS `Return Date` from ((`transactions` `t` join `books` `b` on((`t`.`book_id` = `b`.`book_id`))) join `borrowers` `br` on((`t`.`transaction_id` = `br`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `transactions_list`
--

/*!50001 DROP VIEW IF EXISTS `transactions_list`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `transactions_list` AS select `t`.`transaction_id` AS `Transaction ID`,`b`.`title` AS `Title`,`bo`.`Name` AS `Name`,`t`.`borrow_date` AS `Transaction Date`,`t`.`due_date` AS `Due Date`,`t`.`return_date` AS `Return Date`,`t`.`late_fee` AS `Late Fee` from ((`transactions` `t` join `books` `b` on((`t`.`book_id` = `b`.`book_id`))) join `borrowers` `bo` on((`t`.`borrower_id` = `bo`.`ID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-15 16:20:10
