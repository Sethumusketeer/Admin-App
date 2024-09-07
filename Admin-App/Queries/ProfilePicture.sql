create Table ProfilePicture(
EmpId INT FOREIGN KEY REFERENCES PersonalDetails(EmpId),
ImageName VARCHAR(50),
ImageData VARBINARY(MAX))

select * from ProfilePicture

INSERT INTO ProfilePicture (EmpId, ImageName, ImageData)
SELECT 101, 'SethuDP', BulkColumn
FROM OPENROWSET(BULK N'C:\Project\Repository\SethuDP.jpg', SINGLE_BLOB) AS ImageData;
