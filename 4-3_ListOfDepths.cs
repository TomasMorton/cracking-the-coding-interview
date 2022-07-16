/*
  If it's stored in an array, then each level (index) is (2^k)-1 through to ((2^k)-1)*2.
  So if you want level 4, the nodes are from a[15..30]

  This probably isn't an array though, so
    Recursively iterate the tree. Include a "depth" value starting from 0.
    At each depth, add to a class field List<LinkedList> at that index.

  This will be O(n) time, with O(n + n + logn) space (so O(n)), which matches BCR
*/

class TreeSplitter<T>
{
  private readonly List<LinkedList<T>> _result;

  public List<LinkedList<T> TreeSplitter(BinaryTree tree)
  {
    if (tree == null)
      throw new InvalidOperationException();

    _result = new();
    Split(tree.Root, 0);

    return _result;
  }

  private void Split(BinaryTreeNode current, int depth)
  {
    if (current == null)
      return;

    AddToResult(current.Data, depth);
    Split(current.Left, depth+1);
    Split(current.Right, depth+1);
  }

  private void AddToResult(T data, int depth)
  {
    while (_result.Length < depth + 1)
      _result.Add(new LinkedList<T>());

    _result[depth].Add(data);
  }
}
