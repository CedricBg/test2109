CREATE PROCEDURE [dbo].[Loginemployee]
	@Login VARCHAR(50),
	@Password VARCHAR(50)

AS
Begin
	Set NOCOUNT ON
	DECLARE @SecretKey VARCHAR(200)
	SET @SecretKey = dbo.GetSecretKey()



	DECLARE @salt VARCHAR(100)
	SET @salt = (SELECT Salt  FROM Users WHERE  Login = @Login)

	DECLARE @password_hash VARBINARY(64)
	SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@salt, @SecretKey, @Password, @salt))


	Select Top 1 E.[SurName], E.firstName, E.Id, R.[Name] as Role
	from DetailedEmployees E, Users U , Roles R
	Where Password_hash = @password_hash
	and E.UserId = U.Id 
	and U.[Login] = @Login
	and E.RoleId = R.Id
	
End 
