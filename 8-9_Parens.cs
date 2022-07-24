/*

*/

public class ParenthesisPermuter
{
    public List<String> CalculatePermutations(int count)
    {
        return Run(count).ToList();
    }
    
    private HashSet<string> Run(int count)
    {
        if (count == 1)
            return new HashSet<string> { "()" };
        
        var lower = Run(count - 1);
        var result = new HashSet<string>();
        foreach (var v in lower)
        {
            for (var i = 0; i < v.Length; i++)
            {
                if (v[i] == '(')
                {
                    result.Add(v.Insert(i+1, "()"));
                    result.Add(v.Insert(i+1, ")("));
                }
            }
        }                
 
        return result;
    }
}