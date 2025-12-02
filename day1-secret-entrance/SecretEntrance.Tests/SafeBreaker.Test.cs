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

  [Test]
  public void SolveSafePassword_GivenLargeLeftRotation_ReturnsCorrectClicks()
  {
    var expected = 0;

    var rotations = new List<string>()
    {
      "L151",
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }

  [Test]
  public void SolveSafePassword_GivenLargeRightRotation_ReturnsCorrectClicks()
  {
    var expected = 0;

    var rotations = new List<string>()
    {
      "R151",
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }

  [Test]
  public void SolveSafePassword_GivenSmallLeftRotation_ReturnsCorrectClicks()
  {
    var expected = 0;

    var rotations = new List<string>()
    {
      "L1",
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }

  [Test]
  public void SolveSafePassword_GivenSmallRotation_ReturnsCorrectClicks()
  {
    var expected = 0;

    var rotations = new List<string>()
    {
      "R1",
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }

  [TestCase("L50")]
  [TestCase("R50")]
  [TestCase("L150")]
  [TestCase("R150")]
  public void SolveSafePassword_GivenRotationLandingOnZero_ReturnsCorrectClicks(string rotation)
  {
    var expected = 1;

    var rotations = new List<string>()
    {
      rotation
    };

    var result = SafeBreaker.SolveSafePassword(rotations);

    Assert.That(result, Is.EqualTo(expected));
  }

}