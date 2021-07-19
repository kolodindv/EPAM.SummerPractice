use master
GO

IF EXISTS(SELECT *
			FROM sys.databases 
		   WHERE name = 'Achievements')
   BEGIN
	     DROP DATABASE Achievements;
	 END
GO

CREATE DATABASE Achievements
GO

USE Achievements
GO

/*	1 layer	*/

/*	профили пользователей	*/
CREATE TABLE user_profiles(
	PRIMARY KEY (user_id_pk),
	user_login	NVARCHAR(32)		NOT NULL,
	user_pass	VARBINARY(512)		NOT NULL,
	user_id_pk	UNIQUEIDENTIFIER	NOT NULL,
	full_name	NVARCHAR(50)		NOT NULL,
	birth_date	DATETIME			NOT NULL,
				CONSTRAINT user_profiles_format
				CHECK (birth_date	BETWEEN 01-01-1950 AND GETDATE()),
				UNIQUE (user_login),
);
GO


/*	2 layer	*/

/*	все достижения всех пользователей	*/
CREATE TABLE achievements(
	PRIMARY KEY (id_pk),
	id_pk				UNIQUEIDENTIFIER	NOT NULL,
	user_id_pk_fk		UNIQUEIDENTIFIER	NOT NULL,
	heading				NVARCHAR(256)		NOT NULL,
	location_of_receipt	NVARCHAR(256),
	degree				INT,	
	year_of_receipt		SMALLINT,
						CONSTRAINT achievements_format
						FOREIGN KEY	(user_id_pk_fk)	REFERENCES user_profiles(user_id_pk)	ON DELETE CASCADE ON UPDATE CASCADE,
						CHECK (year_of_receipt >= 1950),
						UNIQUE (user_id_pk_fk, heading, location_of_receipt, degree, year_of_receipt),
);
GO