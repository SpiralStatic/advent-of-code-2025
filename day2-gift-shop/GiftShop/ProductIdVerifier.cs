namespace GiftShop;

public class ProductIdVerifier
{
  public static async Task<IEnumerable<Range>> ReadProductIds(string path)
  {
    var lines = await File.ReadAllLinesAsync(path);
    return lines
      .First()
      .Split(',')
      .Select(x =>
      {
        var range = x.Split("-");
        // No validation
        return new Range(int.Parse(range[0]), int.Parse(range[1]));
      });
  }

  public static IEnumerable<int> FindInvalidIds(IEnumerable<Range> ranges)
  {
    return [0];
  }

  public static int GetTotal(IEnumerable<int> invalidIds)
  {
    return invalidIds.Sum();
  }
}