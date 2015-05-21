CREATE DATABASE `nhibernate-example` /*!40100 DEFAULT CHARACTER SET utf8 */;

CREATE TABLE `creditcardpayment` (
  `CreditCardPaymentId` int(11) NOT NULL AUTO_INCREMENT,
  `CardholderName` varchar(45) DEFAULT NULL,
  `CardNumber` varchar(45) DEFAULT NULL,
  `CardType` varchar(45) DEFAULT NULL,
  `ExpiryDate` date DEFAULT NULL,
  PRIMARY KEY (`CreditCardPaymentId`),
  UNIQUE KEY `CreditCardPaymentId_UNIQUE` (`CreditCardPaymentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `item` (
  `ItemId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Price` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  UNIQUE KEY `ItemId_UNIQUE` (`ItemId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `order` (
  `OrderId` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentType` varchar(45) DEFAULT NULL,
  `PaymentId` varchar(45) DEFAULT NULL,
  `ReferenceNumber` int(11) NOT NULL,
  PRIMARY KEY (`OrderId`,`ReferenceNumber`),
  UNIQUE KEY `idorder_UNIQUE` (`OrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `orderitem` (
  `OrderItemId` int(11) NOT NULL AUTO_INCREMENT,
  `OrderId` int(11) DEFAULT NULL,
  `ItemId` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`OrderItemId`),
  UNIQUE KEY `OrderItemId_UNIQUE` (`OrderItemId`),
  KEY `fkOrder_idx` (`OrderId`),
  KEY `fkItem_idx` (`ItemId`),
  CONSTRAINT `fkItem` FOREIGN KEY (`ItemId`) REFERENCES `item` (`ItemId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fkOrder` FOREIGN KEY (`OrderId`) REFERENCES `order` (`OrderId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
CREATE TABLE `paypalpayment` (
  `PayPalPaymentId` int(11) NOT NULL AUTO_INCREMENT,
  `AccountName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PayPalPaymentId`),
  UNIQUE KEY `PayPalPaymentId_UNIQUE` (`PayPalPaymentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

