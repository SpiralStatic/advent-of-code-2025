using GiftShop;

var productIdRanges = await ProductIdVerifier.ReadProductIds("./input.txt");

var invalidIds = ProductIdVerifier.FindInvalidIds(productIdRanges);

var invalidIdsTotal = ProductIdVerifier.GetTotal(invalidIds);

Console.WriteLine("Part 1 - Invalid Id Total {0}", invalidIdsTotal);

var invalidIds2 = ProductIdVerifier.FindInvalidIds(productIdRanges, true);

var invalidIdsTotal2 = ProductIdVerifier.GetTotal(invalidIds2);

Console.WriteLine("Part 2 - Invalid Id Total {0}", invalidIdsTotal2);