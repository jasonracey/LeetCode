using System.Text;

namespace LeetCode;

public static class Solutions
{
    public static string MergeAlternately(string word1, string word2) 
    {
        var maxLength = Math.Max(word1.Length, word2.Length);

        var output = new StringBuilder();

        for (var i = 0; i < maxLength; i++)
        {
            output.Append(GetNextLetterOrEmpty(i, word1));
            output.Append(GetNextLetterOrEmpty(i, word2));
        }

        return output.ToString();
        
        string GetNextLetterOrEmpty(int index, string word) => index < word.Length
            ? word[index].ToString()
            : string.Empty;
    }
    
    public static string GreatestCommonDivisor(string str1, string str2)
    {
        ArgumentNullException.ThrowIfNull(str1);
        ArgumentNullException.ThrowIfNull(str2);
        
        if (str1 + str2 != str2 + str1)
            return string.Empty;

        var lenA = str1.Length;
        var lenB = str2.Length;

        /*
        The Euclidean algorithm. Finds the greatest common divisor of 2 numbers. Since we know 
        the strings are equivalent if concatenated in opposite orders, then all we have to do 
        is find the greatest common divisor of their lengths. This is the longest common substring.
        
        lenA 6 ABABAB 4 ABAB 2 AB <-- GCD
        lenB 4 ABAB   2 AB   0
        temp          4      2
         */
        while (lenB != 0)
        {
            var temp = lenB;
            lenB = lenA % lenB;
            lenA = temp;
        }

        return str1[..lenA];
    }

    public static IEnumerable<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        // determine max O(n)
        var max = candies.Max();

        var result = new bool[candies.Length];

        // each value + extra >= max is true O(n)
        for (var i = 0; i < candies.Length; i++)
        {
            result[i] = candies[i] + extraCandies >= max;
        }

        return result;
    }
    
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        // iterate over array with 3 pointers (i-1, i, i+1)
        // every time there's 3 empty spots, increment x
        // return x >= n
        var x = 0;
        
        for (var i = 0; i < flowerbed.Length; i++)
        {
            // For left pointer, start at 0 to catch when first position is eligible [0,0,1]
            var left = i == 0 ? 0 : i - 1;
            
            var center = i;
            
            // For right pointer, end at flowerbed.Length - 1 to catch when last position is eligible [1,0,0]
            var right = i == flowerbed.Length - 1 ? i : i + 1;
            
            if (flowerbed[left] == 0 && flowerbed[center] == 0 && flowerbed[right] == 0)
            {
                x++; // increment counter
                i++; // skip next position because we placed a flower
            }
        }

        return x >= n;
    }
    
    public static string ReverseVowels(string s)
    {
        /*
        Given a string s, reverse only all the vowels in the string and return it.
        The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.
        
        Example 1:
           
        Input: s = "hello"
        Output: "holle"
        
        Example 2:
           
        Input: s = "leetcode"
        Output: "leotcede"
        
        not sure what "reverse" means, examples are ambiguous because there's 2 different ways
        you can solve the second example, assume it means swap each vowel with the next one
        in the string from left to right
        
        2 pointers
        left at start, right at end
        increment left
        if left at vowel or == right stop left else repeat
        decrement right
        if right at vowel or == left stop right else repeat
        if both at vowel swap and repeat
        exit condition is left >= right
        */
        HashSet<char> vowels = [..new[] {'a', 'e', 'i', 'o', 'u'}];
        
        var left = 0;
        var right = s.Length - 1;

        // because strings are immutable use a char array to allow character swap
        var chars = s.ToCharArray();

        while (left < right)
        {
            while (!IsVowel(chars[left]) && left < right)
            {
                left++;
            }
            
            while (!IsVowel(chars[right]) && right > left)
            {
                right--;
            }

            if (left < right)
            {
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }
        }

        return new string(chars);

        bool IsVowel(char c) => vowels.Contains(char.ToLower(c));
    }
    
    public static string ReverseWords(string s)
    {
        var words = s.Split(
            separator: ' ', 
            options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var sb = new StringBuilder();
        
        for (var i = words.Length; i > 0; i--)
        {
            sb.Append(words[i - 1]);
            if (i - 1 > 0)
                sb.Append(' ');
        }

        return sb.ToString();
    }

    public static string ReverseWordsPointers(string s)
    {
        // reverse the entire string <- easy
        // reverse each letter in each word <- hard
        // either order of these steps works
        // hello world > olleh dlrow > world hello
        // hello world > dlrow olleh > world hello
        
        var chars = new char[s.Length];
        
        // hello world > dlrow olleh
        for (int i = 0, j = s.Length; j > 0; i++, j--)
        {
            chars[i] = s[j - 1];
        }
        
        // dlrow olleh > world hello
        // ^   ^
        // need 2 pointers, first at start, second at last (next is space)
        
        int left = 0, right = 0;

        while (right < chars.Length - 1)
        {
            // move right to end of current word
            while (right < chars.Length - 1 && chars[right + 1] != ' ')
                right++;
            
            // reverse word
            int p1 = left, p2 = right;
            while (p1 < p2)
            {
                (chars[p1], chars[p2]) = (chars[p2], chars[p1]);
                p1++;
                p2--;
            }

            // move to start of next word
            right += 2;
            left = right;
        }

        var untrimmed = new string(chars);

        // todo: inefficient
        while (untrimmed.Contains("  "))
            untrimmed = untrimmed.Replace("  ", " ");
        
        // todo: cheating
        return untrimmed.Trim();
    }

    public static string ReverseWordsStack(string s)
    {
        var words = s.Split(
            separator: ' ', 
            options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        var stack = new Stack<string>();

        foreach (var word in words)
        {
            stack.Push(word);
        }

        var sb = new StringBuilder();

        while (stack.TryPop(out var word))
        {
            sb.Append(word);
            if (stack.TryPeek(out _))
                sb.Append(' ');
        }

        return sb.ToString();
    }
    
    public static int[] ProductExceptSelf(int[] nums)
    {
        /*
        Given an integer array nums, return an array answer such that answer[i] is equal to the 
        product of all the elements of nums except nums[i].
        
        Input: nums = [3,4,5]
        Output: [20,15,12]
        
        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]
        
        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]

        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        You must write an algorithm that runs in O(n) time and without using the division operation.
        */
        
        // O(n^2) solution
        // var arrayLength = nums.Length;
        // var results = new int[arrayLength];
        // for (var i = 0; i < nums.Length; i++)
        // {
        //     for (var j = 0; j < nums.Length; j++)
        //     {
        //         if (j != i)
        //             results[i] *= nums[j];
        //     }
        // }
        // return results;
        
        // O(3n) solution
        // var arrayLength = nums.Length;
        // var prefixProducts = new int[arrayLength];
        // var suffixProducts = new int[arrayLength];
        // Array.Fill(prefixProducts, 1);
        // Array.Fill(suffixProducts, 1);
        // // [1,2,3,4] > [1,1,2,6][(1),(1)*1,(1)*1*2,(1)*1*2*3]
        // for (var i = 1; i < arrayLength; i++)
        // {
        //     prefixProducts[i] = nums[i - 1] * prefixProducts[i - 1];
        // }
        // // [1,2,3,4] > [24,12,4,1][(1)*4*3*2,(1)*4*3,(1)*4,(1)]
        // for (var i = arrayLength - 2; i > -1; i--)
        // {
        //     suffixProducts[i] = nums[i + 1] * suffixProducts[i + 1];
        // }
        // var result = new int[arrayLength];
        // for (var i = 0; i < arrayLength; i++)
        // {
        //     // [1,1,2,6] * [24,12,4,1] > [24,12,8,6]
        //     result[i] = prefixProducts[i] * suffixProducts[i];
        // }
        // return result;
        
        // O(2n) solution
        // var arrayLength = nums.Length;
        // var prefixProducts = new int[arrayLength];
        // var suffixProducts = new int[arrayLength];
        // Array.Fill(prefixProducts, 1);
        // Array.Fill(suffixProducts, 1);
        // for (int i = 1, j = arrayLength - 2; i < arrayLength; i++, j--)
        // {
        //     // At each index, one array has part of the set and the other array has the rest of
        //     // the set. The set does not include the "self" value.
        //     // [1,2,3,4] > [1,1,2,6][(1),(1)*1,(1)*1*2,(1)*1*2*3]
        //     prefixProducts[i] = nums[i - 1] * prefixProducts[i - 1];
        //     // [1,2,3,4] > [24,12,4,1][(1)*4*3*2,(1)*4*3,(1)*4,(1)]
        //     suffixProducts[j] = nums[j + 1] * suffixProducts[j + 1];
        // }
        // var result = new int[arrayLength];
        // for (var i = 0; i < arrayLength; i++)
        // {
        //     // Get the product of the complete set, without "self", by multiplying the arrays.
        //     // [1,1,2,6] * [24,12,4,1] > [24,12,8,6][(1)*(1)*4*3*2,(1)*1*(1)*4*3,(1)*1*2*(1)*4,(1)*1*2*3*(1)]
        //     result[i] = prefixProducts[i] * suffixProducts[i];
        // }
        // return result;
        
        // O(2n) with O(1) memory
        // You can save space on memory by using the result array directly instead of storing prefix
        // and suffix products in prefix_products and suffix_products.
        /*
        For ones, who did not understand how prefix-postfix works, lets change 1, 2, 3, 4 positions to symbols like a, b, c, d, so multiplying will be:
        prefix:
        ->
        |       a       |   a*b   | a*b*c | a*b*c*d |
        postfix:
        <-
        | a*b*c*d | b*c*d |   c*d   |      d        |

        the result is a multiply without the symbol in own position (the left value from prefix and the right one from postfix):
        |    b*c*d  | a*c*d | a*b*d |   a*b*c   |
        */
        var results = new int[nums.Length];
        
        // [2,2,3,4] nums
        // [1,1,1,1] results in
        // [1,2,4,12] results
        var prefix = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            results[i] = prefix; //2,2,4,12
            prefix *= nums[i];   //2,1*2,1*2*2,1*2*2*3
        }

        // [2,2,3,4] nums
        // [1,2,4,12] results in
        // [24,24,16,12] results out
        // |x    |a    |a*b  |a*b*c|
        // |a    |b    | c   |  d  |
        // |b*c*d|a*c*d|a*b*d|a*b*c|
        var postfix = 1;
        for (var i = nums.Length - 1; i > -1; i--)
        {
            results[i] *= postfix; //12*1,4*1*4,2*1*4*3,1*1*4*3*2
            postfix *= nums[i];    //1*4,1*4*3,1*4*3*2
        }
        
        return results;
    }
    
    public static bool IncreasingTriplet(int[] nums)
    {
        /*
        Given an integer array nums, return true if there exists a triple of indices (i, j, k) such 
        that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.

        Input: nums = [1,2,3,4,5]
        Output: true
        Explanation: Any triplet where i < j < k is valid. 1,2,3 and 2,3,4

        Input: nums = [5,4,3,2,1]
        Output: false
        Explanation: No triplet exists.

        Input: nums = [2,1,5,0,4,6]
        Output: true
        Explanation: The triplet (3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4 < nums[5] == 6.
        
        Input: nums = [20,100,10,12,5,13]
        Output: true
        */
        
        /*
        // This only works when the indices are sequential.
        int left = 0, center = 1, right = 2;
        while (right < nums.Length)
        {
            if (nums[left] < nums[center] && nums[center] < nums[right])
                return true;
            left++;
            center++;
            right++;
        }
        return false;
        */

        /*
        // inchworm - 3 pointers
        // [2,1,5,3,4] 234 134
        // 215
        // 253 254
        // 234
        // too slow
        int left = 0, center = 1, right = 2;
        var max = int.MinValue;
        while (left < nums.Length - 2)
        {
            while (center < nums.Length - 1)
            {
                while (right < nums.Length)
                {
                    var a = nums[left];
                    var b = nums[center];
                    var c = nums[right];
                    if (a < b && b < c)
                        return true;
                    if (a > b)
                        break;
                    max = Math.Max(a, Math.Max(b, c));
                    right++;
                }
                do
                {
                    // if center is max then any set with this center can't be a solution
                    center++;
                    right = center + 1;
                } while (center < nums.Length - 1 && nums[center] == max);
            }
            do
            {
                // if left is max then any set with this left can't be a solution
                left++;
                center = left + 1;
                right = center + 1;
            } while (left < nums.Length - 2 && nums[left] == max);
        }
        return false;
        */
        
        // faster solution
        // [20,100,10,12,5,13]
        // graph of the points
        // x axis is array index
        // y axis is value
        // horiz bar moves down the graph, every time it hits a point it notes the direction on x-axis since last hit
        // moving L twice in a row means it found 3 increasing numbers
        /*  x(1,100)
         *
         * L
         *
         * x(0,20)
         *     R
         * v--------------------v
         *      L x(5,13)
         *   L x(3,12)
         *   x(2,10)
         *     R
         *      x(4,5)
         */
        
        // generate lists of increasing values
        // [DataRow(new[] {1,5,0,4,1,3}, true)]
        // 1,4x
        // 5
        // 0,4x
        // 0,1,3
        // 4
        // 1,3
        // 3
        // var dict = new Dictionary<int, List<int>>();
        // foreach (var curr in nums)
        // {
        //     if (!dict.ContainsKey(curr))
        //         dict.Add(curr, []);
        //     
        //     foreach (var kvp in dict.Where(kvp => kvp.Key < curr))
        //     {
        //         if (kvp.Value.All(x => x < curr))
        //         {
        //             kvp.Value.Add(curr);
        //         }
        //         else
        //         {
        //             kvp.Value.Clear();
        //             kvp.Value.Add(curr);
        //         }
        //         
        //         if (kvp.Value.Count >= 2)
        //             return true;
        //     }
        // }
        //
        // return false;
        
        // best solution
        var first = int.MaxValue;
        var second = int.MaxValue;
        foreach (var num in nums)
        {
            if (num <= first)
                first = num;
            else if (num <= second)
                second = num;
            else 
                return true;
        }

        return false;
    }
    
    public static int Compress(char[] chars)
    {
        /*
           Given an array of characters chars, compress it using the following algorithm:
           Begin with an empty string s. For each group of consecutive repeating characters in chars:
           If the group's length is 1, append the character to s.
           Otherwise, append the character followed by the group's length.
           The compressed string s should not be returned separately, but instead, be stored in the input character 
           array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.
           After you are done modifying the input array, return the new length of the array.
           You must write an algorithm that uses only constant extra space.
           
           Example 1:
           Input: chars = ["a","a","b","b","c","c","c"]
           Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
           Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".
           
           Example 2:
           Input: chars = ["a"]
           Output: Return 1, and the first character of the input array should be: ["a"]
           Explanation: The only group is "a", which remains uncompressed since it's a single character.
           
           Example 3:
           Input: chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
           Output: Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
           Explanation: The groups are "a" and "bbbbbbbbbbbb". This compresses to "ab12".
         */
        /*
        // my test-driven spaghetti solution
        var outputIdx = 0;
        var prev = chars[0];
        var count = 0;

        for (var i = 0; i < chars.Length; i++)
        {
            // increment count if is first char or char has not changed
            if (i == 0 || chars[i] == prev)
            {
                count++;
            }
            // if char has changed
            else if (chars[i] != prev)
            {
                chars[outputIdx++] = prev;
                if (count > 1)
                {
                    foreach (var c in count.ToString())
                    {
                        chars[outputIdx++] = c;
                    }
                }
                count = 1;
            }

            // if is last char
            if (i == chars.Length - 1)
            {
                // if count is 1 write char
                if (count == 1)
                {
                    chars[outputIdx++] = chars[i];
                }
                else
                {
                    // if char has not changed write curr
                    if (chars[i] == prev)
                    {
                        chars[outputIdx] = chars[i];
                    }
                    
                    outputIdx++;

                    // write count
                    foreach (var c in count.ToString())
                    {
                        chars[outputIdx++] = c;
                    }
                }
            }
            
            prev = chars[i];
        }

        return outputIdx;
        */

        var pos = 0;

        for (var i = 0; i < chars.Length;)
        {
            var count = 0;
            var curr = chars[i];
            
            while (i < chars.Length && curr == chars[i])
            {
                count++;
                i++;
            }

            chars[pos++] = curr;

            if (count <= 1) 
                continue;
            
            foreach (var c in count.ToString())
            {
                chars[pos++] = c;
            }
        }

        return pos;
    }

    public static void MoveZeroes(int[] nums)
    {
        /*
           Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
           Note that you must do this in-place without making a copy of the array.
           
           Example 1:
           Input: nums = [0,1,0,3,12]
           Output: [1,3,12,0,0]
           
           Example 2:
           Input: nums = [0]
           Output: [0]
           
           Constraints:
           1 <= nums.length <= 104
           -231 <= nums[i] <= 231 - 1
           
           Follow up: Could you minimize the total number of operations done?
         */
        
        // keep count of zeroes
        // move non-zero to front
        // iterate backwards setting zeros at end

        var count = 0;
        var pos = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                count++;
            else
                nums[pos++] = nums[i];
        }

        var end = nums.Length - 1;
        for (var i = 0; i < count; i++)
        {
            nums[end--] = 0;
        }
    }
    
    public static bool IsSubsequence(string s, string t)
    {
        /*
        Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

        A subsequence of a string is a new string that is formed from the original string by 
        deleting some (can be none) of the characters without disturbing the relative positions 
        of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

        Example 1:
        Input: s = "abc", t = "ahbgdc"
        Output: true
        
        Example 2:
        Input: s = "axc", t = "ahbgdc"
        Output: false
        */

        if (s == string.Empty)
            return true;

        if (s.Length > t.Length)
            return false;

        if (s == t)
            return true;

        var count = 0;

        foreach (var c in t)
        {
            if (count >= s.Length)
                break;
            if (s[count] == c)
                count++;
        }

        return count == s.Length;
    }
    
    public static int MaxArea(int[] height) 
    {
        /*
        You are given an integer array height of length n. There are n vertical lines drawn such 
        that the two endpoints of the ith line are (i, 0) and (i, height[i]).

        Find two lines that together with the x-axis form a container, such that the container 
        contains the most water.

        Return the maximum amount of water a container can store.

        Notice that you may not slant the container.

        Example 1:

        Input: height = [1,8,6,2,5,4,8,3,7]
        Output: 49
        Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this 
        case, the max area of water (blue section) the container can contain is 49.
        
        Example 2:

        Input: height = [1,1]
        Output: 1

        Constraints:

        n == height.length
        2 <= n <= 105
        0 <= height[i] <= 104
        */
        
        var max = 0;

        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var magnitude = Math.Min(height[left], height[right]);
            var length = right - left;
            var volume = magnitude * length;
            if (volume > max)
                max = volume;
            // only change the index of the side that's lower
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return max;
    }
    
    public static int MaxOperations(int[] nums, int k)
    {
        /*
        You are given an integer array nums and an integer k. In one operation, 
        you can pick two numbers from the array whose sum equals k and remove 
        them from the array. Return the maximum number of operations you can 
        perform on the array.
        
        Example 1:

        Input: nums = [1,2,3,4], k = 5
        Output: 2
        Explanation: Starting with nums = [1,2,3,4]:
        - Remove numbers 1 and 4, then nums = [2,3]
        - Remove numbers 2 and 3, then nums = []
        There are no more pairs that sum up to 5, hence a total of 2 operations.
        
        Example 2:

        Input: nums = [3,1,3,4,3], k = 6
        Output: 1
        Explanation: Starting with nums = [3,1,3,4,3]:
        - Remove the first two 3's, then nums = [1,4,3]
        There are no more pairs that sum up to 6, hence a total of 1 operation.
        */
        
        //Input: nums = [1,2,3,4], k = 5
        //Output: 2
        
        /*
        // this works but it times out because O(n^2)
        
        // iterate through array left to right
        // sum curr with every num in the array until k is found
        // if sum is found:
        //  - increment count
        //  - also "remove" matches from array
        //    - the first one is already removed by incrementing i
        //    - the second one needs to be tracked
        //      - use an array of bool to track indexes that have been used

        var flags = new bool[nums.Length];
        var count = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            // if left is already taken move on
            if (flags[i])
                continue;
            
            var left = nums[i];
            
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (flags[j])
                    continue;
                var right = nums[j];
                if (left + right != k) 
                    continue;
                
                // found a match
                count++;
                flags[j] = true;
                
                // move to next left
                break;
            }
        }
        
        return count;
        */
        
        /*
        // sum all the numbers in the array
        // how many times is sum divisible by k
           
        // no this doesn't work
        // it doesn't take into account *pairs* of numbers that sum to k
        // so 3 numbers can sum to more than k and give false positive
        
        var sum = nums.Sum();
        var countdown = nums.Length;
        var count = 0;

        while (countdown > 1 && sum > 0)
        {
            count++;
            sum -= k;
            countdown -= 2; // remove pair
        }

        return count;
        */
        
        //Input: nums = [3,2,1,4], k = 5
        //Output: 2
        
        //Input: nums = [3,1,3,4,3], k = 6
        //Output: 1
        
        // todo: faster solution
        
        // sort the array
        // start and end pointers
        // iterate moving one or the other while looking for pairs
        
        //[3,2,1,4]
        //[3,1,3,4,3]
        Array.Sort(nums);
        //[1,2,3,4]
        //[1,3,3,3,4]

        var count = 0;
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + nums[right];

            // if too much decrement right
            // if not enough increment left
            if (sum == k)
            {
                left++;
                right--;
                count++;
            }
            else if (sum < k)
                left++;
            else
                right--;
        }

        return count;
    }
    
    public static double FindMaxAverage(int[] nums, int k) 
    {
        /*
        You are given an integer array nums consisting of n elements, and an integer k.
        Find a contiguous subarray whose length is equal to k that has the maximum average 
        value and return this value. Any answer with a calculation error less than 10-5 
        will be accepted.

        Example 1:
        Input: nums = [1,12,-5,-6,50,3], k = 4
        Output: 12.75000
        Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
        
        Example 2:
        Input: nums = [5], k = 1
        Output: 5.00000
        */

        /*
        // todo: this works but times out because O(n*k)
        var max = double.MinValue;

        for (var i = 0; i <= nums.Length - k; i++)
        {
            var sum = 0.0D;
            for (var j = 0; j < k && i + j < nums.Length; j++)
            {
                sum += nums[i + j];
            }

            var curr = sum / k;
            if (curr > max)
                max = curr;
        }

        return max;
        */
        
        // zip array into tuples with index
        // sort the array by value
        // iterate in reverse
        // calculate sets starting with the highest value
        // no - this is pointless the max average can be
        //   any set of k, so you have to check all combinations
        //   for example: 9,-9,0,0,1,0,0,-9,9
        
        // todo: faster solution
        //Input: nums = [1,12,-5,-6,50,3], k = 4
        //Output: 12.75000
        /*
        To solve this problem effectively, we can use the "sliding window" technique. 
        The key idea behind this technique is to maintain a "window" of size k that 
        moves through the array, one element at a time, updating the sum of the window 
        as it goes. By doing this, we avoid recalculating the sum for each subarray 
        from scratch, which leads to significant time savings.
        */

        // get initial window
        var sum = 0;
        for (var i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        var max = sum;
        
        // slide window right
        for (var i = 0; i < nums.Length - k; i++)
        {
            // remove old value
            sum -= nums[i];
            
            // add new value
            sum += nums[i + k];

            if (sum > max)
                max = sum;
        }

        return Math.Round((double)max / k, 5);
    }

    public static int MaxVowels(string s, int k)
    {
        /*
        Given a string s and an integer k, return the maximum number of vowel 
        letters in any substring of s with length k.

        Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

        Example 1:
        Input: s = "abciiidef", k = 3
        Output: 3
        Explanation: The substring "iii" contains 3 vowel letters.
        
        Example 2:
        Input: s = "aeiou", k = 2
        Output: 2
        Explanation: Any substring of length 2 contains 2 vowels.
        
        Example 3:
        Input: s = "leetcode", k = 3
        Output: 2
        Explanation: "lee", "eet" and "ode" contain 2 vowels.
        */
        
        // use flags so "is vowel" lookup is O(1)
        var flags = new bool[255];
        
        flags['a'] = true;
        flags['e'] = true;
        flags['i'] = true;
        flags['o'] = true;
        flags['u'] = true;

        var count = 0;
        
        for (var i = 0; i < k; i++)
        {
            if (flags[s[i]])
                count++;
        }

        var max = count;

        for (var i = 0; i < s.Length - k; i++)
        {
            // remove prev
            var prev = s[i];
            if (flags[prev])
                count--;

            // add curr
            var curr = s[i + k];
            if (flags[curr])
                count++;

            if (count > max)
                max = count;

            // short-circuit: no need to continue if we
            // already found k length
            if (max == k)
                break;
        }

        return max;
    }
    
    public static int LongestOnes(int[] nums, int k)
    {
        /*
        Given a binary array nums and an integer k, return the maximum number 
        of consecutive 1's in the array if you can flip at most k 0's.

        Example 1:
        Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
        Output: 6
        Explanation: [1,1,1,0,0,*1*,1,1,1,1,*1*]
        Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

        Example 2:
        Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
        Output: 10
        Explanation: [0,0,1,1,*1*,*1*,1,1,1,*1*,1,1,0,0,0,1,1,1,1]
        Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
        */

        var max = 0;
        var countOfOnes = 0;
        var countOfZeroes = 0;
        var startOfWindow = 0;

        foreach (var num in nums)
        {
            if (num == 1)
                countOfOnes++;
            else
                countOfZeroes++;

            if (countOfZeroes > k)
            {
                var prev = nums[startOfWindow];
                
                startOfWindow++;

                if (prev == 0)
                    countOfZeroes--;
                else
                    countOfOnes--;
            }

            if (countOfOnes + countOfZeroes > max)
                max = countOfOnes + countOfZeroes;
        }

        return max;
    }
    
    public static int LongestSubarray(int[] nums) 
    {
        /*
        Given a binary array nums, you should delete one element from it.

        Return the size of the longest non-empty subarray containing only 
        1's in the resulting array. Return 0 if there is no such subarray.

        Example 1:
        Input: nums = [1,1,0,1]
        Output: 3
        Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.
        
        Example 2:
        Input: nums = [0,1,1,1,0,1,1,0,1]
        Output: 5
        Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value 
        of 1's is [1,1,1,1,1].
        
        Example 3:
        Input: nums = [1,1,1]
        Output: 2
        Explanation: You must delete one element.
        */

        var countOfOnes = 0;
        var countSinceZero = 0;
        var removed = false;
        var max = 0;
        
        foreach (var num in nums)
        {
            if (num == 0)
            {
                removed = true;

                countOfOnes = countSinceZero;
                countSinceZero = 0;
            }
            else
            {
                countOfOnes++;
                countSinceZero++;
            }
            
            if (countOfOnes > max)
                max = countOfOnes;
        }

        return removed == false 
            ? max - 1
            : max;
    }
}