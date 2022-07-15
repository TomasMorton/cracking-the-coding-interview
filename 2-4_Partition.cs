/*
  Partition element may not be unique
  Partition element may not even exist

  Ideas:
    - Create two lists, one for less than and one for equal or greater, and then join them
      - O(n) runtime and O(n) space

    - iterate through, "pull out" any that are larger or equal, and reattach at end
      - O(n) runtime and O(n) space

  Risks:
    - ensure nodes are separated from previous parent
    - list could be null, empty, single
    - head may be moved

*/

public class LinkedListPartitioner
{
  public Node Partition(Node head, int partitioner)
  {
    if (head == null || head.Next == null)
      return head;

    var current = head;
    Node movedHead = null;
    Node movedTail = null;
    Node newHead = null;

    while (current.Next != null)
    {
      if (current >= partitioner)
      {
        //Move the node to the tail list
        if (movedHead == null)
        {
          movedHead = current;
          movedTail = current;
        } else {
          movedTail.Next = current;
          movedTail = current;
        }
        current = movedTail.Next;
        movedTail.Next = null; //detach the new tail node from the list
      } else {
        if (newHead == null)
          newHead = current;
        current = current.Next;
      }
    }

    current.Next = movedTail; //doesn't matter if final mode is <, == or > than partitioner
    return newHead;
  }
}
