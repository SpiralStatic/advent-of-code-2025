using System.Text.RegularExpressions;

namespace SecretEntrance;

public partial class SafeBreaker
{
  public static async Task<IEnumerable<string>> ReadRotationsInput(string path)
  {
    return await File.ReadAllLinesAsync(path);
  }

  public static int SolveSafePassword(IEnumerable<string> rotations, PasswordMethod passwordMethod = PasswordMethod.Default)
  {
    var clicks = passwordMethod == PasswordMethod._0x434C49434 ? CalculateDialClicks0x434C49434B(rotations) : CalculateDialClicks(rotations);

    return clicks;
  }

  private static int CalculateDialClicks(IEnumerable<string> rotations)
  {
    var (_finalDialPosition, clicks) = rotations.Aggregate((50, 0), (current, next) =>
    {
      var directionDistance = RotationsRegex().Split(next);

      var (direction, distance) = CreateDirectionDistanceTuple(directionDistance);

      var (currentDialPosition, currentClicks) = current;

      var nextDialPosition = direction == 'L' ? currentDialPosition - distance : currentDialPosition + distance;
      var nextClicks = nextDialPosition % 100 == 0 ? currentClicks + 1 : currentClicks;

      return (nextDialPosition, nextClicks);
    });

    return clicks;
  }

  private static int CalculateDialClicks0x434C49434B(IEnumerable<string> rotations)
  {
    var (_finalDialPosition, clicks) = rotations.Aggregate((50, 0), (current, next) =>
    {
      var directionDistance = RotationsRegex().Split(next);

      var (direction, distance) = CreateDirectionDistanceTuple(directionDistance);

      var (currentDialPosition, currentClicks) = current;

      var nextClicks = 0;
      if (direction == 'L')
      {
        var nextDialPosition = currentDialPosition - distance;
        
        for (var i = currentDialPosition - 1; i >= nextDialPosition; i--)
        {
          if (i == 0 || i % 100 == 0)
          {
            nextClicks++;
          }
        }

        var remainingDistance = 100 + (nextDialPosition % 100);
        return (nextClicks > 0 ? remainingDistance : nextDialPosition, currentClicks + nextClicks);
      }
      else
      {
        var nextDialPosition = currentDialPosition + distance;
        for (var i = currentDialPosition + 1; i <= nextDialPosition; i++)
        {
          if (i == 0 || i % 100 == 0)
          {
            nextClicks++;
          }
        }

        var remainingDistance = 0 + (nextDialPosition % 100);
        return (nextClicks > 0 ? remainingDistance : nextDialPosition, currentClicks + nextClicks);
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
    if (direction != 'L' && direction != 'R') throw new FormatException("Invalid Direction, not L or R");
    if (!distanceSuccess) throw new FormatException("Invalid Distance, not an int");

    return (direction, distance);
  }

  [GeneratedRegex(@"(?<=[LR])")]
  private static partial Regex RotationsRegex();
}