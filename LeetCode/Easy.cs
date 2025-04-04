﻿using System.Runtime.InteropServices;

namespace LeetCode;

public static class Easy
{
    public static int[] TwoSum(int[] nums, int target)
    {
        /*
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.
 
        Example 1:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        
        Example 2:
        Input: nums = [3,2,4], target = 6
        Output: [1,2]
        
        Example 3:
        Input: nums = [3,3], target = 6
        Output: [0,1]
 
        Constraints:
        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.
        */

        // two indexes
        // iterate through array
        // hold first index
        // increment second index until sum is met or end of array
        // increment first index
        // set second index first + 1
        // if sum is met set values in return array and return
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        throw new Exception("No pair of values added up to target value.");
    }

    public static bool PalindromeNumber(int x)
    {
        /*
        Given an integer x, return true if x is a palindrome, and false otherwise.

        Example 1:
        Input: x = 121
        Output: true
        Explanation: 121 reads as 121 from left to right and from right to left.

        Example 2:
        Input: x = -121
        Output: false
        Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

        Example 3:
        Input: x = 10
        Output: false
        Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

        Constraints:
        -231 <= x <= 231 - 1
        */

        // negative values are never a palindrome
        if (x < 0) return false;

        // single digits are always a palindrome
        if (x >= 0 && x <= 9) return true;

        // we got here if x >= 10
        var digits = new int[10];

        // put individual digits into an array
        int index = 0;
        while (x > 0 && index < digits.Length)
        {
            if (x < 10)
                digits[index++] = x;
            else
                digits[index++] = x % 10;
            x /= 10;
        }

        // iterate over digits from each end and check palindrome
        for (int i = 0, j = index - 1; i < j; i++, j--)
        {
            if (digits[i] != digits[j])
                return false;
        }

        return true;
    }

    public static int RomanToInteger(string roman)
    {
        /*
        Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

        Symbol       Value
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000

        For example, 2 is written as II in Roman numeral, just two ones added together. 
        12 is written as XII, which is simply X + II. 
        The number 27 is written as XXVII, which is XX + V + II.
        Roman numerals are usually written largest to smallest from left to right. 
        However, the numeral for four is not IIII. 
        Instead, the number four is written as IV. 
        Because the one is before the five we subtract it making four. 
        The same principle applies to the number nine, which is written as IX.
        
        There are six instances where subtraction is used:
        I can be placed before V (5) and X (10) to make 4 and 9. 
        X can be placed before L (50) and C (100) to make 40 and 90. 
        C can be placed before D (500) and M (1000) to make 400 and 900.

        Given a roman numeral, convert it to an integer.

        Example 1:
        Input: s = "III"
        Output: 3
        Explanation: III = 3.

        Example 2:
        Input: s = "LVIII"
        Output: 58
        Explanation: L = 50, V = 5, III = 3.

        Example 3:
        Input: s = "MCMXCIV"
        Output: 1994
        Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 
        Constraints:
        1 <= s.length <= 15
        s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
        It is guaranteed that s is a valid roman numeral in the range [1, 3999].
        */

        // define symbol to int map, including subtraction cases
        // iterate through string
        // 2 pointers
        // look for subtraction symbol first (IV)
        // look for repeats second (II)
        // if single convert to int and store in sum, next position
        // if repeat convert to int and store in sum, first position after repeat
        // if subtraction convert to int and store in sum, first position after subtraction
        /*
        var symbolToInt = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var subtractionSymbolToInt = new Dictionary<string, int>
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 },
        };

        var sum = 0;
        int i = 0;
        while (i < roman.Length)
        {
            if (i < roman.Length - 1 && subtractionSymbolToInt.TryGetValue($"{roman[i]}{roman[i+1]}", out int value))
            {
                sum += value;
                i += 2;
            }
            else if (i < roman.Length - 1 && roman[i] == roman[i+1])
            {
                var j = i + 1;
                while (j < roman.Length && roman[i] == roman[j])
                {
                    j++;
                }
                var baseVal = symbolToInt[roman[i]];
                var multiplier = j - i;
                var total = baseVal * multiplier;
                sum += total;
                i = j;
            }
            else
            {
                sum += symbolToInt[roman[i++]];
            }
        }

        return sum;
        */

        var symbolToInt = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var sum = symbolToInt[roman[^1]];
        for (var i = roman.Length - 2; i >= 0; i--)
        {
            if (symbolToInt[roman[i]] < symbolToInt[roman[i + 1]])
                sum -= symbolToInt[roman[i]];
            else
                sum += symbolToInt[roman[i]];
        }

        return sum;
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        /*
        Write a function to find the longest common prefix string amongst an array of strings.

        If there is no common prefix, return an empty string "".

        Example 1:
        Input: strs = ["flower","flow","flight"]
        Output: "fl"

        Example 2:
        Input: strs = ["dog","racecar","car"]
        Output: ""
        Explanation: There is no common prefix among the input strings.

        Constraints:
        1 <= strs.length <= 200
        0 <= strs[i].length <= 200
        strs[i] consists of only lowercase English letters if it is non-empty.
        */

        // iterate over curr index of each string
        // if past string return result
        // if mismatch return result
        // else append c and increment index

        var result = string.Empty;
        var i = 0;
        if (strs.Length < 0)
            return result;
        if (strs[0].Length == 0)
            return result;
        char c = strs[0][0];
        while (true)
        {
            foreach (var str in strs)
            {
                if (str.Length == 0)
                    return result;

                if (i >= str.Length)
                    return result;

                if (c != str[i])
                    return result;

                c = str[i];
            }
            result += c;
            i++;
            if (i >= strs[0].Length)
                return result;
            c = strs[0][i];
        }
    }

    public static bool IsValidParens(string s)
    {
        /*
        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        An input string is valid if:

        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.

        Example 1:
        Input: s = "()"
        Output: true

        Example 2:
        Input: s = "()[]{}"
        Output: true

        Example 3:
        Input: s = "(]"
        Output: false

        Example 4:
        Input: s = "([])"
        Output: true

        Example 5:
        Input: s = "([)]" // brackets cannot intersect, one set must enclose another, this means the inner (second) must close before the outer (first)
        Output: false
        */

        // open count must equal close count by type
        // outer set's bracket must close after inner set's closing bracket
        /*
         ) - don't push on stack, just pop curr
         ] - don't push on stack, just pop curr
         [
         (
         */
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (stack.Count == 0 || c == '(' || c == '{' || c == '[')
                stack.Push(c);
            else if (c == ')' && stack.Peek() == '(')
                stack.Pop();
            else if (c == ']' && stack.Peek() == '[')
                stack.Pop();
            else if (c == '}' && stack.Peek() == '{')
                stack.Pop();
            else
                stack.Push(c);
        }

        return stack.Count == 0;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        /*
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element 
        appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements 
        in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present 
        in nums initially. The remaining elements of nums are not important as well as the size of nums. Return k.
        
        The judge will test your solution with the following code:
        int[] nums = [...]; // Input array
        int[] expectedNums = [...]; // The expected answer with correct length
        int k = removeDuplicates(nums); // Calls your implementation
        assert k == expectedNums.length;
        for (int i = 0; i < k; i++) {
            assert nums[i] == expectedNums[i];
        }
        
        If all assertions pass, then your solution will be accepted.

        remove the duplicates in-place such that each unique element appears only once

        Example 1:
        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        
        Example 2:
        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).

        Constraints:
        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        // iterate over array
        // curr search index
        // curr save index
        // if val incremented, store in curr save index, inc save index
        // inc search index
        // k = curr save index + 1

        var searchIndex = 1;
        var saveIndex = 1;

        var prev = nums[0];

        while (searchIndex < nums.Length)
        {
            if (nums[searchIndex] > prev)
            {
                nums[saveIndex] = nums[searchIndex];
                prev = nums[searchIndex];
                saveIndex++;
            }
            searchIndex++;
        }

        return saveIndex;
    }
}