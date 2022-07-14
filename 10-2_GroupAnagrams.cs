/*
  Sort an array of strings so that all anagrams are next to eachother

  Anagram: rearrangement of letters
  Notice:
    * counting the amount of each letter will identify anagrams

  Brute force:
    Go through every string in the array
      for each string, find the anagrams of it and move them to the next index
    Worst case (no matches): O(n2) (?)
    Best case(already sorted): O(n)
    Space: O(n), sort can be done in place

  Hashmap:
    Map each word from its sorted version

*/

public class GroupAnagrams
{
    public void Sort(string[] words)
    {
        var map = CreateAnagramMap(words);

        var currentIndex = 0;
        foreach (var (_, wordGroup) in map)
            foreach (var word in wordGroup)
                words[currentIndex++] = word;
    }

    private Dictionary<string, List<string>> CreateAnagramMap(string[] words)
    {
        var result = new Dictionary<string, List<string>>();
        foreach (var word in words)
        {
            var key = SortString(word);
            var list = GetOrAddListToMap(result, key);
            list.Add(word);
        }

        return result;
    }

    private static List<string> GetOrAddListToMap(Dictionary<string, List<string>> map, string key)
    {
        if (map.TryGetValue(key, out var list))
            return list;

        var newList = new List<string>();
        map[key] = newList;

        return newList;
    }

    private string SortString(string s)
    {
        var result = s.ToCharArray();
        Array.Sort(result);
        return new string(result);
    }
}
