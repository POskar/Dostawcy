-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 11, 2020 at 10:22 AM
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
(2, 'Bartek', 'B', 'Rower', 1),
(3, 'Cyprian', 'C', 'Dostawczy', 0),
(4, 'Denis', 'D', 'Rower', 1),
(5, 'Eugeniusz', 'E', 'Samochód osobowy', 0);

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
(1, 'Szosowa', 667510519),
(2, 'Brukowa', 619302938),
(3, 'Zielona', 509831290),
(4, 'Zimowa', 732018394);

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
(2, 'Bella', 'Warszawska', 'Jarosław', 24.9),
(3, 'Cytrynarnia', 'Cytrynowa', 'Janusz', 19.75),
(4, 'Dębowa', 'Kasztanowa', 'Mirosław', 37.2);

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
  `powodzenie` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `zamówienia`
--

INSERT INTO `zamówienia` (`id_zamowienia`, `typ_zamowienia`, `id_klienta`, `id_restauracji`, `id_dostawcy`, `typ_platnosci`, `cena`, `ilosc`, `powodzenie`) VALUES
(1, 'Średnie', 1, 2, 5, 'Gotówka', 74.7, 3, 0),
(2, 'Duże', 2, 4, 3, 'BLIK', 297.6, 8, 0);

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
  ADD CONSTRAINT `zamówienia_ibfk_2` FOREIGN KEY (`id_dostawcy`) REFERENCES `dostawcy` (`id_dostawcy`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `zamówienia_ibfk_3` FOREIGN KEY (`id_restauracji`) REFERENCES `restauracje` (`id_restauracji`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
