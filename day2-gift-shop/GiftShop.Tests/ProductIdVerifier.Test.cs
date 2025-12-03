namespace GiftShop.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ReadProductIds_GivenExampleFile_ReturnsExpectedRanges()
    {
        var expectedRanges = new List<(long start, long end)> {
            (11,22),
            (95,115),
            (998,1012),
            (1188511880,1188511890),
            (222220,222224),
            (1698522,1698528),
            (446443,446449),
            (38593856,38593862),
            (565653,565659),
            (824824821,824824827),
            (2121212118,2121212124)
        };

        var path = "./example.txt";

        var ranges = await ProductIdVerifier.ReadProductIds(path);

        Assert.That(ranges, Is.EquivalentTo(expectedRanges));
    }

    [Test]
    public async Task ReadProductIds_GivenExampleFileWithLargeRange_ReturnsExpectedRanges()
    {
        var expectedRanges = new List<(long start, long end)> {
            new(9226466333, 9226692707)
        };

        var path = "./largerange.txt";

        var ranges = await ProductIdVerifier.ReadProductIds(path);

        Assert.That(ranges, Is.EquivalentTo(expectedRanges));
    }

    [Test]
    public async Task ReadProductIds_GivenExampleRanges_ReturnsExpectedInvalidIds()
    {
        var expectedInvalidIds = new List<long>
        {
          11, 22, 99, 1010, 1188511885, 222222, 446446, 38593859
        };

        var ranges = new List<(long start, long end)> {
            (11,22),
            (95,115),
            (998,1012),
            (1188511880,1188511890),
            (222220,222224),
            (1698522,1698528),
            (446443,446449),
            (38593856,38593862),
            (565653,565659),
            (824824821,824824827),
            (2121212118,2121212124)
        };

        var invalidIds = ProductIdVerifier.FindInvalidIds(ranges);

        Assert.That(invalidIds, Is.EquivalentTo(expectedInvalidIds));
    }

    [Test]
    public async Task ReadProductIds_GivenInvalidIds_ReturnsTotal()
    {
        var expectedTotal = 1227775554;
        var invalidIds = new List<long>
        {
          11, 22, 99, 1010, 1188511885, 222222, 446446, 38593859
        };

        var total = ProductIdVerifier.GetTotal(invalidIds);

        Assert.That(total, Is.EqualTo(expectedTotal));
    }
}