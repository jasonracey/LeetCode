namespace LeetCode; 
public static class Prep
{
    public static int LargestAltitude(int[] gain)
    {
        /*
        Find The Highest Altitude

        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.

        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1 for all (0 <= i < n). Return the highest altitude of a point.

        Example 1:

        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
        Example 2:

        Input: gain = [-4,-3,-2,-1,4,3,2]
        Output: 0
        Explanation: The altitudes are [0,-4,-7,-9,-10,-6,-3,-1]. The highest is 0.

        Constraints:

        n == gain.length
        1 <= n <= 100
        -100 <= gain[i] <= 100
        */

        // todo: implement solution here

        // start at 0
        // iterate over changes
        // add change to curr
        // if new max reached store max
        // return max

        var curr = 0;
        var max = 0;

        foreach (var i in gain)
        {
            curr += i;
            if (curr > max)
                max = curr;
        }

        return max;
    }

    public static bool IsSubsequence(string s, string t)
    {
        /*
        Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

        A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters
        without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).

        Example 1:

        Input: s = "bd", t = "abcd"
        Output: true
        Example 2:

        Input: s = "ba", t = "abcd"
        Output: false
        */

        // iterate over t
        // if match count > s length then break
        // if s at current count matches curr t then increment count
        // return match count is s length

        if (s == string.Empty)
            return true;

        if (s.Length > t.Length)
            return false;

        if (s == t)
            return true;

        var matches = 0;

        foreach (var c in t)
        {
            if (matches > s.Length)
                break;

            if (s[matches] == c)
                matches++;
        }

        return matches == s.Length;
    }
}