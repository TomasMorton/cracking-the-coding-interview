/*
  BST: left < parent, right > parent
  Input:
    Integer Array
    Potentially negative
    No duplicates
    Sorted

  Output:
    A BST with minimal height

  Option 1:
      Take the middle element.
      Recurse on array before for left child.
      Recurse on array after for right child.
      Return a Node at each level.
      Stop when size is 1
      O(n) time, O(log n) space

  Option 2:
    Same approach, but return the result as an array.
    Same complexity, just minorly more space efficient and faster to search after
*/

public class MinimalTree
{
  private readonly int[] _original; //Note: could remove to save memory once computation is complete, or pass inline in recursion instead of using a field
  private Node<int>? _head;

  private void ComputeMinimalTree()
    => _head = ComputeMinimalTree(0, _original.Length-1);

  private Node<int> ComputeMinimalTree(int from, int to)
  {
    if (from == to) //Note: check is redundant, code below would handle this case
      return new Node<int>(_original[from]);

    if (from > to)
      return null;

    var middle = (from + to) / 2;
    var current = new Node<int>(_original[middle]);
    current.Left = ComputeMinimalTree(from, middle - 1);
    current.Right = ComputeMinimalTree(middle + 1, to);

    return current;
  }

  public Node<int> Head => _head ?? throw new EmptyTreeException();

  private MinimalTree(int[] sortedUniqueArray)
  {
    _original = sortedUniqueArray;
    _head = null;
  }

  public MinimalTree Init(int[] sortedUniqueArray)
  {
    var result = new MinimalTree(sortedUniqueArray);
    result.ComputeMinimalTree();
    return result;
  }

}
