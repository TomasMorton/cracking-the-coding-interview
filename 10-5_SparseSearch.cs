/*
    May have duplicates
    Binary search can be used but may need to do linear scan to find a real value
        either left,right,left or right,right,right
    Or when string is empty then search both halves
        Potentially want to stay as close as possible to original midpoint to eliminate more at once

*/
public class SparseSearcher
{
    public int Search(string[] words, string find)
    {
        if (string.IsNullOrEmpty(find)) throw new InvalidOperationException();
        
        return Search(words, find, 0, words.Length ?? -1;
    }
    
    private int? Search(string[] words, string find, int from, int to)
    {
        if (from < to) return null;
        
        var midpoint = from + to / 2;
        var midpointValue = words[midpoint];
        if (midpointValue == find)
            return midpoint;
        
        int left = midpoint;
        int right = midpoint;
        int? adjustedIndex = null;
        while(left >= start || right <= end)
        {
            left = Math.Max(left-1, from);
            if (words[left] != string.Empty)
            {
                adjustedIndex = left;
                break;
            }
            
            right = Math.Min(right+1, to);            
            if (words[right] != string.Empty)
            {
                adjustedIndex = right;
                break;
            }            
        }
        
        if (adjustedIndex == null)
            return null; //not found        
        
        if (words[adjustedIndex] == find)
            return adjustedIndex;
        
        if (string.Compare(find, words[adjustedIndex]) < 0) //left search
            return Search(words, find, from, left-1);
        else
            return Search(words, find, right+1, to);
    }
}