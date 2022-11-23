SELECT COUNT([Person].[Id]) AS 'Nombre de personnes'
FROM [Person]
INNER JOIN [Group] ON [Group].[Id] = [Person].[IDGroup]
INNER JOIN [Project] ON [Project].[Id] = [Group].[IDProject]
WHERE [Project].[Id] = 4
