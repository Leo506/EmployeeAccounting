-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: employersdb
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Temporary view structure for view `directorinfo`
--

DROP TABLE IF EXISTS `directorinfo`;
/*!50001 DROP VIEW IF EXISTS `directorinfo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `directorinfo` AS SELECT 
 1 AS `idEmp`,
 1 AS `FullName`,
 1 AS `DateOfBirth`,
 1 AS `Sex`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `headinfo`
--

DROP TABLE IF EXISTS `headinfo`;
/*!50001 DROP VIEW IF EXISTS `headinfo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `headinfo` AS SELECT 
 1 AS `idEmp`,
 1 AS `FullName`,
 1 AS `DateOfBirth`,
 1 AS `Sex`,
 1 AS `DepartmenName`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `workerinfo`
--

DROP TABLE IF EXISTS `workerinfo`;
/*!50001 DROP VIEW IF EXISTS `workerinfo`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `workerinfo` AS SELECT 
 1 AS `idEmp`,
 1 AS `EmpFullname`,
 1 AS `DateOfBirth`,
 1 AS `Sex`,
 1 AS `idHead`,
 1 AS `HeadFullname`,
 1 AS `DepartmenName`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `directorinfo`
--

/*!50001 DROP VIEW IF EXISTS `directorinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `directorinfo` AS select `d`.`idEmp` AS `idEmp`,`e`.`FullName` AS `FullName`,`e`.`DateOfBirth` AS `DateOfBirth`,`e`.`Sex` AS `Sex` from (`director` `d` join `employer` `e` on((`e`.`idEmp` = `d`.`idEmp`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `headinfo`
--

/*!50001 DROP VIEW IF EXISTS `headinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `headinfo` AS select `dh`.`idEmp` AS `idEmp`,`e`.`FullName` AS `FullName`,`e`.`DateOfBirth` AS `DateOfBirth`,`e`.`Sex` AS `Sex`,`dh`.`DepartmenName` AS `DepartmenName` from (`departmenthead` `dh` join `employer` `e` on((`e`.`idEmp` = `dh`.`idEmp`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `workerinfo`
--

/*!50001 DROP VIEW IF EXISTS `workerinfo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `workerinfo` AS select `w`.`idEmp` AS `idEmp`,`e`.`FullName` AS `EmpFullname`,`e`.`DateOfBirth` AS `DateOfBirth`,`e`.`Sex` AS `Sex`,`w`.`idHead` AS `idHead`,`e2`.`FullName` AS `HeadFullname`,`d`.`DepartmenName` AS `DepartmenName` from (((`worker` `w` join `employer` `e` on((`e`.`idEmp` = `w`.`idEmp`))) join `employer` `e2` on((`e2`.`idEmp` = `w`.`idHead`))) join `departmenthead` `d` on((`d`.`idEmp` = `w`.`idHead`))) */;
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

-- Dump completed on 2022-06-05 20:21:38
