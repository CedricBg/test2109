CREATE PROCEDURE [dbo].[UpdateAccessContractor]
	@Login VARCHAR(50),
	@Password VARCHAR(50),
	@New_Password VARCHAR(50)
As
Begin

	DECLARE @SecretKey VARCHAR(200)
	SET @SecretKey  = dbo.GetSecretKey()

	Declare @Salt VARCHAR(100)
	Set @Salt = (Select Salt from Users where Login = @Login)

	DECLARE @password_hashOld VARBINARY(64)
	SET @password_hashOld = HASHBYTES('SHA2_512', CONCAT(@Salt,@SecretKey,@Password, @Salt))

	DECLARE @password_hashNew VARBINARY(64)
	SET @password_hashNew = HASHBYTES('SHA2_512', CONCAT(@Salt,@SecretKey,@New_Password, @Salt))

	
	If((SELECT Password_hash FROM Users where Login = @Login) = @password_hashOld)
	Begin
	  UPDATE Users SET Password_hash = @password_hashNew where Login = @Login
	end
end