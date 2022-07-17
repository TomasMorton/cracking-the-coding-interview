/*
  At least one half of the array will still be sorted normally.
  We can use this half to decide if the element will be there or in the other side.
*/

public class RotatedArraySearch
{
  private int _find;
  private int[] _values;

  public int? FindIndexOf(int find, int[] values)
  {
    if (values == null) return null;

    _find = find;
    _values = values;

    return FindIndex(0, values.Length - 1);
  }

  private int? FindIndex(int start, int end)
  {
    if (start > end) return null;

    var midPoint = GetMidpoint(start, end);
    var midValue = values[midPoint];
    if (midValue == _find)
      return midPoint;

    if (IsLeftSorted(start, end))
    {
      if (midValue > find)
        return SearchLeftOf(start, end);
      else
        return SearchRightOf(start, end)
    } else if(IsRightSorted(start, end)) {
      if (midValue < find)
        return SearchRightOf(start, end);
      else
        return SearchLeftOf(start, end);
    } else { //Don't know which half, search both
      var leftResult = SearchLeftOf(start, end);
      if (leftResult != null)
        return leftResult;
      else
        return SearchRightOf(start, end);
    }
    // var isLeftSorted = values[start] <= midValue;
    // if (isLeftSorted && midValue > find)
    //   return FindIndexOf(find, values, start, midPoint - 1);
    // else
    //   return FindIndexOf(find, values, midPoint + 1, end);
  }

  private int? SearchLeftOf(int start, int end)
    => FindIndex(start, GetMidpoint(start, end) - 1);

  private int? SearchRightOf(int start, int end)
    => FindIndex(GetMidpoint(start, end) + 1, end);

  private bool IsLeftSorted(int start, int end)
    => _values[start] < _values[GetMidpoint(start, end)];

  private bool IsRightSorted(int start, int end)
    => _values[end] > _values[GetMidpoint(start, end)];

  private int GetMidpoint(int start, int end)
    => (start + end) / 2;
}
