/*
  Each node in a list is one digit in a base 10 number.
  The head node is the "1s" digit (10^0).

  Notes:
    - The numbers may be of different lengths
    - Result is a new LinkedList

  Simple option:
    Calculate the value of each list indepently, add them together, create a new list

  Next option:
    Iterate on both lists together.
    If the two digits added are less than 10, create the new node.
      Note: modulo
    If they're larger, the remainder needs to be "kept" for the next digit.
    If we reach the end of one list (and have dealth with the remainder), we can just set the pointer to the remaining larger list
*/

public class ListAddifier
{
  public Node Sum(Node a, Node b)
  {
    if (a == null || a.Next == null) return b;
    if (b == null || b.Next == null) return a;

    Node? result, resultTail = null;
    int carriedValue = 0;

    while (a != null || b != null || carriedValue > 0)
    {
      (var sumNode, carriedValue) = Add(a, b, carriedValue);
      if (result == null)
        result = sumNode;
      else
        resultTail.Next = sumNode;
      resultTail = sumNode;

      a = a?.Next;
      b = b?.Next;
    }

    return result;
  }

  private (Node sumNode, int carriedValue) Add(Node a, Node b, int carriedValue)
  {
    var sum = (a?.Data ?? 0) + (b?.Data ?? 0) + carriedValue;
    var digitValue = sum % 10;
    var nextCarriedValue = sum / 10;

    return (new Node(digitValue), nextCarriedValue);
  }
}
