/*
    Assumption:
        This shouldn't automatically recurse otherwise the whole matrix becomes 0
        0 < m,n
    Ideas:
        iterate on each cell, and if there is a row/col with 0 then set it to 0
            use a hashmap/memo to prevent repeat checks
            
        iterate on each cell, and if it is 0 then mark the related row/col to be zeroed.
            Update at the end based on marks.
            
        iterate on 0,0; 1,1; 2,2; and check
            Implemented below, but this doesn't actually work. Above solution is correct
*/
public class ZeroMatrix //Note: Doesn't solve the problem! Need to store the rows/cols that are 0d and then push out at the end.
{
    private int[][] _matrix;
    private int _rows;
    private int _cols;
    
    public void Initialise(int[][] matrix)
    {
        if (matrix == null) return null;
        if (matrix.Length == 0 || matrix[0].Length ==) return matrix; //Assumption that there will be at least one row and col
        
        _matrix = matrix;
        _rows = matrix.Length;
        _cols = matrix[0];
        int iterations = Math.Min(_rows, _cols);
        
        for (i = 0; i < iterations; i++)
        {
            if (ShouldBeZeroed(i))
                ZeroMatrixSegment(i);
        }
        
        return matrix;
    }
    
    private bool ShouldBeZeroed(int segment)
    {
        for (var row = segment; row < _rows; row++)
        {
            if (_matrix[row, segment] == 0)
                return true;
        }
        for (var col = segment; col < _cols; col++)
        {
            if (_matrix[segment, col] == 0)
                return true;
        }
        
        return false;
    }
    
    private void ZeroMatrixSegment(int segment)
    {
        for (var row = segment; row < _rows; row++)
        {
            _matrix[row, segment] = 0;
        }
        for (var col = segment; col < _cols; col++)
        {
            _matrix[segment, col] = 0;
        }
    }
}