CREATE TABLE [dbo].[Clubs]
(
    ClubId INT IDENTITY(1,1) 
		CONSTRAINT Clubs_ClubId_PK PRIMARY KEY,
    AgencyId INT NOT NULL 
		CONSTRAINT Clubs_AgencyId_FK FOREIGN KEY REFERENCES dbo.Agencies(AgencyId),
    ChairUserId INT 
		CONSTRAINT Clubs_ChairUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    SecretaryUserId INT 
		CONSTRAINT Clubs_SecretaryUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    TreasurerUserId INT 
        CONSTRAINT Clubs_TreasurerUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    DivingOfficerUserId INT 
        CONSTRAINT Clubs_DivingOfficerUserId_FK FOREIGN KEY REFERENCES dbo.Users(UserId),
    ContactAddressId INT 
        CONSTRAINT Clubs_ContactAddressId_FK FOREIGN KEY REFERENCES dbo.Addresses(AddressId),
    PoolAddressId INT 
        CONSTRAINT Clubs_PoolAddressId_FK FOREIGN KEY REFERENCES dbo.Addresses(AddressId),
    ContactEmail VARCHAR(100),
    ContactMobile VARCHAR(50),
    ContactLandLine VARCHAR(50)
);