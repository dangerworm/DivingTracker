CREATE TABLE [dbo].[Addresses]
(
    AddressId INT IDENTITY(1,1) 
        CONSTRAINT Addresses_AddressId_PK PRIMARY KEY,
    OrganisationName VARCHAR(100),
    BuildingName VARCHAR(60),
    BuildingNumber VARCHAR(10),
    Street VARCHAR(60),
    Village VARCHAR(60),
    Town VARCHAR(60),
    Postcode VARCHAR(10),
    County VARCHAR(60),
    Country VARCHAR(60),
    PoBox VARCHAR(10)
);
