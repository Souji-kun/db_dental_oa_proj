-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: db_dental
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `appointments`
--

DROP TABLE IF EXISTS `appointments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `appointments` (
  `appointment_id` int(11) NOT NULL AUTO_INCREMENT,
  `status` enum('pending','processing','cancelled','finished') NOT NULL,
  `appointment_date` datetime DEFAULT NULL,
  `patients_patient_id` int(11) NOT NULL,
  `patients_medical_history_md_id` varchar(45) NOT NULL,
  `employees_employee_id` int(11) NOT NULL,
  `employees_role_id` varchar(45) NOT NULL,
  `treatments_treatment_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`appointment_id`,`patients_patient_id`,`patients_medical_history_md_id`,`employees_employee_id`,`employees_role_id`),
  KEY `fk_appointments_patients1_idx` (`patients_patient_id`,`patients_medical_history_md_id`),
  KEY `fk_appointments_employees1_idx` (`employees_employee_id`,`employees_role_id`),
  KEY `fk_appointment_treatment` (`treatments_treatment_id`),
  CONSTRAINT `fk_appointment_treatment` FOREIGN KEY (`treatments_treatment_id`) REFERENCES `treatments` (`treatment_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_appointments_employees1` FOREIGN KEY (`employees_employee_id`) REFERENCES `employees` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_appointments_patients` FOREIGN KEY (`patients_patient_id`) REFERENCES `patients` (`patient_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_appointments_patients1` FOREIGN KEY (`patients_patient_id`, `patients_medical_history_md_id`) REFERENCES `patients` (`patient_id`, `medical_history_md_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appointments`
--

LOCK TABLES `appointments` WRITE;
/*!40000 ALTER TABLE `appointments` DISABLE KEYS */;
INSERT INTO `appointments` VALUES (19,'pending','2025-07-27 00:00:00',8,'',1,'',1),(20,'pending','2025-07-27 00:00:00',8,'',1,'',1),(21,'pending','2025-07-27 08:00:00',16,'',1,'',NULL),(22,'pending','2025-07-28 08:00:00',17,'',1,'',NULL),(23,'processing','2025-07-28 09:00:00',18,'',1,'',NULL),(24,'pending','2025-08-30 08:00:00',19,'',1,'',NULL),(25,'pending','2025-07-28 11:00:00',20,'',1,'',NULL),(26,'pending','2025-08-10 08:00:00',21,'',1,'',NULL),(27,'pending','2025-08-10 09:00:00',21,'',1,'',NULL),(28,'pending','2025-08-14 08:00:00',21,'',1,'',NULL),(29,'pending','2025-08-14 08:00:00',21,'',1,'',NULL),(30,'pending','2025-07-31 15:00:00',16,'',1,'',NULL),(31,'pending','2025-07-31 16:00:00',16,'',1,'',NULL),(32,'pending','2025-08-01 08:00:00',16,'',1,'',NULL),(33,'pending','2025-08-01 09:00:00',16,'',1,'',NULL),(34,'pending','2025-08-01 10:00:00',16,'',1,'',NULL),(35,'pending','2025-08-01 11:00:00',16,'',1,'',NULL),(36,'pending','2025-08-01 12:00:00',16,'',1,'',NULL),(37,'pending','2025-08-01 13:00:00',16,'',1,'',NULL),(38,'pending','2025-08-01 14:00:00',16,'',1,'',NULL),(39,'pending','2025-08-01 15:00:00',16,'',1,'',NULL),(40,'pending','2025-08-01 16:00:00',16,'',1,'',NULL),(41,'pending','2025-08-08 08:00:00',16,'',1,'',NULL),(42,'pending','2025-08-08 09:00:00',16,'',1,'',NULL),(43,'pending','2025-08-08 10:00:00',16,'',1,'',NULL),(44,'pending','2025-08-08 11:00:00',16,'',1,'',NULL),(45,'pending','2025-08-08 12:00:00',16,'',1,'',NULL),(46,'pending','2025-08-08 13:00:00',16,'',1,'',NULL);
/*!40000 ALTER TABLE `appointments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employees` (
  `employee_id` int(11) NOT NULL,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `roles_role_id` int(11) NOT NULL,
  PRIMARY KEY (`employee_id`,`roles_role_id`),
  KEY `fk_employees_roles1_idx` (`roles_role_id`),
  CONSTRAINT `fk_employees_roles1` FOREIGN KEY (`roles_role_id`) REFERENCES `roles` (`role_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Eric','Santos',2);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory` (
  `item_id` int(11) NOT NULL,
  `item_name` varchar(45) NOT NULL,
  `quantity` varchar(45) NOT NULL,
  `item_price` decimal(10,2) DEFAULT NULL,
  `supplier_id` int(11) NOT NULL,
  `expiration_date` date DEFAULT NULL,
  `date_of_acquirement` date DEFAULT NULL,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,'Probe','23',85.00,2,'2026-06-27','2025-05-25'),(2,'Gloves','113',2.50,2,'2028-06-27','2025-06-27'),(3,'Bib','126',1.50,2,'2026-01-19','2025-06-27'),(4,'Prophy Paste','13',180.00,6,'2028-01-18','2025-01-13'),(5,'Suction Tip','156',2.00,4,'2030-01-15','2025-03-18'),(6,'Zoom Kit','34',3200.00,3,'2027-04-18','2025-04-14'),(7,'Pola Kit','37',2900.00,3,'2027-04-30','2025-04-14'),(8,'Abutment','24',5000.00,5,'2030-02-18','2025-02-25'),(9,'Implant Fixture','16',20000.00,5,'2032-02-27','2025-02-25'),(10,'X-Ray Film Sheet','118',12.00,1,'2026-06-08','2025-06-27'),(11,'Anesthetic Cartridge','89',8.00,5,'2026-02-05','2025-02-06'),(12,'Disposable Syringe','156',2.00,4,'2027-08-16','2025-03-18'),(13,'Gauze / Cotton','153',2.00,4,'2031-12-31','2025-03-18'),(14,'Disposable Forceps','92',11.00,1,'2030-06-12','2025-06-24'),(15,'Composite Resin','79',420.00,6,'2028-01-11','2025-01-24'),(16,'Bonding Agent','74',300.00,6,'2028-01-01','2025-01-24'),(17,'Endo Files','44',250.00,1,'2027-06-03','2025-06-27'),(18,'Sodium Hypochlorite (NaOCl)','30',200.00,1,'2025-12-07','2025-06-27'),(19,'Gutta-percha Points','29',150.00,1,'2028-06-12','2025-06-27'),(20,'Brackets','54',700.00,5,'2035-02-13','2025-02-12'),(21,'Archwire Set','110',300.00,5,'2035-02-13','2025-02-12'),(22,'Molar Bands / Tubes / Ligatures','77',330.00,5,'2035-02-13','2025-02-12');
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medical_history`
--

DROP TABLE IF EXISTS `medical_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medical_history` (
  `md_id` int(11) NOT NULL AUTO_INCREMENT,
  `md_description` varchar(255) DEFAULT NULL,
  `patients_patient_id` int(11) NOT NULL,
  `patients_medical_history_md_id` varchar(45) NOT NULL,
  PRIMARY KEY (`md_id`,`patients_patient_id`,`patients_medical_history_md_id`),
  KEY `fk_medical_history_patients1_idx` (`patients_patient_id`,`patients_medical_history_md_id`),
  CONSTRAINT `fk_med_history_patients` FOREIGN KEY (`patients_patient_id`) REFERENCES `patients` (`patient_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_medical_history_patients1` FOREIGN KEY (`patients_patient_id`, `patients_medical_history_md_id`) REFERENCES `patients` (`patient_id`, `medical_history_md_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medical_history`
--

LOCK TABLES `medical_history` WRITE;
/*!40000 ALTER TABLE `medical_history` DISABLE KEYS */;
INSERT INTO `medical_history` VALUES (1,'Tooth Decay',1,''),(2,'Went Under Dental Cleaning a Year Ago',2,''),(3,'123',3,''),(4,'a',4,''),(5,'aa',5,''),(6,'zz',6,''),(8,'may schedule na',8,''),(15,'N/A',16,''),(16,'',17,''),(17,'Tooth Destruction',18,''),(18,'N/A',19,''),(19,'1234567890',20,''),(20,'n/a',21,''),(21,'none',21,''),(22,'none',21,''),(23,'none',21,''),(24,'',16,''),(25,'yawa',16,''),(26,'yawa',16,''),(27,'yawa',16,''),(28,'q',16,''),(29,'a',16,''),(30,'q',16,''),(31,'a',16,''),(32,'a',16,''),(33,'sa',16,''),(34,'sa',16,''),(35,'Tooth Cleaning',16,''),(36,'',16,''),(37,'',16,''),(38,'',16,''),(39,'Dental Cleaning',16,''),(40,'Dental Cleaning',16,'');
/*!40000 ALTER TABLE `medical_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patients` (
  `patient_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `middle_name` varchar(45) NOT NULL,
  `birth_date` date NOT NULL,
  `address` varchar(255) NOT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `email_address` varchar(45) DEFAULT NULL,
  `medical_history_md_id` varchar(45) NOT NULL,
  `treatments_treatment_id` int(11) DEFAULT NULL,
  `users_user_id` int(11) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`patient_id`,`medical_history_md_id`),
  KEY `fk_patients_treatments` (`treatments_treatment_id`),
  KEY `fk_user` (`user_id`),
  KEY `fk_patients_users` (`users_user_id`),
  CONSTRAINT `fk_patients_treatments` FOREIGN KEY (`treatments_treatment_id`) REFERENCES `treatments` (`treatment_id`),
  CONSTRAINT `fk_patients_users` FOREIGN KEY (`users_user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `patients_ibfk_1` FOREIGN KEY (`users_user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES (1,'Banania','Bananai','Bananis','0000-00-00','New York City','2147483647','Banania@ahkbar.com','',8,NULL,NULL),(2,'Josef Andrei','Opiz','Sotta','2003-12-27','Taguig CIty','09123456789','Jao@gmail.com','',8,NULL,NULL),(3,'a','a','a','2025-07-25','a','009735405353','a','',8,NULL,NULL),(4,'a','a','a','2025-07-25','a','aa','aa','',8,NULL,NULL),(5,'a','aa','a','2025-07-25','aa','aa','a','',8,NULL,NULL),(6,'zz','zz','zz','2025-07-25','zz','zz','zz','',8,NULL,NULL),(8,'aaaca','kk','k','2025-07-25','k','k','k','',8,NULL,NULL),(16,'human','last','the','2025-07-27','earth','N/A','N/A','',1,9,NULL),(17,'asd','sd','asd','2025-07-27','asda','asd','sda','',1,11,NULL),(18,'Banania','Bananai','Bananis','2001-09-11','New York City','09696964545','','',5,12,NULL),(19,'Bread','Baguette','Hon Hon','2000-01-01','Bakery','555','','',4,13,NULL),(20,'QWERTYUIOP','QWERTYUIOP','QWERTYUIOP','2025-07-21','1234567890','1234567890','','',4,14,NULL),(21,'lexes','acuesta','tabaquirso','2006-02-14','2 Sambakai','09099049791','','',6,16,NULL);
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = cp850 */ ;
/*!50003 SET character_set_results = cp850 */ ;
/*!50003 SET collation_connection  = cp850_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER trg_delete_user_after_patient
AFTER DELETE ON patients
FOR EACH ROW
BEGIN
    DELETE FROM users WHERE user_id = OLD.users_user_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL,
  `role_name` varchar(45) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Dentist'),(3,'Staff');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `supplier_name` varchar(255) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `contact_number` int(11) DEFAULT NULL,
  PRIMARY KEY (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'JC Dental Supply',NULL,NULL,NULL),(2,'Philippine Medical Supplies',NULL,NULL,NULL),(3,'Dental Domain Corporation',NULL,NULL,NULL),(4,'Brite Sources',NULL,NULL,NULL),(5,'Nedco Dental Supply',NULL,NULL,NULL),(6,'One Dental PH',NULL,NULL,NULL);
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions` (
  `transaction_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `appointment_date` date DEFAULT NULL,
  `treatment_name` varchar(100) DEFAULT NULL,
  `appointment_id` int(11) DEFAULT NULL,
  `treatment_id` int(11) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `amount_paid` int(11) DEFAULT NULL,
  `amount_tendered` int(11) DEFAULT NULL,
  PRIMARY KEY (`transaction_id`),
  KEY `fk_transactions_patient` (`patient_id`),
  KEY `fk_transactions_appointment` (`appointment_id`),
  CONSTRAINT `fk_appointment` FOREIGN KEY (`appointment_id`) REFERENCES `appointments` (`appointment_id`),
  CONSTRAINT `fk_transactions_appointment` FOREIGN KEY (`appointment_id`) REFERENCES `appointments` (`appointment_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_transactions_patient` FOREIGN KEY (`patient_id`) REFERENCES `patients` (`patient_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,16,'human last','2025-08-01',NULL,40,1,NULL,NULL,NULL),(2,16,'human last','2025-08-08','Dental Cleaning',43,1,1200,NULL,NULL),(3,16,'human last','2025-08-08','Dental Cleaning',44,1,1200,1201,1),(4,16,'human last','2025-08-08','Braces/Orthodontics',45,7,60000,65000,5000),(5,16,'human last','2025-08-08','Braces/Orthodontics',46,7,60000,60000,0);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `treatments`
--

DROP TABLE IF EXISTS `treatments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `treatments` (
  `treatment_id` int(11) NOT NULL AUTO_INCREMENT,
  `treatment_name` varchar(255) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `treatment_date` date NOT NULL,
  `employees_employee_id` int(11) NOT NULL,
  `employees_role_id` varchar(45) NOT NULL,
  `Inventory_item_id` int(11) NOT NULL,
  PRIMARY KEY (`treatment_id`,`employees_employee_id`,`employees_role_id`,`Inventory_item_id`),
  KEY `fk_treatments_employees1_idx` (`employees_employee_id`,`employees_role_id`),
  KEY `fk_treatments_Inventory1_idx` (`Inventory_item_id`),
  CONSTRAINT `fk_treatments_Inventory1` FOREIGN KEY (`Inventory_item_id`) REFERENCES `inventory` (`item_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_treatments_employees1` FOREIGN KEY (`employees_employee_id`) REFERENCES `employees` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `treatments`
--

LOCK TABLES `treatments` WRITE;
/*!40000 ALTER TABLE `treatments` DISABLE KEYS */;
INSERT INTO `treatments` VALUES (1,'Dental Cleaning',1200,'Removes plaque, tartar, and stains to maintain oral health and prevent gum disease.','0000-00-00',0,'',0),(2,'Dental Whitening',6000,'Brightens natural tooth color using safe bleaching agents and light-activated gels.','0000-00-00',0,'',0),(3,'Dental Implants',80000,'Permanent tooth replacement using titanium posts surgically placed in the jawbone.','0000-00-00',0,'',0),(4,'Dental X-Ray',1000,'Diagnostic imaging used to identify cavities, bone loss, or hidden dental issues.','0000-00-00',0,'',0),(5,'Tooth Extraction',1500,'Removal of damaged or problematic teeth, often done under local anesthesia.','0000-00-00',0,'',0),(6,'Dental Fillings',1500,'Restoration of tooth structure after cavity removal using resin or other materials.','0000-00-00',0,'',0),(7,'Braces/Orthodontics',60000,'Long-term treatment that uses brackets and wires to align teeth and correct bite issues.','0000-00-00',0,'',0),(8,'Root Canal Treatment',8000,'Procedure to remove infected pulp from the tooth root and preserve the natural tooth.','0000-00-00',0,'',0);
/*!40000 ALTER TABLE `treatments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email_address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'nyahallo','nyawa@waha',NULL),(2,'sdasdas','sdasdd',NULL),(3,'qwer','qwee',NULL),(4,'dwa','dwa',NULL),(5,'7654321','7654321',NULL),(9,'5555','5555',NULL),(10,'','',NULL),(11,'54321','54321',NULL),(12,'Ambatu_furtz','buzz_3',NULL),(13,'dbBread','Bread@db',NULL),(14,'dbLoaf','loaf@db','theloaf@unnof.com'),(15,'15','dbCroissant','croissant@db'),(16,'lex','acuesta',NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-03 12:32:57
