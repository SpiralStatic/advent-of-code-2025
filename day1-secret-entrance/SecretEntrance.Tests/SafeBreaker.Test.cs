namespace SecretEntrance.Tests;

public class Tests
{
  [SetUp]
  public void Setup()
  {
  }

  [Test]
  public void SolveSafePassword_GivenRotations_ReturnsCorrectPassword()
  {
    var expected = 3;

    var rotations = new List<string>()
    {
      "L68",
      "L30",
      "R48",
      "L5",
      "R60",
      "L55",
      "L1",
      "L99",
      "R14",
      "L82",
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }
}