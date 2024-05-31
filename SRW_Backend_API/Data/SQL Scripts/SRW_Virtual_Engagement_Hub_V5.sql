-- SRW Virtual Engagement Hub
USE SRWVirtualHub;


-- Remove Existing Tables
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Reservation];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Registration];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Rental];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Equipment];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Opportunity];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[OpportunityType];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[UserRoom];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Room];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[RoomType];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[UserRole];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Role];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[User];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Function];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[ResourceTag];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Tag];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Resource];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Location];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Assistance];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[DatasetType];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Sector];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Dataset];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Training];
DROP TABLE IF EXISTS [SRWVirtualHub].[dbo].[Image];



-- Create Assistance Table
CREATE TABLE [SRWVirtualHub].[dbo].[Assistance] (
	[Assistance_ID]				INT				NOT NULL		IDENTITY(0, 1),	
	[Assistance_First_Name]		VARCHAR(100)	NOT NULL,
	[Assistance_Last_Name]		VARCHAR(100)	NOT NULL,
	[Assistance_Email]			VARCHAR(100)	NOT NULL,
	[Assistance_Phone]			VARCHAR(100),
	[Assistance_Description]	VARCHAR(500)	NOT NULL,
	[Assistance_Resolved]       BIT             NOT NULL		DEFAULT 0,
    PRIMARY KEY (Assistance_ID)
);

-- Create Image Table
CREATE TABLE [SRWVirtualHub].[dbo].[Image] (
	[Image_ID]					INT				NOT NULL		IDENTITY(0, 1),	
	[Image_Name]				VARCHAR(100)	NOT NULL,
    [Image_Address]				VARCHAR(100)	NOT NULL,
    PRIMARY KEY (Image_ID)
);

-- Create Location Table
CREATE TABLE [SRWVirtualHub].[dbo].[Location] (
	[Location_ID]				INT				NOT NULL		IDENTITY(0, 1),	
	[Location_Name]				VARCHAR(100)	NOT NULL,
	[Location_Street]			VARCHAR(100)	NOT NULL,
    [Location_City]				VARCHAR(100)	NOT NULL,
	[Location_County]			VARCHAR(100)	NOT NULL,
    [Location_State]			VARCHAR(100)	NOT NULL,
	[Location_Country]			VARCHAR(100)	NOT NULL,
    [Location_Zip]				VARCHAR(100)	NOT NULL,
    PRIMARY KEY (Location_ID)
);

-- Create Resource Table
CREATE TABLE [SRWVirtualHub].[dbo].[Resource] (
	[Resource_ID]				INT				NOT NULL		IDENTITY(0, 1),	
	[Image_ID]					INT				NOT NULL,
    [Location_ID]				INT,
	[Resource_Name]				VARCHAR(100)	NOT NULL,
	[Resource_Phone]			VARCHAR(100),
	[Resource_Website]			VARCHAR(100),
	[Resource_Eligibility]		VARCHAR(100),
	[Resource_Description]		VARCHAR(500)	NOT NULL,
    PRIMARY KEY (Resource_ID),
	FOREIGN KEY (Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID),
	FOREIGN KEY (Location_ID) REFERENCES [SRWVirtualHub].[dbo].[Location](Location_ID)
);

-- Create Tag Table
CREATE TABLE [SRWVirtualHub].[dbo].[Tag] (
	[Tag_ID]				    INT				NOT NULL		IDENTITY(0, 1),
	[Tag_Name]				    VARCHAR(100)	NOT NULL,
    PRIMARY KEY (Tag_ID)
);

-- Create ResourceTag Table
CREATE TABLE [SRWVirtualHub].[dbo].[ResourceTag] (
	[Resource_ID]				INT				NOT NULL,	
	[Tag_ID]					INT				NOT NULL,
    PRIMARY KEY (Resource_ID, Tag_ID),
	FOREIGN KEY (Resource_ID) REFERENCES [SRWVirtualHub].[dbo].[Resource](Resource_ID),
	FOREIGN KEY (Tag_ID) REFERENCES [SRWVirtualHub].[dbo].[Tag](Tag_ID)
);

-- Create Function Table
CREATE TABLE [SRWVirtualHub].[dbo].[Function] (
	[Function_ID]				INT				NOT NULL        IDENTITY(0, 1),	
	[Image_ID]					INT				NOT NULL,
    [Function_Name]				VARCHAR(100)    NOT NULL,
	[Function_Address]			VARCHAR(100)    NOT NULL,
	[Function_Description]      VARCHAR(500)    NOT NULL,
    PRIMARY KEY (Function_ID),
	FOREIGN KEY (Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID)
);

-- Create User Table
CREATE TABLE [SRWVirtualHub].[dbo].[User] (
	[User_ID]   				INT				NOT NULL        IDENTITY(0, 1),	
    [User_First_Name]			VARCHAR(100)    NOT NULL,
	[User_Last_Name]			VARCHAR(100)    NOT NULL,
	[User_Phone]                VARCHAR(20),
	[User_Email]    			VARCHAR(100)    NOT NULL,
	[User_Password] 			VARCHAR(128)    NOT NULL,
    PRIMARY KEY (User_ID)
);

-- Create Role Table
CREATE TABLE [SRWVirtualHub].[dbo].[Role] (
	[Role_ID]   				INT				NOT NULL        IDENTITY(0, 1),	
    [Role_Name]     			VARCHAR(100)    NOT NULL,
	[Role_Description]			VARCHAR(500)	NOT NULL,
    PRIMARY KEY (Role_ID)
);

-- Create UserRole Table
CREATE TABLE [SRWVirtualHub].[dbo].[UserRole] (
	[User_ID]   				INT				NOT NULL,	
	[Role_ID]					INT				NOT NULL,
    PRIMARY KEY (User_ID, Role_ID),
	FOREIGN KEY (User_ID) REFERENCES [SRWVirtualHub].[dbo].[User](User_ID),
	FOREIGN KEY (Role_ID) REFERENCES [SRWVirtualHub].[dbo].[Role](Role_ID)
);

-- Create RoomType Table
CREATE TABLE [SRWVirtualHub].[dbo].[RoomType] (
	[RoomType_ID]   			INT				NOT NULL        IDENTITY(0, 1),
    [RoomType_Name] 			VARCHAR(100)    NOT NULL,
    PRIMARY KEY (RoomType_ID)
);

-- Create Room Table
CREATE TABLE [SRWVirtualHub].[dbo].[Room] (
	[Room_ID]   				INT				NOT NULL        IDENTITY(0, 1),
	[RoomType_ID]				INT				NOT NULL,
	[Image_ID]					INT				NOT NULL,
    [Room_Name] 				VARCHAR(100)    NOT NULL,
	[Room_Number]			    INT,
	[Room_Floor]                INT             NOT NULL,
	[Room_Description]          VARCHAR(500),
    PRIMARY KEY (Room_ID),
	FOREIGN KEY (RoomType_ID) REFERENCES [SRWVirtualHub].[dbo].[RoomType](RoomType_ID),
	FOREIGN KEY (Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID)
);

-- Create UserRoom Table
CREATE TABLE [SRWVirtualHub].[dbo].[UserRoom] (
	[User_ID]   				INT				NOT NULL,	
	[Room_ID]					INT				NOT NULL,
    PRIMARY KEY (User_ID, Room_ID),
	FOREIGN KEY (User_ID) REFERENCES [SRWVirtualHub].[dbo].[User](User_ID),
	FOREIGN KEY (Room_ID) REFERENCES [SRWVirtualHub].[dbo].[Room](Room_ID)
);

-- Create OpportunityType Table
CREATE TABLE [SRWVirtualHub].[dbo].[OpportunityType] (
	[OpportunityType_ID]   		INT				NOT NULL        IDENTITY(0, 1),
    [OpportunityType_Name] 		VARCHAR(100)    NOT NULL,
    PRIMARY KEY (OpportunityType_ID),
);

-- Create Opportunity Table
CREATE TABLE [SRWVirtualHub].[dbo].[Opportunity] (
	[Opportunity_ID]   			INT				NOT NULL        IDENTITY(0, 1),
	[OpportunityType_ID]		INT,
	[Image_ID]					INT,
	[Location_ID]				INT,
	[Role_ID]					INT,
    [Opportunity_Name] 			VARCHAR(100)    NOT NULL,
	[Opportunity_Host_Name]		VARCHAR(100)	NOT NULL,
    [Opportunity_Email] 		VARCHAR(100),
    [Opportunity_Phone] 		VARCHAR(20),
    [Opportunity_Start_Date] 	DATETIME,
    [Opportunity_End_Date] 	    DATETIME,
	[Opportunity_Description]   VARCHAR(500)	NOT NULL,
    PRIMARY KEY (Opportunity_ID),
	FOREIGN KEY (OpportunityType_ID) REFERENCES [SRWVirtualHub].[dbo].[OpportunityType](OpportunityType_ID),
	FOREIGN KEY (Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID),
	FOREIGN KEY (Location_ID) REFERENCES [SRWVirtualHub].[dbo].[Location](Location_ID),
	FOREIGN KEY (Role_ID) REFERENCES [SRWVirtualHub].[dbo].[Role](Role_ID)
);

-- Create Equipment Table
CREATE TABLE [SRWVirtualHub].[dbo].[Equipment] (
	[Equipment_ID]          	INT				NOT NULL        IDENTITY(0, 1),
	[Image_ID]					INT,
	[Role_ID]					INT,
    [Equipment_Name]      		VARCHAR(100)    NOT NULL,
    [Equipment_Quantity]      	INT             NOT NULL,
    [Equipment_Available]     	INT             NOT NULL,
	[Equipment_Description]     VARCHAR(500)	NOT NULL,
    PRIMARY KEY (Equipment_ID),
	FOREIGN KEY (Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID),
	FOREIGN KEY (Role_ID) REFERENCES [SRWVirtualHub].[dbo].[Role](Role_ID)
);

-- Create Rental Table
CREATE TABLE [SRWVirtualHub].[dbo].[Rental] (
	[Rental_ID]          		INT				NOT NULL        IDENTITY(0, 1),
	[User_ID]					INT             NOT NULL,
	[Equipment_ID]				INT             NOT NULL,
    [Rental_Start_Date]         DATETIME,
    [Rental_End_Date]           DATETIME,
	[Rental_Approved]			BIT             NOT NULL		DEFAULT 0,
    [Rental_Returned]           BIT             NOT NULL		DEFAULT 0,
    PRIMARY KEY (Rental_ID),
	FOREIGN KEY (User_ID) REFERENCES [SRWVirtualHub].[dbo].[User](User_ID),
	FOREIGN KEY (Equipment_ID) REFERENCES [SRWVirtualHub].[dbo].[Equipment](Equipment_ID)
);

-- Create Registration Table
CREATE TABLE [SRWVirtualHub].[dbo].[Registration] (
	[Registration_ID]          	INT				NOT NULL        IDENTITY(0, 1),
	[User_ID]					INT             NOT NULL,
	[Opportunity_ID]			INT             NOT NULL,
    [Registration_Notification] BIT             NOT NULL		DEFAULT 0,
    PRIMARY KEY (Registration_ID),
	FOREIGN KEY (User_ID) REFERENCES [SRWVirtualHub].[dbo].[User](User_ID),
	FOREIGN KEY (Opportunity_ID) REFERENCES [SRWVirtualHub].[dbo].[Opportunity](Opportunity_ID)
);

-- Create Reservation Table
CREATE TABLE [SRWVirtualHub].[dbo].[Reservation] (
	[Reservation_ID]          	INT				NOT NULL        IDENTITY(0, 1),
	[User_ID]					INT             NOT NULL,
	[Room_ID]			        INT             NOT NULL,
	[Reservation_Start_Date]    DATETIME        NOT NULL,
    [Reservation_End_Date]      DATETIME        NOT NULL,
    [Reservation_Notification]  BIT             NOT NULL		DEFAULT 0,
    PRIMARY KEY (Reservation_ID),
	FOREIGN KEY (User_ID) REFERENCES [SRWVirtualHub].[dbo].[User](User_ID),
	FOREIGN KEY (Room_ID) REFERENCES [SRWVirtualHub].[dbo].[Room](Room_ID)
);

-- Create Dataset Type Table
CREATE TABLE [SRWVirtualHub].[dbo].[DatasetType](
	[DatasetType_ID]			INT				NOT NULL		IDENTITY(0,1),
	[DatasetType_Name]			VARCHAR(100)	NOT NULL,
	PRIMARY KEY (DatasetType_ID)
);

-- Create Sector Table
CREATE TABLE [SRWVirtualHub].[dbo].[Sector](
	[Sector_ID]					INT				NOT NULL		IDENTITY(0,1),
	[Sector_Name]				VARCHAR(100)		NOT NULL,
	PRIMARY KEY (Sector_ID)
);

-- Create Dataset Table
CREATE TABLE [SRWVirtualHub].[dbo].[Dataset](
	[Dataset_ID]				INT				NOT NULL		IDENTITY(0,1),
	[DatasetType_ID]			INT				NOT NULL,
	[Sector_ID]					INT				NOT NULL,
	[Dataset_Name]				VARCHAR(200)	NOT NULL,
	[Dataset_Link]				VARCHAR(500)	NOT NULL,
	PRIMARY KEY (Dataset_ID),
	FOREIGN KEY (DatasetType_ID) REFERENCES [SRWVirtualHub].[dbo].[DatasetType](DatasetType_ID),
	FOREIGN KEY (Sector_ID) REFERENCES [SRWVirtualHub].[dbo].[Sector](Sector_ID)
);

-- Create Training Table
CREATE TABLE [SRWVirtualHub].[dbo].[Training](
	[Training_ID]				INT				NOT NULL		IDENTITY(0, 1),
	[Training_Name]				VARCHAR(100)	NOT NULL,
	[Training_Certificate]		VARCHAR(100)	NOT NULL,
	[Training_Link]				VARCHAR(100)	NOT NULL,
	[Training_Description]		VARCHAR(250),
	[Image_ID]					INT				NOT NULL,
	PRIMARY KEY(Training_ID),
	FOREIGN KEY(Image_ID) REFERENCES [SRWVirtualHub].[dbo].[Image](Image_ID)
)


-- Insert Assistance Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Assistance] (Assistance_First_Name, Assistance_Last_Name, Assistance_Email, Assistance_Phone, Assistance_Description, Assistance_Resolved)
VALUES ('John', 'Doe', 'john.doe@gmail.com', '(864)444-4444', 'This is a test description.', 0);

-- Insert Image Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Image] (Image_Name, Image_Address)
VALUES ('Stringer Emergency Lodge', '/Images/Resources/stringer_emergency_lodge.jpg'),
('Anderson Housing Authority', '/Images/Resources/anderson_housing_authority.jpg'),
('Good Shepherds House', '/Images/Resources/good_shepherds_house.jpg'),
('United Housing Connections', '/Images/Resources/united_housing_connections.jpg'),
('Emmanuel''s Hammer', '/Images/Resources/emmanuels_hammer.jpg'),
('Habitat for Humanity', '/Images/Resources/habitat_for_humanity_anderson.jpg'),
('Rebuild Upstate', '/Images/Resources/rebuild_upstate.jpg'),
('Haven of Rest', '/Images/Resources/haven_of_rest.jpg'),
('Family Promise', '/Images/Resources/family_promise.jpg'),
('SC Housing', '/Images/Resources/sc_housing.jpg'),
('United Way of Anderson', '/Images/Resources/united_way_of_anderson.jpg'),
('Clemson Community Care', '/Images/Resources/clemson_community_care.png'),
('Homeless Period Project', '/Images/Resources/homeless_period_project.jpg'),
('HOPE Missions', '/Images/Resources/hope_missions.jpg'),
('Anderson Emergency Soup Kitchen', '/Images/Resources/anderson_emergency_soup_kitchen.jpg'),
('Anderson County Human Resources Office', '/Images/Resources/anderson_county_human_resources_office.jpg'),
('Anderson County Economic Development', '/Images/Resources/anderson_county_economic_development.jpg'),
('Anderson County Library System', '/Images/Resources/anderson_county_library_system.jpg'),
('SC Works WorkLink', '/Images/Resources/sc_works_worklink.jpg'),
('Test Image', '/Images/Test/test.jpg'),
('CEDC', 'Images/cedc.png'),
('Meeting Room', 'Images/Meeting Room.jpg'),
('Kitchen', 'Images/Kitchen.jpg'),
('Office', 'Images/office.jpg');

-- Insert Location Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Location] (Location_Name, Location_Street, Location_City, Location_County, Location_State, Location_Country, Location_Zip)
VALUES ('Stringer Emergency Lodge', '106 906', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Anderson Housing Authority', '1335 E River St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Good Shepherds House', '8595 Pelham Rd', 'Greenville', 'Greenville', 'South Carolina', 'United States', '29615'),
('United Housing Connections', '135 Edinburgh Ct', 'Greenville', 'Greenville', 'South Carolina', 'United States', '29607'),
('Emmanuel''s Hammer', '143 Dry Rock Rd', 'Townville', 'Anderson', 'South Carolina', 'United States', '29689'),
('Habitat for Humanity', '210 S Murray Ave Suite B', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Rebuild Upstate', '601 Green Ave,', 'Greenville', 'Greenville', 'South Carolina', 'United States', '29601'),
('Haven of Rest', '219 W Whitner St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Family Promise', 'P.O. Box 1466', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29621'),
('SC Housing', '300 Outlet Pointe Blvd', 'Columbia', 'Richland', 'South Carolina', 'United States', '29210'),
('United Way of Anderson', '604 N Murray Ave', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29625'),
('Clemson Community Care', '105 Anderson Hwy', 'Clemson', 'Anderson', 'South Carolina', 'United States', '29631'),
('Homeless Period Project', '355 Woodruff Road, Suite 106', 'Greenville', 'Greenville', 'South Carolina', 'United States', '29607'),
('HOPE Missions', '213 S Towers St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Anderson Emergency Soup Kitchen', '1527 South Main St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29626'),
('Anderson County Human Resources Office', 'Anderson County Historic Courthouse, 101 S Main St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29624'),
('Anderson County Economic Development', '1428 Pearman Dairy Rd', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29625'),
('Anderson County Library System', '300 N McDuffie St', 'Anderson', 'Anderson', 'South Carolina', 'United States', '29621'),
('SC Works WorkLink', '1376 Tiger Blvd', 'Clemson', 'Anderson', 'South Carolina', 'United States', '29631'),
('Test Location', '123 Test Rd', 'Test City', 'Test County', 'Test State', 'Test Country', '12345');

-- Insert Resource Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Resource] (Image_ID, Location_ID, Resource_Name, Resource_Phone, Resource_Website, Resource_Eligibility, Resource_Description)
VALUES (0, 0, 'Stringer Emergency Lodge', '864-225-7381', 'https://southernusa.salvationarmy.org/north-south-carolina/', 'Call the above number for eligibility.', 'Provides emergency shelter. It is part of the Salvation Army of Anderson County.'),
(1, 1, 'Anderson Housing Authority', '765-641-2620', 'https://andersonha.org', 'Call the above number for eligibility.', 'A housing agency governed by the U.S. Department of Housing and Urban Development, with commissioners appointed by Anderson’s major. Their goal is to provide affordable housing to low income, elderly, and disabled residents of Anderson County.'),
(2, 2, 'Good Shepherds House', '864-881-2002', 'https://goodshepherdshouse.com', 'Call the above number for eligibility.', 'A social enterprise LLC that provides affordable housing, training, and supportive services.'),
(3, 3, 'United Housing Connections', '864-241-0462', 'https://www.unitedhousingconnections.org', 'Call the above number for eligibility.', 'An organization with a variety of partnerships that provides safe housing options and holistic care to prevent falling into the cycle of homelessness.'),
(4, 4, 'Emmanuel''s Hammer', '864-214-6139', 'https://ehammer1.org', 'Call the above number for eligibility.', 'An organization with a history in disaster relief, that provides critical repairs for houses in need.'),
(5, 5, 'Habitat for Humanity', '864-375-1177', 'https://www.habitat.org', 'Call the above number for eligibility.', 'The Anderson extension of a global organization dedicated to providing safe homes to people.'),
(6, 6, 'Rebuild Upstate', '864-603-2708', 'https://rebuildupstate.org', 'Call the above number for eligibility.', 'An organization that focuses on repairs to preserve homes and keep residents from needing to relocate.'),
(7, 7, 'Haven of Rest', '864-226-6193', 'https://www.havenofrest.cc', 'Call the above number for eligibility.', 'A shelter for men that provides GED classes, recovery classes, job training, and life skills training.'),
(8, 8, 'Family Promise', '864-760-0908', 'https://familypromise.org', 'Call the above number for eligibility.', 'A shelter that assists with case management and financial budgeting service. They work specifically with children and families with children.'),
(9, 9, 'SC Housing', '803-896-9001', 'https://www.schousing.com', 'Call the above number for eligibility.', 'Provides down-payment assistance, and can help match you with a loan with a low,fixed interest rate. It also provides home-buyer training courses.'),
(10, 10, 'United Way of Anderson', '864-226-3438', 'https://www.unitedwayofanderson.org', 'Call the above number for eligibility.', 'Provides rent and utility funding assistance.'),
(11, 11, 'Clemson Community Care', '864-653-4460', 'https://clemsoncommunitycare.org', 'Call the above number for eligibility.', 'Provides utility bill and rental assistance, homeless support, food programs, SNAP applications, back-to-school supplies, home repair, a holiday program, and a referral service.'),
(12, 12, 'Homeless Period Project', '864-438-1157', 'https://homelessperiodproject.org', 'Call the above number for eligibility.', 'Provides products to menstruating individuals.'),
(13, 13, 'HOPE Missions', '864-359-2396', 'https://hopeupstate.org', 'Call the above number for eligibility.', 'A faith-based ministry that provides hot meals,showers, laundry services, hygiene items, bus tickets, and clothing.'),
(14, 14, 'Anderson Emergency Soup Kitchen', '864-224-4763', 'https://andersonemergencykitchen.org', 'Call the above number for eligibility.', 'Provides hot meals.'),
(15, 15, 'Anderson County Human Resources Office', '864-260-4225', 'https://www.andersoncountysc.org/work-live/for-residents/human-resources/', 'Call the above number for eligibility.', 'Recruits, trains, motivates, and rewards qualified employees. Provides a list of current job openings.'),
(16, 16, 'Anderson County Economic Development', '864-260-4386', 'https://acedsc.org', 'Call the above number for eligibility.', 'Facilitates economic development in Anderson County by advising corporations and growing companies about locating or expanding their business in Anderson County.'),
(17, 17, 'Anderson County Library System', '864-260-4500 x 118', 'https://www.andersonlibrary.org', 'Call the above number for eligibility.', 'Provides two designated computers for job hunting, resumes, and/or unemployment claims.'),
(18, 18, 'SC Works WorkLink', '864-642-0466', 'https://worklinkweb.com/en/', 'Call the above number for eligibility.', 'Connects employees to potential jobs, provides employment and training services, helps companies hire quality employees, and funds programs for adults, dislocated workers, youth, and supports employers through training programs. They advertise hiring events, and hold career counseling appointments.');

-- Insert Tag Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Tag] (Tag_Name)
VALUES ('Housing'),
('Food'),
('Employment');

-- Insert ResourceTag Test Data
INSERT INTO [SRWVirtualHub].[dbo].[ResourceTag] (Resource_ID, Tag_ID)
VALUES (0, 0),
(1, 0),
(2, 0),
(3, 0),
(4, 0),
(5, 0),
(6, 0),
(7, 0),
(8, 0),
(9, 0),
(10, 0),
(11, 0),
(12, 0),
(13, 0),
(14, 1),
(15, 2),
(16, 2),
(17, 2),
(18, 2);

-- Insert Function Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Function] (Image_ID, Function_Name, Function_Address, Function_Description)
VALUES (19, 'Test Name', 'Test/test', 'Test Description');

-- Insert User Test Data
INSERT INTO [SRWVirtualHub].[dbo].[User] (User_First_Name, User_Last_Name, User_Phone, User_Email, User_Password)
VALUES ('John', 'Doe', '(864)444-4444', 'john.doe@gmail.com', '$2a$13$nAUa0oYnw.0lYaXLUk.apevv9FRISiUJPH7ay2FJoD.6FCJcnUNdy'),
('Jane','Doe','(864)864-8644','janedoe@gmail.com','$2a$13$nAUa0oYnw.0lYaXLUk.apevv9FRISiUJPH7ay2FJoD.6FCJcnUNdy');


-- Insert Role Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Role] (Role_Name, Role_Description)
VALUES ('General User', 'General user permissions'),
	   ('Admin','Engagement Hub admin');

-- Insert UserRole Test Data
INSERT INTO [SRWVirtualHub].[dbo].[UserRole] (User_ID, Role_ID)
VALUES (0, 0),
	     (1,1);

-- Insert RoomType Test Data
INSERT INTO [SRWVirtualHub].[dbo].[RoomType] (RoomType_Name)
VALUES ('Office'),
('Meeting Room'),
('Kitchen');

-- Insert Room Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Room] (RoomType_ID, Image_ID, Room_Name, Room_Number, Room_Floor, Room_Description)
VALUES (0, 20, 'John''s Office', 123, 1, 'Head of Testing.'),
(1, 20, 'Meeting Room 1', 124, 1, 'Space for Testing Meetings.'),
(1, 21, 'M8810', 8810, 8, 'Large Meeting Room'),
(1, 21, 'M8820', 8820, 8, 'Medium Meeting Room'),
(1, 21, 'M8830', 8830, 8, 'Small Meeting Room'),
(2, 22, 'K8810', 8810, 1, 'First Floor Kitchen'),
(2, 22, 'K8820', 8810, 2, 'Second Floor Kitchen'),
(2, 22, 'K8830', 8810, 3, 'Third Floor Kitchen'),
(0, 23, 'O8810', 8810, 7, 'Small Buisness Office'),
(0, 23, 'O8810', 8820, 7, 'Large Buisness Office'),
(0, 23, 'O8810', 8830, 7, 'Recreational Office');

-- Insert UserRoom Test Data
INSERT INTO [SRWVirtualHub].[dbo].[UserRoom] (User_ID, Room_ID)
VALUES (0, 0),
 (0, 1);

-- Insert OpportunityType Test Data
INSERT INTO [SRWVirtualHub].[dbo].[OpportunityType] (OpportunityType_Name)

VALUES ('ResearchOpportunity_Organization'),
('Event'),
('Internship_Organization'),
('Announcment'),
('Internship_Major'),
('ResearchOpportunity_Major');

-- Insert Opportunity Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Opportunity] (OpportunityType_ID, Image_ID, Location_ID, Role_ID, Opportunity_Name, Opportunity_Host_Name, Opportunity_Email, Opportunity_Phone, Opportunity_Start_Date, Opportunity_End_Date, Opportunity_Description)
VALUES (0, 20, 19, 0, 'Student Government Research', 'Clemson', 'engagement.hub@clemson.edu', '(864)123-4567', '2023-10-20 09:30:00', '2023-10-20 11:30:00', 'All Engagement Hub Staff Must Attend!'),
(3, 19, 19, 0, 'CEDC Summit', 'Clemson','', '', '2024-02-14', '', 'Attend the Clemson Engineers for Developing Communities event'),
(3, 19, 19, 0, 'E-Week','Clemson', '', '', '2024-02-19', '', 'Celebrate Engineering Week with CECAS!'),
(1, 20, 19, 0, 'Event 1', 'Clemson','', '', '2024-02-08', '', 'Come to the quad and check out the event.'),
(1, 20, 19, 0, 'Event 2', 'Clemson','', '', '2024-02-09', '', 'Cook with the chefs in the Cafeteria today at noon.'),
(2, 20, 19, 0, 'Front-end Software Developer', 'Student Government','', '', '', '', 'Must be good with C#, Mudblazor, and blazor.'),
(2, 20, 19, 0, 'Back-end Software Developer', 'Student Government','', '', '', '', 'Familar with database design and SQL'),
(2, 20, 19, 0, 'Managment', 'CEDC','', '', '', '', 'Manager position for interns on piolting of new kisok design'),
(2, 20, 19, 0, 'Community outreach', 'CEDC','', '', '', '', 'Working with the community to gather information for interns'),
(2, 20, 19, 0, 'Undergrad Assistant', 'CEDC','', '', '', '', 'Help manage all realative undergrad internship responsibilities'),
(4, 20, 19, 0, 'Front-end Software Developer', 'Biomedical Sciences','', '', '', '', 'Must be good with C#, Mudblazor, and blazor.'),
(4, 20, 19, 0, 'Back-end Software Developer', 'Biomedical Sciences','', '', '', '', 'Familar with database design and SQL'),
(4, 20, 19, 0, 'Undergrad Assistant', 'Software Engineering','', '', '', '', 'Help manage all realative undergrad internship responsibilities'),
(4, 20, 19, 0, 'Management', 'Software Engineering','', '', '', '', 'Manager position for interns on piolting of new kisok design'),
(4, 20, 19, 0, 'Community outreach', 'Software Engineering','', '', '', '', 'Working with the community to gather information for interns'),
(0, 20, 19, 0, 'CNC Milling Operations', 'Seaway Plastics','', '', '', '', 'Creating molds for plastic injection molding'),
(5, 20, 19, 0, 'CAD Systems Designing', 'Software Engineering','', '', '', '', 'Design Computer Aided Designs');

-- Insert Equipment Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Equipment] (Image_ID, Role_ID, Equipment_Name, Equipment_Quantity, Equipment_Available, Equipment_Description)
VALUES (19, 0, 'Camera', 3, 2, 'Fancy Testing Camera'),
 (20, 1, 'Computer', 99, 2, 'Must be operated in an ergonomic setup for user safety'),
 (20, 1, 'Laptop', 9, 2, 'Use on a stable surface to prevent overheating and discomfort'),
 (20, 1, 'Tablet', 19, 2, 'Ensure proper posture and avoid prolonged use to prevent strain'),
 (20, 1, 'Smartphone', 99, 2, 'Take breaks from screen time to protect your eyes and well-being'),
 (20, 1, 'Printer', 99, 2, 'Handle with care and keep away from flammable materials'),
 (20, 1, 'Monitor', 99, 2, 'Position at eye level and adjust brightness for eye safety'),
 (20, 1, 'Keyboard', 29, 2, 'Keep clean and free of debris to prevent damage and health hazards'),
 (20, 1, 'Mouse', 49, 2, 'Ensure comfortable grip to avoid strain and discomfort'),
 (20, 1, 'Headphones', 39, 2, 'Mind volume levels to protect your hearing health'),
 (20, 1, 'Projector', 9, 2, 'Plastic covers to be removed before turning on the light'),
 (20, 1, 'Smartboard', 99, 2, 'Must be trained by CCIT, making sure that the markers are all on the board before turning on'),
 (20, 1, 'Audio System', 99, 2, 'Sound system for clear communication'),
 (20, 1, 'Refrigerator', 99, 2, 'Large refrigerator for food storage'),
 (20, 1, 'Stove', 99, 2, 'Stove for cooking and food preparation'),
 (20, 1, 'Microwave', 99, 2, 'Microwave for heating food'),
 (20, 1, 'Sink', 99, 2, 'Sink with running water for dishwashing'),
 (20, 1, 'Pantry Shelves', 99, 2, 'Shelves for food storage and organization'),
 (20, 1, '3D Printers', 99, 2, '3D printers for prototyping and creation'),
 (20, 1, 'Laser Cutters', 99, 2, 'Laser cutting machines for precise designs'),
 (20, 1, 'Workbenches', 99, 2, 'Workbenches with tools for DIY projects'),
 (20, 1, 'Soldering Stations', 99, 2, 'Stations for soldering and electronics projects'),
 (20, 1, 'Woodworking Tools', 99, 2, 'Tools for woodworking and carpentry');


 -- Insert Training Test Data
 INSERT INTO [SRWVirtualHub].[dbo].[Training] (Image_ID, Training_Name, Training_Certificate, Training_Link, Training_Description)
	VALUES (20, 'Computer', 'Computer Certificate Level 1', '/Training', ''),
	 (20, 'Laptop', 'Computer Certificate Level 2', '/Training', ''),
	 (20, 'Macbook', 'Computer Certificate Level 3', '/Training', ''),
	 (20, 'Smart Board', 'Computer Certificate Level 4', '/Training', ''),
	 (20, 'Handsaw', 'Machiners Certificate Level 1', '/Training', ''),
	 (20, 'Powersaw', 'Machiners Certificate Level 2', '/Training', ''),
	 (20, 'Lasercutter', 'Machiners Certificate Level 3', '/Training', ''),
	 (20, 'Beltsaw', 'Machiners Certificate Level 4', '/Training', ''),
	 (20, 'Measuring Cups', 'Kitchen Certificate Level 1', '/Training', ''),
	 (20, 'Pasta Maker', 'Kitchen Certificate Level 2', '/Training', ''),
	 (20, 'Mixer', 'Kitchen Certificate Level 3', '/Training', ''),
	 (20, 'Knife Set', 'Kitchen Certificate Level 4', '/Training', ''),
	 (20, 'Automatic Drill', 'Makerspaces Certificate Level 1', '/Training', ''),
	 (20, 'Machine Press', 'Makerspaces Certificate Level 2', '/Training', ''),
	 (20, '3D Printer', 'Makerspaces Certificate Level 3', '/Training', ''),
	 (20, 'CNC Machine', 'Makerspaces Certificate Level 4', '/Training', '');

-- Insert Rental Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Rental] (User_ID, Equipment_ID, Rental_Start_Date, Rental_End_Date, Rental_Approved, Rental_Returned)
VALUES (0, 0, '2023-10-20 09:30:00', '2023-10-20 11:30:00', 0, 0);

-- Insert Registration Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Registration] (User_ID, Opportunity_ID, Registration_Notification)
VALUES (0, 0, 1);

-- Insert Reservation Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Reservation] (User_ID, Room_ID, Reservation_Start_Date, Reservation_End_Date, Reservation_Notification)
VALUES (0, 1, '2023-10-20 09:30:00', '2023-10-20 11:30:00', 1);

-- Insert Sector Test Data
INSERT INTO [SRWVirtualHub].[dbo].[Sector] (Sector_Name)
VALUES  ('Chemical'),
		('Commercial Facilities'),
		('Communications'),
		('Critical Manufacturing'),
		('Dams'),
		('Defense Industrial Base'),
		('Emergency Services'),
		('Energy'),
		('Financial Services'),
		('Food and Agriculture'),
		('Government Facilities'),
		('Healthcare and Public Health'),
		('Information Technology'),
		('Nuclear Reactors, Materials, and Waste'),
		('Transportation Systems'),
		('Water and Wastewater Systems');

-- Insert Dataset Type Test Data
INSERT INTO [SRWVirtualHub].[dbo].[DatasetType] (DatasetType_Name)
VALUES  ('Geodataset'),
		('Planning Tool'),
		('Social');

INSERT INTO [SRWVirtualHub].[dbo].[Dataset] (Dataset_Name, Dataset_Link, DatasetType_ID, Sector_ID)
VALUES  ('Alternative Fuel Corridors','https://geodata.bts.gov/datasets/usdot::alternative-fuel-corridors/about',0,0),
		('SC Children''s Trust', 'https://scchildren.org/resources/research-data/', 2,11),
		('Live Healthy SC','https://livehealthy.sc.gov/data',2,11),
		('National Telecommunications and Information Administration (NTIA)','https://nbam.ntia.gov/pages/open-data',2,2),
		('SC School Report Card','https://ed.sc.gov/data/report-cards/sc-school-report-card/',2,10),
		('FBI Crime Data Explorer','https://cde.ucr.cjis.gov/LATEST/webapp/#/pages/home',2,6),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,1),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,2),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,7),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,9),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,10),
		('SC Socioeconomic Data','https://rfa.sc.gov/data-research/population-demographics/census-state-data-center/socioeconomic-data',2,11),
		('FEMA National Risk Index','https://hazards.fema.gov/nri/',2,6),
		('FEMA National Risk Index','https://hazards.fema.gov/nri/',2,10),
		('FEMA National Risk Index','https://hazards.fema.gov/nri/',2,11),
		('FEMA National Risk Index','https://hazards.fema.gov/nri/',2,14),
		('County Health Rankings','www.countyhealthrankings.org',2,1),
		('County Health Rankings','www.countyhealthrankings.org',2,6),
		('County Health Rankings','www.countyhealthrankings.org',2,9),
		('County Health Rankings','www.countyhealthrankings.org',2,11),
		('County Health Rankings','www.countyhealthrankings.org',2,14),
		('County Health Rankings','www.countyhealthrankings.org',2,15),
		('CDC PLACES','https://www.cdc.gov/places',2,11),
		('Social Capital Atlas','www.socialcapital.org ',2,2),
		('Social Capital Atlas','www.socialcapital.org ',2,8),
		('Social Capital Atlas','www.socialcapital.org ',2,10),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,0),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,1),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,6),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,7),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,8),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,9),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,10),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,11),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,13),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,14),
		('Climate and Economic Justice Screening Tool','https://screeningtool.geoplatform.gov/en/ ',2,15),
		('USDA Food Access Research Atlas','https://www.ers.usda.gov/data-products/food-access-research-atlas/',2,1),
		('USDA Food Access Research Atlas','https://www.ers.usda.gov/data-products/food-access-research-atlas/',2,8),
		('USDA Food Access Research Atlas','https://www.ers.usda.gov/data-products/food-access-research-atlas/',2,9),
		('USDA Food Access Research Atlas','https://www.ers.usda.gov/data-products/food-access-research-atlas/',2,14),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,4),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,6),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,7),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,9),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,11),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,14),
		('SC DHEC Environmental Justice Community Tool','https://sc-dhec.maps.arcgis.com/apps/webappviewer/index.html?id=f8ff40f3e0fb46f2b5209ae9252dc3a0',2,15),
		('SC DSS','https://dss.sc.gov/about/data-and-resources/',2,8),
		('SC DSS','https://dss.sc.gov/about/data-and-resources/',2,9),
		('SC DSS','https://dss.sc.gov/about/data-and-resources/',2,11),
		('SC Rural Infrastructure Authority','https://ria.sc.gov/loans/rates/',2,15),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,1),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,2),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,3),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,6),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,7),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,8),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,9),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,10),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,11),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,12),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,14),
		('Baseline Resilience Indicators for Communities (BRIC)','https://sc.edu/study/colleges_schools/artsandsciences/centers_and_institutes/hvri/data_and_resources/bric/bric_data/index.php',2,15),
		('US Census - American Communities Survey','https://data.census.gov/',2,2),
		('US Census - American Communities Survey','https://data.census.gov/',2,8),
		('US Census - American Communities Survey','https://data.census.gov/',2,9),
		('US Census - American Communities Survey','https://data.census.gov/',2,11),
		('US Census - American Communities Survey','https://data.census.gov/',2,12),
		('US Census - American Communities Survey','https://data.census.gov/',2,14),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,1),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,2),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,4),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,6),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,7),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,8),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,10),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,11),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,12),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,14),
		('FEMA Resilience Analysis and Planning Tool (RAPT)','https://www.fema.gov/emergency-managers/practitioners/resilience-analysis-and-planning-tool',2,15),
		('Health Resources and Services Administration (HRSA)','https://data.hrsa.gov/',2,11),
		('CDC COPEWELL','https://copewellmodel.org/',2,1),
		('CDC COPEWELL','https://copewellmodel.org/',2,2),
		('CDC COPEWELL','https://copewellmodel.org/',2,6),
		('CDC COPEWELL','https://copewellmodel.org/',2,8),
		('CDC COPEWELL','https://copewellmodel.org/',2,9),
		('CDC COPEWELL','https://copewellmodel.org/',2,10),
		('CDC COPEWELL','https://copewellmodel.org/',2,11),
		('CDC COPEWELL','https://copewellmodel.org/',2,14),
		('CDC COPEWELL','https://copewellmodel.org/',2,15);


-- View Tables
SELECT * FROM [SRWVirtualHub].[dbo].[Assistance];
SELECT * FROM [SRWVirtualHub].[dbo].[Image];
SELECT * FROM [SRWVirtualHub].[dbo].[Location];
SELECT * FROM [SRWVirtualHub].[dbo].[Resource];
SELECT * FROM [SRWVirtualHub].[dbo].[ResourceTag];
SELECT * FROM [SRWVirtualHub].[dbo].[Tag];
SELECT * FROM [SRWVirtualHub].[dbo].[Function];
SELECT * FROM [SRWVirtualHub].[dbo].[User];
SELECT * FROM [SRWVirtualHub].[dbo].[Role];
SELECT * FROM [SRWVirtualHub].[dbo].[UserRole];
SELECT * FROM [SRWVirtualHub].[dbo].[RoomType];
SELECT * FROM [SRWVirtualHub].[dbo].[Room];
SELECT * FROM [SRWVirtualHub].[dbo].[UserRoom];
SELECT * FROM [SRWVirtualHub].[dbo].[Opportunity];
SELECT * FROM [SRWVirtualHub].[dbo].[Equipment];
SELECT * FROM [SRWVirtualHub].[dbo].[Rental];
SELECT * FROM [SRWVirtualHub].[dbo].[Registration];
SELECT * FROM [SRWVirtualHub].[dbo].[Reservation];
SELECT * FROM [SRWVirtualHub].[dbo].[Dataset];
SELECT * FROM [SRWVirtualHub].[dbo].[DatasetType];
SELECT * FROM [SRWVirtualHub].[dbo].[Sector];
SELECT * FROM [SRWVirtualHub].[dbo].[OpportunityType];
SELECT * FROM [SRWVirtualHub].[dbo].[Training];