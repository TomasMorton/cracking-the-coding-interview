/*
  upper left corner of an r * c grid
  move only right or down
  some cells are blocked
  goal is bottom right

  Path from (0,0) to (r-1, c-1)

  brute force:
    depth first search
      return the co-ordinate when found, or null otherwise

  Improved:
    Keep track of visited (failed) paths
*/

class Robot
{
  private readonly bool[][] _grid;
  private readonly HashSet<Cell> _visitedCells;
  private int lastRow => _grid.Length;
  private int lastColumn => _grid[0].Length;

  public Robot(bool[][] grid)
  {
    //todo: fail if 0 length in either dimension
    _grid = grid;
    _visitedCells = new HashSet<Cell>();
  }

  public List<Cell>? FindPath()
  {
    var result = FindPath(0, 0);
    return result.Any() ? result : null;
  }

  private List<Cell> FindPath(int row, int col)
  {
    if (row > lastRow || col > lastCol
        || _grid[row][col] == false
        || _visitedCells.Contains(currentCell))
    {
      return null;
    }

    var currentCell = new Cell(row, col);

    if (row == lastRow && col == lastCol)
      return new List<Cell>() { currentCell };

    var possiblePath = FindPath(row, col + 1)) || FindPath(row + 1, col);
    if (possiblePath != null)
      return moveHorizontal.Add(currentCell);

    _visitedCells.Add(currentCell);
    return null;
  }

  public record Cell(int Row, int Column);
}
