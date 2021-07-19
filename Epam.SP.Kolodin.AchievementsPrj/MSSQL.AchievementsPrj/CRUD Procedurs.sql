USE Achievements
GO

CREATE PROCEDURE AddUserProfile
(
@login		NVARCHAR(32),
@password	VARBINARY(512),
@id			UNIQUEIDENTIFIER,
@fullName	NVARCHAR(50),
@birthDate	DATETIME
)
AS
BEGIN
	INSERT INTO user_profiles (user_login, user_pass, user_id_pk, full_name, birth_date) VALUES  
	(@login, @password, @id,	@fullName,	@birthDate)
END
GO

CREATE PROCEDURE GetUserProfile
(
@id UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT user_id_pk, full_name, birth_date  
	FROM user_profiles 
	WHERE user_id_pk = @id
END
GO

CREATE PROCEDURE GetUserProfileByLogin
(
@login NVARCHAR(32)
)
AS
BEGIN
	SELECT user_id_pk, user_pass    
	FROM user_profiles 
	WHERE user_login = @login
END
GO

CREATE PROCEDURE EditUserProfile
(
@id UNIQUEIDENTIFIER,
@fullName	NVARCHAR(50),
@birthDate	DATETIME
)
AS
BEGIN
	UPDATE user_profiles  
	SET full_name = @fullName, 
		birth_date = @birthDate
	WHERE user_id_pk = @id
END
GO

CREATE PROCEDURE RemoveUserProfile
(
@id UNIQUEIDENTIFIER
)
AS
BEGIN
	DELETE FROM user_profiles 
		WHERE user_id_pk = @id
END
GO


/**************************************************/


CREATE PROCEDURE AddAchievement
(
@id					UNIQUEIDENTIFIER,
@userId				UNIQUEIDENTIFIER,
@heading			NVARCHAR(256),
@locationOfReceipt	NVARCHAR(256),
@degree				INT,
@yearOfReceipt		SMALLINT
)
AS
BEGIN
	INSERT INTO achievements (id_pk, user_id_pk_fk, heading, location_of_receipt, 
		degree, year_of_receipt) VALUES  
	(@id, @userId, @heading, @locationOfReceipt, @degree, @yearOfReceipt)
END
GO

CREATE PROCEDURE GetAchievement
(
@id UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT user_id_pk_fk, heading, location_of_receipt, degree, year_of_receipt  
	FROM achievements 
	WHERE id_pk = @id
END
GO

CREATE PROCEDURE GetUserAchievements
(
@userId UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT id_pk, heading, location_of_receipt, degree, year_of_receipt  
	FROM achievements 
	WHERE user_id_pk_fk = @userId
END
GO

CREATE PROCEDURE EditAchievement
(
@id					UNIQUEIDENTIFIER,
@heading			NVARCHAR(256),
@locationOfReceipt	NVARCHAR(256),
@degree				INT,
@yearOfReceipt		SMALLINT
)
AS
BEGIN
	UPDATE achievements  
	SET heading = @heading,
		location_of_receipt = @locationOfReceipt,
		degree = @degree, 
		year_of_receipt = @yearOfReceipt
	WHERE id_pk = @id
END
GO

CREATE PROCEDURE RemoveAchievement
(
@id UNIQUEIDENTIFIER
)
AS
BEGIN
	DELETE FROM achievements 
		WHERE id_pk = @id
END
GO
