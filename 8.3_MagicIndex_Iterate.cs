/*
  Array is sorted and distinct

  Brute force:
      iterate on array, check for equality to index, return when found

  Slightly improved:
      iterate on array, check for equality to index, set next index to Max(value + 1, i + 1), return when found

  Recursive:
    call with (0)
      check for equality at 0
        recurse with (max(1, value))

  Bad:
  1 2 3 4 5 6 7 8 9 10
  0 1 2 3 4 5 6 7 8 09
  x
      x
          x
              x
                  x
                    x

  Worst is say -99 through -89, it's n steps to fail

  Better:
    Binary search. See next file
*/

public class MagicIndex
{
  public bool HasMagicIndex(int[] values)
  {
    if (values == null)
      return false;

    return FindMagicIndex(values, 0);
  }

  private bool FindMagicIndex(int[] values, int fromIndex)
  {
    if (fromIndex >= values.Length)
      return false;

    if (values[fromIndex] == fromIndex)
      return true;

    var nextIndex = Math.Max(fromIndex + 1, values[fromIndex] + 1);
    return FindMagicIndex(values, nextIndex);
  }
}
