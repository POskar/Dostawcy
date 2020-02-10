-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 10, 2020 at 01:01 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bazadanych_2020`
--

-- --------------------------------------------------------

--
-- Table structure for table `dostawcy`
--

CREATE TABLE `dostawcy` (
  `id_dostawcy` int(11) NOT NULL,
  `imię` text COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` text COLLATE utf8_polish_ci NOT NULL,
  `typ_pojazdu` set('Samochód osobowy','Rower','Dostawczy','') COLLATE utf8_polish_ci NOT NULL,
  `dostępność` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `dostawcy`
--

INSERT INTO `dostawcy` (`id_dostawcy`, `imię`, `nazwisko`, `typ_pojazdu`, `dostępność`) VALUES
(1, 'Adam', 'A', 'Samochód osobowy', 1),
(2, 'Bartosz', 'B', 'Rower', 0),
(3, 'Eugeniusz', 'E', 'Dostawczy', 0),
(8, 'Cyprian', 'C', 'Samochód osobowy', 0),
(9, 'Denis', 'D', 'Rower', 1);

-- --------------------------------------------------------

--
-- Table structure for table `klient`
--

CREATE TABLE `klient` (
  `id_klienta` int(11) NOT NULL,
  `adres` text COLLATE utf8_polish_ci NOT NULL,
  `nr_tel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `klient`
--

INSERT INTO `klient` (`id_klienta`, `adres`, `nr_tel`) VALUES
(1, 'szosowa', 518369123),
(2, 'szosowa', 518369124),
(3, 'Deszczowa', 667511520),
(4, 'asdasdasd', 512312312);

-- --------------------------------------------------------

--
-- Table structure for table `restauracje`
--

CREATE TABLE `restauracje` (
  `id_restauracji` int(11) NOT NULL,
  `nazwa` text COLLATE utf8_polish_ci NOT NULL,
  `adres` text COLLATE utf8_polish_ci NOT NULL,
  `właściciel` text COLLATE utf8_polish_ci NOT NULL,
  `cena` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `restauracje`
--

INSERT INTO `restauracje` (`id_restauracji`, `nazwa`, `adres`, `właściciel`, `cena`) VALUES
(1, 'Abstrakcja', 'Grunwaldzka', 'Henryk', 32.5),
(2, 'Bajera', 'Adresowa', 'Jarosław', 28.75),
(4, 'Cytrynarnia', 'Cypriana', 'Bogdan', 24.34);

-- --------------------------------------------------------

--
-- Table structure for table `zamówienia`
--

CREATE TABLE `zamówienia` (
  `id_zamowienia` int(11) NOT NULL,
  `typ_zamowienia` set('Małe','Średnie','Duże') COLLATE utf8_polish_ci NOT NULL,
  `id_klienta` int(11) NOT NULL,
  `id_restauracji` int(11) NOT NULL,
  `id_dostawcy` int(11) NOT NULL,
  `typ_platnosci` set('Karta','Gotówka','BLIK') COLLATE utf8_polish_ci NOT NULL,
  `cena` float NOT NULL,
  `ilosc` int(11) NOT NULL,
  `powodzenie` tinyint(1) NOT NULL,
  `odebranie` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `zamówienia`
--

INSERT INTO `zamówienia` (`id_zamowienia`, `typ_zamowienia`, `id_klienta`, `id_restauracji`, `id_dostawcy`, `typ_platnosci`, `cena`, `ilosc`, `powodzenie`, `odebranie`) VALUES
(1, 'Małe', 2, 1, 2, 'BLIK', 37.3, 2, 0, 0),
(2, 'Średnie', 1, 1, 1, 'Gotówka', 22.75, 2, 1, 0),
(3, 'Małe', 2, 1, 1, 'Karta', 65, 2, 0, 0),
(4, 'Średnie', 1, 2, 1, 'Karta', 86.25, 3, 0, 0),
(5, 'Małe', 2, 1, 1, 'Gotówka', 65, 2, 0, 0),
(6, 'Małe', 4, 2, 1, 'Gotówka', 57.5, 2, 0, 0),
(7, 'Duże', 4, 2, 3, 'Karta', 287.5, 10, 0, 0),
(8, 'Małe', 4, 1, 1, 'Karta', 65, 2, 0, 0),
(9, 'Duże', 4, 4, 3, 'Karta', 243.4, 10, 0, 0),
(10, 'Duże', 4, 4, 3, 'Karta', 243.4, 10, 0, 0),
(11, 'Duże', 3, 2, 3, 'Karta', 287.5, 10, 0, 0),
(12, 'Duże', 4, 4, 3, 'BLIK', 243.4, 10, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dostawcy`
--
ALTER TABLE `dostawcy`
  ADD PRIMARY KEY (`id_dostawcy`);

--
-- Indexes for table `klient`
--
ALTER TABLE `klient`
  ADD PRIMARY KEY (`id_klienta`);

--
-- Indexes for table `restauracje`
--
ALTER TABLE `restauracje`
  ADD PRIMARY KEY (`id_restauracji`);

--
-- Indexes for table `zamówienia`
--
ALTER TABLE `zamówienia`
  ADD PRIMARY KEY (`id_zamowienia`),
  ADD KEY `zamówienia_ibfk_1` (`id_klienta`),
  ADD KEY `zamówienia_ibfk_2` (`id_dostawcy`),
  ADD KEY `zamówienia_ibfk_3` (`id_restauracji`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `zamówienia`
--
ALTER TABLE `zamówienia`
  ADD CONSTRAINT `zamówienia_ibfk_1` FOREIGN KEY (`id_klienta`) REFERENCES `klient` (`id_klienta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `zamówienia_ibfk_2` FOREIGN KEY (`id_dostawcy`) REFERENCES `dostawcy` (`id_dostawcy`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `zamówienia_ibfk_3` FOREIGN KEY (`id_restauracji`) REFERENCES `restauracje` (`id_restauracji`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
