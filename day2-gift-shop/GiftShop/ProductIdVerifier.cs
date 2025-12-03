using System.Text.RegularExpressions;

namespace GiftShop;

public class ProductIdVerifier
{
  public static async Task<IEnumerable<Range>> ReadProductIds(string path)
  {
    var lines = await File.ReadAllLinesAsync(path);
    return lines
      .First()
      .Split(',')
      .Select(range =>
      {
        var startEnd = range.Split("-");
        // No validation
        return new Range(int.Parse(startEnd[0]), int.Parse(startEnd[1]));
      });
  }

  public static IEnumerable<int> FindInvalidIds(IEnumerable<Range> ranges)
  {
    return ranges.SelectMany(range =>
    {
      return Enumerable.Range(range.Start.Value, range.End.Value - range.Start.Value + 1) // + 1 as the end of the range is exclusive
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

  public static int GetTotal(IEnumerable<int> invalidIds)
  {
    return invalidIds.Sum();
  }
}