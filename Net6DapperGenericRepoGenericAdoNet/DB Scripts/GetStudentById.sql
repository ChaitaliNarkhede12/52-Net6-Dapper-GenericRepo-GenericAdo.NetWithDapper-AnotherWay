CREATE PROCEDURE [dbo].[GetStudentById]
@Id Int
AS
BEGIN
		SELECT * FROm [dbo].[Student] WHERE Id = @Id
END