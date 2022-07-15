/*
  You can't perform the usual operation of "parent.next to parent.next.next" because we don't have access
  So we will instead move the values of the children "up" to replace the deleted node.
*/

class DeletedMiddleNode
{
  private void Delete(Node nodeToDelete)
  {
    var replacement = nodeToDelete?.Next;
    if (replacement == null)
      throw new Exception("Cannot delete tail node or missing node");

    nodeToDelete.Data = replacement.Data;
    nodeToDelete.Next = replacement.Next;
  }
}
