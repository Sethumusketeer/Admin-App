create table UserData(
Email varchar(60),
EmpId INT FOREIGN KEY REFERENCES PersonalDetails(EmpId),
Password varchar(10) not null
)

Insert into UserData Values('sethu55sri@gmail.com','101','password')

Drop table UserData

select * from UserData