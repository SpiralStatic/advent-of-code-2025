using SecretEntrance;

var rotations = await SafeBreaker.ReadRotationsInput("./input.txt");
var clicks = SafeBreaker.SolveSafePassword(rotations);

Console.WriteLine("Password: {0}", clicks);