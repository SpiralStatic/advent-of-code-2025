namespace GiftShop;

public class ProductIdVerifier
{
  public static async Task<IEnumerable<Range>> ReadProductIds(string path)
  {
    var bytes = await File.ReadAllBytesAsync(path);
    return [0..^1];
  }
}