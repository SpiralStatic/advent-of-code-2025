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
    var (lTotalDistanc, rTotalDistance) = rotations.Aggregate((0, 0), (total, next) =>
    {
      var directionDistance = RotationsRegex().Split(next);

      var (direction, distance) = CreateDirectionDistanceTuple(directionDistance);

      var (lTotal, rTotal) = total;

      if (direction == 'L')
      {
        return (lTotal + distance, rTotal);
      }
      else
      {
        return (lTotal, rTotal + distance);
      }
    });

    var dial = 50 - lTotalDistanc + rTotalDistance;

    return dial;
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