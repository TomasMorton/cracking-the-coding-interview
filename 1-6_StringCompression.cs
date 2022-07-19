/*
  Only uppercase and lowercase letters.
  A single character still becomes "a1".
  Don't return if larger or equal

  Ideas:
    Hash map won't work as order is important
    Array won't work as we don't know final size
    List or StringBuilder can work

    1:
      create a StringBuilder and iterate through
      keep track of "current" letter and its count
      when letter changes (or end), write the count
      check length and return
*/

public class StringCompressor
{
  public string Compress(string original)
  {
    if (string.IsNullOrEmpty(original))
      return original;

    var compressed = CreateCompressedString(original);

    return (compressed != null && compressed.Length < original.Length)
      ? compressed
      : original;
  }

  private string? CreateCompressedString(string original)
  {
    var builder = new StringBuilder();

    var currentChar = original[0];
    var currentCount = 1;
    for (var i = 1; i < original.Length; i++)
    {
      if (c == currentChar) {
        currentCount++
      } else {
        builder.Append(currentChar);
        builder.Append(currentCount);
        currentChar = c;
        currentCount = 1;

        if (builder.Length >= original.Length)
          return null; //early-exit if it's not really compressed
      }
    }

    builder.Append(currentChar);
    builder.Append(currentCount);

    return builder.ToString();
  }
}
