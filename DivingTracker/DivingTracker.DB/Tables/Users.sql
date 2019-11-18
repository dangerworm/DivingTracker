CREATE TABLE [dbo].[Users]
(
    UserId INT IDENTITY(1,1) 
		CONSTRAINT Users_UserId_PK PRIMARY KEY,
	CreatedDate DATETIME2(3)
		CONSTRAINT Users_CreatedDate_DF DEFAULT(SYSDATETIME()),
	SystemLoginId INT
		CONSTRAINT Users_SystemLoginId_FK FOREIGN KEY REFERENCES dbo.SystemLogins(SystemLoginId)
		CONSTRAINT Users_SystemLoginId_UQ UNIQUE (SystemLoginId),
    SystemRoleId INT
		CONSTRAINT Users_SystemRoleId_FK FOREIGN KEY REFERENCES dbo.SystemRoles(SystemRoleId),
    FirstName VARCHAR(256),
    Surname VARCHAR(256),
    DateOfBirth DATETIME2(3)
);
