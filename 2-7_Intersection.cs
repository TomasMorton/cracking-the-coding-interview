/*
    Input:
        two singly linked lists
        
    Output:
        the intersecting node

    Notes:
        compare by reference, not value.
        values may not be distinct
        Not ordered

    Edge cases:
        one list is null
        lists are of different lengths
        
    Brute force:
        iterate through a and check every node in b for equality
        
    ideas:
        hash map of the value to the node
        set of the node
        ability to mark each node as visited
        go to end of lists and check equality
        
    Solution:
        end of list equality
            iterate through both, counting the length
            if the final nodes are equal then they intersect
            if they intersect, we can iterate through to find the initial intersection
                we offset the longer pointer so that they both have the same length
*/
public class Intersector
{
    public Node? FindIntersection(Node a, Node b)
    {
        if (a == null || b == null) return false;
        
        var tailA = FindTail(a);
        var tailB = FindTail(b);
        
        if (tailA.Tail != tailB.Tail) return false;
        
        return FindIntersection(new(a, tailA.Length), new(b, tailB.Length));
    }
    
    private TailResult FindTail(Node head)
    {
        //todo: validate input
        var current = head;
        var length = 1;
        while (current.Next != null)
        {
            length++;
            current = current.Next;
        }
        
        return new (current, length);
    }
    
    private Node FindIntersection(ListWithLength shorter, ListWithLength longer)
    {
        //todo: validate input
        var difference = longer.Length - shorter.Length;        
        for (i = 0; i < difference; i++)
            longer = longer.Next;
        
        while (shorter != null)
        {
            if (shorter == longer)
                return shorter;
            
            shorter = shorter.Next;
            longer = longer.Next;
        }
        
        throw new InvalidOperationException("No intersection found");
    }
    
    private record TailResult(Node Tail, int Length);
    private record ListWithLength(Node Head, int Length);
}
