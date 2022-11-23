SELECT [Person].[FirstName], [Person].[LastName], [Person].[BirthYear]
FROM [Person]
WHERE [Person].[BirthYear] >= 2000
ORDER BY [Person].[LastName], [Person].[FirstName]