/*
  Flip one bit from 0 to 1 to find the longest sequence of 1s
  Can the number 11 be seen as 011? What if it is int.MaxValue?

  0 -> 1 = 1
  00 -> 01 or 10 = 1
  000 -> 100 or 010 or 001 = 1

  010 -> 110 or 011 = 2
  101 -> 111 = 3

  1001 -> 1101 or 1011 = 2
  1001001101 -> 1001001111 = 4

  Find the longest sequence of 1s, allowing for a 0.
    Upon finding a 0 we may have to start a second tracker

  split string by 0s
    for each i&i+1, add these + 1

  iterate through, keeping last count and current count
    on finding 0
      if last count + current count + 1 > max, update max
      set last count to current count.
      set current count to 0.
*/

class LongestBitSequence
{
  public int GetLongestSequenceOf1s(uint number)
  {
    int maxCount = 1;
    int lastCount = 0;
    int currentCount = 0;
    while (true)
    {
      if (number % 2 == 0) //ends with 0. Could use number&1==0
      {
          var currentTotal = lastCount + currentCount + 1;
          if (currentTotal > maxCount)
            maxCount = currentTotal;

          lastCount = currentCount;
          currentCount = 0;
      }
      else
      {
        currentCount++;
      }

      // break inside loop to ensure that the final block is counted
      if (number == 0)
        break;

      number >>= 1;
    }

    return maxCount;
  }
}
