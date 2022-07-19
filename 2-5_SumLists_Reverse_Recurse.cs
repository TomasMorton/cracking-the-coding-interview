/*
  Each node in a list is one digit in a base 10 number.
  The tail node is the "1s" digit (10^0).

  Notes:
    - The numbers may be of different lengths
    - Result is a new LinkedList
*/

public class ListAddifier
{
  public Node SumLists(Node a, Node b)
  {
      if (a == null || a.Next == null) return b;
      if (b == null || b.Next == null) return a;

      var (result, carriedValue) = Sum(a, b);
      if (carriedValue > 0)
      {
          var finalDigit = new Node(carriedValue);
          finalDigit.Next = result;
          result = finalDigit;
      }

      return result;
  }

  private (Node n, int carriedValue) Sum(Node a, Node b)
  {
    if (a == null && b == null)
      return (null, 0);

    var (next, carriedValue) = Sum(a?.Next, b?.Next); //Bug: different length numbers will end up padding 0s, so 123+1 will become 123+100. Reverse-Iterate version doesn't have this problem.
    var (sumNode, nextCarriedValue) = Add(a, b, carriedValue);

    sumNode.Next = next;
    return (sumNode, nextCarriedValue);
  }

  private (Node sumNode, int carriedValue) Add(Node a, Node b, int carriedValue)
  {
    var sum = (a?.Data ?? 0) + (b?.Data ?? 0) + carriedValue;
    var digitValue = sum % 10;
    var nextCarriedValue = sum / 10;

    return (new Node(digitValue), nextCarriedValue);
  }
}
