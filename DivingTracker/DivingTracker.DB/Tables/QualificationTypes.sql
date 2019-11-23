CREATE TABLE [dbo].[QualificationTypes]
(
    [QualificationTypeId] INT IDENTITY(1,1)
		CONSTRAINT QualificationTypes_QualificationTypeId_PK PRIMARY KEY,
    [Description] VARCHAR(50) NOT NULL
);
