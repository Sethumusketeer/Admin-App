create table OtherDetails(
EmpId INT FOREIGN KEY REFERENCES PersonalDetails(EmpId),
Shift varchar(32),
Location varchar(10),
Visa varchar(32),
Languages varchar(32))

Drop table OtherDetails

insert into OtherDetails("EmpId","Shift","Location","Visa","Languages") values ('101','Regular','India', 'Citizen','English, Tamil')

Select * from OtherDetails