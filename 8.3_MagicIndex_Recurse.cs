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

  Better:
    Binary search.
      When index is 6, value is 5, then 5<=4, 4 <= 3, .., so must be in right half
      When index is 6, value is 7, then 7 >= 8, 8 >= 9, .., so must be in top half
*/

public class MagicIndex
{
  public int? HasMagicIndex(int[] values)
  {
    if (values == null)
      return null;

    return FindMagicIndex(values, 0, values.Length - 1);
  }

  private int? FindMagicIndex(int[] values, int fromIndex, int toIndex)
  {
    if (fromIndex > toIndex)
      return null;

    var midPoint = (fromIndex + toIndex) / 2;

    if (values[midPoint] == midPoint)
      return midPoint;
    else if (values[midPoint] < midpoint)
      return FindMagicIndex(values, midPoint + 1, toIndex);
    else
      return FindMagicIndex(values, fromIndex, midPoint - 1);
  }
}
