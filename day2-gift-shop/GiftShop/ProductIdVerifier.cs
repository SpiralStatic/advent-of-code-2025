namespace GiftShop;

public class ProductIdVerifier
{
  public static async Task<IEnumerable<(long start, long end)>> ReadProductIds(string path)
  {
    var lines = await File.ReadAllLinesAsync(path);
    return lines
      .First()
      .Split(',')
      .Select(range =>
      {
        var startEnd = range.Split("-");
        // No validation
        return (long.Parse(startEnd[0]), long.Parse(startEnd[1]));
      });
  }

  public static IEnumerable<long> FindInvalidIds(IEnumerable<(long start, long end)> ranges, bool part2 = false)
  {
    return ranges.SelectMany(range =>
    {
      return CreateRange(range.start, range.end - range.start + 1) // + 1 as the end of the range as it is exclusive
        .Where(num => part2 ? CheckStringRepeatAtLeastTwice(num.ToString()) : CheckStringNumRepeatTwice(num.ToString()));
    });
  }

  public static long GetTotal(IEnumerable<long> invalidIds)
  {
    return invalidIds.Sum();
  }

  private static bool CheckStringNumRepeatTwice(string stringNum)
  {
    if (stringNum.Length % 2 != 0) return false; // To mirror length needs to be a multiple of two

    var front = stringNum.Substring(0, stringNum.Length / 2);
    var back = stringNum.Substring(stringNum.Length / 2, stringNum.Length / 2);

    return front == back;
  }

  private static bool CheckStringRepeatAtLeastTwice(string stringNum)
  {
    var divisibles = new List<int>();
    for (int i = 1; i <= stringNum.Length; i++)
    {
      if (stringNum.Length % i == 0) divisibles.Add(i);
    }

    return divisibles.Any(divisor =>
    {
      var parts = Enumerable.Range(0, stringNum.Length / divisor)
        .Select(i => stringNum.Substring(i * divisor, divisor));

      return parts.Count() > 1 && parts.All(x => x == parts.First());
    });
  }

  private static IEnumerable<long> CreateRange(long start, long count)
  {
    var limit = start + count;

    while (start < limit)
    {
      yield return start;
      start++;
    }
  }
}