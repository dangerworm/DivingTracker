CREATE TABLE [dbo].[ModuleSections]
(
    [ModuleSectionId] INT IDENTITY(1,1) 
		CONSTRAINT ModuleSections_ModuleSectionId_PK PRIMARY KEY,
    [ModuleId] INT
		CONSTRAINT ModuleSections_ModuleId_FK FOREIGN KEY REFERENCES dbo.Modules(ModuleId),
    [Name] VARCHAR(100) NOT NULL,
    [Description] VARCHAR(256)
);
