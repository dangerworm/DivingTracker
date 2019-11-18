CREATE TABLE [dbo].[Agencies]
(
    [AgencyId] INT IDENTITY(1,1) 
		CONSTRAINT Agencies_AgencyId_PK PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(256)
);
