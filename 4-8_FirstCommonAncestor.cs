/*
    Edge cases:
        null inputs
        same node
        not found
        a is the ancestor of b
        
    Ideas:
        Get the height of both nodes, then iterate up to the same node (with offset)
        
        DFS, "return" when found and check equality
*/
public class AncestryFinder
{
    public Node? FindFirstCommonAncestor(Tree tree, Node a, Node b)
    {
        if (tree == null || a == null || b == null) return null;
        if (a == b) return a;
        
        var result = Search(tree.Root, a, b);
        return result.Ancestor;
    }
    
    public SearchResult Search(Node current, Node a, Node b)
    {
        if (current == null)
            return new (false, false, null);

        //bug: if a is an ancestor of b, we will never find b)
        if (current == a)
            return new(true, false, null);
        
        if (current == b)
            return new(false, true, null);        
        
        var leftResult = Search(current.Left, a, b);
        var rightResult = Search(current.Right, a, b);
        var combinedResult = CombineResults(leftResult, rightResult);
        if (combinedResult.Ancestor != null)
            return combinedResult;
        
        if (combinedResult.AFound && combinedResult.BFound)
            return new (true, true, current);
        
        return combinedResult;
    }
    
    public SearchResult CombineResults(SearchResult left, SearchResult right)
    {
        return new SearchResult(
            left.AFound || right.AFound,
            left.BFound || right.BFound,
            left.Ancestor ?? right.Ancestor);
    }
    
    public record SearchResult(bool AFound, bool BFound, Node? Ancestor);
}