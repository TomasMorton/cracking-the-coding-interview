/*
    Ideas:
        Recursive, adding one letter at each index at each step

*/
public class Permutator
{
    public List<string> Permute(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        
        if (s.Length == 1)
            return new List<string> { s };
        
        var smallerPermutations = Permute(s[1..]);
        
        return smallerPermutations
            .SelectMany(x => AddToString(s[..1], x))
            .ToList();  
    }
    
    private IEnumerable<string> AddToString(char toAdd, string s)
    {
        for (var i = 0; i <= s.Length; i++)
            yield return s.Insert(toAdd, i);
    }
}
