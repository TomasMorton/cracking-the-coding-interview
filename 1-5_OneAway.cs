/*
  Notice:
    * same length is true
    * length more than 1 different is false


  Ideas:
    - hash map of the shortest one?
    - standard iteration with a pointer on each
      - allow 1 "error"
      - always compare from longer to shorter
      - mismatch length will only have a "removal"
      - same length will only have a "change"
  removal: ale, al
  removal: ale, le
  insert: ale, pale -> pale, ale
  insert: ale, ales -> ales, ale
  insert: ale, ales -> able, ale
  replace: ale, ole
  replace: ale, ate
*/

public class OneAway
{
  public bool IsOneAway(string a, string b)
  {
    if (a.Length == b.Length)
      return CompareEqualLengthStrings(a, b);
    else
      return CompareMismatchedLengthStrings(a, b);
  }

  private bool CompareEqualLengthStrings(string a, string b)
  {
    bool hasFoundReplacement = false;
    for (var i = 0; i < a.Length; i++)
    {
      if (a[i] != b[i])
      {
        if (hasFoundReplacement) return false; //two or more edits were made
        hasFoundReplacement = true;
      }
    }

    return true;
  }

  private bool CompareMismatchedLengthStrings(string a, string b)
  {
    var (shorter, longer) = OrderStringsFromShorterToLarger(a, b);
    if (longer.Length - shorter.Length > 1) return false;

    bool hasFoundRemoval = false;
    int shorterIndex = 0;
    for(var longerIndex = 0; longerIndex < longer.Length; longerIndex++)
    {
      if (shorterIndex >= shorter.Length || longer[longerIndex] != shorter[shorterIndex])
      {
        if (hasFoundRemoval) return false; //multiple changes were made
      } else {
        shorterIndex++;
      }
    }
  }

  private (string shorter, string longer) OrderStringsFromShorterToLarger(string a, string b)
    => a.Length < b.Length
        ? (a, b)
        : (b, a);
}
