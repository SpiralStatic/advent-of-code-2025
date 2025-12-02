namespace SecretEntrance;

public class SafeBreaker
{
  public static async Task<IEnumerable<string>> ReadRotationsInput(string path)
  {
    return await File.ReadAllLinesAsync(path);
  }

  public static int SolveSafePassword(List<string> rotations)
  {
    return 0;
  }
}