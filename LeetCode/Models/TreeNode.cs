namespace LeetCode.Models;

public class TreeNode {
    public int val { get; private set; }

    public TreeNode? left { get; private set; }

    public TreeNode? right { get; private set; }

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}