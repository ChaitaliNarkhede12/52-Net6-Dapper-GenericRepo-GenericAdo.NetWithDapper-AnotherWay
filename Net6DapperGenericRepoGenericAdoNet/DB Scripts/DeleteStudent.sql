CREATE PROCEDURE [dbo].[DeleteStudent]
@Id Int
AS
BEGIN
		DELETE FROM  [dbo].[Student]
		WHERE Id = @Id
END