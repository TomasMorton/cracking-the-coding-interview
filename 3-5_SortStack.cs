/*
  Have to be able to store one element in a temporary variable, otherwise the stack order can never change

  Notes:
    - Are there duplicates?

  Ideas:
    - FlipFlop:
      Empty the first stack into the other, keeping hold of the largest element as you go
      Push the largest element into the first stack.
      Empty the second stack into the first stack, keeping hold of the smallest element as you go
      Push the smallest element into the second stack
      Repeat, but keep one more on each stack at each iteration. Stop when iteration is half of size + 1
*/

public class StackSorter
{
  private readonly Stack<int> _increasing;
  private readonly Stack<int> _decreasing = new()

  public void Sort(Stack<int> stack)
  {
    if (stack == null || stack.IsEmpty())
      return stack;

    _increasing = stack;
    var elementCount = SetLargestAndGetCount();
    var sortedCount = 1;

    while (sortedCount < elementCount))
    {
      var currentFlips = elementCount - sortedCount;
      if (sortedCount % 2 == 1)
        SetNextSmallest(currentFlips);
      else
        SetNextLargest(currentFlips);

      elementCount--;
    }

    CombineStacks();
  }

  private int SetLargestAndGetCount()
  {
    var count = 0;
    int? largest = null;
    while (!_increasing.IsEmpty())
    {
      count++;
      var current = _increasing.Pop();
      if (largest == null)
      {
        largest = current;
      } else if (current > largest) {
        _decreasing.Push(largest);
        largest = current;
      } else {
        _decreasing.Push(current);
      }
    }

    _increasing.Push(largest);

    return count;
  }

  private void SetNextLargest(int flips)
    => FlipStackExceptFor(_increasing, _decreasing, (x, largest) => x > largest);

  private void SetNextSmallest(int flips)
    => FlipStackExceptFor(_decreasing, _increasing, (x, smallest) => x < smallest);

  private static void FlipStackExceptFor(Stack<int> from, Stack<int> to, int flips, Predicate<int, int> compare)
  {
    int? toKeep = null;
    for (var i = 0; i < flips; i++)
    {
      var current = from.Pop();
      if (toKeep == null)
      {
        toKeep = current;
      } else if(compare(current, toKeep)) {
        to.Push(toKeep);
        toKeep = current;
      } else {
        to.Push(current);
      }
    }

    from.Push(toKeep);
  }

  private void CombineStacks()
  {
    while (!_decreasing.IsEmpty())
      _increasing.Push(_decreasing.Pop());
  }
}
