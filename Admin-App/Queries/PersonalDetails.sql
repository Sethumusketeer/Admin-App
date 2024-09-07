create table PersonalDetails(
Name varchar(32) not null,
EmpId INT IDENTITY(101,1) PRIMARY KEY,
PersonalEmail varchar(32),
Gender varchar(10),
Age int,
Address varchar(300),
DateofBirth date)

Drop Table PersonalDetails

select * from PersonalDetails

insert into PersonalDetails("Name","PersonalEmail","Gender","Age","Address","DateofBirth") values ('Sethupathi', 'sethu55sri@gmail.com','Male', '26','Palani', '05/04/2020')
