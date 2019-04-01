-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 18, 2018 at 11:04 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `studentrecord`
--
CREATE DATABASE IF NOT EXISTS `studentrecord` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `studentrecord`;

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE IF NOT EXISTS `log` (
  `id` varchar(15) NOT NULL,
  `LogInDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `logInHour` int(2) NOT NULL,
  `logInMin` int(11) NOT NULL,
  `logInSec` int(11) NOT NULL,
  `logOutDate` datetime NOT NULL,
  `logOutHour` int(11) NOT NULL,
  `logOutMin` int(11) NOT NULL,
  `logOutSec` int(11) NOT NULL,
  `renderedHour` int(2) NOT NULL,
  `renderedMin` int(2) NOT NULL,
  `renderedSec` int(2) NOT NULL,
  `no` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `studentregistral`
--

CREATE TABLE IF NOT EXISTS `studentregistral` (
  `id` varchar(15) NOT NULL,
  `lastname` varchar(35) NOT NULL,
  `firstname` varchar(35) NOT NULL,
  `middlename` varchar(35) NOT NULL,
  `yearSection` varchar(20) NOT NULL,
  `requiredHour` int(2) NOT NULL DEFAULT '80',
  `requiredMin` int(2) NOT NULL,
  `requiredSec` int(11) NOT NULL,
  `renderedHour` int(11) NOT NULL,
  `renderedMin` int(11) NOT NULL,
  `renderedSec` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
