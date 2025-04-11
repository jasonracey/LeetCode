using static LeetCode.Easy;

namespace LeetCodeTests;

[TestClass]
public class EasyTests
{
    [DataTestMethod]
    [DataRow(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [DataRow(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [DataRow(new[] { 3, 3 }, 6, new[] { 0, 1 })]
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

    [DataTestMethod]
    [DataRow(new[] { "flower", "flow", "flight" }, "fl")]
    [DataRow(new[] { "dog", "racecar", "car" }, "")]
    [DataRow(new[] { "" }, "")]
    [DataRow(new string[] { "a" }, "a")]
    public void LongestCommonPrefixTests(string[] sets, string expected)
    {
        LongestCommonPrefix(sets).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow("()", true)]
    [DataRow("()[]{}", true)]
    [DataRow("(]", false)]
    [DataRow("([])", true)]
    [DataRow("([)]", false)]
    [DataRow("(])", false)]
    public void IsValidParensTests(string s, bool expected)
    {
        IsValidParens(s).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new[] { 1, 1, 2 }, 2)]
    [DataRow(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    public void RemoveDuplicatesTests(int[] nums, int expected)
    {
        RemoveDuplicates(nums).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new int[] { }, 0, 0)]
    [DataRow(new[] { 1 }, 1, 0)]
    [DataRow(new[] { 3, 2, 2, 3 }, 3, 2)]
    [DataRow(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    [DataRow(new[] { 2, 2, 3 }, 2, 1)]
    public void RemoveElementTests(int[] nums, int val, int expected)
    {
        RemoveElement(nums, val).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow("sadbutsad", "sad", 0)]
    [DataRow("leetcode", "leeto", -1)]
    [DataRow("bubutsad", "but", 2)]
    [DataRow("aaa", "aaaa", -1)]
    [DataRow("mississippi", "issip", 4)]
    [DataRow("mississippi", "issipi", -1)]
    [DataRow("ippi", "ipi", -1)]
    public void StrStrTests(string haystack, string needle, int expected)
    {
        StrStr(haystack, needle).Should().Be(expected);
    }
}