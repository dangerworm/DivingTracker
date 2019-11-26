IF NOT EXISTS (SELECT 1 FROM dbo.SystemLogins)
BEGIN
	INSERT INTO 
		dbo.SystemLogins(EmailAddress, PasswordHash, PasswordSalt, EmailConfirmationToken, IsEmailConfirmed)
	VALUES
		('dangerworm+student@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '9B871B2F-8F15-4310-B43E-D4895D24ACEC', 1),
		('dangerworm+instructor@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '45A9BCE2-661F-4980-9106-596984CA5CEC', 1),
		('dangerworm+admin@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '8B630B25-4289-48E5-A743-D687F539C581', 1),
		('gergo@gmail.com', 'Ko6Uu7pJCXdUCXiGLvgBrCnHXAP4ezMDCwPHkePwzSEZvulC3Yg9WtoWyPgpYVJNCWOiMx4Dunb9Vk/eXSNk9g==', 'vUhHimbRTRFlsOMHlZBn8jMCr8luXGyCDDXb2kHFhwvfXX8IY4wwfb3L4zVkbPQEmHsVOLGcstlW2flvCcSBX/Uhuta9U89rrvz2TAKSx9StcugHqQ59PRchN1q4lvduw0GTr3aqfYPp52OJEXRew5eaIXVoHgXdlLYNZIP9oTU=', 'E26DD79B-38C1-45CB-B323-F328D3334B5E', 1),
		('sam@gmail.com', 'cgAadshEtl6EAsUfW178b34KTYhGfv+W3ArZBpAS85Ji2maGjyxHuOIEW5tkeVO5UbPffWMSuo2UC5jqBU8lhg==', '89Uk+BRJNv5V/OyPtK18JbDIPQ8bCIcxTShXtD1YPJT/t02Ir2iuBkydQUplgrNrGCE6hX3tBsnxTj8ZTO+9Y4JswKIZPW13zIy4QkhZygjfLg3pm4ai6tMpcFTp4dxnZJULkb3K6b/AxOIMlGrJNqYozxqcD7IKT13JOXukx+Y=', '4E83D0B6-EB69-45B8-A268-1DCB85A2300D', 1),
		('hannah@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),

        /* 123456789 */
		('larissa@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('emily@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('haodong@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('sarah@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('george@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('elizabeth@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('antonin@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('yuyan@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('harry@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('kasia@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('wojciech@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1),
		('ellie@gmail.com', '544deb0JQb/jbxmB+clhI4rvaGGnkMWQMDYNeOjcpPflDnmEcom/7U+3Zh5dvIqwzEj4jGQBJ+jz7zSXwQfmEA==', '+z1EolMdWnFvyopJ1rxcDaPx+tgMjV6xC9bdi8IzxcwSvnVd4RJ16+O11qicgZ3K+C35BQppVBSRw1O48zlC3UW9gysZzQbfHcxB+58HmPZPBXDbwP8/VI3PN0jrDsbmeLBKnWU1L8/oCzyhqeYdCdWZqy4hhL40/oEcYjpZUDM=', '62F0945D-5DC1-4A8D-9F1B-FD2B3ED0EA82', 1)
END

IF NOT EXISTS (SELECT 1 FROM dbo.SystemRoles)
BEGIN
	INSERT INTO 
		dbo.SystemRoles([Description])
	VALUES
        ('Unknown'),
		('Student'),
		('Instructor'),
		('Admin')
END

IF NOT EXISTS (SELECT 1 FROM dbo.Addresses)
BEGIN
    INSERT INTO 
        dbo.Addresses(OrganisationName, BuildingName, BuildingNumber, Street, Village, Town, County, Postcode, PoBox, Country)
    VALUES
        ('British Sub-Aqua Club', 'Telford''s Quay', NULL, 'South Pier Road', NULL, 'Ellesmere Port', 'Cheshire', 'CH65 4FL', NULL, 'United Kingdom'),
		('Confédération Mondiale des Activités Subaquatiques (World Underwater Federation)', 'CMAS Headquarters', '74', 'Viale Tiziano', NULL, 'Roma', NULL, '00196', NULL, 'Italy'),
		('Scuba Diving International', NULL, '1321', 'SE Decker Avenue', NULL, 'Stuart', 'Florida', '34994', NULL, 'United States'),
		('Scuba Schools International', 'Head UK Ltd.', '2', 'Beezon Road', NULL, 'Kendal', 'Cumbria', 'LA9 6BW', NULL, 'United Kingdom'),
        ('Manchester University Sub Aqua Branch', 'University of Manchester Students'' Union', NULL, 'Oxford Road', NULL, 'Manchester', NULL, 'M13 9PR', NULL, 'United Kingdom'),
        ('Manchester Aquatics Centre', NULL, '2', 'Booth Street East', NULL, 'Manchester', NULL, 'M13 9SS', NULL, 'United Kingdom')
END

IF NOT EXISTS (SELECT 1 FROM dbo.Agencies)
BEGIN
	INSERT INTO
		dbo.Agencies(AddressId, [Name], [Description], ContactEmail, ContactLandLine, ContactMobile)
	VALUES 
		(1, 'BSAC', 'British Sub-Aqua Club', NULL, '+44 (0) 208 6385934', NULL),
		(2, 'CMAS', 'Confédération Mondiale des Activités Subaquatiques (World Underwater Federation)', NULL, NULL, NULL),
		(3, 'SDI', 'Scuba Diving International', NULL, NULL, NULL),
		(4, 'SSI', 'Scuba Schools International', NULL, NULL, NULL)
END

IF NOT EXISTS (SELECT 1 FROM dbo.Branches)
BEGIN
	INSERT INTO
		dbo.Branches(AgencyId, ChairUserId, SecretaryUserId, TreasurerUserId, DivingOfficerUserId,
        ContactAddressId, PoolAddressId, ContactEmail, ContactLandLine, ContactMobile)
	VALUES 
		(1, NULL, NULL, NULL, NULL, 5, 6, 'dangerworm+gergo@gmail.com', '07654 123456', '01234 567890')
END

IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN
	INSERT INTO 
		dbo.Users(SystemLoginId, SystemRoleId, BranchId, FirstName, Surname, DateOfBirth)
	VALUES
/*  1 */	( 1, 1, 1, 'Drew', 'Student', '19800101'),
/*  2 */	( 2, 2, 1, 'Drew', 'Instructor', '19800101'),
/*  3 */	( 3, 3, 1, 'Drew', 'Admin', '19800101'),
/*  4 */	( 4, 3, 1, 'Gergo', 'Pinter', '19800101'),
/*  5 */	( 5, 3, 1, 'Sam', 'Humphreys', '19800101'),
/*  6 */	( 6, 3, 1, 'Hannah', 'Perkins', '19800101'),
    
/*  7 */	( 7, 0, 1, 'Larissa', 'Bailey', '20000101'),
/*  8 */	( 8, 0, 1, 'Emily', 'Songhurst', '20000101'),
/*  9 */	( 9, 0, 1, 'Haodong', 'Guo', '20000101'),
/* 10 */	(10, 0, 1, 'Sarah', 'Stocks', '20000101'),
/* 11 */	(11, 0, 1, 'George', 'Rayner', '20000101'),
/* 12 */	(12, 0, 1, 'Elizabeth', 'Johnston', '20000101'),
/* 13 */	(13, 0, 1, 'Antonin', 'Hudec', '20000101'),
/* 14 */	(14, 0, 1, 'Yuyan', 'Wang', '20000101'),
/* 15 */	(15, 0, 1, 'Harry', 'Moss', '20000101'),
/* 16 */	(16, 0, 1, 'Kasia', 'de Kock Jewell', '20000101'),
/* 17 */	(17, 0, 1, 'Wojciech', 'Czosnyka', '20000101'),
/* 18 */	(18, 0, 1, 'Ellie', 'Mercala', '20000101');

UPDATE
    dbo.Branches
SET
    ChairUserId = 4,
    SecretaryUserId = 6,
    TreasurerUserId = 5,
    DivingOfficerUserId = 4
WHERE
    BranchId = 1
END

IF NOT EXISTS (SELECT 1 FROM dbo.QualificationTypes)
BEGIN
	INSERT INTO 
		dbo.QualificationTypes([Description])
	VALUES
		('Diving'),
		('Instructor')
END

IF NOT EXISTS (SELECT 1 FROM dbo.Qualifications)
BEGIN
	INSERT INTO 
		dbo.Qualifications([AgencyId], [QualificationTypeId], [Name], [Description])
	VALUES
		/* BSAC */
		(  1, 1, 'Drysuit Diver', NULL),
		(  1, 1, 'Ocean Diver', NULL),
		(  1, 1, 'Sports Diver', NULL),
		(  1, 2, 'Assistant Diving Instructor (IFC)', NULL),
		(  1, 1, 'Dive Leader', NULL),
		(  1, 2, 'Assistant Open Water Instructor (OWIC)', NULL),
		(  1, 2, 'Open Water Instructor', NULL),
		(  1, 1, 'Advanced Diver', NULL),
		(  1, 2, 'Advanced Instructor', NULL),
		(  1, 1, 'First Class Diver', NULL),
		(  1, 2, 'National Instructor', NULL);

END

IF NOT EXISTS (SELECT 1 from dbo.UserQualifications)
BEGIN
	INSERT INTO
		dbo.UserQualifications(UserId, QualificationId, UpdatedDate)
	VALUES
		/* Drew (Student) */
		(  1, 1, '20170818'),
		(  1, 5, '20180211'),
		(  1, 6, '20181024'),
		
		/* Drew (Instructor) */
		(  2, 7, '20190101'),
		(  2, 8, '20190101'),
        
        /* Drew (Admin) */
		(  3, 1, '20190101'),
		(  3, 3, '20190101'),

        /* Gergo */
		(  4, 1, '20190101'),

        /* Sam */
		(  5, 1, '20190101'),

        /* Hannah */
		(  6, 1, '20191117');
END

IF NOT EXISTS (SELECT 1 FROM dbo.Modules)
BEGIN
	INSERT INTO
		dbo.Modules(QualificationId, [Name], [Description])
	VALUES
		(  2, 'OS1', 'Being underwater'),
		(  2, 'OS2', 'Basic skills'),
		(  2, 'OS3', 'Developing skills'),
		(  2, 'OS4', 'Beyond the basics'),
		(  2, 'OS5', 'Safety skills'),
	   
		(  2, 'OT1', 'Adapting to the underwater world'),
		(  2, 'OT2', 'The body and effects of diving'),
		(  2, 'OT3', 'Going diving'),
		(  2, 'OT4', 'Dive planning'),
		(  2, 'OT5', 'What happens if?'),
		(  2, 'OT6', 'Enjoying your diving'),
	   
		(  2, 'OO1', 'Introduction to open water'),
		(  2, 'OO2', 'Developing open water skills'),
		(  2, 'OO3', 'Open water rescue skills'),
		(  2, 'OO4', 'Buddy diving skills'),

        (  4, 'IFC', 'Instructor Foundation Course'),

        (  6, 'OWIC', 'Open Water Instructor Course');
END

IF NOT EXISTS (SELECT 1 FROM dbo.ModuleSections)
BEGIN
	INSERT INTO
		dbo.ModuleSections(ModuleId, [Name], [Description])
	VALUES
		/* OS1 */
		(  1, 'Fit and use mask, fins and snorkel - standing depth', NULL),
		(  1, 'Fit and use scuba - standing depth', NULL),
		(  1, 'Buoyancy control - standing depth', NULL),
		(  1, 'Swimming underwater - deeper water', NULL),
		(  1, 'Remove scuba - standing depth', NULL),
		(  1, 'Equipment care', NULL ),

		/* OS2 */
		(  2, 'Kit assembly', NULL),
		(  2, 'Kit-up, buddy check, dry run and entry', NULL),
		(  2, 'Surface and underwater swimming, buoyancy control', NULL),
		(  2, 'Mask and demand valve clearing - standing depth', NULL),
		(  2, 'Use of alternative supply (AS) - standing depth', NULL),
		(  2, 'Exit and dekit', NULL),
	
		/* OS3 */
		(  3, 'Kit-up and buddy check, dry run, stride entry', NULL),
		(  3, 'Buoyancy control and descent/ascent procedures', NULL),
		(  3, 'Mask clearing - deeper water', NULL),
		(  3, 'Use of alternative supply (AS) - deeper water', NULL),
		(  3, 'Exit from deeper water and dekit', NULL),

		/* OS4 */
		(  4, 'Kit-up and buddy check, backward-roll entry', NULL),
		(  4, 'Master basic skills', NULL),
		(  4, 'Extend mobility skills', NULL),
		(  4, 'De-kit in water, exit suitable for small boat', NULL),

		/* OS5 */
		(  5, 'Kit-up and buddy check, dry run, forward-roll entry', NULL),
		(  5, 'Master alternative-supply skills', NULL),
		(  5, 'Controlled buoyant lift (CBL)', NULL),
		(  5, 'Towing', NULL),
		(  5, 'Rescue CBL', NULL),
		(  5, 'Exit from deeper water and de-kit', NULL),

		(  6, 'Attend OT1', NULL),
		(  7, 'Attend OT2', NULL),
		(  8, 'Attend OT3', NULL),
		(  9, 'Attend OT4', NULL),
		( 10, 'Attend OT5', NULL),
		( 11, 'Attend OT6', NULL),

		/* OO1 */
		( 12, 'Kit-up and buddy check, dry run and entry', NULL),
		( 12, 'Adjust weighting and achieve neutral buoyancy - standing depth', NULL),
		( 12, 'Exploratory dive - 4-6m', NULL),
		( 12, 'Skills practice - 2-3m', NULL),
		( 12, 'Exit - standing depth', NULL),
	
		/* OO2 */
		( 13, 'Kit-up and buddy check, dry run and entry', NULL),
		( 13, 'Skills practice at 4-6m', NULL),
		( 13, 'Exploratory dive - 7-10m', NULL),
		( 13, 'Exit - standing depth', NULL),
	
		/* OO3 */
		( 14, 'Kit-up and buddy check, dry run and entry', NULL),
		( 14, 'Skills practice - 4-6m', NULL),
		( 14, 'Exploratory dive - 12-15m (maximum)', NULL),
		( 14, 'Ascent and exit - deep water', NULL),
	
		/* OO4 */
		( 15, 'Kit-up and buddy check', NULL),
		( 15, 'Dive leading practice - 14-17m (maximum)', NULL),
		( 15, 'Skills practice - 4-6m', NULL),
		( 15, 'Exit - deep water', NULL),

        /* IFC */
        ( 16, 'Attend IFC', NULL),

        /* OWIC */
        ( 17, 'Attend OWIC', NULL);
END

IF NOT EXISTS (SELECT 1 FROM dbo.Criteria)
BEGIN
	INSERT INTO
		dbo.Criteria(ModuleSectionId, [Description], Details, IncludeInSyllabus)
	VALUES
		/* OS1 */
		(  1, 'Entry into shallow water without equipment by ladder or wading', NULL, 1),
		(  1, 'Mask demisting/fitting', NULL, 1),
		(  1, 'Secure snorkel', NULL, 1),
		(  1, 'Breathe through snorkel, face submerged, static', NULL, 1),
		(  1, 'Flood snorkel/clear by blowing (static, standing)', NULL, 1),
		(  1, 'Fit fins, finning action on back and front', NULL, 1),
		(  1, 'Flood/clear snorkel, face submerged, while finning', NULL, 1),
		(  1, 'Remove fins, mask and snorkel', NULL, 1),
	   
		(  2, 'Fit weight belt (if needed), scuba unit and carry out buddy check', NULL, 1),
		(  2, 'Entry into shallow water by ladder/wading (or kit up in water)', NULL, 1),
		(  2, 'Breathe from demand valve', NULL, 1),
		(  2, 'Use of hand signals', NULL, 1),
		(  2, 'Fit fins', NULL, 1),
	   
		(  3, 'Use of BC controls (inflate and deflate)', NULL, 1),
		(  3, 'Swim on back with BC inflated - on the surface', NULL, 1),
		(  3, 'Swim on front with BC inflated - on the surface', NULL, 1),
		(  3, 'Descend and adjust for neutral buoyancy - kneeling - lying flat - hover', NULL, 1),
		(  3, 'Check trim', NULL, 1),
		(  3, 'Underwater swim, develop finning action - constant depth', NULL, 1),
		(  3, 'Monitor instruments - throughout module', NULL, 1),
	   
		(  4, 'Buoyancy adjustment with changing depth', NULL, 1),
		(  4, 'Underwater use of hand signals', NULL, 1),
		(  4, 'Practice finning action', NULL, 1),
		(  4, 'Instrument monitoring', NULL, 1),
	   
		(  5, 'Remove fins, weight belt', NULL, 1),
		(  5, 'Remove scuba', NULL, 1),
		(  5, 'Exit from shallow water by ladder or wading', NULL, 1),

		(  6, 'Wash kit', NULL, 1),

		/* OS2 */
		(  7, 'Assemble scuba equipment', NULL, 1),
		(  7, 'Functionally check equipment', NULL, 1),
	
		(  8, 'Fit weight belt (if needed), scuba unit and carry out buddy check', NULL, 1),
		(  8, 'Dry run demand valve clear by exhaling', NULL, 1),
		(  8, 'Dry run demand valve clear with purge button', NULL, 1),
		(  8, 'Fit mask and regulator', NULL, 1),
		(  8, 'Entry into shallow water by ladder or wading', NULL, 1),
		(  8, 'Fit fins - standing depth', NULL, 1),
	
		(  9, 'Swimming on surface, on front and back, BC inflated', NULL, 1),
		(  9, 'Buoyancy check - standing depth', NULL, 1),
		(  9, 'Swim underwater to deeper water - maintain buoyancy and trim', NULL, 1),
		(  9, 'Controlled ascent and descent using BC - deeper water', NULL, 1),
		(  9, 'Swimming underwater to standing depth', NULL, 1),
		(  9, 'Monitor instruments - throughout module', NULL, 1),
	
		( 10, 'Breathing without mask, nose submerged', NULL, 1),
		( 10, 'Mask clearing - no strap - face partially submerged', NULL, 1),
		( 10, 'Mask clearing - no strap - face fully submerged', NULL, 1),
		( 10, 'Mask clearing - with strap - partial flood', NULL, 1),
		( 10, 'Mask clearing - with strap - progressive flood', NULL, 1),
		( 10, 'Mask clearing - with strap - full flood', NULL, 1),
		( 10, 'Demand valve mouthpiece clearing (exhale and purge valve)', NULL, 1),
		( 10, 'Underwater retrieval and clearing of demand valve', NULL, 1),
	
		( 11, 'Underwater use of out of gas signal', NULL, 1),
		( 11, 'Use of alternative supply - donor', NULL, 1),
		( 11, 'Use of alternative supply - recipient', NULL, 1),
	
		( 12, 'Remove fins', NULL, 1),
		( 12, 'Exit from shallow water by ladder or wading', NULL, 1),
		( 12, 'De-kit', NULL, 1),
		( 12, 'Wash kit', NULL, 1),
	  	
		/* OS3 */
		( 13, 'Assemble scuba equipment and check functionality', NULL, 1),
		( 13, 'Kit-up and buddy check', NULL, 1),
		( 13, 'Dry run - action for BC inflator hose stuck open', NULL, 1),
		( 13, 'Stride entry - into deeper water', NULL, 1),
	
		( 14, 'Demand valve and snorkel exchange while surface swimming', NULL, 1),
		( 14, 'Controlled descent into deeper water', NULL, 1),
		( 14, 'Efficient underwater swimming - changing depth', NULL, 1),
		( 14, 'BC inflator stuck open', NULL, 1),
		( 14, 'Mid-water hover', NULL, 1),
		( 14, 'Controlled buoyancy on ascent and surfacing procedure', NULL, 1),
	
		( 15, 'Mask clearing in standing depth', NULL, 1),
		( 15, 'Breathing from a free flowing demand valve - standing depth', NULL, 1),
		( 15, 'Mask clearing in deeper water', NULL, 1),
	
		( 16, 'Out of gas signal', NULL, 1),
		( 16, 'Static AS - as donor', NULL, 1),
		( 16, 'Static AS - as recipient', NULL, 1),
		( 16, 'AS ascent -  as donor', NULL, 1),
		( 16, 'AS ascent -  as recipient', NULL, 1),
		( 16, 'Surface actions following AS ascent', NULL, 1),

		( 17, 'Deep water exit via ladder', NULL, 1),
		( 17, 'De-kit', NULL, 1),
		( 17, 'Wash kit', NULL, 1),
	
		/* OS4 */
		( 18, 'Assemble scuba equipment and check functionality', NULL, 1),
		( 18, 'Kit-up and buddy check', NULL, 1),
		( 18, 'Backward-roll entry - deep water', NULL, 1),
	
		( 19, 'Controlled descent into deeper water', NULL, 1),
		( 19, 'Adjust for neutral buoyancy', NULL, 1),
		( 19, 'Buddy-diving techniques and monitor instruments', NULL, 1),
		( 19, 'Efficient underwater swimming - changing depth', NULL, 1),
		( 19, 'Remove and replace mask in deeper water', NULL, 1),
		( 19, 'Finning without a mask', NULL, 1),
	
		( 20, 'Surface snorkel swim in full scuba kit', NULL, 1),
		( 20, 'Controlled descent into deeper water', NULL, 1),
		( 20, 'Frog kick', NULL, 1),
		( 20, 'Forward rolls in deeper water', NULL, 1),
		( 20, 'Ascent in buddy pairs from deeper water', NULL, 1),
	
		( 21, 'Exit pool (simulated boat exit)', NULL, 1),
		( 21, 'Wash kit', NULL, 1),

		/* OS5 */
		( 22, 'Assemble scuba equipment and check functionality', NULL, 1),
		( 22, 'Kit-up and buddy check', NULL, 1),
		( 22, 'Dry run CBL (controlled buoyant lift)', NULL, 1),
		( 22, 'Forward-roll entry - deep water', NULL, 1),
	
		( 23, 'Surface actions post AS ascent', NULL, 1),
		( 23, 'AS ascent - donor, with surface actions', NULL, 1),
		( 23, 'AS ascent - recipient, with surface actions', NULL, 1),
		( 23, 'AS on horizontal swim', NULL, 1),
	
		( 24, 'Self-lift', NULL, 1),
		( 24, 'Mini CBL', NULL, 1),
		( 24, 'CBL', NULL, 1),
	
		( 25, 'Towing hold', NULL, 1),
		( 25, 'Tow (progressively increase distance to 25m)', NULL, 1),
		( 25, 'Alternative holds', NULL, 1),
	
		( 26, 'Surface actions', NULL, 1),
		( 26, 'Initial underwater contact', NULL, 1),
		( 26, 'Rescue CBL', NULL, 1),
		( 26, 'Rescue CBL and surface tow', NULL, 1),
	
		( 27, 'Deeper water exit', NULL, 1),
		( 27, 'Remove equipment', NULL, 1),
		( 27, 'Wash kit', NULL, 1),

        ( 28, 'Attend Ocean Diver Theory lecture 1', NULL, 1),
        ( 29, 'Attend Ocean Diver Theory lecture 2', NULL, 1),
        ( 30, 'Attend Ocean Diver Theory lecture 3', NULL, 1),
        ( 31, 'Attend Ocean Diver Theory lecture 4', NULL, 1),
        ( 32, 'Attend Ocean Diver Theory lecture 5', NULL, 1),
        ( 33, 'Attend Ocean Diver Theory lecture 6', NULL, 1),

        ( 34, 'Prepare scuba unit, fit wetsuit / dry suit, prepare weights', NULL, 1),
        ( 34, 'Kit-up', NULL, 1),
        ( 34, 'Conduct buddy check', NULL, 1),
        ( 34, 'Dry run of the "inflator hose stuck open" exercise', NULL, 1),
        ( 34, 'Fit mask and check seal', NULL, 1),
        ( 34, 'Shore entry by wading or steps into standing depth', NULL, 1),
        
        ( 35, 'Buoyancy check and weight adjustment', NULL, 1),
        ( 35, 'Maintain hover', NULL, 1),
        ( 35, 'Check trim', NULL, 1),
        
        ( 36, 'Signals', NULL, 1),
        ( 36, 'Buoyancy control & weight check', NULL, 1),
        ( 36, 'Swimming, orientation, awareness', NULL, 1),
        
        ( 37, 'Mask clearing including removal and replacement', NULL, 1),
        ( 37, 'Demand valve retrieval and clear', NULL, 1),
        ( 37, 'Dry suit inflator stuck open (if worn)', NULL, 1),
        ( 37, 'BC inflator stuck open', NULL, 1),
        ( 37, 'Dry suit inversion recovery (if worn)', NULL, 1),

        ( 38, 'Weight belt / weight jettison', NULL, 1),
        ( 38, 'Exit water by wading or steps', NULL, 1),
        ( 38, 'De-kit', NULL, 1),
        ( 38, 'Report back to Dive Manager', NULL, 1),
        ( 38, 'Equipment disassembly and care', NULL, 1),

        ( 51, 'Attend the Instructor Foundation Course', NULL, 1),
        ( 52, 'Attend the Open Water Instructor Course', NULL, 1);
END

IF NOT EXISTS (SELECT 1 FROM dbo.CriterionStatuses)
BEGIN
	INSERT INTO 
		dbo.CriterionStatuses([Description])
	VALUES
		('Unknown'),
		('Not Started'),
		('Needs Consolidation'),
		('Complete');
END

IF NOT EXISTS (SELECT 1 FROM dbo.UserCriteria)
BEGIN
	INSERT INTO 
		dbo.UserCriteria(UserId, CriterionId, CriterionStatusId, AwardedByUserId, UpdatedDate)
	VALUES
		(1,   1, 3, 2, SYSDATETIME()),
		(1,   2, 3, 2, SYSDATETIME()),
		(1,   3, 3, 2, SYSDATETIME()),
		(1,   4, 3, 2, SYSDATETIME()),
		(1,   5, 3, 2, SYSDATETIME()),
		(1,   6, 2, 2, SYSDATETIME()),
		(1,   7, 3, 2, SYSDATETIME()),
		(1,   8, 3, 2, SYSDATETIME()),
		(1,   9, 2, 2, SYSDATETIME()),
		(1,  10, 3, 2, SYSDATETIME()),
		(1,  11, 3, 2, SYSDATETIME()),
		(1,  12, 3, 2, SYSDATETIME()),
		(1,  13, 3, 2, SYSDATETIME()),
		(1,  14, 3, 2, SYSDATETIME()),
		(1,  15, 3, 2, SYSDATETIME()),
		(1,  16, 3, 2, SYSDATETIME()),
		(1,  17, 3, 2, SYSDATETIME()),
		(1,  18, 3, 2, SYSDATETIME()),
		(1,  19, 3, 2, SYSDATETIME()),
		(1,  20, 3, 2, SYSDATETIME()),
        (1,  21, 3, 2, SYSDATETIME()),
		(1,  22, 3, 2, SYSDATETIME()),
		(1,  23, 3, 2, SYSDATETIME()),
		(1,  24, 3, 2, SYSDATETIME()),
		(1,  25, 2, 2, SYSDATETIME()),
		(1,  26, 3, 2, SYSDATETIME()),
		(1,  27, 3, 2, SYSDATETIME()),
		(1,  28, 3, 2, SYSDATETIME()),
		(1,  29, 3, 2, SYSDATETIME()),
		(1,  30, 3, 2, SYSDATETIME()),
		(1,  31, 2, 2, SYSDATETIME()),
		(1,  32, 3, 2, SYSDATETIME()),
		(1,  33, 3, 2, SYSDATETIME()),
		(1,  34, 3, 2, SYSDATETIME()),
		(1,  35, 3, 2, SYSDATETIME()),
		(1,  36, 3, 2, SYSDATETIME()),
		(1,  37, 2, 2, SYSDATETIME()),
		(1,  38, 3, 2, SYSDATETIME()),
		(1,  39, 3, 2, SYSDATETIME()),
		(1,  40, 3, 2, SYSDATETIME()),
        (1,  41, 3, 2, SYSDATETIME()),
		(1,  42, 3, 2, SYSDATETIME()),
		(1,  43, 3, 2, SYSDATETIME()),
		(1,  44, 3, 2, SYSDATETIME()),
		(1,  45, 3, 2, SYSDATETIME()),
		(1,  46, 3, 2, SYSDATETIME()),
		(1,  47, 3, 2, SYSDATETIME()),
		(1,  48, 3, 2, SYSDATETIME()),
		(1,  49, 2, 2, SYSDATETIME()),
		(1,  50, 3, 2, SYSDATETIME()),
        (1,  51, 3, 2, SYSDATETIME()),
		(1,  52, 3, 2, SYSDATETIME()),
		(1,  53, 3, 2, SYSDATETIME()),
		(1,  54, 3, 2, SYSDATETIME()),
		(1,  55, 3, 2, SYSDATETIME()),
		(1,  56, 2, 2, SYSDATETIME()),
		(1,  57, 3, 2, SYSDATETIME()),
		(1,  58, 3, 2, SYSDATETIME()),
		(1,  59, 2, 2, SYSDATETIME()),
		(1,  60, 3, 2, SYSDATETIME()),
        (1,  61, 3, 2, SYSDATETIME()),
		(1,  62, 3, 2, SYSDATETIME()),
		(1,  63, 3, 2, SYSDATETIME()),
		(1,  64, 3, 2, SYSDATETIME()),
		(1,  65, 2, 2, SYSDATETIME()),
		(1,  66, 3, 2, SYSDATETIME()),
		(1,  67, 3, 2, SYSDATETIME()),
		(1,  68, 3, 2, SYSDATETIME()),
		(1,  69, 3, 2, SYSDATETIME()),
		(1,  70, 3, 2, SYSDATETIME()),
		(1,  71, 2, 2, SYSDATETIME()),
		(1,  72, 3, 2, SYSDATETIME()),
		(1,  73, 3, 2, SYSDATETIME()),
		(1,  74, 3, 2, SYSDATETIME()),
		(1,  75, 3, 2, SYSDATETIME()),
		(1,  76, 2, 2, SYSDATETIME()),
		(1,  77, 3, 2, SYSDATETIME()),
		(1,  78, 2, 2, SYSDATETIME()),
		(1,  79, 3, 2, SYSDATETIME()),
		(1,  80, 3, 2, SYSDATETIME()),
        (1,  81, 3, 2, SYSDATETIME()),
		(1,  82, 3, 2, SYSDATETIME()),
		(1,  83, 3, 2, SYSDATETIME()),
		(1,  84, 3, 2, SYSDATETIME()),
		(1,  85, 3, 2, SYSDATETIME()),
		(1,  86, 3, 2, SYSDATETIME()),
		(1,  87, 3, 2, SYSDATETIME()),
		(1,  88, 3, 2, SYSDATETIME()),
		(1,  89, 3, 2, SYSDATETIME()),
		(1,  90, 3, 2, SYSDATETIME()),
        (1,  91, 3, 2, SYSDATETIME()),
		(1,  92, 3, 2, SYSDATETIME()),
		(1,  93, 3, 2, SYSDATETIME()),
		(1,  94, 3, 2, SYSDATETIME()),
		(1,  95, 1, NULL, SYSDATETIME()),
		(1,  96, 1, NULL, SYSDATETIME()),
		(1,  97, 1, NULL, SYSDATETIME()),
		(1,  98, 1, NULL, SYSDATETIME()),
		(1,  99, 1, NULL, SYSDATETIME()),
        (1, 101, 1, NULL, SYSDATETIME()),
        (1, 102, 1, NULL, SYSDATETIME()),
		(1, 103, 1, NULL, SYSDATETIME()),
		(1, 104, 1, NULL, SYSDATETIME()),
		(1, 105, 1, NULL, SYSDATETIME()),
		(1, 106, 1, NULL, SYSDATETIME()),
		(1, 107, 1, NULL, SYSDATETIME()),
		(1, 108, 1, NULL, SYSDATETIME()),
		(1, 109, 1, NULL, SYSDATETIME()),
		(1, 110, 1, NULL, SYSDATETIME()),
		(1, 111, 1, NULL, SYSDATETIME()),
		(1, 112, 1, NULL, SYSDATETIME()),
		(1, 113, 1, NULL, SYSDATETIME()),
		(1, 114, 1, NULL, SYSDATETIME()),
		(1, 115, 1, NULL, SYSDATETIME()),
		(1, 116, 1, NULL, SYSDATETIME());
END


