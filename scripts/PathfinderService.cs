using Godot;
using System.Collections.Generic;
using System.Linq;

namespace ExampleGame;

public partial class PathfinderService
{
	public static List<Vector2I> FindPath(Vector2I origin, Vector2I target, int[,] map) {
		/* 
		 * map is a 2D array of integers that represent the "cost" of travelling to that tile at x, y.
		 * e.g.: 
		 * int[,] map = {
         *   {1,10, 1},
         *   {2,-1, 2},
         *   {2, 2, 2}
         * };
		 * 
		 * origin and target are both Vector2Is that represent coordinates on the given map
		 * If the target or origin are illegal or same, path is illegal
		 */
		if (origin == target || !IsLegalTile(origin, map) || !IsLegalTile(target, map)) return null; 

        Dictionary<Vector2I, int> bestCost = [];
        Dictionary<Vector2I, Vector2I?> bestOrigin = [];
        MinHeap<Vector2I> toSee = new((a) => bestCost[a] + a.DistanceSquaredTo(origin));
        Vector2I current = origin;

        bestCost.Add(current, 0);
        bestOrigin.Add(current, null);

        while (true) {
			// Retrieves all adjacent tile addresses
            List<Vector2I> neighbours = GetPassableNeighbours(current, map);
            foreach (Vector2I neighbour in neighbours) {
                if (current == target) {
					// We've found our target! Now trace it back to origin with the bestOrigin dictionary
                    return TracePath(origin, target, bestOrigin);
                }

                int costToNeighbour = bestCost[current] + GetTileMovementCost(neighbour, map);
                
                
                if (!bestCost.TryGetValue(neighbour, out int value)) {
					// There isn't an existing entry for this in our bestCost/origin dictionaries; add one
                    bestCost.Add(neighbour, costToNeighbour);
                    bestOrigin.Add(neighbour, current);
					// Also add this unseen value to the toSee dictionary
                    toSee.Add(neighbour);
                } else if (value > costToNeighbour) {
					// There is an existing entry, but it's got a higher cost; update it
                    bestCost[neighbour] = costToNeighbour;
                    bestOrigin[neighbour] = current;
                }
            }

            if (toSee.Size == 0) {
				// If there are no more addresses to visit in our toSee heap, the path is impossible
                return null;
            } else {
				// We grab the next item from the toSee heap; because it's a min heap, this will be the closest one to the target
                current = toSee.Pop();
            }
        }
    }

	// Used to generate neighbours
	private static readonly Vector2I[] _directions = [
		Vector2I.Up,
		Vector2I.Right,
		Vector2I.Down,
		Vector2I.Left
	];

	private static List<Vector2I> GetPassableNeighbours(Vector2I target, int[,] map) {
		// Generates a list of neighbours that aren't impassable and are on the board
		// To add non-orthogonal directions, we could add more values to directions and also multiply diagonal cost by √2
		return [.. _directions.Select(v => v + target).Where(v => IsLegalTile(v, map))];
	}
    
	private static int GetTileMovementCost(Vector2I target, int[,] map) {
		// Checks the value at x,y and returns the cost
		return map[target.Y, target.X];
	}

	private static bool IsLegalTile(Vector2I target, int[,] map) {
		int length = map.GetLength(0);
		int width = map.GetLength(1);
		return (
			target.X >= 0 && target.X < width // Out of bounds
			&& target.Y >= 0 && target.Y < length  // Out of bounds
			&& map[target.Y, target.X] > -1); // -1 means impassable!
	}

    private static List<Vector2I> TracePath(Vector2I origin, Vector2I target, Dictionary<Vector2I, Vector2I?> bestOrigins) {
        Vector2I current = target;
        List<Vector2I> path = [];
        while (current != origin) {
            path.Add(current);
            current = bestOrigins[current].Value;
        }
        path.Reverse(); // If we follow the path back from target, it is backwards; reverse it.
        return path;
    }

}
