﻿using LeetCode.Models;
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

    [DataTestMethod]
    [DataRow(new[] { 1, 3, 5, 6 }, 5, 2)]
    [DataRow(new[] { 1, 3, 5, 6 }, 2, 1)]
    [DataRow(new[] { 1, 3, 5, 6 }, 7, 4)]
    [DataRow(new[] { 1 }, 2, 1)]
    public void SearchInsertTests(int[] nums, int target, int expected)
    {
        SearchInsert(nums, target).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow("Hello World", 5)]
    [DataRow("   fly me   to   the moon  ", 4)]
    [DataRow("luffy is still joyboy", 6)]
    public void LengthOfLastWordTests(string s, int expected)
    {
        LengthOfLastWord(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(0, 0)]
    [DataRow(1, 1)]
    [DataRow(2, 1)]
    [DataRow(3, 1)]
    [DataRow(4, 2)]
    [DataRow(5, 2)]
    [DataRow(6, 2)]
    [DataRow(7, 2)]
    [DataRow(8, 2)]
    [DataRow(9, 3)]
    [DataRow(2147395600, 46340)]
    [DataRow(2147483647, 46340)]
    public void MySqrtTests(int i, int expected)
    {
        MySqrt(i).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
    [DataRow(new[] { 8, 9, 9 }, new[] { 9, 0, 0 })]
    [DataRow(new[] { 9, 9, 9 }, new[] { 1, 0, 0, 0 })]
    [DataRow(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [DataRow(new[] { 9 }, new[] { 1, 0 })]
    [DataRow(new[] { 8, 9, 9, 9 }, new[] { 9, 0, 0, 0 })]
    [DataRow(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 })]
    public void PlusOneTests(int[] digits, int[] expected)
    {
        PlusOne(digits).Should().Equal(expected);
    }

    // [DataTestMethod]
    // [DataRow(2, 2)]
    // [DataRow(3, 3)]
    // [DataRow(4, 5)]
    // [DataRow(5, 8)]
    // public void ClimbStairsTests(int num, int expected)
    // {
    //     ClimbStairs(num).Should().Be(expected);
    // }
    
    [DataTestMethod]
    [DataRow(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
    [DataRow(new[] { 1 }, 1, new int[]{}, 0, new[] { 1 })]
    [DataRow(new[] { 0 }, 0, new []{ 1 }, 1, new[] { 1 })]
    [DataRow(new[] { 2, 0 }, 1, new []{ 1 }, 1, new[] { 1, 2 })]
    [DataRow(new[] { 4,5,6,0,0,0 }, 3, new []{ 1,2,3 }, 3, new[] { 1,2,3,4,5,6 })]
    [DataRow(new[] { 1,2,4,5,6,0 }, 5, new []{ 3 }, 1, new[] { 1,2,3,4,5,6 })]
    [DataRow(new[] { 1,2,4,5,6,0,0,0 }, 5, new []{ 3,4,7 }, 3, new[] { 1,2,3,4,4,5,6,7 })]
    public void MergeTests(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        Merge(nums1, m, nums2, n);
        nums1.Should().Equal(expected);
    }
    
    public static IEnumerable<object[]> InorderTraversalData
    {
        get
        {
            return new[]
            { 
                new object[] { new TreeNode(val: 1, right: new TreeNode(val: 2, left: new TreeNode(val: 3))), new []{1, 3, 2} },
                new object[] { new TreeNode(val: 1, left: new TreeNode(2, left: new TreeNode(4), right: new TreeNode(5, left: new TreeNode(6), right: new TreeNode(7))), right: new TreeNode(val: 3, right: new TreeNode(val: 8), left: new TreeNode(val: 9))), new[]{4, 2, 6, 5, 7, 1, 9, 3, 8} },
            };
        }
    }

    [DataTestMethod]
    [DynamicData(nameof(InorderTraversalData))]
    public void InorderTraversalRecursiveTests(TreeNode root, IList<int> expected)
    {
        InorderTraversalRecursive(root).Should().Equal(expected);
    }
    
    [DataTestMethod]
    [DynamicData(nameof(InorderTraversalData))]
    public void InorderTraversalIterativeTests(TreeNode root, IList<int> expected)
    {
        InorderTraversalIterative(root).Should().Equal(expected);
    }
    
    public static IEnumerable<object[]> IsSameTreeData
    {
        get
        {
            return new[]
            {
                new object[] { null, new TreeNode(val: 0), false },
                new object[] { new TreeNode(val: 1), new TreeNode(val: 1, left: null, right: new TreeNode(val: 2)), false },
                new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2), right: new TreeNode(val: 3)), new TreeNode(val: 1, left: new TreeNode(val: 2), right: new TreeNode(val: 3)), true },
                new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2)), new TreeNode(val: 1, right: new TreeNode(val: 2)), false },
                new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2), right: new TreeNode(val: 1)), new TreeNode(val: 1, left: new TreeNode(val: 1), right: new TreeNode(val: 2)), false },
                new object[] { new TreeNode(val: 2, right: new TreeNode(val: 4)), new TreeNode(val: 2, left: new TreeNode(val: 3), right: new TreeNode(val: 4)), false },
            };
        }
    }
    
    [DataTestMethod]
    [DynamicData(nameof(IsSameTreeData))]
    public void IsSameTreeTests(TreeNode p, TreeNode q, bool expected)
    {
        IsSameTree(p, q).Should().Be(expected);
    }

    public static IEnumerable<object[]> IsSymmetricData
    {
        get
        {
            return new[]
            {
                //[1,2,2,3,4,4,3]
                //new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2, left: new TreeNode(val: 3), right: new TreeNode(val: 4)), right: new TreeNode(val: 2, left: new TreeNode(val: 4), right: new TreeNode(val: 3))), true },
                //[1,2,2,null,3,null,3]
                //new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2, left: null, right: new TreeNode(val: 3)), right: new TreeNode(val: 2, left: null, right: new TreeNode(val: 3))), false },
                //[1,2,2,2,null,2]
                new object[] { new TreeNode(val: 1, left: new TreeNode(val: 2, left: new TreeNode(val: 2), right: null), right: new TreeNode(val: 2, left: new TreeNode(val: 2), right: null)), false },
            };
        }
    }

    [DataTestMethod]
    [DynamicData(nameof(IsSymmetricData))]
    public void IsSymmetricTests(TreeNode root, bool expected)
    {
        IsSymmetric(root).Should().Be(expected);
    }
}