-- phpMyAdmin SQL Dump
-- version 4.2.12deb2+deb8u5
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Lun 03 Février 2020 à 10:33
-- Version du serveur :  5.5.62-0+deb8u1
-- Version de PHP :  5.6.40-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `myrostand`
--

-- --------------------------------------------------------

--
-- Structure de la table `accompagnement`
--

CREATE TABLE IF NOT EXISTS `accompagnement` (
  `ACC_ID` int(11) NOT NULL,
  `ACC_LIBELLE` char(50) DEFAULT NULL,
  `ACC_DESCRIPTION` char(250) DEFAULT NULL,
  `ACC_TYPE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `accompagnement`
--

INSERT INTO `accompagnement` (`ACC_ID`, `ACC_LIBELLE`, `ACC_DESCRIPTION`, `ACC_TYPE`) VALUES
(1, 'riz', 'riz', 1),
(2, 'orge', 'orge', 1),
(3, 'couscous', 'couscous', 1),
(4, 'quinoa', 'quinoa', 1),
(5, 'courges', 'courges', 2),
(6, 'maïs', 'maïs', 2),
(7, 'patates douces', 'patates douces', 2),
(8, 'pois verts', 'pois verts', 2),
(9, 'haricots', 'haricots', 3),
(10, 'lentilles', 'lentilles', 3),
(11, 'pois chiches', 'pois chiches', 3),
(12, 'Soja', 'soja', 3);

-- --------------------------------------------------------

--
-- Structure de la table `accompagnementtype`
--

CREATE TABLE IF NOT EXISTS `accompagnementtype` (
  `AT_ID` int(11) NOT NULL,
  `AT_LIBELLE` varchar(20) NOT NULL,
  `AT_POIDS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `accompagnementtype`
--

INSERT INTO `accompagnementtype` (`AT_ID`, `AT_LIBELLE`, `AT_POIDS`) VALUES
(1, 'Féculents', 155),
(2, 'Légumes', 202),
(3, 'Légumineuses', 146);

-- --------------------------------------------------------

--
-- Structure de la table `administratif`
--

CREATE TABLE IF NOT EXISTS `administratif` (
  `ADM_UTILISATEUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `annonce`
--

CREATE TABLE IF NOT EXISTS `annonce` (
  `ANN_PASSAGER` int(11) NOT NULL,
  `ANN_ID` int(11) NOT NULL,
  `ANN_DATE` date DEFAULT NULL,
  `ANN_TITRE` char(32) DEFAULT NULL,
  `ANN_DESCRIPTION` char(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `avis`
--

CREATE TABLE IF NOT EXISTS `avis` (
  `AVI_ID` int(11) NOT NULL,
  `AVI_UTILISATEUR` int(11) NOT NULL,
  `AVI_NOTE` int(1) DEFAULT NULL,
  `AVI_COMMENTAIRE` char(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `avis`
--

INSERT INTO `avis` (`AVI_ID`, `AVI_UTILISATEUR`, `AVI_NOTE`, `AVI_COMMENTAIRE`) VALUES
(1, 1, 4, 'Agréable');

-- --------------------------------------------------------

--
-- Structure de la table `classe`
--

CREATE TABLE IF NOT EXISTS `classe` (
  `CLA_ID` int(11) NOT NULL,
  `CLA_LIBELLE` char(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `concerner`
--

CREATE TABLE IF NOT EXISTS `concerner` (
  `con_res_id` int(11) NOT NULL DEFAULT '0',
  `con_accompagnement` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `concerner`
--

INSERT INTO `concerner` (`con_res_id`, `con_accompagnement`) VALUES
(67, 3),
(72, 4),
(27, 7),
(68, 9),
(72, 9);

-- --------------------------------------------------------

--
-- Structure de la table `conducteur`
--

CREATE TABLE IF NOT EXISTS `conducteur` (
  `CON_UTILISATEUR` int(11) NOT NULL,
  `CON_VOITURE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `conducteur`
--

INSERT INTO `conducteur` (`CON_UTILISATEUR`, `CON_VOITURE`) VALUES
(1, 1),
(2, 2);

-- --------------------------------------------------------

--
-- Structure de la table `conversation`
--

CREATE TABLE IF NOT EXISTS `conversation` (
  `CON_UTILISATEUR_EMETTEUR` int(11) NOT NULL,
  `CON_UTILISATEUR_DESTINATAIRE` int(11) NOT NULL,
  `CON_ID` bigint(11) DEFAULT NULL,
  `CON_CORPS` char(255) DEFAULT NULL,
  `CON_DATE` date DEFAULT NULL,
  `CON_HEURE` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `couleur`
--

CREATE TABLE IF NOT EXISTS `couleur` (
  `COU_ID` int(11) NOT NULL,
  `COU_LIBELLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `couleur`
--

INSERT INTO `couleur` (`COU_ID`, `COU_LIBELLE`) VALUES
(1, 'Rouge');

-- --------------------------------------------------------

--
-- Structure de la table `demandetrajet`
--

CREATE TABLE IF NOT EXISTS `demandetrajet` (
`DEM_ID` int(11) NOT NULL,
  `DEM_DEPART` varchar(75) NOT NULL,
  `DEM_ARRIVER` varchar(75) NOT NULL,
  `DEM_DATE` varchar(75) DEFAULT NULL,
  `DEM_FREQUENCE` varchar(75) NOT NULL,
  `DEM_HEURE_DEPART` varchar(75) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Contenu de la table `demandetrajet`
--

INSERT INTO `demandetrajet` (`DEM_ID`, `DEM_DEPART`, `DEM_ARRIVER`, `DEM_DATE`, `DEM_FREQUENCE`, `DEM_HEURE_DEPART`) VALUES
(1, 'Caen', 'Aix', '12/11/2019 12:00:00 AM', 'Tous les Vendredi', '06:30:00'),
(2, 'caen', 'paris', '12/21/2019 12:00:00 AM', 'Tous les Lundi', '05:01:00'),
(3, 'caen', 'falaise', '12/13/2019 12:00:00 AM', 'Tous les Jours', '06:30:00'),
(4, 'NGO', 'MARSEILLE', '12/13/2019 12:00:00 AM', 'Tous les Jeudi', '08:37:00'),
(5, 'hh', '6u', '22/02/2020 00:00:00', 'Tous les Vendredi', '04:14:00'),
(6, 'hh', '6u', '22/02/2020 00:00:00', 'Tous les Vendredi', '04:14:00');

-- --------------------------------------------------------

--
-- Structure de la table `dessert`
--

CREATE TABLE IF NOT EXISTS `dessert` (
  `DES_ID` int(11) NOT NULL,
  `DES_LIBELLE` char(50) DEFAULT NULL,
  `DES_DESCRIPTION` char(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `dessert`
--

INSERT INTO `dessert` (`DES_ID`, `DES_LIBELLE`, `DES_DESCRIPTION`) VALUES
(1, 'Desserts lactés en pot', 'Lactés'),
(2, 'Fromage blanc', 'Fromage Blanc'),
(3, 'Coupe de fruits frais', 'Coupe de fruits frais'),
(4, 'Riz au lait', 'Riz au lait'),
(5, 'Crème dessert chocolat', 'Crème dessert Chocolat'),
(6, 'Forêt noire', 'Forêt noire'),
(7, 'Abricots au sirop', 'Abricots au sirop'),
(8, 'Fruits de saison', 'Fruits de saison'),
(9, 'Mousse chocolat', 'Mousse chocolat'),
(10, 'Tarte Bourdaloue', 'Tarte Bourdaloue'),
(11, 'Panna cotta', 'Panna cotta'),
(12, 'Compote', 'Compote'),
(13, 'Flan patissier', 'Flan patissier');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE IF NOT EXISTS `eleve` (
  `ELE_UTILISATEUR` int(11) NOT NULL,
  `ELE_CLASSE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `entree`
--

CREATE TABLE IF NOT EXISTS `entree` (
  `ENT_ID` int(11) NOT NULL,
  `ENT_LIBELLE` char(50) DEFAULT NULL,
  `ENT_DESCRIPTION` char(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `entree`
--

INSERT INTO `entree` (`ENT_ID`, `ENT_LIBELLE`, `ENT_DESCRIPTION`) VALUES
(1, 'Wrap', 'Wraps desc'),
(2, 'Betteraves rapées', 'Betteraves desc'),
(3, 'Salade de pâtes au saumon', 'Pates saumon desc'),
(4, 'Carottes à l''orange', 'Carottes desc'),
(5, 'Terrine de poisson', 'Terrine poission desc'),
(6, 'Salade de crudités', 'Salade Crudités desc'),
(7, 'Salade cesar', 'Salade Cesar desc'),
(8, 'Surimi mayonnaise', 'Surimi mayo desc'),
(9, 'Gougère maison', 'Gougère desc'),
(10, 'Salade d''endives', 'Endives desc');

-- --------------------------------------------------------

--
-- Structure de la table `etape`
--

CREATE TABLE IF NOT EXISTS `etape` (
  `ETA_LIEUX` int(11) NOT NULL,
  `ETA_TRAJET` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `intendance`
--

CREATE TABLE IF NOT EXISTS `intendance` (
  `INT_UTILISATEUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `laitage`
--

CREATE TABLE IF NOT EXISTS `laitage` (
  `LAI_ID` int(11) NOT NULL,
  `LAI_LIBELLE` char(50) DEFAULT NULL,
  `LAI_DESCRIPTION` char(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `laitage`
--

INSERT INTO `laitage` (`LAI_ID`, `LAI_LIBELLE`, `LAI_DESCRIPTION`) VALUES
(1, 'Yaourts', 'Yaourts desc'),
(2, 'Camembert', 'Camembert desc'),
(3, 'Brie', 'Brie desc');

-- --------------------------------------------------------

--
-- Structure de la table `lieux`
--

CREATE TABLE IF NOT EXISTS `lieux` (
  `LIE_ID` int(11) NOT NULL,
  `LIE_LIBELLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `lieux`
--

INSERT INTO `lieux` (`LIE_ID`, `LIE_LIBELLE`) VALUES
(1, 'Caen'),
(2, 'Ifs');

-- --------------------------------------------------------

--
-- Structure de la table `marque`
--

CREATE TABLE IF NOT EXISTS `marque` (
  `MAR_ID` int(11) NOT NULL,
  `MAR_LIBELLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `marque`
--

INSERT INTO `marque` (`MAR_ID`, `MAR_LIBELLE`) VALUES
(1, 'Peugeot'),
(2, 'Fiat');

-- --------------------------------------------------------

--
-- Structure de la table `model`
--

CREATE TABLE IF NOT EXISTS `model` (
  `MOD_ID` int(11) NOT NULL,
  `MOD_MARQUE` int(11) NOT NULL,
  `MOD_LIBELLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `model`
--

INSERT INTO `model` (`MOD_ID`, `MOD_MARQUE`, `MOD_LIBELLE`) VALUES
(1, 2, 'Multipla'),
(2, 1, '5008');

-- --------------------------------------------------------

--
-- Structure de la table `passager`
--

CREATE TABLE IF NOT EXISTS `passager` (
  `PAS_UTILISATEUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `passager`
--

INSERT INTO `passager` (`PAS_UTILISATEUR`) VALUES
(1),
(2);

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

CREATE TABLE IF NOT EXISTS `personnel` (
  `PER_UTILISATEUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `professeur`
--

CREATE TABLE IF NOT EXISTS `professeur` (
  `PRO_UTILISATEUR` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `repas`
--

CREATE TABLE IF NOT EXISTS `repas` (
  `REP_ID` int(11) NOT NULL,
  `REP_DATE` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repas`
--

INSERT INTO `repas` (`REP_ID`, `REP_DATE`) VALUES
(0, '2020-01-14'),
(1, '2020-01-17'),
(2, '2020-01-20'),
(3, '2020-01-21'),
(4, '2020-01-22'),
(5, '2020-01-23'),
(6, '2020-01-24'),
(7, '2020-01-27'),
(8, '2020-01-28'),
(9, '2020-01-29'),
(10, '2020-01-30'),
(11, '2020-01-31'),
(12, '2020-02-03'),
(13, '2020-02-04'),
(14, '2020-02-05'),
(15, '2020-02-06'),
(16, '2020-02-07'),
(17, '2020-02-10'),
(18, '2020-02-11'),
(19, '2020-02-12'),
(20, '2020-02-13'),
(21, '2020-02-14'),
(22, '2020-02-17'),
(23, '2020-02-18'),
(24, '2020-02-19'),
(25, '2020-02-20'),
(26, '2020-02-21'),
(27, '2020-02-24'),
(28, '2020-02-25'),
(29, '2020-02-26'),
(30, '2020-02-27'),
(31, '2020-02-28'),
(32, '2020-03-02'),
(33, '2020-03-03'),
(34, '2020-03-04'),
(35, '2020-03-05'),
(36, '2020-03-06'),
(37, '2020-03-09'),
(38, '2020-03-10'),
(39, '2020-03-11'),
(40, '2020-03-12'),
(41, '2020-03-13'),
(42, '2020-03-16'),
(43, '2020-03-17'),
(44, '2020-03-18'),
(45, '2020-03-19'),
(46, '2020-03-20'),
(47, '2020-03-23'),
(48, '2020-03-24'),
(49, '2020-03-25'),
(50, '2020-03-26'),
(51, '2020-03-27'),
(52, '2020-03-30'),
(53, '2020-03-31'),
(54, '2020-04-01'),
(55, '2020-04-02'),
(56, '2020-04-03'),
(57, '2020-04-06'),
(58, '2020-04-07'),
(59, '2020-04-08'),
(60, '2020-04-09'),
(61, '2020-04-10');

-- --------------------------------------------------------

--
-- Structure de la table `repasaccompagnement`
--

CREATE TABLE IF NOT EXISTS `repasaccompagnement` (
  `RA_REPAS` int(11) NOT NULL,
  `RA_ACCOMPAGNEMENT` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repasaccompagnement`
--

INSERT INTO `repasaccompagnement` (`RA_REPAS`, `RA_ACCOMPAGNEMENT`) VALUES
(1, 1),
(6, 1),
(13, 1),
(1, 2),
(9, 2),
(12, 2),
(11, 3),
(13, 3),
(7, 4),
(8, 4),
(10, 4),
(6, 5),
(9, 5),
(11, 5),
(12, 6),
(7, 7),
(8, 7),
(9, 7),
(14, 7),
(6, 8),
(12, 8),
(7, 9),
(10, 9),
(12, 9),
(14, 9),
(11, 10),
(13, 10),
(6, 11),
(11, 11),
(13, 11),
(12, 12);

-- --------------------------------------------------------

--
-- Structure de la table `repasdessert`
--

CREATE TABLE IF NOT EXISTS `repasdessert` (
  `RD_REPAS` int(11) NOT NULL,
  `RD_DESSERT` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repasdessert`
--

INSERT INTO `repasdessert` (`RD_REPAS`, `RD_DESSERT`) VALUES
(9, 3),
(10, 4),
(11, 4),
(14, 4),
(8, 9),
(14, 9),
(9, 12),
(10, 12),
(11, 12),
(8, 13);

-- --------------------------------------------------------

--
-- Structure de la table `repasentree`
--

CREATE TABLE IF NOT EXISTS `repasentree` (
  `RE_REPAS` int(11) NOT NULL,
  `RE_ENTREE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repasentree`
--

INSERT INTO `repasentree` (`RE_REPAS`, `RE_ENTREE`) VALUES
(1, 1),
(1, 2),
(7, 2),
(14, 2),
(2, 3),
(7, 3),
(10, 3),
(2, 4),
(5, 4),
(9, 4),
(3, 5),
(5, 5),
(7, 6),
(11, 6),
(10, 7),
(16, 7),
(6, 8),
(9, 8),
(11, 9),
(14, 9);

-- --------------------------------------------------------

--
-- Structure de la table `repaslaitage`
--

CREATE TABLE IF NOT EXISTS `repaslaitage` (
  `RL_REPAS` int(11) NOT NULL,
  `RL_LAITAGE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repaslaitage`
--

INSERT INTO `repaslaitage` (`RL_REPAS`, `RL_LAITAGE`) VALUES
(1, 1),
(5, 1),
(9, 1),
(10, 1),
(14, 1),
(2, 2),
(5, 2),
(7, 2),
(9, 2),
(10, 2),
(11, 2),
(2, 3),
(5, 3),
(6, 3),
(7, 3),
(11, 3),
(14, 3);

-- --------------------------------------------------------

--
-- Structure de la table `repaspresence`
--

CREATE TABLE IF NOT EXISTS `repaspresence` (
`rpr_id` int(11) NOT NULL,
  `rpr_repas` int(11) NOT NULL,
  `rpr_uti` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Contenu de la table `repaspresence`
--

INSERT INTO `repaspresence` (`rpr_id`, `rpr_repas`, `rpr_uti`) VALUES
(1, 8, 3),
(2, 8, 2),
(3, 7, 3),
(4, 11, 3),
(5, 1, 1),
(11, 16, 1),
(12, 16, 3),
(13, 10, 3);

-- --------------------------------------------------------

--
-- Structure de la table `repasresistance`
--

CREATE TABLE IF NOT EXISTS `repasresistance` (
  `RR_REPAS` int(11) NOT NULL,
  `RR_RESISTANCE` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `repasresistance`
--

INSERT INTO `repasresistance` (`RR_REPAS`, `RR_RESISTANCE`) VALUES
(6, 1),
(1, 2),
(8, 2),
(9, 2),
(10, 2),
(14, 2),
(1, 3),
(6, 3),
(15, 3),
(12, 4),
(9, 5),
(6, 6),
(7, 6),
(10, 6),
(11, 6),
(12, 7),
(14, 7),
(6, 8),
(7, 8),
(11, 8),
(8, 9),
(14, 9);

-- --------------------------------------------------------

--
-- Structure de la table `reservationmenu`
--

CREATE TABLE IF NOT EXISTS `reservationmenu` (
`res_id` int(11) NOT NULL,
  `res_repas` int(11) NOT NULL DEFAULT '0',
  `res_plat` int(11) DEFAULT NULL,
  `res_uti` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=utf8;

--
-- Contenu de la table `reservationmenu`
--

INSERT INTO `reservationmenu` (`res_id`, `res_repas`, `res_plat`, `res_uti`) VALUES
(7, 1, 1, 3),
(26, 1, 6, 3),
(27, 8, 9, 3),
(28, 7, 5, 1),
(29, 7, 5, 2),
(51, 12, 7, 3),
(52, 9, 2, 3),
(61, 13, 0, 3),
(62, 13, 0, 1),
(63, 8, 0, 1),
(64, 9, 0, 1),
(65, 16, 0, 1),
(66, 16, 0, 3),
(67, 11, 6, 3),
(68, 10, 6, 3),
(69, 10, 2, 2),
(72, 10, 6, 1),
(73, 15, 3, 3),
(77, 14, 0, 3),
(78, 17, 0, 3);

-- --------------------------------------------------------

--
-- Structure de la table `reserver`
--

CREATE TABLE IF NOT EXISTS `reserver` (
  `RES_UTILISATEUR` int(11) NOT NULL,
  `RES_TRAJET` int(11) NOT NULL,
  `RES_ID` int(11) DEFAULT NULL,
  `RES_PRIX` bigint(4) DEFAULT NULL,
  `RES_DECENTE` char(32) DEFAULT NULL,
  `RES_MONTER` char(32) DEFAULT NULL,
  `RES_ARCHIVE` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `reserver`
--

INSERT INTO `reserver` (`RES_UTILISATEUR`, `RES_TRAJET`, `RES_ID`, `RES_PRIX`, `RES_DECENTE`, `RES_MONTER`, `RES_ARCHIVE`) VALUES
(1, 1, 2, 200, 'Bayeux', 'Ifs', 1),
(1, 2, 3, 50, 'Ifs', 'Ouistreham', 0),
(2, 1, 4, 350, 'Ifs', 'Caen', 0),
(2, 2, 1, 50, 'Ifs', 'Caen', 0);

-- --------------------------------------------------------

--
-- Structure de la table `resistance`
--

CREATE TABLE IF NOT EXISTS `resistance` (
  `RES_ID` int(11) NOT NULL,
  `RES_LIBELLE` char(50) DEFAULT NULL,
  `RES_DESCRIPTION` char(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `resistance`
--

INSERT INTO `resistance` (`RES_ID`, `RES_LIBELLE`, `RES_DESCRIPTION`) VALUES
(1, 'Tartiflette maison', 'Tartiflette desc'),
(2, 'Poisson du jour', 'Cabillaud, Colin ou Julienne'),
(3, 'Chili végétarien', 'Viande remplacée par des lentilles'),
(4, 'Omelette', 'Omelette desc'),
(5, 'Cordon bleu de dinde', 'Cordon bleu classique'),
(6, 'Filet mignon au caramel', 'Pièce de viande accompagnée d''une sauce caramelisée'),
(7, 'Steak de poulet à la plancha', 'Poulet fermier'),
(8, 'Saucisse et lard', 'Une saucisse entourée d''une tranche de lard'),
(9, 'Poisson beurre blanc', 'Cabillaud avec sauce au beurre blanc');

-- --------------------------------------------------------

--
-- Structure de la table `role`
--

CREATE TABLE IF NOT EXISTS `role` (
  `ROL_ID` int(11) NOT NULL,
  `ROL_LIBELLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `role`
--

INSERT INTO `role` (`ROL_ID`, `ROL_LIBELLE`) VALUES
(1, 'Admin'),
(2, 'Membre');

-- --------------------------------------------------------

--
-- Structure de la table `sondage`
--

CREATE TABLE IF NOT EXISTS `sondage` (
  `SON_ID` int(11) NOT NULL,
  `SON_TITRE` varchar(10) NOT NULL,
  `SON_MUSIQUEUN` char(100) DEFAULT NULL,
  `SON_MUSIQUEDEUX` char(100) DEFAULT NULL,
  `SON_MUSIQUETROIS` char(100) DEFAULT NULL,
  `SON_MUSIQUEQUATRE` char(100) DEFAULT NULL,
  `SON_DATE` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `sondage`
--

INSERT INTO `sondage` (`SON_ID`, `SON_TITRE`, `SON_MUSIQUEUN`, `SON_MUSIQUEDEUX`, `SON_MUSIQUETROIS`, `SON_MUSIQUEQUATRE`, `SON_DATE`) VALUES
(1, '', 'TOTO - AFRICA', 'LAKEY INSPIRED - Arcade', 'Post Malone - Circles', 'Guns N'' Roses - Welcome To The Jungle', 5);

-- --------------------------------------------------------

--
-- Structure de la table `trajet`
--

CREATE TABLE IF NOT EXISTS `trajet` (
  `TRA_ID` int(11) NOT NULL,
  `TRA_LIEU_DEPART` int(11) NOT NULL,
  `TRA_LIEU_ARRIVER` int(11) NOT NULL,
  `TRA_CONDUCTEUR` int(11) NOT NULL,
  `TRA_DATE` date DEFAULT NULL,
  `TRA_HEUREDEPART` varchar(20) DEFAULT NULL,
  `TRA_HEUREARRIVER` varchar(20) DEFAULT NULL,
  `TRA_NBRPLACE` int(2) DEFAULT NULL,
  `TRA_DESCRIPTION` char(75) DEFAULT NULL,
  `TRA_ETAT` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `trajet`
--

INSERT INTO `trajet` (`TRA_ID`, `TRA_LIEU_DEPART`, `TRA_LIEU_ARRIVER`, `TRA_CONDUCTEUR`, `TRA_DATE`, `TRA_HEUREDEPART`, `TRA_HEUREARRIVER`, `TRA_NBRPLACE`, `TRA_DESCRIPTION`, `TRA_ETAT`) VALUES
(1, 1, 1, 1, '2019-11-05', '20:00', '22:00', 4, 'Un trajet de fou', 1),
(2, 1, 2, 2, '2019-11-04', '12:00', '18:00', 4, 'Ce trajet de dingue', 1);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE IF NOT EXISTS `utilisateur` (
  `UTI_ID` int(11) NOT NULL,
  `UTI_ROLE` int(11) NOT NULL,
  `UTI_NOM` char(32) DEFAULT NULL,
  `UTI_PRENOM` char(32) DEFAULT NULL,
  `UTI_BIO` char(150) DEFAULT NULL,
  `UTI_DATENAISSANCE` date DEFAULT NULL,
  `UTI_TEL` char(10) DEFAULT NULL,
  `UTI_PHOTO` char(255) DEFAULT NULL,
  `UTI_NBRANNUL` int(11) DEFAULT NULL,
  `UTI_FUMEUR` int(1) DEFAULT NULL,
  `UTI_PARLEUR` int(1) DEFAULT NULL,
  `UTI_MUSIQUE` int(1) DEFAULT NULL,
  `UTI_ANIMAUX` int(1) DEFAULT NULL,
  `UTI_EMAIL` char(50) DEFAULT NULL,
  `UTI_MDP` char(100) DEFAULT NULL,
  `UTI_RUE` char(75) DEFAULT NULL,
  `UTI_CP` char(5) DEFAULT NULL,
  `UTI_VILLE` char(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `utilisateur`
--

INSERT INTO `utilisateur` (`UTI_ID`, `UTI_ROLE`, `UTI_NOM`, `UTI_PRENOM`, `UTI_BIO`, `UTI_DATENAISSANCE`, `UTI_TEL`, `UTI_PHOTO`, `UTI_NBRANNUL`, `UTI_FUMEUR`, `UTI_PARLEUR`, `UTI_MUSIQUE`, `UTI_ANIMAUX`, `UTI_EMAIL`, `UTI_MDP`, `UTI_RUE`, `UTI_CP`, `UTI_VILLE`) VALUES
(1, 2, 'Leconte', 'Thomas', 'Le mec assez fort en c# tu vois', '2000-05-05', '0625410034', NULL, 1, 0, 1, 1, 1, 'thomasleconte05@gmail.com', 'toto', '18 rue de la guérande', '14123', 'Cormelles Le Royal'),
(2, 2, 'Brionne', 'Axel', 'Axel''Hair', '1999-11-30', '0607080910', NULL, 1, 1, 1, 1, 1, 'axel.brionne@gmail.com', 'axel', 'rue de falaise', '14000', 'Caen'),
(3, 2, 'Leroux', 'Alexis', 'Possède une voiture de sport', '1999-07-26', '0780435361', NULL, NULL, 0, 0, 1, 0, 'lerouxalexispro@gmail.com', 'password', '12 rue de nesmond', '14400', 'Bayeux'),
(6, 1, 'test', 'Tom', 'To fast for U', '2020-01-02', '0780435360', NULL, NULL, NULL, 1, 1, NULL, 't.t@t.t', 'test', '51 boulevard des moissons', '14258', 'Moussons sur Odon');

-- --------------------------------------------------------

--
-- Structure de la table `voiture`
--

CREATE TABLE IF NOT EXISTS `voiture` (
  `VOI_ID` int(11) NOT NULL,
  `VOI_MODEL` int(11) NOT NULL,
  `VOI_COULEUR` int(11) NOT NULL,
  `VOI_PHOTO` char(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `voiture`
--

INSERT INTO `voiture` (`VOI_ID`, `VOI_MODEL`, `VOI_COULEUR`, `VOI_PHOTO`) VALUES
(1, 1, 1, NULL),
(2, 2, 1, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `voter`
--

CREATE TABLE IF NOT EXISTS `voter` (
  `VOT_UTILISATEUR` int(11) NOT NULL,
  `VOT_SONDAGE` int(11) NOT NULL,
  `VOT_MUSIQUE` char(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `voter`
--

INSERT INTO `voter` (`VOT_UTILISATEUR`, `VOT_SONDAGE`, `VOT_MUSIQUE`) VALUES
(2, 1, 'TOTO - AFRICA');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `accompagnement`
--
ALTER TABLE `accompagnement`
 ADD PRIMARY KEY (`ACC_ID`), ADD KEY `fk_accomp_type` (`ACC_TYPE`);

--
-- Index pour la table `accompagnementtype`
--
ALTER TABLE `accompagnementtype`
 ADD PRIMARY KEY (`AT_ID`);

--
-- Index pour la table `administratif`
--
ALTER TABLE `administratif`
 ADD PRIMARY KEY (`ADM_UTILISATEUR`);

--
-- Index pour la table `annonce`
--
ALTER TABLE `annonce`
 ADD PRIMARY KEY (`ANN_ID`), ADD KEY `I_FK_ANNONCE_PASSAGER` (`ANN_PASSAGER`);

--
-- Index pour la table `avis`
--
ALTER TABLE `avis`
 ADD PRIMARY KEY (`AVI_ID`), ADD KEY `I_FK_AVIS_UTILISATEUR` (`AVI_UTILISATEUR`);

--
-- Index pour la table `classe`
--
ALTER TABLE `classe`
 ADD PRIMARY KEY (`CLA_ID`);

--
-- Index pour la table `concerner`
--
ALTER TABLE `concerner`
 ADD PRIMARY KEY (`con_res_id`,`con_accompagnement`), ADD KEY `con_accompagnement` (`con_accompagnement`);

--
-- Index pour la table `conducteur`
--
ALTER TABLE `conducteur`
 ADD PRIMARY KEY (`CON_UTILISATEUR`), ADD UNIQUE KEY `I_FK_CONDUCTEUR_VOITURE` (`CON_VOITURE`);

--
-- Index pour la table `conversation`
--
ALTER TABLE `conversation`
 ADD PRIMARY KEY (`CON_UTILISATEUR_EMETTEUR`,`CON_UTILISATEUR_DESTINATAIRE`), ADD KEY `I_FK_CONVERSATION_UTILISATEUR` (`CON_UTILISATEUR_EMETTEUR`), ADD KEY `I_FK_CONVERSATION_UTILISATEUR1` (`CON_UTILISATEUR_DESTINATAIRE`);

--
-- Index pour la table `couleur`
--
ALTER TABLE `couleur`
 ADD PRIMARY KEY (`COU_ID`);

--
-- Index pour la table `demandetrajet`
--
ALTER TABLE `demandetrajet`
 ADD PRIMARY KEY (`DEM_ID`);

--
-- Index pour la table `dessert`
--
ALTER TABLE `dessert`
 ADD PRIMARY KEY (`DES_ID`);

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
 ADD PRIMARY KEY (`ELE_UTILISATEUR`), ADD KEY `I_FK_ELEVE_CLASSE` (`ELE_CLASSE`);

--
-- Index pour la table `entree`
--
ALTER TABLE `entree`
 ADD PRIMARY KEY (`ENT_ID`);

--
-- Index pour la table `etape`
--
ALTER TABLE `etape`
 ADD PRIMARY KEY (`ETA_LIEUX`,`ETA_TRAJET`), ADD KEY `I_FK_ETAPE_LIEUX` (`ETA_LIEUX`), ADD KEY `I_FK_ETAPE_TRAJET` (`ETA_TRAJET`);

--
-- Index pour la table `intendance`
--
ALTER TABLE `intendance`
 ADD PRIMARY KEY (`INT_UTILISATEUR`);

--
-- Index pour la table `laitage`
--
ALTER TABLE `laitage`
 ADD PRIMARY KEY (`LAI_ID`);

--
-- Index pour la table `lieux`
--
ALTER TABLE `lieux`
 ADD PRIMARY KEY (`LIE_ID`);

--
-- Index pour la table `marque`
--
ALTER TABLE `marque`
 ADD PRIMARY KEY (`MAR_ID`);

--
-- Index pour la table `model`
--
ALTER TABLE `model`
 ADD PRIMARY KEY (`MOD_ID`), ADD KEY `I_FK_MODEL_MARQUE` (`MOD_MARQUE`);

--
-- Index pour la table `passager`
--
ALTER TABLE `passager`
 ADD PRIMARY KEY (`PAS_UTILISATEUR`);

--
-- Index pour la table `personnel`
--
ALTER TABLE `personnel`
 ADD PRIMARY KEY (`PER_UTILISATEUR`);

--
-- Index pour la table `professeur`
--
ALTER TABLE `professeur`
 ADD PRIMARY KEY (`PRO_UTILISATEUR`);

--
-- Index pour la table `repas`
--
ALTER TABLE `repas`
 ADD PRIMARY KEY (`REP_ID`);

--
-- Index pour la table `repasaccompagnement`
--
ALTER TABLE `repasaccompagnement`
 ADD PRIMARY KEY (`RA_REPAS`,`RA_ACCOMPAGNEMENT`), ADD KEY `repasaccompagnement_ibfk_1` (`RA_ACCOMPAGNEMENT`);

--
-- Index pour la table `repasdessert`
--
ALTER TABLE `repasdessert`
 ADD PRIMARY KEY (`RD_DESSERT`,`RD_REPAS`), ADD KEY `I_FK_REPASDESSERT_REPAS` (`RD_DESSERT`), ADD KEY `I_FK_REPASDESSERT_DESSERT` (`RD_REPAS`);

--
-- Index pour la table `repasentree`
--
ALTER TABLE `repasentree`
 ADD PRIMARY KEY (`RE_ENTREE`,`RE_REPAS`), ADD KEY `I_FK_REPASENTREE_ENTREE` (`RE_ENTREE`), ADD KEY `I_FK_REPASENTREE_REPAS` (`RE_REPAS`);

--
-- Index pour la table `repaslaitage`
--
ALTER TABLE `repaslaitage`
 ADD PRIMARY KEY (`RL_LAITAGE`,`RL_REPAS`), ADD KEY `I_FK_REPASLAITAGE_LAITAGE` (`RL_LAITAGE`), ADD KEY `I_FK_REPASLAITAGE_REPAS` (`RL_REPAS`);

--
-- Index pour la table `repaspresence`
--
ALTER TABLE `repaspresence`
 ADD PRIMARY KEY (`rpr_id`), ADD KEY `fk_repaspresence_repas` (`rpr_repas`), ADD KEY `fk_repaspresence_utilisateur` (`rpr_uti`);

--
-- Index pour la table `repasresistance`
--
ALTER TABLE `repasresistance`
 ADD PRIMARY KEY (`RR_REPAS`,`RR_RESISTANCE`), ADD KEY `repasresistance_ibfk_2` (`RR_RESISTANCE`);

--
-- Index pour la table `reservationmenu`
--
ALTER TABLE `reservationmenu`
 ADD PRIMARY KEY (`res_id`,`res_repas`,`res_uti`), ADD KEY `res_repas` (`res_repas`), ADD KEY `res_uti` (`res_uti`);

--
-- Index pour la table `reserver`
--
ALTER TABLE `reserver`
 ADD PRIMARY KEY (`RES_UTILISATEUR`,`RES_TRAJET`), ADD KEY `I_FK_RESERVER_PASSAGER` (`RES_UTILISATEUR`), ADD KEY `I_FK_RESERVER_TRAJET` (`RES_TRAJET`);

--
-- Index pour la table `resistance`
--
ALTER TABLE `resistance`
 ADD PRIMARY KEY (`RES_ID`);

--
-- Index pour la table `role`
--
ALTER TABLE `role`
 ADD PRIMARY KEY (`ROL_ID`);

--
-- Index pour la table `sondage`
--
ALTER TABLE `sondage`
 ADD PRIMARY KEY (`SON_ID`);

--
-- Index pour la table `trajet`
--
ALTER TABLE `trajet`
 ADD PRIMARY KEY (`TRA_ID`), ADD KEY `I_FK_TRAJET_LIEUX` (`TRA_LIEU_DEPART`), ADD KEY `I_FK_TRAJET_LIEUX2` (`TRA_LIEU_ARRIVER`), ADD KEY `I_FK_TRAJET_CONDUCTEUR` (`TRA_CONDUCTEUR`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
 ADD PRIMARY KEY (`UTI_ID`), ADD KEY `I_FK_UTILISATEUR_ROLE` (`UTI_ROLE`);

--
-- Index pour la table `voiture`
--
ALTER TABLE `voiture`
 ADD PRIMARY KEY (`VOI_ID`), ADD KEY `I_FK_VOITURE_MODEL` (`VOI_MODEL`), ADD KEY `I_FK_VOITURE_COULEUR` (`VOI_COULEUR`);

--
-- Index pour la table `voter`
--
ALTER TABLE `voter`
 ADD PRIMARY KEY (`VOT_UTILISATEUR`,`VOT_SONDAGE`), ADD KEY `I_FK_VOTER_UTILISATEUR` (`VOT_UTILISATEUR`), ADD KEY `I_FK_VOTER_SONDAGE` (`VOT_SONDAGE`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `demandetrajet`
--
ALTER TABLE `demandetrajet`
MODIFY `DEM_ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT pour la table `repaspresence`
--
ALTER TABLE `repaspresence`
MODIFY `rpr_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT pour la table `reservationmenu`
--
ALTER TABLE `reservationmenu`
MODIFY `res_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=79;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `accompagnement`
--
ALTER TABLE `accompagnement`
ADD CONSTRAINT `fk_accomp_type` FOREIGN KEY (`ACC_TYPE`) REFERENCES `accompagnementtype` (`AT_ID`);

--
-- Contraintes pour la table `administratif`
--
ALTER TABLE `administratif`
ADD CONSTRAINT `administratif_ibfk_1` FOREIGN KEY (`ADM_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `annonce`
--
ALTER TABLE `annonce`
ADD CONSTRAINT `annonce_ibfk_1` FOREIGN KEY (`ANN_PASSAGER`) REFERENCES `passager` (`PAS_UTILISATEUR`);

--
-- Contraintes pour la table `avis`
--
ALTER TABLE `avis`
ADD CONSTRAINT `avis_ibfk_1` FOREIGN KEY (`AVI_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `concerner`
--
ALTER TABLE `concerner`
ADD CONSTRAINT `concerner_ibfk_3` FOREIGN KEY (`con_accompagnement`) REFERENCES `accompagnement` (`ACC_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `concerner_ibfk_1` FOREIGN KEY (`con_res_id`) REFERENCES `reservationmenu` (`res_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `concerner_ibfk_2` FOREIGN KEY (`con_accompagnement`) REFERENCES `repasaccompagnement` (`RA_ACCOMPAGNEMENT`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `conducteur`
--
ALTER TABLE `conducteur`
ADD CONSTRAINT `conducteur_ibfk_1` FOREIGN KEY (`CON_VOITURE`) REFERENCES `voiture` (`VOI_ID`),
ADD CONSTRAINT `conducteur_ibfk_2` FOREIGN KEY (`CON_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `conversation`
--
ALTER TABLE `conversation`
ADD CONSTRAINT `conversation_ibfk_1` FOREIGN KEY (`CON_UTILISATEUR_EMETTEUR`) REFERENCES `utilisateur` (`UTI_ID`),
ADD CONSTRAINT `conversation_ibfk_2` FOREIGN KEY (`CON_UTILISATEUR_DESTINATAIRE`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
ADD CONSTRAINT `eleve_ibfk_1` FOREIGN KEY (`ELE_CLASSE`) REFERENCES `classe` (`CLA_ID`),
ADD CONSTRAINT `eleve_ibfk_2` FOREIGN KEY (`ELE_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `etape`
--
ALTER TABLE `etape`
ADD CONSTRAINT `etape_ibfk_1` FOREIGN KEY (`ETA_LIEUX`) REFERENCES `lieux` (`LIE_ID`),
ADD CONSTRAINT `etape_ibfk_2` FOREIGN KEY (`ETA_TRAJET`) REFERENCES `trajet` (`TRA_ID`);

--
-- Contraintes pour la table `intendance`
--
ALTER TABLE `intendance`
ADD CONSTRAINT `intendance_ibfk_1` FOREIGN KEY (`INT_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `model`
--
ALTER TABLE `model`
ADD CONSTRAINT `model_ibfk_1` FOREIGN KEY (`MOD_MARQUE`) REFERENCES `marque` (`MAR_ID`);

--
-- Contraintes pour la table `passager`
--
ALTER TABLE `passager`
ADD CONSTRAINT `passager_ibfk_1` FOREIGN KEY (`PAS_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `personnel`
--
ALTER TABLE `personnel`
ADD CONSTRAINT `personnel_ibfk_1` FOREIGN KEY (`PER_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `professeur`
--
ALTER TABLE `professeur`
ADD CONSTRAINT `professeur_ibfk_1` FOREIGN KEY (`PRO_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `repasaccompagnement`
--
ALTER TABLE `repasaccompagnement`
ADD CONSTRAINT `repasaccompagnement_ibfk_1` FOREIGN KEY (`RA_ACCOMPAGNEMENT`) REFERENCES `accompagnement` (`ACC_ID`),
ADD CONSTRAINT `repasaccompagnement_ibfk_2` FOREIGN KEY (`RA_REPAS`) REFERENCES `repas` (`REP_ID`);

--
-- Contraintes pour la table `repasdessert`
--
ALTER TABLE `repasdessert`
ADD CONSTRAINT `repasdessert_ibfk_2` FOREIGN KEY (`RD_DESSERT`) REFERENCES `dessert` (`DES_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `repasdessert_ibfk_1` FOREIGN KEY (`RD_REPAS`) REFERENCES `repas` (`REP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `repasentree`
--
ALTER TABLE `repasentree`
ADD CONSTRAINT `repasentree_ibfk_1` FOREIGN KEY (`RE_ENTREE`) REFERENCES `entree` (`ENT_ID`),
ADD CONSTRAINT `repasentree_ibfk_2` FOREIGN KEY (`RE_REPAS`) REFERENCES `repas` (`REP_ID`);

--
-- Contraintes pour la table `repaslaitage`
--
ALTER TABLE `repaslaitage`
ADD CONSTRAINT `repaslaitage_ibfk_1` FOREIGN KEY (`RL_LAITAGE`) REFERENCES `laitage` (`LAI_ID`),
ADD CONSTRAINT `repaslaitage_ibfk_2` FOREIGN KEY (`RL_REPAS`) REFERENCES `repas` (`REP_ID`);

--
-- Contraintes pour la table `repaspresence`
--
ALTER TABLE `repaspresence`
ADD CONSTRAINT `fk_repaspresence_repas` FOREIGN KEY (`rpr_repas`) REFERENCES `repas` (`REP_ID`),
ADD CONSTRAINT `fk_repaspresence_utilisateur` FOREIGN KEY (`rpr_uti`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `repasresistance`
--
ALTER TABLE `repasresistance`
ADD CONSTRAINT `repasresistance_ibfk_1` FOREIGN KEY (`RR_REPAS`) REFERENCES `repas` (`REP_ID`),
ADD CONSTRAINT `repasresistance_ibfk_2` FOREIGN KEY (`RR_RESISTANCE`) REFERENCES `resistance` (`RES_ID`);

--
-- Contraintes pour la table `reservationmenu`
--
ALTER TABLE `reservationmenu`
ADD CONSTRAINT `reservationmenu_ibfk_1` FOREIGN KEY (`res_repas`) REFERENCES `repas` (`REP_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
ADD CONSTRAINT `reservationmenu_ibfk_3` FOREIGN KEY (`res_uti`) REFERENCES `utilisateur` (`UTI_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `reserver`
--
ALTER TABLE `reserver`
ADD CONSTRAINT `reserver_ibfk_1` FOREIGN KEY (`RES_UTILISATEUR`) REFERENCES `passager` (`PAS_UTILISATEUR`),
ADD CONSTRAINT `reserver_ibfk_2` FOREIGN KEY (`RES_TRAJET`) REFERENCES `trajet` (`TRA_ID`);

--
-- Contraintes pour la table `trajet`
--
ALTER TABLE `trajet`
ADD CONSTRAINT `trajet_ibfk_1` FOREIGN KEY (`TRA_LIEU_DEPART`) REFERENCES `lieux` (`LIE_ID`),
ADD CONSTRAINT `trajet_ibfk_2` FOREIGN KEY (`TRA_LIEU_ARRIVER`) REFERENCES `lieux` (`LIE_ID`),
ADD CONSTRAINT `trajet_ibfk_3` FOREIGN KEY (`TRA_CONDUCTEUR`) REFERENCES `conducteur` (`CON_UTILISATEUR`);

--
-- Contraintes pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
ADD CONSTRAINT `utilisateur_ibfk_1` FOREIGN KEY (`UTI_ROLE`) REFERENCES `role` (`ROL_ID`);

--
-- Contraintes pour la table `voiture`
--
ALTER TABLE `voiture`
ADD CONSTRAINT `voiture_ibfk_1` FOREIGN KEY (`VOI_MODEL`) REFERENCES `model` (`MOD_ID`),
ADD CONSTRAINT `voiture_ibfk_2` FOREIGN KEY (`VOI_COULEUR`) REFERENCES `couleur` (`COU_ID`);

--
-- Contraintes pour la table `voter`
--
ALTER TABLE `voter`
ADD CONSTRAINT `voter_ibfk_1` FOREIGN KEY (`VOT_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`),
ADD CONSTRAINT `voter_ibfk_2` FOREIGN KEY (`VOT_SONDAGE`) REFERENCES `sondage` (`SON_ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
