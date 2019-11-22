IF NOT EXISTS (SELECT 1 FROM dbo.SystemLogins)
BEGIN
	INSERT INTO 
		dbo.SystemLogins(EmailAddress, PasswordHash, PasswordSalt, EmailConfirmationToken, IsEmailConfirmed)
	VALUES
		('dangerworm+admin@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '8B630B25-4289-48E5-A743-D687F539C581', 1),
		('dangerworm+leadinstructor@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '8F356A7D-D0C3-4DCA-BFE9-A078380EC0BF', 1),
		('dangerworm+instructor@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '45A9BCE2-661F-4980-9106-596984CA5CEC', 1),
		('dangerworm+student@gmail.com', '423czO3+n0TCb/Qcu6Ql98zlQRLH592vbFj7P2hd7DeAEtjVU3FktZURIFX6XFKnSMT/yRC4J8pX/xxnIIAVyA==', 'umPnMkUeGxHTVw5FXw5rJaEhUVkC6A5OqyydLJOhnkuO0/6oka4fUHvRr3FZbTBxYS5zZOP/YORHAuhvGh04nCW9RbWYb1Z6QXaTDbjwitddQNddV+FOyvZlT5XMLayj9GgHm18aH2lQ9lHqnr6allM+2Osdm8p3p02UaV0upTU=', '9B871B2F-8F15-4310-B43E-D4895D24ACEC', 1)
END

IF NOT EXISTS (SELECT 1 FROM dbo.SystemRoles)
BEGIN
	INSERT INTO 
		dbo.SystemRoles([Description])
	VALUES
		('Admin'),
		('Lead Instructor'),
		('Instructor'),
		('Student');
END

IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN
	INSERT INTO 
		dbo.Users(SystemLoginId, SystemRoleId, FirstName, Surname, DateOfBirth)
	VALUES
		(1, 1, 'Drew', 'Morgan', '19800101'),
		(2, 2, 'Drew', 'Morgan', '19800101'),
		(3, 3, 'Drew', 'Morgan', '19800101'),
		(4, 4, 'Drew', 'Morgan', '19800101')
END

IF NOT EXISTS (SELECT 1 FROM dbo.Agencies)
BEGIN
	INSERT INTO
		dbo.Agencies([Name], [Description])
	VALUES 
		('BSAC', 'British Sub Aqua Club'),
		('CMAS', 'Confédération Mondiale des Activités Subaquatiques (World Underwater Federation)'),
		('NAUI', 'National Association of Underwater Instructors'),
		('PADI', 'Professional Association of Diving Instructors'),
		('SDI', 'Scuba Diving International'),
		('SSI', 'Scuba Schools International');
END

IF NOT EXISTS (SELECT 1 FROM dbo.Qualifications)
BEGIN
	INSERT INTO 
		dbo.Qualifications([AgencyId], [Name], [Description])
	VALUES
		/* BSAC */
		(  1, 'Drysuit Diver', NULL),
		(  1, 'Ocean Diver', NULL),
		(  1, 'Sports Diver', NULL),
		(  1, 'Assistant Diving Instructor (IFC)', NULL),
		(  1, 'Dive Leader', NULL),
		(  1, 'Assistant Open Water Instructor (OWIC)', NULL),
		(  1, 'Open Water Instructor', NULL),
		(  1, 'Advanced Diver', NULL),
		(  1, 'Advanced Instructor', NULL),
		(  1, 'First Class Diver', NULL),
		(  1, 'National Instructor', NULL),
	
		/* CMAS */
		(  2, 'Introductory SCUBA', NULL),
		(  2, 'Advanced Skills Diver', NULL),
		(  2, 'Apnoea Diver', NULL),
		(  2, 'Enriched Air Nitrox Diver', NULL),
		(  2, 'Underwater Navigation', NULL),
		(  2, 'Night Diver', NULL),
		(  2, 'Rescue Diver', NULL),
		(  2, 'Wreck Diver', NULL),
		(  2, 'Cave Diver', NULL),

		/* NAUI */
		(  3, 'Try Scuba/Passport Scuba', NULL),
		(  3, 'Tandem Scuba Diver', NULL),
		(  3, 'Scuba Diver', NULL),
		(  3, 'Enriched Air Nitrox (EANx) Diver', NULL),
		(  3, 'Advanced Scuba Diver', NULL),
		(  3, 'Rescue Scuba Diver', NULL),
		(  3, 'Master Scuba Diver', NULL),
		(  3, 'First Aid Provider', NULL),
		(  3, 'Night Diver', NULL),
		(  3, 'Deep Diver', NULL),
		(  3, 'Divemaster', NULL),
		(  3, 'Underwater Imaging', NULL),
		(  3, 'Public Safety Diver', NULL),

		/* PADI */
		(  4, 'Open Water Diver', NULL),
		(  4, 'Advanced Open Water Diver', NULL),
		(  4, 'Rescue Diver', NULL),
		(  4, 'Master Scuba Diver', NULL),
		(  4, 'Divemaster', NULL),
		(  4, 'Adaptive Support Diver', NULL),
		(  4, 'Adventure Diver', NULL),
		(  4, 'Scuba Diver', NULL),
		(  4, 'Assistant Instructor', NULL),
	
		/* SDI */
		(  5, 'Open Water Scuba Diver', NULL),
		(  5, 'Advanced Adventure Diver', NULL),
		(  5, 'Computer Nitrox Diver', NULL),
		(  5, 'Solo Diver', NULL),
		(  5, 'Wreck Diver', NULL),
		(  5, 'Sidemount Diver', NULL),
		(  5, 'Night/Limited Visibility Diver', NULL),
		(  5, 'Rescue Diver', NULL),
		(  5, 'Scubility Diver', NULL),
		(  5, 'Divemaster', NULL),
		(  5, 'Scuba Instructor', NULL),

		/* SSI */
		(  6, 'Scuba Diver', NULL),
		(  6, 'Open Water Diver', NULL),
		(  6, 'Enriched Air Nitrox', NULL),
		(  6, 'Night Diving', NULL),
		(  6, 'Wreck Diving', NULL),
		(  6, 'Deep Diving', NULL),
		(  6, 'Master Diver', NULL);
END

IF NOT EXISTS (SELECT 1 from dbo.UserQualifications)
BEGIN
	INSERT INTO
		dbo.UserQualifications(UserId, QualificationId, UpdatedDate)
	VALUES
		/* Drew */
		(  1, 1, '20170818'),
		(  1, 4, '20171007'),
		(  1, 5, '20180211'),
		(  1, 6, '20181024'),
		
		/* Drew 2 (Lead Instructor) */
		(  2, 1, '20191117'),
		(  2, 8, '20191117'),
		(  2, 9, '20191117');
END

IF NOT EXISTS (SELECT 1 FROM dbo.Modules)
BEGIN
	INSERT INTO
		dbo.Modules(QualificationId, [Name], [Description])
	VALUES
		(  1, 'OS1', 'Being underwater'),
		(  1, 'OS2', 'Basic skills'),
		(  1, 'OS3', 'Developing skills'),
		(  1, 'OS4', 'Beyond the basics'),
		(  1, 'OS5', 'Safety skills'),
	   
		(  1, 'OT1', 'Adapting to the underwater world'),
		(  1, 'OT2', 'The body and effects of diving'),
		(  1, 'OT3', 'Going diving'),
		(  1, 'OT4', 'Dive planning'),
		(  1, 'OT5', 'What happens if?'),
		(  1, 'OT6', 'Enjoying your diving'),
	   
		(  1, 'OO1', 'Introduction to open water'),
		(  1, 'OO2', 'Developing open water skills'),
		(  1, 'OO3', 'Open water rescue skills'),
		(  1, 'OO4', 'Buddy diving skills');
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
		( 15, 'Exit - deep water', NULL);
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
		( 27, 'Wash kit', NULL, 1);
END

IF NOT EXISTS (SELECT 1 FROM dbo.CriterionStatuses)
BEGIN
	INSERT INTO 
		dbo.CriterionStatuses([Description])
	VALUES
		('Unknown'),
		('Module Started'),
		('Needs Consolidation'),
		('Achieved');
END
