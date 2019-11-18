CREATE TABLE [dbo].[SystemLogins]
(
	SystemLoginId INT IDENTITY(1, 1)
		CONSTRAINT SystemLogins_SystemLoginId_PK PRIMARY KEY,
	CreatedDate DATETIME2(3)
		CONSTRAINT SystemLogins_CreatedDate_DF DEFAULT(SYSDATETIME()),
	EmailAddress VARCHAR(256) NOT NULL,
	PasswordHash VARCHAR(256) NOT NULL,
	PasswordSalt VARCHAR(256) NOT NULL,
	EmailConfirmationToken UNIQUEIDENTIFIER NOT NULL,
	IsEmailConfirmed BIT NOT NULL
		CONSTRAINT SystemLogins_IsEmailConfirmed_DF DEFAULT(0)
);

