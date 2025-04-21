using ExampleGame;
using Godot;

namespace ExampleGame2000UnitTests;

public class PathfinderServiceTests {

    [Fact]
    public void PathfinderServiceFindPath_From00To20_SimplePath () {
        int[,] map = {
            {1, 1, 1},
            {2, 2, 2},
            {2, 2, 2}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(2,0);

        List<Vector2I> expectedPath = [new Vector2I(1, 0), target];

        Assert.Equal(expectedPath, PathfinderService.FindPath(origin, target, map));
    }

    [Fact]
    public void PathfinderServiceFindPath_From00To20_BlockedPath () {
        int[,] map = {
            {1, -1, 1},
            {2, -1, 2},
            {2, -1, 2}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(2,0);

        Assert.Null(PathfinderService.FindPath(origin, target, map));
    }

    [Fact]
    public void PathfinderServiceFindPath_From00To30_ShouldReturnNull () {
        int[,] map = {
            {1, 1, 1},
            {2, 2, 2},
            {2, 2, 2}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(3,0);

        Assert.Null(PathfinderService.FindPath(origin, target, map));
    }

    [Fact]
    public void PathfinderServiceFindPath_From00To00_ShouldReturnNull () {
        int[,] map = {
            {1, 1, 1},
            {2, 2, 2},
            {2, 2, 2}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(0,0);

        Assert.Null(PathfinderService.FindPath(origin, target, map));
    }

    [Fact]
    public void PathfinderServiceFindPath_From00To20_ComplexPath () {
        int[,] map = {
            {1, -1, 1},
            {1, -1, 1},
            {1,  1, 1}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(2,0);

        List<Vector2I> expectedPath = [
            new Vector2I(0, 1), 
            new Vector2I(0, 2), 
            new Vector2I(1, 2), 
            new Vector2I(2, 2), 
            new Vector2I(2, 1), 
            new Vector2I(2, 0)
        ];

        Assert.Equal(expectedPath, PathfinderService.FindPath(origin, target, map));
    }

        [Fact]
    public void PathfinderServiceFindPath_From00To20WithDifficultTerrain_ComplexPath () {
        int[,] map = {
            {1, 10, 1},
            {1, -1, 1},
            {1,  1, 1}
        };

        Vector2I origin = new Vector2I(0,0);
        Vector2I target = new Vector2I(2,0);

        List<Vector2I> expectedPath = [
            new Vector2I(0, 1), 
            new Vector2I(0, 2), 
            new Vector2I(1, 2), 
            new Vector2I(2, 2), 
            new Vector2I(2, 1), 
            new Vector2I(2, 0)
        ];

        Assert.Equal(expectedPath, PathfinderService.FindPath(origin, target, map));
    }

}