CREATE TABLE [dbo].[Addresses]
(
    AddressId INT IDENTITY(1,1) 
        CONSTRAINT Addresses_AddressId_PK PRIMARY KEY,
    OrganisationName VARCHAR(60),
    BuildingName VARCHAR(60),
    BuildingNumber VARCHAR(10),
    Street VARCHAR(60),
    Village VARCHAR(60),
    Town VARCHAR(60),
    City VARCHAR(60),
    Postcode VARCHAR(10),
    Country VARCHAR(60),
    PoBox VARCHAR(10)
);
