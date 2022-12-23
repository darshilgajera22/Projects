-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 07, 2022 at 10:21 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sa000867069`
--

-- --------------------------------------------------------

--
-- Table structure for table `catalogue`
--

CREATE TABLE `catalogue` (
  `product_id` varchar(40) NOT NULL,
  `product_name` varchar(100) DEFAULT NULL,
  `product_description` longtext DEFAULT NULL,
  `product_price` float DEFAULT NULL,
  `product_category` varchar(25) DEFAULT NULL,
  `product_quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `catalogue`
--

INSERT INTO `catalogue` (`product_id`, `product_name`, `product_description`, `product_price`, `product_category`, `product_quantity`) VALUES
('cricket-balls-004', 'Cricket Balls', 'Cricnix Cricket Ball Gold Red Leather 142g (1-Pack/3-Pack/6-Pack) for Practice or Training', 22.99, 'Cricket', 0),
('cricket-bat-001', 'Cricket Bat ', ' SS Kashmir Willow Leather Ball Cricket Bat, Exclusive Cricket Bat For Adult Full Size with Full Protection Cover', 84.24, 'Cricket', 13),
('cricket-gloves-003', 'Cricket Gloves', 'Superlite Cricket Batting Gloves Mens Right Hand and Left Hand Batting', 71.37, 'Cricket', 18),
('cricket-helmet-002', 'Cricket Helmet', 'SS Cricket Gutsy Cricket Helmet (Blue & Black Color)', 69.99, 'Cricket', 7),
('cricket-shoe-006', 'Cricket Shoe', 'KD Vector Cricket Shoes Rubber Spike Cricket', 85.36, 'Cricket', 5),
('cricket-stumps-005', 'Cricket Stumps', 'FORTRESS Spring Back Cricket Stumps - 28in ICC Regulation Stumps for Cricket | Club & Pro Styles | Spring Back Wickets & Bails', 99.99, 'Cricket', 7),
('football-ball-007', 'Football Ball', 'Adidas Tango Glider Soccer Ball', 25.18, 'Football', 6),
('football-gloves-010', 'Football Gloves', 'Football Gloves Adult Youth Football Receiver Gloves,Enhanced Performance Football Gloves and Tacky Silicone Grip Football Gloves', 26.99, 'Football', 5),
('football-Jersey-008', 'Football Jersey', 'Messi Argentina Football Leo #10 Soccer Jersey Style Shirt Men ', 24.99, 'Football', 3),
('football-pads-011', 'Football Pads', 'Youth Padded Compression Shirt, Chest Protector, Heart Guard Sternum Protection Shirt', 29.99, 'Football', 6),
('football-shoe-009', 'Football Shoe', 'Soccer Cleats for Mens Womens FG Football Boots Outdoor Professional', 65.27, 'Football', 4),
('TableTennis-balls-013', 'Table Tennis Balls', 'PRO-SPIN Ping Pong Balls - Orange 3-Star 40+ Table Tennis Balls (Pack of 12, 24) | High-Performance ABS Training Balls | Ultimate Durability', 16.99, 'TableTennis', 13),
('TableTennis-net-015', 'Table Tennis Net', 'JOOLA Professional Grade WX Aluminum Indoor & Outdoor Table Tennis Net and Post Set - Quick Setup - 72in Regulation Ping Pong', 83.71, 'TableTennis', 4),
('TableTennis-racket-012', 'Table Tennis Racket', 'STIGA Pro Carbon Table Tennis Racket', 133.12, 'TableTennis', 9),
('TableTennis-table-014', 'Table Tennis Table, RUSTIC OAK', 'JOOLA Midsize Compact Table Tennis Table Great for Small Spaces and Apartments, Multi-Use Free Standing Table - Compact Storage', 228.99, 'TableTennis', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `catalogue`
--
ALTER TABLE `catalogue`
  ADD PRIMARY KEY (`product_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
