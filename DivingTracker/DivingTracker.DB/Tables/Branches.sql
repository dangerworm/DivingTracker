CREATE TABLE [dbo].[Branches]
(
    BranchId INT IDENTITY(1,1) 
		CONSTRAINT Branches_BranchId_PK PRIMARY KEY,
    AgencyId INT NOT NULL 
		CONSTRAINT Branches_AgencyId_FK FOREIGN KEY REFERENCES dbo.Agencies(AgencyId),
    ChairUserId INT 
		CONSTRAINT Branches_ChairUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    SecretaryUserId INT 
		CONSTRAINT Branches_SecretaryUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    TreasurerUserId INT 
        CONSTRAINT Branches_TreasurerUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    DivingOfficerUserId INT 
        CONSTRAINT Branches_DivingOfficerUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    ContactAddressId INT 
        CONSTRAINT Branches_ContactAddressId_FK FOREIGN KEY REFERENCES dbo.Addresses(AddressId),
    PoolAddressId INT 
        CONSTRAINT Branches_PoolAddressId_FK FOREIGN KEY REFERENCES dbo.Addresses(AddressId),
    ContactEmail VARCHAR(100),
    ContactLandLine VARCHAR(50),
    ContactMobile VARCHAR(50)
);