create table ProfessionalDetails(
EmpId INT FOREIGN KEY REFERENCES PersonalDetails(EmpId),
Email varchar(32),
Designation varchar(32),
DateJoined Date,
JobTitle varchar(32),
Department varchar(32),
Manager varchar(32))

drop table ProfessionalDetails

insert into ProfessionalDetails("EmpId","Email","Designation","DateJoined","JobTitle","Department","Manager") values ('101','sethu55sri@abc.com','Developer', '05/04/2020','Team Member', 'R&D', 'Siva')

select * from ProfessionalDetails

