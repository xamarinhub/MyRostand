-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 17 déc. 2019 à 10:33
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `myrostand`
--

-- --------------------------------------------------------

--
-- Structure de la table `accompagnement`
--

DROP TABLE IF EXISTS `accompagnement`;
CREATE TABLE IF NOT EXISTS `accompagnement` (
  `ACC_ID` int(11) NOT NULL,
  `ACC_LIBELLE` char(50) DEFAULT NULL,
  `ACC_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`ACC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `accompagnement`
--

INSERT INTO `accompagnement` (`ACC_ID`, `ACC_LIBELLE`, `ACC_DESCRIPTION`) VALUES
(1, 'salade verte', NULL),
(2, 'légumes du moment', NULL),
(3, 'laitage nature', NULL),
(4, 'camembert pt lévèque emmental', NULL),
(5, 'riz', NULL),
(6, 'courgettes aux herbes', NULL),
(7, 'mimolette coulommiers', NULL),
(8, 'petits pois', NULL),
(9, 'carottes étuvées', NULL),
(10, 'comté brie', NULL),
(11, 'pépinettes', NULL),
(12, 'gratin de légumes', NULL),
(13, 'chèvre camembert', NULL),
(14, 'choucroute', NULL),
(15, 'pomme vapeur', NULL),
(16, 'camembert pont l\'évèque', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `administratif`
--

DROP TABLE IF EXISTS `administratif`;
CREATE TABLE IF NOT EXISTS `administratif` (
  `ADM_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`ADM_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `annonce`
--

DROP TABLE IF EXISTS `annonce`;
CREATE TABLE IF NOT EXISTS `annonce` (
  `ANN_PASSAGER` int(11) NOT NULL,
  `ANN_ID` int(11) NOT NULL,
  `ANN_DATE` date DEFAULT NULL,
  `ANN_TITRE` char(32) DEFAULT NULL,
  `ANN_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`ANN_ID`),
  KEY `I_FK_ANNONCE_PASSAGER` (`ANN_PASSAGER`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `avis`
--

DROP TABLE IF EXISTS `avis`;
CREATE TABLE IF NOT EXISTS `avis` (
  `AVI_ID` int(11) NOT NULL,
  `AVI_UTILISATEUR` int(11) NOT NULL,
  `AVI_NOTE` int(1) DEFAULT NULL,
  `AVI_COMMENTAIRE` char(150) DEFAULT NULL,
  PRIMARY KEY (`AVI_ID`),
  KEY `I_FK_AVIS_UTILISATEUR` (`AVI_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `avis`
--

INSERT INTO `avis` (`AVI_ID`, `AVI_UTILISATEUR`, `AVI_NOTE`, `AVI_COMMENTAIRE`) VALUES
(1, 1, 4, 'Dans ma tête y\'a tout qui tourne');

-- --------------------------------------------------------

--
-- Structure de la table `choisir`
--

DROP TABLE IF EXISTS `choisir`;
CREATE TABLE IF NOT EXISTS `choisir` (
  `cho_id` int(11) NOT NULL,
  `cho_repas` int(11) DEFAULT NULL,
  `cho_plat` int(11) DEFAULT NULL,
  `cho_acc1` int(11) DEFAULT NULL,
  `cho_acc2` int(11) DEFAULT NULL,
  `cho_uti` int(11) DEFAULT NULL,
  PRIMARY KEY (`cho_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `classe`
--

DROP TABLE IF EXISTS `classe`;
CREATE TABLE IF NOT EXISTS `classe` (
  `CLA_ID` int(11) NOT NULL,
  `CLA_LIBELLE` char(150) DEFAULT NULL,
  PRIMARY KEY (`CLA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `conducteur`
--

DROP TABLE IF EXISTS `conducteur`;
CREATE TABLE IF NOT EXISTS `conducteur` (
  `CON_UTILISATEUR` int(11) NOT NULL,
  `CON_VOITURE` int(11) NOT NULL,
  PRIMARY KEY (`CON_UTILISATEUR`),
  UNIQUE KEY `I_FK_CONDUCTEUR_VOITURE` (`CON_VOITURE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `conducteur`
--

INSERT INTO `conducteur` (`CON_UTILISATEUR`, `CON_VOITURE`) VALUES
(1, 1),
(2, 2);

-- --------------------------------------------------------

--
-- Structure de la table `conversation`
--

DROP TABLE IF EXISTS `conversation`;
CREATE TABLE IF NOT EXISTS `conversation` (
  `CON_UTILISATEUR_EMETTEUR` int(11) NOT NULL,
  `CON_UTILISATEUR_DESTINATAIRE` int(11) NOT NULL,
  `CON_ID` bigint(11) DEFAULT NULL,
  `CON_CORPS` char(255) DEFAULT NULL,
  `CON_DATE` date DEFAULT NULL,
  `CON_HEURE` time DEFAULT NULL,
  PRIMARY KEY (`CON_UTILISATEUR_EMETTEUR`,`CON_UTILISATEUR_DESTINATAIRE`),
  KEY `I_FK_CONVERSATION_UTILISATEUR` (`CON_UTILISATEUR_EMETTEUR`),
  KEY `I_FK_CONVERSATION_UTILISATEUR1` (`CON_UTILISATEUR_DESTINATAIRE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `couleur`
--

DROP TABLE IF EXISTS `couleur`;
CREATE TABLE IF NOT EXISTS `couleur` (
  `COU_ID` int(11) NOT NULL,
  `COU_LIBELLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`COU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `couleur`
--

INSERT INTO `couleur` (`COU_ID`, `COU_LIBELLE`) VALUES
(1, 'Rouge');

-- --------------------------------------------------------

--
-- Structure de la table `demandetrajet`
--

DROP TABLE IF EXISTS `demandetrajet`;
CREATE TABLE IF NOT EXISTS `demandetrajet` (
  `DEM_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DEM_DEPART` varchar(75) NOT NULL,
  `DEM_ARRIVER` varchar(75) NOT NULL,
  `DEM_DATE` varchar(75) DEFAULT NULL,
  `DEM_FREQUENCE` varchar(75) NOT NULL,
  `DEM_HEURE_DEPART` varchar(75) NOT NULL,
  PRIMARY KEY (`DEM_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `demandetrajet`
--

INSERT INTO `demandetrajet` (`DEM_ID`, `DEM_DEPART`, `DEM_ARRIVER`, `DEM_DATE`, `DEM_FREQUENCE`, `DEM_HEURE_DEPART`) VALUES
(1, 'Caen', 'Aix', '12/11/2019 12:00:00 AM', 'Tous les Vendredi', '06:30:00'),
(2, 'caen', 'paris', '12/21/2019 12:00:00 AM', 'Tous les Lundi', '05:01:00'),
(3, 'caen', 'falaise', '12/13/2019 12:00:00 AM', 'Tous les Jours', '06:30:00'),
(4, 'NGO', 'MARSEILLE', '12/13/2019 12:00:00 AM', 'Tous les Jeudi', '08:37:00');

-- --------------------------------------------------------

--
-- Structure de la table `dessert`
--

DROP TABLE IF EXISTS `dessert`;
CREATE TABLE IF NOT EXISTS `dessert` (
  `DES_ID` int(11) NOT NULL,
  `DES_LIBELLE` char(50) DEFAULT NULL,
  `DES_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`DES_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `dessert`
--

INSERT INTO `dessert` (`DES_ID`, `DES_LIBELLE`, `DES_DESCRIPTION`) VALUES
(1, 'desserts lactés en pot', NULL),
(2, 'fromage blanc', NULL),
(3, 'coupe de fruits frais', NULL),
(4, 'riz au lait', NULL),
(5, 'crème dessert chocolat', NULL),
(6, 'forêt noire', NULL),
(7, 'abricots au sirop', NULL),
(8, 'Fruits de saison', NULL),
(9, 'mousse chocolat', NULL),
(10, 'tarte Bourdaloue', NULL),
(11, 'panna cotta', NULL),
(12, 'compote', NULL),
(13, 'flan patissier', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

DROP TABLE IF EXISTS `eleve`;
CREATE TABLE IF NOT EXISTS `eleve` (
  `ELE_UTILISATEUR` int(11) NOT NULL,
  `ELE_CLASSE` int(11) NOT NULL,
  PRIMARY KEY (`ELE_UTILISATEUR`),
  KEY `I_FK_ELEVE_CLASSE` (`ELE_CLASSE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `entree`
--

DROP TABLE IF EXISTS `entree`;
CREATE TABLE IF NOT EXISTS `entree` (
  `ENT_ID` int(11) NOT NULL,
  `ENT_LIBELLE` char(50) DEFAULT NULL,
  `ENT_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`ENT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `entree`
--

INSERT INTO `entree` (`ENT_ID`, `ENT_LIBELLE`, `ENT_DESCRIPTION`) VALUES
(1, 'wraps', NULL),
(2, 'betteraves rapées', NULL),
(3, 'salade de pâtes au saumon', NULL),
(4, 'carottes à l\'orange', NULL),
(5, 'terrine de poisson', NULL),
(6, 'salade de crudités', NULL),
(7, 'salade cesar', NULL),
(8, 'surimi mayonnaise', NULL),
(9, 'gougère maison', NULL),
(10, 'salade d\'endives', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `etape`
--

DROP TABLE IF EXISTS `etape`;
CREATE TABLE IF NOT EXISTS `etape` (
  `ETA_LIEUX` int(11) NOT NULL,
  `ETA_TRAJET` int(11) NOT NULL,
  PRIMARY KEY (`ETA_LIEUX`,`ETA_TRAJET`),
  KEY `I_FK_ETAPE_LIEUX` (`ETA_LIEUX`),
  KEY `I_FK_ETAPE_TRAJET` (`ETA_TRAJET`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `intendance`
--

DROP TABLE IF EXISTS `intendance`;
CREATE TABLE IF NOT EXISTS `intendance` (
  `INT_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`INT_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `laitage`
--

DROP TABLE IF EXISTS `laitage`;
CREATE TABLE IF NOT EXISTS `laitage` (
  `LAI_ID` int(11) NOT NULL,
  `LAI_LIBELLE` char(50) DEFAULT NULL,
  `LAI_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`LAI_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `lieux`
--

DROP TABLE IF EXISTS `lieux`;
CREATE TABLE IF NOT EXISTS `lieux` (
  `LIE_ID` int(11) NOT NULL,
  `LIE_LIBELLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`LIE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `lieux`
--

INSERT INTO `lieux` (`LIE_ID`, `LIE_LIBELLE`) VALUES
(1, 'Caen'),
(2, 'Ifs');

-- --------------------------------------------------------

--
-- Structure de la table `marque`
--

DROP TABLE IF EXISTS `marque`;
CREATE TABLE IF NOT EXISTS `marque` (
  `MAR_ID` int(11) NOT NULL,
  `MAR_LIBELLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`MAR_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `marque`
--

INSERT INTO `marque` (`MAR_ID`, `MAR_LIBELLE`) VALUES
(1, 'Peugeot'),
(2, 'Fiat');

-- --------------------------------------------------------

--
-- Structure de la table `model`
--

DROP TABLE IF EXISTS `model`;
CREATE TABLE IF NOT EXISTS `model` (
  `MOD_ID` int(11) NOT NULL,
  `MOD_MARQUE` int(11) NOT NULL,
  `MOD_LIBELLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`MOD_ID`),
  KEY `I_FK_MODEL_MARQUE` (`MOD_MARQUE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `model`
--

INSERT INTO `model` (`MOD_ID`, `MOD_MARQUE`, `MOD_LIBELLE`) VALUES
(1, 2, 'Multipla'),
(2, 1, '5008');

-- --------------------------------------------------------

--
-- Structure de la table `passager`
--

DROP TABLE IF EXISTS `passager`;
CREATE TABLE IF NOT EXISTS `passager` (
  `PAS_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`PAS_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `passager`
--

INSERT INTO `passager` (`PAS_UTILISATEUR`) VALUES
(1),
(2);

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `PER_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`PER_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `professeur`
--

DROP TABLE IF EXISTS `professeur`;
CREATE TABLE IF NOT EXISTS `professeur` (
  `PRO_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`PRO_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `repas`
--

DROP TABLE IF EXISTS `repas`;
CREATE TABLE IF NOT EXISTS `repas` (
  `REP_ID` int(11) NOT NULL,
  `REP_DATE` date DEFAULT NULL,
  PRIMARY KEY (`REP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `repas`
--

INSERT INTO `repas` (`REP_ID`, `REP_DATE`) VALUES
(1, '2019-11-25'),
(2, '2019-11-26'),
(3, '2019-11-27'),
(4, '2019-11-28'),
(5, '2019-12-10');

-- --------------------------------------------------------

--
-- Structure de la table `repasaccompagnement`
--

DROP TABLE IF EXISTS `repasaccompagnement`;
CREATE TABLE IF NOT EXISTS `repasaccompagnement` (
  `RA_REPAS` int(11) NOT NULL,
  `RA_ACCOMPAGNEMENT` int(11) NOT NULL,
  `RA_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`RA_REPAS`,`RA_ACCOMPAGNEMENT`,`RA_UTILISATEUR`),
  KEY `I_FK_REPASACCOMPAGNEMENT_ACCOMPAGNEMENT` (`RA_REPAS`),
  KEY `I_FK_REPASACCOMPAGNEMENT_REPAS` (`RA_ACCOMPAGNEMENT`),
  KEY `I_FK_REPASACCOMPAGNEMENT_UTILISATEUR` (`RA_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `repasdessert`
--

DROP TABLE IF EXISTS `repasdessert`;
CREATE TABLE IF NOT EXISTS `repasdessert` (
  `RD_DESSERT` int(11) NOT NULL,
  `RD_REPAS` int(11) NOT NULL,
  PRIMARY KEY (`RD_DESSERT`,`RD_REPAS`),
  KEY `I_FK_REPASDESSERT_REPAS` (`RD_DESSERT`),
  KEY `I_FK_REPASDESSERT_DESSERT` (`RD_REPAS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `repasdessert`
--

INSERT INTO `repasdessert` (`RD_DESSERT`, `RD_REPAS`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(3, 1),
(3, 3),
(3, 4),
(3, 5),
(4, 1),
(5, 1);

-- --------------------------------------------------------

--
-- Structure de la table `repasentree`
--

DROP TABLE IF EXISTS `repasentree`;
CREATE TABLE IF NOT EXISTS `repasentree` (
  `RE_ENTREE` int(11) NOT NULL,
  `RE_REPAS` int(11) NOT NULL,
  PRIMARY KEY (`RE_ENTREE`,`RE_REPAS`),
  KEY `I_FK_REPASENTREE_ENTREE` (`RE_ENTREE`),
  KEY `I_FK_REPASENTREE_REPAS` (`RE_REPAS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `repasentree`
--

INSERT INTO `repasentree` (`RE_ENTREE`, `RE_REPAS`) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3);

-- --------------------------------------------------------

--
-- Structure de la table `repaslaitage`
--

DROP TABLE IF EXISTS `repaslaitage`;
CREATE TABLE IF NOT EXISTS `repaslaitage` (
  `RL_LAITAGE` int(11) NOT NULL,
  `RL_REPAS` int(11) NOT NULL,
  PRIMARY KEY (`RL_LAITAGE`,`RL_REPAS`),
  KEY `I_FK_REPASLAITAGE_LAITAGE` (`RL_LAITAGE`),
  KEY `I_FK_REPASLAITAGE_REPAS` (`RL_REPAS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `repasresistance`
--

DROP TABLE IF EXISTS `repasresistance`;
CREATE TABLE IF NOT EXISTS `repasresistance` (
  `RR_REPAS` int(11) NOT NULL,
  `RR_RESISTANCE` int(11) NOT NULL,
  `RR_UTILISATEUR` int(11) NOT NULL,
  PRIMARY KEY (`RR_REPAS`,`RR_RESISTANCE`,`RR_UTILISATEUR`),
  KEY `I_FK_REPASRESISTANCE_REPAS` (`RR_REPAS`),
  KEY `I_FK_REPASRESISTANCE_RESISTANCE` (`RR_RESISTANCE`),
  KEY `I_FK_REPASRESISTANCE_UTILISATEUR` (`RR_UTILISATEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `reserver`
--

DROP TABLE IF EXISTS `reserver`;
CREATE TABLE IF NOT EXISTS `reserver` (
  `RES_UTILISATEUR` int(11) NOT NULL,
  `RES_TRAJET` int(11) NOT NULL,
  `RES_ID` int(11) DEFAULT NULL,
  `RES_PRIX` bigint(4) DEFAULT NULL,
  `RES_DECENTE` char(32) DEFAULT NULL,
  `RES_MONTER` char(32) DEFAULT NULL,
  `RES_ARCHIVE` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`RES_UTILISATEUR`,`RES_TRAJET`),
  KEY `I_FK_RESERVER_PASSAGER` (`RES_UTILISATEUR`),
  KEY `I_FK_RESERVER_TRAJET` (`RES_TRAJET`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `reserver`
--

INSERT INTO `reserver` (`RES_UTILISATEUR`, `RES_TRAJET`, `RES_ID`, `RES_PRIX`, `RES_DECENTE`, `RES_MONTER`, `RES_ARCHIVE`) VALUES
(1, 1, 2, 200, 'Bayeux', 'Ifs', 1),
(1, 2, 3, 50, 'Ifs', 'Ouistreham', 1),
(2, 1, 4, 350, 'Ifs', 'Caen', 0),
(2, 2, 1, 50, 'Ifs', 'Caen', 0);

-- --------------------------------------------------------

--
-- Structure de la table `resistance`
--

DROP TABLE IF EXISTS `resistance`;
CREATE TABLE IF NOT EXISTS `resistance` (
  `RES_ID` int(11) NOT NULL,
  `RES_LIBELLE` char(50) DEFAULT NULL,
  `RES_DESCRIPTION` char(250) DEFAULT NULL,
  PRIMARY KEY (`RES_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `resistance`
--

INSERT INTO `resistance` (`RES_ID`, `RES_LIBELLE`, `RES_DESCRIPTION`) VALUES
(1, 'tartiflette maison', NULL),
(2, 'poisson du jour', NULL),
(3, 'chili végétarien', NULL),
(4, 'omelette', NULL),
(5, 'cordon bleus de dinde', NULL),
(6, 'filet mignon au caramel', NULL),
(7, 'steak de poulet à la plancha', NULL),
(8, 'saucisse et lard', NULL),
(9, 'poisson beurre blanc', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `ROL_ID` int(11) NOT NULL,
  `ROL_LIBELLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`ROL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `role`
--

INSERT INTO `role` (`ROL_ID`, `ROL_LIBELLE`) VALUES
(1, 'Admin'),
(2, 'Membre');

-- --------------------------------------------------------

--
-- Structure de la table `sondage`
--

DROP TABLE IF EXISTS `sondage`;
CREATE TABLE IF NOT EXISTS `sondage` (
  `SON_ID` int(11) NOT NULL,
  `SON_MUSIQUEUN` char(100) DEFAULT NULL,
  `SON_MUSIQUEDEUX` char(100) DEFAULT NULL,
  `SON_MUSIQUETROIS` char(100) DEFAULT NULL,
  `SON_MUSIQUEQUATRE` char(100) DEFAULT NULL,
  `SON_DATE` date DEFAULT NULL,
  PRIMARY KEY (`SON_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `trajet`
--

DROP TABLE IF EXISTS `trajet`;
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
  `TRA_ETAT` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`TRA_ID`),
  KEY `I_FK_TRAJET_LIEUX` (`TRA_LIEU_DEPART`),
  KEY `I_FK_TRAJET_LIEUX2` (`TRA_LIEU_ARRIVER`),
  KEY `I_FK_TRAJET_CONDUCTEUR` (`TRA_CONDUCTEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `trajet`
--

INSERT INTO `trajet` (`TRA_ID`, `TRA_LIEU_DEPART`, `TRA_LIEU_ARRIVER`, `TRA_CONDUCTEUR`, `TRA_DATE`, `TRA_HEUREDEPART`, `TRA_HEUREARRIVER`, `TRA_NBRPLACE`, `TRA_DESCRIPTION`, `TRA_ETAT`) VALUES
(1, 1, 1, 1, '2019-11-05', '20:00', '22:00', 4, 'Un trajet de fou', 1),
(2, 1, 2, 2, '2019-11-04', '12:00', '18:00', 4, 'Ce trajet de dingue', 1);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
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
  `UTI_VILLE` char(50) DEFAULT NULL,
  PRIMARY KEY (`UTI_ID`),
  KEY `I_FK_UTILISATEUR_ROLE` (`UTI_ROLE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`UTI_ID`, `UTI_ROLE`, `UTI_NOM`, `UTI_PRENOM`, `UTI_BIO`, `UTI_DATENAISSANCE`, `UTI_TEL`, `UTI_PHOTO`, `UTI_NBRANNUL`, `UTI_FUMEUR`, `UTI_PARLEUR`, `UTI_MUSIQUE`, `UTI_ANIMAUX`, `UTI_EMAIL`, `UTI_MDP`, `UTI_RUE`, `UTI_CP`, `UTI_VILLE`) VALUES
(1, 2, 'Leconte', 'Thomas', 'Toto le deglinguo', '2000-05-05', '0625410034', NULL, 1, 0, 1, 1, 1, 'thomasleconte05@gmail.com', 'toto', '18 rue de la guérande', '14123', 'Cormelles Le Royal'),
(2, 2, 'Brionne', 'Axel', 'Axel\'Hair', '1999-11-30', '0607080910', NULL, 1, 1, 1, 1, 1, 'axel.brionne@gmail.com', 'axel', 'rue de falaise', '14000', 'Caen');

-- --------------------------------------------------------

--
-- Structure de la table `voiture`
--

DROP TABLE IF EXISTS `voiture`;
CREATE TABLE IF NOT EXISTS `voiture` (
  `VOI_ID` int(11) NOT NULL,
  `VOI_MODEL` int(11) NOT NULL,
  `VOI_COULEUR` int(11) NOT NULL,
  `VOI_PHOTO` char(255) DEFAULT NULL,
  PRIMARY KEY (`VOI_ID`),
  KEY `I_FK_VOITURE_MODEL` (`VOI_MODEL`),
  KEY `I_FK_VOITURE_COULEUR` (`VOI_COULEUR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `voiture`
--

INSERT INTO `voiture` (`VOI_ID`, `VOI_MODEL`, `VOI_COULEUR`, `VOI_PHOTO`) VALUES
(1, 1, 1, NULL),
(2, 2, 1, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `voter`
--

DROP TABLE IF EXISTS `voter`;
CREATE TABLE IF NOT EXISTS `voter` (
  `VOT_UTILISATEUR` int(11) NOT NULL,
  `VOT_SONDAGE` int(11) NOT NULL,
  `VOT_MUSIQUE` char(100) DEFAULT NULL,
  PRIMARY KEY (`VOT_UTILISATEUR`,`VOT_SONDAGE`),
  KEY `I_FK_VOTER_UTILISATEUR` (`VOT_UTILISATEUR`),
  KEY `I_FK_VOTER_SONDAGE` (`VOT_SONDAGE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contraintes pour les tables déchargées
--

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
  ADD CONSTRAINT `repasaccompagnement_ibfk_1` FOREIGN KEY (`RA_REPAS`) REFERENCES `accompagnement` (`ACC_ID`),
  ADD CONSTRAINT `repasaccompagnement_ibfk_2` FOREIGN KEY (`RA_ACCOMPAGNEMENT`) REFERENCES `repas` (`REP_ID`),
  ADD CONSTRAINT `repasaccompagnement_ibfk_3` FOREIGN KEY (`RA_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

--
-- Contraintes pour la table `repasdessert`
--
ALTER TABLE `repasdessert`
  ADD CONSTRAINT `repasdessert_ibfk_1` FOREIGN KEY (`RD_DESSERT`) REFERENCES `repas` (`REP_ID`),
  ADD CONSTRAINT `repasdessert_ibfk_2` FOREIGN KEY (`RD_REPAS`) REFERENCES `dessert` (`DES_ID`);

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
-- Contraintes pour la table `repasresistance`
--
ALTER TABLE `repasresistance`
  ADD CONSTRAINT `repasresistance_ibfk_1` FOREIGN KEY (`RR_REPAS`) REFERENCES `repas` (`REP_ID`),
  ADD CONSTRAINT `repasresistance_ibfk_2` FOREIGN KEY (`RR_RESISTANCE`) REFERENCES `resistance` (`RES_ID`),
  ADD CONSTRAINT `repasresistance_ibfk_3` FOREIGN KEY (`RR_UTILISATEUR`) REFERENCES `utilisateur` (`UTI_ID`);

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
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
