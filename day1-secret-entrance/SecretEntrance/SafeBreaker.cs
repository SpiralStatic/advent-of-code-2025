using System.Text.RegularExpressions;

namespace SecretEntrance;

public partial class SafeBreaker
{
  public static async Task<IEnumerable<string>> ReadRotationsInput(string path)
  {
    return await File.ReadAllLinesAsync(path);
  }

  public static int SolveSafePassword(List<string> rotations)
  {
    var clicks = CalculateDialClicks(rotations);

    return clicks;
  }

  private static int CalculateDialClicks(List<string> rotations)
  {
    var (_, clicks) = rotations.Aggregate((50, 0), (current, next) =>
    {
      var directionDistance = RotationsRegex().Split(next);

      var (direction, distance) = CreateDirectionDistanceTuple(directionDistance);

      var (currentDialPosition, currentClicks) = current;

      if (direction == 'L')
      {
        var nextDialPosition = currentDialPosition - distance;
        if (nextDialPosition < 0)
        {
          return (0 - nextDialPosition, currentClicks + 1);
        }
        return (nextDialPosition, currentClicks);
      }
      else
      {
        var nextDialPosition = currentDialPosition + distance;
        if (nextDialPosition > 99)
        {
          return (nextDialPosition, currentClicks + 1);
        }
        return (99 + nextDialPosition, currentClicks);
      }
    });

    return clicks;
  }

  private static (char, int) CreateDirectionDistanceTuple(string[] directionDistance)
  {
    if (directionDistance.Length > 2)
    {
      throw new Exception($"{nameof(directionDistance)} has too many components");
    }

    var directionSuccess = char.TryParse(directionDistance[0], out char direction);
    var distanceSuccess = int.TryParse(directionDistance[1], out int distance);

    if (!directionSuccess) throw new FormatException("Invalid Direction, not a char");
    if (!distanceSuccess) throw new FormatException("Invalid Distance, not an int");

    return (direction, distance);
  }

  [GeneratedRegex(@"(?<=[LR])")]
  private static partial Regex RotationsRegex();
}