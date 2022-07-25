/*
    An int is 4B, and we have 1000 * 4B so we could fit 1000 ints
    4KB is also 32000 bits, which is the maximum value this problem will contain.
    1 < N < 32000
    
    The data is sorted
        Actually it isn't!
    
    Below is no longer true since it's not sorted:
        We don't "know" N, but we can work it out by checking the value at arr[arr.Length-1].
        We could also calculate the number of duplicates with arr.Length - N.
        Finally, any value will appear at a <= index (eg value 6 cannot be at index 3)
    
    Solution:
        Store a bit vector of duplicates, and iterate through the array to find them.
*/
public class DuplicateFinder
{
    public HashSet<int> FindDuplicates(int[] numbers)
    {
        var previousValues = new BitVector(32000);
        var duplicates = new HashSet<int>();
        foreach (var x in numbers)
        {
            if (previousValues.GetBit(x-1))
                duplicates.Add(x-1);
            else
                previousValues.SetBit(x-1);
        }
        
        return duplicates;
        
        //Below is no longer relevant as we're storing all found values, not duplicates, due to unsorted requirement
        
        /*
        var results = new List<int>();
        for (var i = 0; i < 32000; i++)
            if (duplicates.GetBit(i))
                results.Add(i+1);
            
        return results; 
        */
        //return duplicates.GetFlaggedNumbers();
    }
}

public class BitVector()
{
    private readonly int[] _vector;
    
    public BitVector(int numberOfBits)
    {
        var size = numberOfBits / 32.0m;
        var adjustedSize = (int)Math.Ceil(size);
        _vector = new int[adjustedSize];
    }
    
    public void SetBit(int bit)
    {
        var index = bit / 32;
        var localBit = index % 32;
        var mask = 1 << localBit;
        _vector[index] |= mask;
    }
    
    public bool GetBit(int bit)
    {        
        var index = bit / 32;
        var localBit = index % 32;
        var mask = 1 << localBit;
        return _vector[index] & mask != 0;
    }
    
    public List<int> GetFlaggedNumbers()
    {
        var results = new List<int>();
        for (var i = 0; i < _vector.Length; i++)
        {
            var current = _vector[i];
            int offset = i * 32;
            int index = 1; //Additional 1 to print the 1-N value, offset from 0-(N-1). Not ideal place to have this.
            
            do
            {
                if ((current & 1) == 1)
                    results.Add(offset + index);
                
                current >> 1;
                index++;
            } while (current > 0)
        }
    
        return results;
    }
}