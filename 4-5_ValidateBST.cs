/*
    A binary tree is a BST if max(left) < n < min(right), for every node in the tree
    
    Assumptions:
        - tree values are unique
    
    Ideas:
        Recurse and check that each left is < and right is >, bubbling up the max/min
*/
public class BinarySearchTreeValidator
{
    public bool IsBinarySearchTree(Node root)
    {
        if (root == null) return true;
        
        var result = IsBinarySearchSubtree(root);
        return result.IsValidSubtree;
    }
    
    private SubtreeResult IsBinarySearchSubtree(Node n)
    {
        if (n.Left == null && n.Right == null)
            return new SubtreeResult(true, n.Data, n.Data);
        
        var left = n.Left != null ? IsBinarySearchSubtree(n.Left) : null;
        var right = n.Right != null ? IsBinarySearchSubtree(n.Right) : null;
        
        var isValid = (left == null || left.IsValidSubtree && left.MaxValue < n.Data) &&
                      (right == null || right.IsValidSubtree && right.MinValue > n.Data);
        
        if (isValid)
            return new SubtreeResult(true, GetMinimumSubtreeValue(n.Data, left?.MinValue), GetMaximumSubtreeValue(n.Data, right?.MaxValue);
        else
            return new SubtreeResult(false, null, null);
    }
    
    private int GetMinimumSubtreeValue(int current, int? subtree)
    {
        if (subtree == null)
            return current;
        
        return Math.Min(current, subtree);
    }
    
    private int GetMaximumSubtreeValue(int current, int? subtree)
    {
        if (subtree == null)
            return current;
        
        return Math.Max(current, subtree);
    }
}

public record SubtreeResult(bool IsValidSubtree, int? MinValue, int? MaxValue);