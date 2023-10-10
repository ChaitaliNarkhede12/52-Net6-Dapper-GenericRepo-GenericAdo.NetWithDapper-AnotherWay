CREATE PROCEDURE [dbo].[UpdateStudent]
@Id Int,
@Name VARCHAR(40),
@EmailId VARCHAR(40)
AS
BEGIN
		UPDATE [dbo].[Student]
		SET
		Name = @Name,
		EmailId = @EmailId
		WHERE Id = @Id
END