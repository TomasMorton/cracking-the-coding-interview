/*
	Balanced = max depth - min depth <= 1.
	This is a binary tree
	Assumption: a height of 0 (no child on one side) is still a subtree
	
	ideas:
		DFS, early exit when greater than 1 difference
		- iterate/recurse down, incrementing a depth variable, until you reach a leaf node (no children).
			At the leaf, either return the value as min/max, or store in a class variable

*/
public class BalanceChecker
{
	public bool IsBalanced(Node root)
	{
		if (root == null) return true;

		var result = CheckDepth(root, 1);
		return IsDepthBalanced(result.Min, result.Max);
	}
	
	private (int Min, int Max) CheckDepth(Node n, int depth)
	{		
		if (n == null) 
			return depth - 1;
	
		//Leaf node
		if (n.Left == null && n.Right == null)
			return (depth, depth);		

		var leftDepth = CheckDepth(n.Left, depth + 1);
		if (!IsDepthBalanced(leftDepth.Min, leftDepth.Max) //Early exit
			return leftDepth;
		
		var rightDepth = CheckDepth(n.Right, depth + 1);
		
		return CombineDepths(leftDepth.Min, leftDepth.Max, rightDepth.Min, rightDepth.Max);
		
	}
	
	private bool IsDepthBalanced(int min, int max)
		=> (max - min) <= 1;
	
	private (int Min, int Max) CombineDepths(int minA, int maxA, int minB, int maxB)
	{
		var min = Math.Min(minA, minB);
		var max = Math.Max(maxA, maxB);
		
		return (min, max);
	}
}