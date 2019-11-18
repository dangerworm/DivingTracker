CREATE TABLE [dbo].[Modules]
(
    [ModuleId] INT IDENTITY(1,1)
		CONSTRAINT Modules_ModuleId_PK PRIMARY KEY,
    [QualificationId] INT 
		CONSTRAINT Modules_QualificationId_FK FOREIGN KEY REFERENCES dbo.Qualifications(QualificationId),
    [Name] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(256)
);
