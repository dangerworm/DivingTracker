CREATE TABLE [dbo].[CriterionStatuses]
(
    [CriterionStatusId] INT IDENTITY(1,1) 
		CONSTRAINT CriterionStatuses_CriterionStatusId_PK PRIMARY KEY,
    [Description] VARCHAR(50) NOT NULL
);
