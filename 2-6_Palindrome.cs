/*
	Assumption: Don't know length so have to go through whole list
        Book said that we could know the length, so implemented that.
            Additional iteration through to get size could be added, or stack with double pointer.
	
	Risks:
		Midpoint can be single or double
	
	Ideas:
		HashMapList doesn't work as order is important
		
		double pointer can work to find midpoint, but then need to go backwards
		
		Stack
		- iterate through to build stack and get length
		- iterate again up to midpoint and check that popping stack matches iterated values
		- trade: can sacrifice another runthrough to save half of the stack size

		Reversed
		- iterate through and build up a linked list in the opposite direction, then check equality.
		
		Recursive
			base: middle reached. return middle node (or next when even)
			recurse: check if the current level (in the first half of list) equals the returned value.Next
			if not equal, fail.
*/
public class PalindromeCheckerRecursive
{
	public bool IsPalindrome(LinkedList<char> list)
	{
		return IsPalindrome(list.Head, list.Length, 0);
	}

	private (bool couldBePalindrome, Node next) IsPalindrome(Node n, int length, int depth)
	{
		if (length / 2 == depth)
		{
			if (length % 2 == 0)
				return (n.Data == n.Next.Data, n.Next.Next);
			else
				return (true, n.Next);
		}
		
		var result = IsPalindrome(n.Next, length, depth + 1);
		var couldBePalindrome = result.couldBePalindrome &&
				n.Data == result.next.Data)
		return (couldBePalindrome, result.next.Next);
	}
}

public class PalindromeCheckerStack
{
    public bool IsPalindrome(LinkedList<char> list)
    {
        if (list == null || list.Length == 1) return true;
        
        var firstHalf = new Stack<char>();
        var n = list.Head;
        for (var i = 0; i < list.Length / 2; i++)
        {
            firstHalf.Push(n);
            n = n.Next;
        }
        if (i % 2 == 1)
            n = n.Next;
        
        while (firstHalf.Any())
        {
            if (firstHalf.Pop().Data != n.Data)
                return false;
            
            n = n.Next;       
        }
        return true;
    }
}