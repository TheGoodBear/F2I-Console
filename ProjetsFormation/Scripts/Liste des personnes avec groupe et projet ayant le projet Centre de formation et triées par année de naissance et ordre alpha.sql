SELECT COUNT([Person].[Id])
	[Person].[FirstName], 
	[Person].[LastName],
	[Person].[BirthYear],
	[Group].[Number],
	[Group].[Name] AS 'Groupe',
	[Project].[Name] AS 'Projet'
FROM [Person]
INNER JOIN [Group] ON [Group].[Id] = [Person].[IDGroup]
INNER JOIN [Project] ON [Project].[Id] = [Group].[IDProject]
WHERE [Project].[Id] = 4
ORDER BY 
	[Person].[BirthYear], 
	[Person].[LastName], 
	[Person].[FirstName]