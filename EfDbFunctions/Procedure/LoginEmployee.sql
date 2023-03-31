CREATE PROCEDURE [dbo].[Loginemployee]
	@Login VARCHAR(50),
	@Password VARCHAR(50)

AS
Begin
	Set NOCOUNT ON
	DECLARE @SecretKey VARCHAR(200)
	SET @SecretKey = dbo.GetSecretKey()

	DECLARE @salt VARCHAR(100)
	SET @salt = (SELECT Salt FROM Users WHERE Login = @Login)

	DECLARE @password_hash VARBINARY(64)
	SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@salt, @SecretKey, @Password, @salt))

	Declare @IdUser INT
	set @IdUser = (SELECT Id from Users WHERE (Password_hash = @password_hash AND ([Login] = @Login)))

	Select E.[SurName], E.firstName, E.Id, R.DiminName as Dimin , R.[Name]  as Role
	from DetailedEmployees E, Users U , Roles R
	Where U.[Login] = @Login
	and U.Password_hash = @password_hash
	and E.UserId = U.Id 
	and E.RoleId = R.roleId
	
End
