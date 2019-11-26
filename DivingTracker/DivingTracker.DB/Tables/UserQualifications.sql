CREATE TABLE [dbo].[UserQualifications]
(
    [UserQualificationId] INT IDENTITY(1,1)
        CONSTRAINT UserQualifications_UserQualificationId_PK PRIMARY KEY,
    [UserId] INT NOT NULL
		CONSTRAINT UserQualifications_UserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    [QualificationId] INT NOT NULL
		CONSTRAINT UserQualifications_QualificationId_FK FOREIGN KEY REFERENCES dbo.Qualifications(QualificationId),
	[UpdatedDate] DATETIME2(3),

    CONSTRAINT UserQualifications_UQ UNIQUE(UserId, QualificationId)
);
