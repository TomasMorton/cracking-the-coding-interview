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

      return Sum(a, b);
  }

  private Node Sum(Node a, Node b)
  {
    var aDigits = CreateStackToSum(a);
    var bDigits = CreateStackToSum(b);

    var carriedValue = 0;
    Node? resultHead = null;
    while (aDigits.Any() || bDigits.Any())
    {
      var nextA = aDigits.Any() ? aDigits.Pop() : null;
      var nextB = bDigits.Any() ? bDigits.Pop() : null;

      (var sumNode, carriedValue) = Add(nextA, nextB, carriedValue);
      if (resultHead == null) {
        resultHead = sumNode;
      } else {
        sumNode.Next = resultHead;
        resultHead = sumNode;
      }
    }

    if (carriedValue > 0)
    {
        var finalDigit = new Node(carriedValue);
        finalDigit.Next = resultHead;
        resultHead = finalDigit;
    }

    return resultHead;
  }

  private Stack<int> CreateStackToSum(Node n)
  {
    var digits = new Stack<int>();
    while (n != null)
    {
      digits.Push(n.Data);
      n = n.Next;
    }
    return digits;
  }

  private (Node sumNode, int carriedValue) Add(int? a, int? b, int carriedValue)
  {
    var sum = (a ?? 0) + (b ?? 0) + carriedValue;
    var digitValue = sum % 10;
    var nextCarriedValue = sum / 10;

    return (new Node(digitValue), nextCarriedValue);
  }
}
