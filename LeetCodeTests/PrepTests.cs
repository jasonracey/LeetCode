using static LeetCode.Prep;

namespace LeetCodeTests;

[TestClass]
public class PrepTests
{
    [DataTestMethod]
    [DataRow(new[] { -5, 1, 5, 0, -7 }, 1)]
    [DataRow(new[] { -4, -3, -2, -1, 4, 3, 2 }, 0)]
    public void LargestAltitudeTests(int[] nums, int expected)
    {
        LargestAltitude(nums).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow("abc", "ahbgdc", true)]
    [DataRow("axc", "ahbgdc", false)]
    [DataRow("bd", "abcd", true)]
    [DataRow("db", "abcd", false)]
    public void IsSubsequenceTests(string s, string t, bool expected)
    {
        IsSubsequence(s, t).Should().Be(expected);
    }
}