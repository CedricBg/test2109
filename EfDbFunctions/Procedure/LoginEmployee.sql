CREATE PROCEDURE [dbo].[Loginemployee]
	@Login VARCHAR(50),
	@Password VARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON

	DECLARE @salt VARCHAR(100)
	DECLARE @password_hash VARBINARY(64)
	DECLARE @SecretKey VARCHAR(200)
	DECLARE @IdUser INT

	SELECT @SecretKey = dbo.GetSecretKey(),
           @salt = Salt
    FROM Users
    WHERE Login = @Login;

	
	SET @password_hash = HASHBYTES('SHA2_256', CONCAT(@salt, @SecretKey, @Password, @salt))

IF EXISTS(
	SELECT *
	FROM Users
	WHERE Password_hash = @password_hash
	AND Login = @Login
)
BEGIN
	SET @IdUser = (SELECT Id FROM Users WHERE (Password_hash = @password_hash AND ([Login] = @Login)))

	SELECT E.[SurName], E.firstName, E.Id, R.DiminName AS Dimin , R.[Name]  AS [Role], E.[SurName] as Token
	FROM DetailedEmployees E, Users U , Roles R
	WHERE U.[Login] = @Login
	and U.Password_hash = @password_hash
	and E.UserId = U.Id 
	and E.RoleId = R.roleId
END
ELSE
BEGIN
	DECLARE @ErrorMessage VARCHAR(255)
	SET @ErrorMessage = 'Utilisateur ou mot de passe incorrect.'
	RAISERROR(100, 100, @ErrorMessage)
END
END
