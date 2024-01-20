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
           @salt = Salt,
           @IdUser = Id
    FROM Users
    WHERE Login = @Login;

	SET @password_hash = HASHBYTES('SHA2_256', CONCAT(@salt, @SecretKey, @Password, @salt))

	SELECT E.[SurName], E.firstName, E.Id, R.DiminName AS Dimin , R.[Name]  AS [Role], E.[SurName] as Token
	FROM DetailedEmployees E
	INNER JOIN Users U ON E.UserId = U.Id
	INNER JOIN Roles R ON E.RoleId = R.roleId
	WHERE U.[Login] = @Login
	AND U.Password_hash = @password_hash
	AND U.Id = @IdUser

	IF @@ROWCOUNT = 0
	BEGIN
		DECLARE @ErrorMessage VARCHAR(255)
		SET @ErrorMessage = 'Utilisateur ou mot de passe incorrect.'
		RAISERROR(100, 100, @ErrorMessage)
	END
END
