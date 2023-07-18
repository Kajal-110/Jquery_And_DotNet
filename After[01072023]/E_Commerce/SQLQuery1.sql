use KajalPatel_01_07_2023

select * from Registration

select * from Image

delete from Image where  id=7

create database Kajal_Patel

use Kajal_Patel
create table Registration(
UserId int primary key identity(1,1),
FirstName varchar(255),
LastName varchar(255),
Email varchar(255),
Password varchar(255),
Address varchar(255),
CountryId int foreign key references Country(CountryId),
StateId int foreign key references State(stateId) ,
CityId int foreign key references City(cityId),
Profile_Picture varchar(max),
Gender varchar(255)
)

select * from Registration 

CREATE TABLE Country (
    CountryId INT PRIMARY KEY identity(1,1),
    CountryName VARCHAR(100) NOT NULL
);


INSERT INTO Country ( CountryName)
VALUES('India'),
( 'United States'),
       ( 'Canada'),
       ( 'Brazil'),
       ( 'Russia');

	   select * from Country 

CREATE TABLE State (
    stateId INT PRIMARY KEY identity(1,1),
    stateName VARCHAR(100) NOT NULL,
    countryId INT,
    FOREIGN KEY (countryId) REFERENCES Country(CountryId)
);


INSERT INTO State ( stateName, countryId)
VALUES ('MP',1),
	( 'Bihar', 1),
       ('California', 2),
       ( 'Ontario', 2),
       ( 'Sao Paulo', 3),
       ( 'Moscow Oblast', 4),
	   ( 'Texas', 5),
       ( 'Quebec', 5),
       ( 'Rio de Janeiro', 3),
       ( 'Saint Petersburg', 4);

	    select * from State 

CREATE TABLE City (
    cityId INT PRIMARY KEY identity(1,1),
    cityName VARCHAR(100) NOT NULL,
    stateId INT,
    FOREIGN KEY (stateId) REFERENCES State(stateId)
);


INSERT INTO City ( cityName, stateId)
VALUES ('Jabalpur',1),('Katni',1),('Riva',2),('Satna',2),
		('New York City', 6),
       ( 'Los Angeles', 6),
       ( 'Toronto', 3),
       ( 'São Paulo', 4),
       ( 'Moscow', 5),	   
		( 'Houston', 7),
       ( 'Montreal', 7),
       ( 'Rio de Janeiro', 3),
       ( 'Saint Petersburg', 4),
       ( 'Toronto', 8),
	   ( 'Chicago', 8),
       ('Vancouver', 9),
       ('Brasília', 9),
       ( 'St. Petersburg', 10),
       ( 'Berlin', 5);


	   select * from City 


create table Product(
ProductId int primary key identity(1,1),
Product_Title varchar(255),
Price DECIMAL(10, 2) NOT NULL,
Description VARCHAR(500),
categoryId int  FOREIGN KEY  REFERENCES Category(categoryId)
)

CREATE TABLE Category (
    categoryId INT PRIMARY KEY identity(1,1),
    categoryName VARCHAR(100) NOT NULL
);

select * from Category


alter table Product 
 add Product_Image varchar(max)

 select * from Product 