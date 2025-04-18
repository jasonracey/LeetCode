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
    
    [DataTestMethod]
    [DataRow(new[]{1,1,0,1}, 3)]
    [DataRow(new[]{0,1,1,1,0,1,1,0,1}, 5)]
    [DataRow(new[]{1,1,1}, 2)]
    public void LongestSubarrayTests(int[] nums, int expected)
    {
        LongestSubarray(nums).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[]{-5,1,5,0,-7}, 1)]
    [DataRow(new[]{-4,-3,-2,-1,4,3,2}, 0)]
    public void LargestAltitudeTests(int[] nums, int expected)
    {
        LargestAltitude(nums).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[]{1,7,3,6,5,6}, 3)]
    [DataRow(new[]{1,2,3}, -1)]
    [DataRow(new[]{2,1,-1}, 0)]
    [DataRow(new[]{-1,-1,-1,-1,-1,0}, 2)]
    [DataRow(new[]{0,-1,-1,-1,-1,-1}, 3)]
    [DataRow(new[]{-1,-1,-1,-1,-1,-1}, -1)]
    [DataRow(new[]{-1,-1,-1,-1,-1,1}, -1)]
    [DataRow(new[]{-1,-1,-1,-1,0,0}, -1)]
    [DataRow(new[]{-1,-1,-1,-1,0,1}, 1)]
    public void PivotIndexTests(int[] nums, int expected)
    {
        PivotIndex(nums).Should().Be(expected);
    }
    
    public static IEnumerable<object[]> FindDifferenceData()
    {
        yield return [ new[]{1,2,3}, new[]{2,4,6}, new List<List<int>> {new() {1, 3},  new() {4, 6}} ];
        yield return [ new[]{1,2,3,3}, new[]{1,1,2,2}, new List<List<int>> {new() {3},  new()} ];
    }
    [DataTestMethod]
    [DynamicData(nameof(FindDifferenceData), DynamicDataSourceType.Method)]
    public void FindDifferenceTests(int[] nums1, int[] nums2, List<List<int>> expected)
    {
        var result = FindDifference(nums1, nums2);
        result[0].Should().Equal(expected[0]);
        result[1].Should().Equal(expected[1]);
    }
    
    [DataTestMethod]
    [DataRow(new[]{1,2,2,1,1,3}, true)]
    [DataRow(new[]{1,2}, false)]
    [DataRow(new[]{-3,0,1,-3,1,1,1,-3,10,0}, true)]
    public void UniqueOccurrencesTests(int[] nums, bool expected)
    {
        UniqueOccurrences(nums).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("abc", "bca", true)]
    [DataRow("a", "aa", false)]
    [DataRow("cabbba", "abbccc", true)]
    [DataRow("uau", "ssx", false)]
    [DataRow("mkmczky", "cckcmmy", false)]
    [DataRow("abbzzca", "babzzcz", false)]
    public void CloseStringsTests(string word1, string word2, bool expected)
    {
        CloseStrings(word1, word2).Should().Be(expected);
    }
    
    public static IEnumerable<object[]> EqualPairsData()
    {
        yield return [new int[][] { [3,2,1], [1,7,6], [2,7,7] }, 1];
        yield return [new int[][] { [3,1,2,2], [1,4,4,5], [2,4,2,2], [2,4,2,2] }, 3];
        yield return [new int[][] { [3,1,2,2], [1,4,4,4], [2,4,2,2], [2,5,2,2] }, 3];
    }
    [DataTestMethod]
    [DynamicData(nameof(EqualPairsData), DynamicDataSourceType.Method)]
    public void EqualPairsTests(int[][] grid, int expected)
    {
        EqualPairs(grid).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("leet**cod*e", "lecoe")]
    [DataRow("erase*****", "")]
    public void RemoveStarsTests(string s, string expected)
    {
        RemoveStars(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow(new[]{5,10,-5}, new[]{5,10})]
    [DataRow(new[]{8,-8}, new int[]{})]
    [DataRow(new[]{10,2,-5}, new []{10})]
    [DataRow(new[]{-2,1,-2,-3}, new []{-2,-2,-3})]
    [DataRow(new[]{-2,1,-1,-2}, new []{-2,-2})]
    [DataRow(new[]{-2,2,-1,-2}, new []{-2})]
    [DataRow(new[]{1,-2,-2,-2}, new []{-2,-2,-2})]
    [DataRow(new[]{-2,2,1,-2}, new []{-2})]
    public void AsteroidCollisionTests(int[] asteroids, int[] expected)
    {
        AsteroidCollision(asteroids).Should().Equal(expected);
    }

    [TestMethod]
    public void TreeHeightTest()
    {
        var f = new Node<int>(null, null);
        var g = new Node<int>(null, null);
        var h = new Node<int>(null, null);
        var d = new Node<int>(f, g);
        var e = new Node<int>(null, h);
        var b = new Node<int>(null, null);
        var c = new Node<int>(d, e);
        var a = new Node<int>(b, c);
        
        var max = TreeHeight(a);
        
        max.Should().Be(4);
    }
    
    private static readonly Node<int> N110 = new(null, null, 110);
    private static readonly Node<int> N125 = new(N110, null, 125);
    private static readonly Node<int> N175 = new(null, null, 175);
    private static readonly Node<int> N150 = new(N125, N175, 150);
    private static readonly Node<int> N25 = new(null, null, 25);
    private static readonly Node<int> N75 = new(null, null, 75);
    private static readonly Node<int> N50 = new(N25, N75, 50);
    private static readonly Node<int> N100 = new(N50, N150, 100);

    [TestMethod]
    public void PreorderTest()
    {
        Preorder(N100);
    }
    
    [TestMethod]
    public void PreorderWithoutRecursionTest()
    {
        PreorderWithoutRecursion(N100);
    }
    
    [TestMethod]
    public void PreorderWithoutRecursionUsingStackTest()
    {
        PreorderWithoutRecursionUsingStack(N100);
    }
    
    [TestMethod]
    public void InorderTest()
    {
        Inorder(N100);
    }
    
    [TestMethod]
    public void PostorderTest()
    {
        Postorder(N100);
    }
    
    [TestMethod]
    public void LowestCommonAncestorTest()
    {
        Node<int> n10 = new(null, null, 10);
        Node<int> n14 = new(null, null, 14);
        Node<int> n12 = new(n10, n14, 12);
        Node<int> n4 = new(null, null, 4);
        Node<int> n8 = new(n4, n12, 8);
        Node<int> n22 = new(null, null, 22);
        Node<int> n20 = new(n8, n22, 20);
        
        LowestCommonAncestor(n20, 4, 14);
    }
    
    [TestMethod]
    public void ToMinHeapTests()
    {
        Node<int> n10 = new(null, null, 10);
        Node<int> n14 = new(null, null, 14);
        Node<int> n12 = new(n10, n14, 12);
        Node<int> n4 = new(null, null, 4);
        Node<int> n8 = new(n4, n12, 8);
        Node<int> n22 = new(null, null, 22);
        Node<int> n20 = new(n8, n22, 20);
        
        var root = ToMinHeap(n20);

        root.Should().NotBeNull();
        root.Value.Should().Be(4);
    }
    
    [DataTestMethod]
    [DataRow("a", true)]
    [DataRow("aa", true)]
    [DataRow("ab", false)]
    [DataRow("aba", true)]
    [DataRow("abba", true)]
    public void IsPalindromeTests(string s, bool expected)
    {
        IsPalindrome(s).Should().Be(expected);
    }
    
    [DataTestMethod]
    [DataRow("soundgarden", "nudedragons", true)]
    [DataRow("soundgarden", "nudedragonss", false)]
    [DataRow("soundgarden", "nudedragonz", false)]
    public void IsAnagramTests(string s1, string s2, bool expected)
    {
        IsAnagram(s1, s2).Should().Be(expected);
    }
}