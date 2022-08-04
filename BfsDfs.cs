public class BFS
{
    public bool Contains(Tree tree, int find)
    {
        var toCheck = new Queue<Node>();
        toCheck.Add(tree.Root);
        while (toCheck.Any())
        {
            var next = toCheck.Dequeue();
            if (next == find) return true;
            
            if (next.Left != null)
                toCheck.Enqueue(next.Left);
                
            if (next.Right != null)
                toCheck.Enqueue(next.Right);
        }
        
        return false;
    }
}

public class IterativeDfs
{
    public bool Contains(Tree tree, int find)
    {
        var next = new Stack<Node>();
        next.Add(tree.Root);
        
        while (next.Any())
        {
            var current = next.Pop();
            if (current == find) return true;
            
            if (current.Left != null)
                next.Push(current.Left);
                
            if (current.Right != null)
                next.Push(current.Right);
        }
        
        return false;
    }
}