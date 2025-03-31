using static LeetCode.Easy;

namespace LeetCodeTests;

[TestClass]
public class EasyTests
{
    [DataTestMethod]
    [DataRow(new[] { 2,7,11,15 }, 9, new[] { 0, 1})]
    [DataRow(new[] { 3,2,4 }, 6, new[] { 1, 2})]
    [DataRow(new[] { 3,3 }, 6, new[] { 0, 1})]
    public void TwoSumTests(int[] nums, int target, int[] expected)
    {
        TwoSum(nums, target).Should().Equal(expected);
    }

    [DataTestMethod]
    [DataRow(-121, false)]
    [DataRow(0, true)]
    [DataRow(10, false)]
    [DataRow(11, true)]
    [DataRow(110, false)]
    [DataRow(111, true)]
    [DataRow(121, true)]
    [DataRow(131000, false)]
    public void PalindromeNumberTests(int x, bool expected)
    {
        PalindromeNumber(x).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow("XIV", 14)]
    [DataRow("XXX", 30)]
    [DataRow("XXI", 21)]
    [DataRow("III", 3)]
    [DataRow("LVIII", 58)]
    [DataRow("MCMXCIV", 1994)]
    [DataRow("MCMXCVI", 1996)]
    [DataRow("MDCXCV", 1695)]
    [DataRow("D", 500)]
    public void RomanToIntegerTests(string roman, int expected)
    {
        RomanToInteger(roman).Should().Be(expected);
    }
}