﻿CREATE TABLE [dbo].[SystemRoles]
(
    [SystemRoleId] INT IDENTITY(0,1)
		CONSTRAINT SystemRoles_SystemRoleId_PK PRIMARY KEY,
    [Description] VARCHAR(50) NOT NULL
);
