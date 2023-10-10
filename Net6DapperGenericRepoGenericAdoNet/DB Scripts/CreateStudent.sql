CREATE PROCEDURE [dbo].[CreateStudent]
@Name VARCHAR(40),
@EmailId VARCHAR(40)
AS
BEGIN
		INSERT INTO [dbo].[Student]
		VALUES (@Name,@EmailId)
END