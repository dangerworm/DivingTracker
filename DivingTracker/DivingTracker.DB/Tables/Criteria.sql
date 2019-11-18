CREATE TABLE [dbo].[Criteria]
(
    [CriterionId] INT IDENTITY(1,1)
		CONSTRAINT Criteria_CriterionId_PK PRIMARY KEY,
    [ModuleSectionId] INT 
		CONSTRAINT Criteria_ModuleSectionId_FK FOREIGN KEY REFERENCES dbo.ModuleSections(ModuleSectionId),
    [Description] VARCHAR(100) NOT NULL,
	[Details] VARCHAR(256),
    [IncludeInSyllabus] BIT NOT NULL
		CONSTRAINT Criteria_IncludeInSyllabus_DF DEFAULT(0)
);
