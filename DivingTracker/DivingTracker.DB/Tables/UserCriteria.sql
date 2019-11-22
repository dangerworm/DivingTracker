CREATE TABLE [dbo].[UserCriteria]
(
	[UserId] INT IDENTITY(1,1)
		CONSTRAINT UserCriteria_UserId_PK PRIMARY KEY 
		CONSTRAINT UserCriteria_UserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    [CriterionId] INT 
		CONSTRAINT UserCriteria_CriterionId_FK FOREIGN KEY REFERENCES dbo.Criteria(CriterionId),
    [CriterionStatusId] INT 
		CONSTRAINT UserCriteria_CriterionStatusId_FK FOREIGN KEY REFERENCES dbo.CriterionStatuses(CriterionStatusId)
		CONSTRAINT UserCriteria_CriterionStatusId_DF DEFAULT(0),
    [AwardedByUserId] INT
		CONSTRAINT UserCriteria_AwardedByUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    [UpdatedDate] DATETIME2(3) 
		CONSTRAINT UserCriteria_UpdatedDate_DF DEFAULT(SYSDATETIME())
);
