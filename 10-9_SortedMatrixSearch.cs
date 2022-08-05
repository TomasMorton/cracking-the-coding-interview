/*
    Apply a binary search, but with pairs of locations.
    Each recursion may need to search two remaining "segments" of the array
*/

public class MatrixSearcher
{
    private readonly int[][] _matrix;
    
    public MatrixSearcher(int[][] matrix)
        => _matrix = matrix; //TODO: Validate
        
    public Point? Search(int find)
    {
        return Search(find, new Point(0, 0), new Point(_matrix.Length - 1, _matrix[0].Length - 1);
    }
    
    private Point? Search(int find, Point from, Point to)
    {
        var middle? = GetCenterPoint(from, to);
        if (middle == null)
            return null;
        
        var midValue = _matrix[middle.Row][middle.Col];
        
        if (midValue == find)
            return middle;
        
        if (midValue < find)
            return SearchAfter(find, middle);
        
        return SearchBefore(find, from, to, middle);
    }
    
    private Point? GetCenterPoint(Point from, Point to)
    {
        if (from.Row > to.Row || from.Col > to.Col)
            return null;
        
        return new Point (from.Row + to.Row / 2, from.Col + to.Col / 2);
    }
        
    private Point? SearchAfter(int find, Point fromPoint, Point toPoint, Point afterPoint)
    {
        var horizontalResult = Search(find, fromPoint with { col = afterPoint.Col + 1}, toPoint);
        if (horizontalResult != null)
            return horizontalResult;
        
        return Search(find, fromPoint with { row = afterPoint.Row + 1}, toPoint);
    }
        
    private Point? SearchBefore(int find, Point fromPoint, Point toPoint, Point beforePoint)
    {
        var horizontalResult = Search(find, fromPoint, toPoint with { row = beforePoint.Row - 1});
        if (horizontalResult != null)
            return horizontalResult;
        
        return Search(find, fromPoint, toPoint with { col = beforePoint.Col - 1});
    }
    
    private record Point(int Row, int Col);
}