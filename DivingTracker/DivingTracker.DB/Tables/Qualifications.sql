CREATE TABLE [dbo].[Qualifications]
(
    [QualificationId] INT IDENTITY(1,1) 
		CONSTRAINT Qualifications_QualificationId_PK PRIMARY KEY,
    [AgencyId] INT NOT NULL
		CONSTRAINT Qualifications_AgencyId_FK FOREIGN KEY REFERENCES dbo.Agencies(AgencyId),
	[QualificationTypeId] INT NOT NULL
		CONSTRAINT Qualifications_QualificationTypeId_FK FOREIGN KEY REFERENCES dbo.QualificationTypes(QualificationTypeId),
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(256)
);
