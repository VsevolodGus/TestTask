using TestTask.Solution;
using TestTask.WorkFile;

var space = GettingSpace.GetModelSpaceFromFile();
var spaceService = new SpaceService();
Console.WriteLine(spaceService.CountAsteroidInSpace(space));
