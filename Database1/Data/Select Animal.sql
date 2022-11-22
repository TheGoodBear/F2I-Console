SELECT 
	[Animal].[Name], 
	[Animal].[Description], 
	[Category].[Name],
	[Animal].[IDCategory] * 5 AS 'Catégorie x 5'
FROM [Animal]
INNER JOIN [Category] ON [Category].[ID] = [Animal].[IDCategory]
WHERE [Animal].[Name] LIKE 'r%'
	AND [Animal].[IDCategory] = 1
ORDER BY [Animal].[Name]