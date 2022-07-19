/*
	Input:
		array-like data structure with unknown length. -1 if out-of-bounds
		value to find
	Output:
		index of found element
	Notes:
		could be size 10 or 1 trillion
		
	Ideas:
		increase the "search window" size by an exponential amount until found
		use the value to find as an indicator of the starting/movement point
		
		
	try x[value].
		If less than, try x[value/2] (maybe different depending on previous search point)
		If greater than, try value * 2, or value ^ 2
		If -1, then try half.

*/
class InfiniteFinder
{
	public int? Find(Listy list, int value)
	{	
		var index = 2;
		while (list.Get(index) is > -1 and < value)
		{
			index *= 2;
		}
		if (list.Get(index) == value)
			return index;
		
		return Find(list, value, index / 2, index-1);
	}
	
	private int? Find(Listy list, int value, int start, int end)
	{
		if (start > end)
			return -1;
		
		var midPoint = start + end / 2;
		var midPointValue = list.Get(midPoint);
		
		if (midPointValue == value)
			return midPoint;
		else if (midPointValue < value)
			return Find(list, value, midPoint + 1, end);
		else //both smaller than and out-of-bounds handling (-1)
			return Find(list, value, start, midPoint - 1);
	}
}