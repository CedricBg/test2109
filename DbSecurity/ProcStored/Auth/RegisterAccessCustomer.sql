CREATE PROCEDURE [dbo].[RegisterAccessCustomer]
	@Login VARCHAR(50),
	@Password VARCHAR(50),
	@Id int
As
Begin
Set NOCOUNT ON
	
	DECLARE @IDUser TABLE  
(  
    id INT  
); 

	DECLARE @SecretKey VARCHAR(200)
	SET @SecretKey  = dbo.GetSecretKey()

	Declare @Salt VARCHAR(100)
	SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @password_hash VARBINARY(64)
	SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt,@SecretKey,@Password, @Salt))

	INSERT INTO Users (Salt,Password_hash,[Login])
	OUTPUT inserted.IdUser INTO  @IDUser
	Values(@Salt, @password_hash,@Login)

	UPDATE Customer SET IdUsers = (SELECT id FROM @IDUser) where IdCustomer = @Id

End
