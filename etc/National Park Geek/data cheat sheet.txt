park
	parkCode varchar(10) not null,
	parkName varchar(200) not null,
	state varchar(30) not null,
	acreage int not null,
	elevationInFeet int not null,
	milesOfTrail real not null,
	numberOfCampsites int not null,
	climate varchar(100) not null,
	yearFounded int not null,
	annualVisitorCount int not null,
	inspirationalQuote varchar(max) not null,
	inspirationalQuoteSource varchar(200) not null,
	parkDescription varchar(max) not null,
	entryFee int not null,
	numberOfAnimalSpecies int not null,
		constraint pk_park primary key (parkCode)


weather
	parkCode varchar(10) not null,
	fiveDayForecastValue int not null,
	low int not null,
	high int not null,
	forecast varchar(100) not null,
		constraint pk_weather primary key (parkCode, fiveDayForecastValue),
		constraint fk_weather_park foreign key (parkCode) references park (parkCode)

survey_results
	surveyId int identity(1,1) not null,
	parkCode varchar(10) not null,
	emailAddress varchar(100) not null,
	state varchar(30) not null,
	activityLevel varchar(100) not null,
		constraint pk_survey_result primary key (surveyId),
		constraint fk_survey_result_park foreign key (parkCode) references park (parkCode)
