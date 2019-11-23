CREATE TABLE [dbo].[Agencies]
(
    [AgencyId] INT IDENTITY(1,1) 
		CONSTRAINT Agencies_AgencyId_PK PRIMARY KEY,
    [AddressId] INT
		CONSTRAINT Agencies_AddressId_PK FOREIGN KEY REFERENCES dbo.Addresses(AddressId),
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(256)
);
