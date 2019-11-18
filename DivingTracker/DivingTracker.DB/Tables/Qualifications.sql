CREATE TABLE [dbo].[Qualifications]
(
    [QualificationId] INT IDENTITY(1,1) 
		CONSTRAINT Qualifications_QualificationId_PK PRIMARY KEY,
    [AgencyId] INT 
		CONSTRAINT Qualifications_AgencyId_FK FOREIGN KEY REFERENCES dbo.Agencies(AgencyId),
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(256)
);
