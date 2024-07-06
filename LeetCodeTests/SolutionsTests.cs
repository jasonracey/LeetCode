using static LeetCode.Solutions;

namespace LeetCodeTests;

[TestClass]
public class SolutionsTests
{
    [DataTestMethod]
    [DataRow("abc", "pqr", "apbqcr")]
    [DataRow("ab", "pqrs", "apbqrs")]
    [DataRow("abcd", "pq", "apbqcd")]
    public void MergeAlternatelyTests(string a, string b, string expected)
    {
        MergeAlternately(a, b).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("ABCABC", "ABC", "ABC")]
    [DataRow("ABABAB", "ABAB", "AB")]
    [DataRow("LEET", "CODE", "")]
    [DataRow("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX")]
    public void GreatestCommonDivisorTests(string a, string b, string expected)
    {
        GreatestCommonDivisor(a, b).Should().Be(expected);
    }

    [DataTestMethod]
    [DataRow(new[] {2, 3, 5, 1, 3}, 3, new []{true, true, true, false, true})]
    [DataRow(new[] {4, 2, 1, 1, 2}, 1, new []{true, false, false, false, false})]
    [DataRow(new[] {12, 1, 12}, 10, new []{true, false, true})]
    public void KidsWithCandiesTests(int[] candies, int extra, bool[] expected)
    {
        KidsWithCandies(candies, extra).Should().Equal(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {1, 0, 0, 0, 1}, 1, true)]
    [DataRow(new[] {1, 0, 0, 0, 1}, 2, false)]
    [DataRow(new[] {1, 0, 0, 0, 0, 1}, 2, false)]
    [DataRow(new[] {1, 0, 0, 0, 0, 0, 1}, 2, true)]
    [DataRow(new[] {0, 0, 1, 0, 1}, 1, true)]
    [DataRow(new[] {1, 0, 1, 0, 0}, 1, true)]
    public void CanPlaceFlowersTests(int[] beds, int n, bool expected)
    {
        CanPlaceFlowers(beds, n).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("hello", "holle")]
    [DataRow("leetcode", "leotcede")]
    public void ReverseVowelsTests(string s, string expected)
    {
        ReverseVowels(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("the sky is blue", "blue is sky the")]
    [DataRow("  hello world  ", "world hello")]
    [DataRow("a good   example", "example good a")]
    public void ReverseWordsTests(string s, string expected)
    {
        ReverseWords(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("the sky is blue", "blue is sky the")]
    [DataRow("  hello world  ", "world hello")]
    [DataRow("a good   example", "example good a")]
    public void ReverseWordsMetalTests(string s, string expected)
    {
        ReverseWordsPointers(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("the sky is blue", "blue is sky the")]
    [DataRow("  hello world  ", "world hello")]
    [DataRow("a good   example", "example good a")]
    public void ReverseWordsStackTests(string s, string expected)
    {
        ReverseWordsStack(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {2,2,3,4}, new[] {24,24,16,12})]
    [DataRow(new[] {1,2,3,4}, new[] {24,12,8,6})]
    [DataRow(new[] {-1,1,0,-3,3}, new[] {0,0,9,0,0})]
    public void ProductExceptSelfTests(int[] nums, int[] expected)
    {
        ProductExceptSelf(nums).Should().Equal(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {0,4,2,1,0,-1,-3}, false)]
    [DataRow(new[] {6,7,1,2}, false)]
    [DataRow(new[] {1,5,0,4,1,3}, true)]
    [DataRow(new[] {1,2,1,3}, true)]
    [DataRow(new[] {2,1,5,0,4,6}, true)]
    [DataRow(new[] {2,1,5,3,4}, true)]
    [DataRow(new[] {1,2,3,4,5}, true)]
    [DataRow(new[] {5,4,3,2,1}, false)]
    [DataRow(new[] {20,100,10,12,5,13}, true)]
    [DataRow(new[] {0,-1,0,0,0,100000000}, true)]
    public void IncreasingTripletTests(int[] nums, bool expected)
    {
        IncreasingTriplet(nums).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {'a','a','a','b','b','a','a'}, new[] {'a','3','b','2','a','2','a'}, 6)]
    [DataRow(new[] {'a'}, new[] {'a'}, 1)]
    [DataRow(new[] {'a','b','c'}, new[] {'a','b','c'}, 3)]
    [DataRow(new[] {'a','b','b'}, new[] {'a','b','2'}, 3)]
    [DataRow(new[] {'a','b','b','b'}, new[] {'a','b','3','b'}, 3)]
    [DataRow(new[] {'a','a','b','b'}, new[] {'a','2','b','2'}, 4)]
    [DataRow(new[] {'a','b','b','b','b','b','b','b','b','b','b','b','b'}, new[] {'a','b','1','2','b','b','b','b','b','b','b','b'}, 4)]
    [DataRow(new[] {'a','a','b','b','c','c','c'}, new[] {'a','2','b','2','c','3','c'}, 6)]
    [DataRow(new[] {'a','a','a','a','a','b'}, new[] {'a','5','b','a','a','b'}, 3)]
    public void CompressTests(char[] chars, char[] output, int expected)
    {
        Compress(chars).Should().Be(expected);
        for (var i = 0; i < output.Length; i++)
        {
            chars[i].Should().Be(output[i]);
        }
    }
    
    [DataTestMethod]
    [DataRow(new[] {0}, new[] {0})]
    [DataRow(new[] {0,1,0,3,12}, new[] {1,3,12,0,0})]
    public void MoveZeroesTests(int[] nums, int[] expected)
    {
        MoveZeroes(nums);
        for (var i = 0; i < expected.Length; i++)
        {
            nums[i].Should().Be(expected[i]);
        }
    }
    
    [DataTestMethod]
    [DataRow("", "ahbgdc", true)]
    [DataRow("abc", "ahbgdc", true)]
    [DataRow("axc", "ahbgdc", false)]
    public void IsSubsequenceTests(string s, string t, bool expected)
    {
        IsSubsequence(s, t).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {2,3,10,5,7,8,9}, 36)]
    [DataRow(new[] {1,8,6,2,5,4,8,3,7}, 49)]
    [DataRow(new[] {1,1}, 1)]
    [DataRow(new[] {1,0,0,0,0,0,0,2,2}, 8)]
    public void MaxAreaTests(int[] heights, int expected)
    {
        MaxArea(heights).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[] {3,2,1,4}, 5, 2)]
    [DataRow(new[] {3,1,3,4,3}, 6, 1)]
    public void MaxOperationsTests(int[] nums, int k, int expected)
    {
        MaxOperations(nums, k).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[]{3,3,4,3,0}, 3, 3.33333)]
    [DataRow(new[] {1,12,-5,-6,50,3}, 4, 12.75000)]
    [DataRow(new[] {5}, 1, 5.00000)]
    [DataRow(new[] {-1}, 1, -1.00000)]
    public void FindMaxAverageTests(int[] nums, int k, double expected)
    {
        FindMaxAverage(nums, k).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("abciiidef", 3, 3)]
    [DataRow("aeiou", 2, 2)]
    [DataRow("leetcode", 3, 2)]
    public void MaxVowelsTests(string s, int k, int expected)
    {
        MaxVowels(s, k).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[]{1,0,1,0}, 2, 4)]
    [DataRow(new[]{1,1,1,0,0,0,1,1,1,1,0}, 2, 6)]
    [DataRow(new[]{0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1}, 3, 10)]
    [DataRow(new[]{1,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,0,0,1,1,0,1,1}, 8, 25)]
    public void LongestOnesTests(int[] nums, int k, int expected)
    {
        LongestOnes(nums, k).Should().Be(expected);
    }
}