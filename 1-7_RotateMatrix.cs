/*
	4 bytes = 32 bits = int
	Rotation direction not specified, so assume clockwise
	In place means swapping or doing a single pass
	Matrix is square
	
	0 1 2		6 3 0
	3 4 5	->  7 4 1
	6 7 8 		8 5 2
	
	0,0 -> 0,2
	0,1 -> 1,2
	0,2 -> 2,2
	
	1,0 -> 0,1
	1,1 -> 1,1
	1,2 -> 2,1
	
	2,0 -> 0,0
	2,1 -> 1,0
	2,2 -> 2,0
	
	row 0 becomes column n.
	row 1 becomes column n-1
	row n becomes column 0
	
	0 1 2 0		6 3 0
	3 4 5 0 ->  7 4 1
	6 7 8 0 	8 5 2
	0 0 0 0
*/
public class MatrixRotator
{
	public void Rotate(int[][] matrix)
	{
		if (matrix == null) return null;
		
		for (var row = 0; row < matrix.Length / 2; row++)
			for (var col = row; col < matrix[row].Length - row - 1; col++)
			{
				int left = col;
				int top = row;
				int bottom = matrix.Length-1-row;
				int right = matrix[row].Length-1-col;
				
				int temp = matrix[top][left];
				matrix[top][left] = matrix[bottom][left];
				matrix[bottom][left] = matrix[bottom][right];
				matrix[bottom][right] = matrix[top][right];
				matrix[top][right] = temp;
			}
	}
}

