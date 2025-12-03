namespace GiftShop.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadProductIds_GivenExampleFile_ReturnsExpectedRanges()
    {
        var expectedRanges = new List<Range> {
            11..22,
            95..115,
            998..1012,
            1188511880..1188511890,
            222220..222224,
            1698522..1698528,
            446443..446449,
            38593856..38593862,
            565653..565659,
            824824821..824824827,
            2121212118..2121212124
        };

        var path = "./example.txt";
        
        var ranges = ProductIdVerifier.ReadProductIds(path);

        Assert.That(ranges, Is.EquivalentTo(expectedRanges));
    }
}