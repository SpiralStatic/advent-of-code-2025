using GiftShop;

var productIdRanges = await ProductIdVerifier.ReadProductIds("./input.txt");

var invalidIds = ProductIdVerifier.FindInvalidIds(productIdRanges);

var invalidIdsTotal = ProductIdVerifier.GetTotal(invalidIds);

Console.WriteLine("Invalid Id Total {0}", invalidIdsTotal);