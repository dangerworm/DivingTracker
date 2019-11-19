CREATE TABLE [dbo].[UserQualifications]
(
    [UserQualificationId] INT IDENTITY(1,1) 
		CONSTRAINT UserQualifications_UserQualificationId_PK PRIMARY KEY,
    [UserId] INT 
		CONSTRAINT UserQualifications_UserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    [QualificationId] INT 
		CONSTRAINT UserQualifications_QualificationId_FK FOREIGN KEY REFERENCES dbo.Qualifications(QualificationId),
    [DateAwarded] DATETIME2(3)
);
