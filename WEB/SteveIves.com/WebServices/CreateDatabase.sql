USE [steveives]
GO

/* DROP FOREIGN KEYS FROM TABLES */

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Airport_Country]') AND parent_object_id = OBJECT_ID(N'[dbo].[Airport]'))
ALTER TABLE [dbo].[Airport] DROP CONSTRAINT [FK_Airport_Country]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Airline_Country]') AND parent_object_id = OBJECT_ID(N'[dbo].[Airline]'))
ALTER TABLE [dbo].[Airline] DROP CONSTRAINT [FK_Airline_Country]
GO

/* DROP TABLES */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Airport]') AND type in (N'U'))
DROP TABLE [dbo].[Airport]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Airline]') AND type in (N'U'))
DROP TABLE [dbo].[Airline]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
DROP TABLE [dbo].[Country]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* CREATE COUNTRY TABLE */

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Country](
	[CountryCode] [char](2) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*  CREATE THE AIRPORT TABLE */

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Airport](
	[AirportCode] [char](3) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[City] [varchar](50) NULL,
	[Region] [varchar](30) NULL,
	[CountryCode] [char](2) NOT NULL,
	[WebSite] [varchar](50) NULL,
   CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED ([AirportCode] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Airport]
   WITH CHECK ADD  CONSTRAINT [FK_Airport_Country]
   FOREIGN KEY([CountryCode])
   REFERENCES [dbo].[Country]([CountryCode])
GO

ALTER TABLE [dbo].[Airport]
   CHECK CONSTRAINT [FK_Airport_Country]
GO

/* CREARE AIRLINE TABLE */

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Airline](
	[IcaoCode] [char](3) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CallSign] [varchar](25) NULL,
	[CountryCode] [char](2) NOT NULL,
	[FlightPrefix] [char](2) NOT NULL,
	[WebSite] [varchar](50) NULL,
   CONSTRAINT [PK_Airline] PRIMARY KEY CLUSTERED ( [IcaoCode] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Airline]
   WITH CHECK ADD  CONSTRAINT [FK_Airline_Country]
   FOREIGN KEY([CountryCode])
   REFERENCES [dbo].[Country]([CountryCode])
GO

ALTER TABLE [dbo].[Airline]
   CHECK CONSTRAINT [FK_Airline_Country]
GO

/* LOAD COUNTRY DATA */

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AD', 'Andorra')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AE', 'United Arab Emirates')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AF', 'Afghanistan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AG', 'Antigua and Barbuda')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AI', 'Anguilla')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AL', 'Albania')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AM', 'Armenia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AN', 'Netherland Antilles')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AO', 'Angola')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AQ', 'Antarctica')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AR', 'Argentina')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AS', 'American Samoa')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AT', 'Austria')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AU', 'Australia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AW', 'Aruba')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('AZ', 'Azerbaijan')

INSERT INTO [Dbo].[Country]
   (CountryCode, Name)
   VALUES('BA', 'Bosnia - Herzegovina')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BB', 'Barbados')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BD', 'Bangladesh')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BE', 'Belgium')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BF', 'Burkina Faso')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BG', 'Bulgaria')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BH', 'Bahrain')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BI', 'Burundi')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BJ', 'Benin')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BM', 'Bermuda')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BN', 'Brunei Darussalam')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BO', 'Bolivia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BR', 'Brazil')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BS', 'Bahamas')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BT', 'Bhutan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BV', 'Bouvet Island')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BW', 'Botswana')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BY', 'Belarus')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('BZ', 'Belize')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CA', 'Canada')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CC', 'Cocos (Keeling) Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CF', 'Central African Republic')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CG', 'Congo')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CH', 'Switzerland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CI', 'Ivory Coast')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CK', 'Cook Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CL', 'Chile')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CM', 'Cameroon')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CN', 'China')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CO', 'Colombia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CR', 'Costa Rica')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CU', 'Cuba')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CV', 'Cape Verde')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CX', 'Christmas Island')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CY', 'Cyprus')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('CZ', 'Czech Republic')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DE', 'Germany')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DJ', 'Djibouti')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DK', 'Denmark')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DM', 'Dominica')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DO', 'Dominican Republic')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('DZ', 'Algeria')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('EC', 'Ecuador')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('EE', 'Estonia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('EG', 'Egypt')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('EH', 'Western Sahara')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ER', 'Eritrea')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ES', 'Spain')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ET', 'Ethiopia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FI', 'Finland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FJ', 'Fiji')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FK', 'Falkland Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FM', 'Micronesia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FO', 'Faroe Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('FR', 'France')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GA', 'Gabon')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GD', 'Grenada')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GE', 'Georgia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GF', 'Guyana')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GH', 'Ghana')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GI', 'Gibraltar')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GL', 'Greenland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GM', 'Gambia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GN', 'Guinea')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GP', 'Guadeloupe')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GQ', 'Equatorial Guinea')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GR', 'Greece')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GS', 'South Georgia & South Sandwich Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GT', 'Guatemala')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GU', 'Guam')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GW', 'Guinea Bissau')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('GY', 'Guyana')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HK', 'Hong Kong')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HM', 'Heard & McDonald Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HN', 'Honduras')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HR', 'Croatia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HT', 'Haiti')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('HU', 'Hungary')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ID', 'Indonesia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IE', 'Ireland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IL', 'Israel')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IN', 'India')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IO', 'British Indian Ocean Terr.')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IQ', 'Iraq')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IR', 'Iran')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IS', 'Iceland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('IT', 'Italy')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('JM', 'Jamaica')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('JO', 'Jordan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('JP', 'Japan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KE', 'Kenya')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KG', 'Kyrgyz Republic')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KH', 'Cambodia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KI', 'Kiribati')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KM', 'Comoros')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KN', 'St. Kitts Nevis Anguilla')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KP', 'Korea (North)')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KR', 'Korea (South)')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KW', 'Kuwait')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KY', 'Cayman Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('KZ', 'Kazachstan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LA', 'Laos')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LB', 'Lebanon')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LC', 'Saint Lucia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LI', 'Liechtenstein')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LK', 'Sri Lanka')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LR', 'Liberia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LS', 'Lesotho')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LT', 'Lithuania')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LU', 'Luxembourg')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LV', 'Latvia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('LY', 'Libya')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MA', 'Morocco')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MC', 'Monaco')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MD', 'Moldova')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MG', 'Madagascar')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MH', 'Marshall Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MK', 'Macedonia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ML', 'Mali')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MM', 'Myanmar')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MN', 'Mongolia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MO', 'Macau')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MP', 'Northern Mariana Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MQ', 'Martinique')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MR', 'Mauritania')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MS', 'Montserrat')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MT', 'Malta')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MU', 'Mauritius')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MV', 'Maldives')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MW', 'Malawi')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MX', 'Mexico')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MY', 'Malaysia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('MZ', 'Mozambique')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NA', 'Namibia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NC', 'New Caledonia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NE', 'Niger')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NF', 'Norfolk Island')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NG', 'Nigeria')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NI', 'Nicaragua')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NL', 'Netherlands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NO', 'Norway')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NP', 'Nepal')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NR', 'Nauru')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NU', 'Niue')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('NZ', 'New Zealand')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('OM', 'Oman')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PA', 'Panama')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PE', 'Peru')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PF', 'Polynesia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PG', 'Papua New Guinea')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PH', 'Philippines')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PK', 'Pakistan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PL', 'Poland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PM', 'St. Pierre & Miquelon')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PN', 'Pitcairn')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PR', 'Puerto Rico')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PT', 'Portugal')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PW', 'Palau')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('PY', 'Paraguay')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('QA', 'Qatar')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('RE', 'Reunion')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('RO', 'Romania')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('RU', 'Russian Federation')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('RW', 'Rwanda')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SA', 'Saudi Arabia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SB', 'Solomon Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SC', 'Seychelles')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SD', 'Sudan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SE', 'Sweden')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SG', 'Singapore')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SH', 'St. Helena')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SI', 'Slovenia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SJ', 'Svalbard& Jan Mayen Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SK', 'Slovakia (Slovak Republic)')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SL', 'Sierra Leone')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SM', 'San Marino')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SN', 'Senegal')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SO', 'Somalia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SR', 'Suriname')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ST', 'St. Tome and Principe')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SV', 'El Salvador')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SY', 'Syria')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('SZ', 'Swaziland')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TC', 'Turks& Caicos Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TD', 'Chad')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TF', 'French Southern Territory')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TG', 'Togo')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TH', 'Thailand')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TJ', 'Tadjikistan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TK', 'Tokelau')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TM', 'Turkmenistan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TN', 'Tunisia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TO', 'Tonga')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TP', 'East Timor')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TR', 'Turkey')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TT', 'Trinidad Tobago')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TV', 'Tuvalu')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TW', 'Taiwan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('TZ', 'Tanzania')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UA', 'Ukraine')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UG', 'Uganda')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UK', 'United Kingdom')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UM', 'US Minor outlying Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('US', 'United States')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UY', 'Uruguay')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('UZ', 'Uzbekistan')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VA', 'Vatican City State')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VC', 'St. Vincent& Grenadines')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VE', 'Venezuela')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VG', 'Virgin Islands (British)')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VI', 'Virgin Islands (American)')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VN', 'Vietnam')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('VU', 'Vanuatu')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('WF', 'Wallis & Futuna Islands')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('WS', 'Samoa')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('YE', 'Yemen')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('YT', 'Mayotte')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ZA', 'South Africa')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ZM', 'Zambia')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ZR', 'Zaire')

INSERT INTO [dbo].[Country]
   (CountryCode, Name)
   VALUES('ZW', 'Zimbabwe')

GO


/* LOAD AIRPORT DATA */

INSERT INTO [dbo].[Airport]
	(AirportCode, Name, City, Region, CountryCode, WebSite)
	VALUES('SMF','Sacramento International Airport','Sacramento','CA','US','')

INSERT INTO [dbo].[Airport]
	(AirportCode, Name, City, Region, CountryCode, WebSite)
	VALUES('ORD','O''Hare International Airport','Chicago','IL','US','')

GO	

/* LOAD AIRLINE DATA */

INSERT INTO [dbo].[Airline]
	(IcaoCode, Name, CallSign, CountryCode, FlightPrefix, WebSite)
	VALUES('AAL','American Airlines','AMERICAN','US','AA','http://www.aa.com')

INSERT INTO [dbo].[Airline]
	(IcaoCode, Name, CallSign, CountryCode, FlightPrefix, WebSite)
	VALUES('NWA','Northwest Airlines','NORTHWEST','US','NW','http://www.nwa.com')

INSERT INTO [dbo].[Airline]
	(IcaoCode, Name, CallSign, CountryCode, FlightPrefix, WebSite)
	VALUES('SWA','Southwest Airlines','SOUTHWEST','US','SW','http://www.southwest.com')

INSERT INTO [dbo].[Airline]
	(IcaoCode, Name, CallSign, CountryCode, FlightPrefix, WebSite)
	VALUES('UAL','United Airlines','UNITED','US','UA','http://www.united.com')

GO	
