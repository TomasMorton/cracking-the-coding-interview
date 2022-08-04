Insertion sort: Assume left is sorted, then move the next value left/right of that. Repeat with index++. Not efficient
Selection sort: Move the minimum value to the left, repeat with remainder. Not efficient.

Merge sort: Recurse to individual elements, then build back up by pulling out the lowest at a time. 2* storage space needed
Quick sort: Sort a pivot, then recurse to do the same with left and right sides. Low memory foot print

Bucket sort: create a hashmap, then iterate through. Fast, large memory footprint
Bubble sort: Compare the element pair, and swap to bubble up the larger. End is then sorted. Repeat. Low memory footprint

public class MergeSort()
{
    public int[] Sort(int[] unsorted)
    {
        return Sort(unsorted, 0, unsorted.Length -1);
    }
    
    private List<int> Sort(int[] a, int left, int right)
    {
        if (right-left < 0) return List.Empty[int];
        if (right - left == 0) return new List<int> { a[right] };
        
        var pivot = left + right / 2;
        
        var resultA = Sort(a, left, pivot);
        var resultB = Sort(a, pivot + 1, right);
        
        return Merge(resultA, resultB);
    }
    
    private List<int> Merge(List<int> a, List<int> b)
    {        
        var result = new List<int>();
        var ixA = 0;
        var ixB = 0;
        while (ixA < resultA.Length || ixB < resultB.Length)
        {
            var valA = ixA < resultA.Length ? resultA[ixA] : int.MinValue;
            var valB = ixB < resultB.Length ? resultB[ixB] : int.MinValue;
            
            if (valA > valB)
            {
                result.Add(valA);
                ixA++;
            } else {            
                result.Add(valB);
                ixB++;
            }
        }
        
        return result;
    }
}

public class QuickSort
{
    public void Sort(int[] unsorted)
    {
        return Sort(unsorted, 0, unsorted.Length - 1);
    }
    
    private void Sort(int[] a, int from, int to)
    {
        if (to < from) return;
        
        var partitionIndex = Partition(a, from, to);
        
        Sort(from, partitionIndex - 1);
        Sort(partitionIndex + 1, to);
    }
    
    private int Partition(int[] a, int from, int to)
    {
        var pivot = a[to];
        var sorted = from;
        for (var i = from; i < to; i++)
        {
            if (a[i] < pivot)
            {
                Swap(a, sorted, i);
                sorted++'
            }
        }
        
        Swap(a, sorted, to);
        return sorted;
    }
    
    private void Swap(int[] a, int x, int y)
    {        
        var temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}