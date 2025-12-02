using SecretEntrance;

var rotations = await SafeBreaker.ReadRotationsInput("./input.txt");

var part1Clicks = SafeBreaker.SolveSafePassword(rotations);
Console.WriteLine("Part 1 - Password: {0}", part1Clicks);

var part2Clicks = SafeBreaker.SolveSafePassword(rotations, PasswordMethod._0x434C49434);
Console.WriteLine("Part 2 - Password: {0}", part2Clicks);