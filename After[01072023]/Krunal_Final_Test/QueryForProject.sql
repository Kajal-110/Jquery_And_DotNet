Create Database KrunalFinalTest

use KrunalFinalTest

Select * From User_Registration


Create Table CountryTable(
	 id int Primary Key Identity(1,1),
	 CountryName varchar(50)
)
Insert Into CountryTable Values('India')
Insert Into CountryTable Values('Pakistan')

Create Table StateTable(
	 id int Primary Key Identity(1,1),
	 StateName varchar(50),
	 CountryId int FOREIGN KEY REFERENCES CountryTable(id)
)

Insert Into StateTable Values('Gujarat',1)
Insert Into StateTable Values('Maharashtra',1)
Insert Into StateTable Values('Karachi',2)
Insert Into StateTable Values('Kazakistan',2)

Create Table CityTable(
	 id int Primary Key Identity(1,1),
	 CityName varchar(50),
	 StateId int FOREIGN KEY REFERENCES StateTable(id),
	 CountryId int FOREIGN KEY REFERENCES CountryTable(id)
)

Insert Into CityTable Values('Ahmedabad',1,1)
Insert Into CityTable Values('Rajkot',1,1)
Insert Into CityTable Values('Mumbai',2,1)
Insert Into CityTable Values('Nasik',2,1)
Insert Into CityTable Values('Karachi City 1',3,2)
Insert Into CityTable Values('Karachi City 2',3,2)
Insert Into CityTable Values('Kazakistan City 1',4,2)
Insert Into CityTable Values('Kazakistan City 2',4,2)


Create Table GenderTable (
	id int Primary Key Identity(1,1),
	GenderName Varchar(6)
)
Insert Into GenderTable Values('Male')
Insert Into GenderTable Values('Female')

Create Table Hobbies (
	id int Primary Key Identity(1,1),
	HobbyName Varchar(20)
)

Insert Into Hobbies Values('Dancing')

Insert Into Hobbies Values('Reading')

Insert Into Hobbies Values('Playing')

Insert Into Hobbies Values('Watching TV')



Select * From CountryTable
Select * From StateTable
Select * From CityTable
Select * From GenderTable
Select * From Hobbies


Create Table User_Registration(
			 id int Primary Key Identity(1,1),
			 FirstName Varchar(30),
			 LastName Varchar(30),
			 Email Varchar(30),
			 Password Varchar(30),
			 DOB Date,
			 Address Varchar(30),
			 CountryId int FOREIGN KEY REFERENCES CountryTable(id),
			 StateId int FOREIGN KEY REFERENCES StateTable(id),
			 CityId int FOREIGN KEY REFERENCES CityTable(id),
			 PhotoPath varchar(Max),
			 Docpath varchar(Max),
			 Gender int FOREIGN KEY REFERENCES GenderTable(id),
			 Hobbies int FOREIGN KEY REFERENCES Hobbies(id)
)

Insert Into User_Registration Values('Krunal','Patel','krunal@gmail.com','1','2000-01-20','Rajkot',1,1,2,'ABC','XYZ',1,1)

Select * From User_Registration
