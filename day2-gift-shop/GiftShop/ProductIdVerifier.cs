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

  public static IEnumerable<long> FindInvalidIds(IEnumerable<(long start, long end)> ranges)
  {
    return ranges.SelectMany(range =>
    {
      return CreateRange(range.start, range.end - range.start + 1) // + 1 as the end of the range is exclusive
        .Where(num => CheckStringNum(num.ToString()));
    });
  }

  private static bool CheckStringNum(string stringnum)
  {
    if (stringnum.Length % 2 != 0) return false; // To mirror length needs to be a multiple of two

    var front = stringnum.Substring(0, stringnum.Length / 2);
    var back = stringnum.Substring(stringnum.Length / 2, stringnum.Length / 2);

    var canDivideFurther = stringnum.Length / 2 > 1;
    if (front != back && canDivideFurther)
    {
      return CheckStringNum(stringnum.Substring(0, stringnum.Length / 2));
    }

    return front == back;
  }

  public static long GetTotal(IEnumerable<long> invalidIds)
  {
    return invalidIds.Sum();
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