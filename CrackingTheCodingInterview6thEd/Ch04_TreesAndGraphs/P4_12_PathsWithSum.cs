using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_12_PathsWithSum
    {
        public static int FindNumberOfPathsWithSum(BinaryTreeNode root, int sum)
        {
            if (root == null)
                return 0;

            if (root.Value == sum)
                return 1;

            var leftCountIncludingRoot = FindNumberOfPathsWithSum(root.Left, sum - root.Value);
            var rightCountIncludingRoot = FindNumberOfPathsWithSum(root.Right, sum - root.Value);
            var leftCountExcludingRoot = FindNumberOfPathsWithSum(root.Left, sum);
            var rightCountExcludingRoot = FindNumberOfPathsWithSum(root.Right, sum);

            return leftCountIncludingRoot + rightCountIncludingRoot
                 + leftCountExcludingRoot + rightCountExcludingRoot;
        }

    }
}
