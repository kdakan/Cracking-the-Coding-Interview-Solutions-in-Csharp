using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs;

namespace Tests
{
    [TestClass]
    public class Ch04_TreesAndGraphsTests
    {
        [TestMethod]
        public void P4_1_RouteBetweenNodes_Test()
        {
            //          A
            //       5/   \6   3     1
            //      x       y----->w--->x
            //    9/ \5   1/ \     1\
            //    p   q<--r   \      y
            //    8\ /3  2    /
            //      Z<-------/10

            Node cityA = new Node("A");
            Node cityx = new Node("x");
            Node cityy = new Node("y");
            Node cityp = new Node("p");
            Node cityq = new Node("q");
            Node cityr = new Node("r");
            Node cityw = new Node("w");
            Node cityZ = new Node("Z");

            cityA.Connections.Add(cityx);
            cityA.Connections.Add(cityy);

            cityx.Connections.Add(cityp);
            cityx.Connections.Add(cityq);

            cityy.Connections.Add(cityr);
            cityy.Connections.Add(cityw);
            cityy.Connections.Add(cityZ);

            cityw.Connections.Add(cityx);
            cityw.Connections.Add(cityy);

            cityp.Connections.Add(cityZ);

            cityq.Connections.Add(cityZ);

            cityr.Connections.Add(cityq);

            Assert.IsTrue(P4_1_RouteBetweenNodes.ExistsRoute(cityA, cityZ));
            Assert.IsFalse(P4_1_RouteBetweenNodes.ExistsRoute(cityx, cityA));
        }

        [TestMethod]
        public void P4_2_MinimalTree_Test()
        {
            //1,2,3,4,5,6 ==> 
            //
            //     4
            //   /   \
            //  2     6
            // / \   / 
            //1   3 5   

            var arr = new int[] { 1, 2, 3, 4, 5, 6 };
            var tree = P4_2_MinimalTree.CreateBalancedBinarySearchTreeFromSortedUniqueArray(arr);

            Assert.AreEqual(tree.Left.Left.Value, 1);
            Assert.AreEqual(tree.Left.Value, 2);
            Assert.AreEqual(tree.Left.Right.Value, 3);
            Assert.AreEqual(tree.Value, 4);
            Assert.AreEqual(tree.Right.Left.Value, 5);
            Assert.AreEqual(tree.Right.Value, 6);

            //1,2,3,4,5,6,7 ==> 
            //
            //     4
            //   /   \
            //  2     6
            // / \   / \
            //1   3 5   7

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            tree = P4_2_MinimalTree.CreateBalancedBinarySearchTreeFromSortedUniqueArray(arr);

            Assert.AreEqual(tree.Left.Left.Value, 1);
            Assert.AreEqual(tree.Left.Value, 2);
            Assert.AreEqual(tree.Left.Right.Value, 3);
            Assert.AreEqual(tree.Value, 4);
            Assert.AreEqual(tree.Right.Left.Value, 5);
            Assert.AreEqual(tree.Right.Value, 6);
            Assert.AreEqual(tree.Right.Right.Value, 7);
        }

        [TestMethod]
        public void P4_3_ListOfDepths_Test()
        {
            //   tree:     list of depths:
            //     4       => 4
            //   /   \
            //  2     6    => 2->6
            // / \   / \
            //1   3 5   7  => 1->3->5->7

            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node5 = new BinaryTreeNode(5);
            var node7 = new BinaryTreeNode(7);
            var node2 = new BinaryTreeNode(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNode(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNode(4) { Left = node2, Right = node6 };

            var levelList = P4_3_ListOfDepths.CreateListOfLevels(root);

            var level0Head = levelList[0];
            Assert.AreEqual(level0Head.Value, root);
            var level1Head = levelList[1];
            Assert.AreEqual(level1Head.Value, node2);
            Assert.AreEqual(level1Head.Next.Value, node6);
            var level2Head = levelList[2];
            Assert.AreEqual(level2Head.Value, node1);
            Assert.AreEqual(level2Head.Next.Value, node3);
            Assert.AreEqual(level2Head.Next.Next.Value, node5);
            Assert.AreEqual(level2Head.Next.Next.Next.Value, node7);
        }

        [TestMethod]
        public void P4_4_CheckBalance_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  

            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node5 = new BinaryTreeNode(5);
            var node7 = new BinaryTreeNode(7);
            var node2 = new BinaryTreeNode(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNode(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNode(4) { Left = node2, Right = node6 };

            Assert.IsTrue(P4_4_CheckBalance.IsBinaryTreeBalanced(root));

            node6.Right = null;
            Assert.IsTrue(P4_4_CheckBalance.IsBinaryTreeBalanced(root));

            node6.Left = null;
            Assert.IsTrue(P4_4_CheckBalance.IsBinaryTreeBalanced(root));

            root.Right = null;
            Assert.IsFalse(P4_4_CheckBalance.IsBinaryTreeBalanced(root));
        }

        [TestMethod]
        public void P4_5_ValidateBST_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  

            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node5 = new BinaryTreeNode(5);
            var node7 = new BinaryTreeNode(7);
            var node2 = new BinaryTreeNode(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNode(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNode(4) { Left = node2, Right = node6 };

            Assert.IsTrue(P4_5_ValidateBST.IsValidBinarySearchTree(root));

            node6.Value = 8;
            Assert.IsFalse(P4_5_ValidateBST.IsValidBinarySearchTree(root));
        }

        [TestMethod]
        public void P4_6_Successor_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  

            var node1 = new BinaryTreeNodeWithParent(1);
            var node3 = new BinaryTreeNodeWithParent(3);
            var node5 = new BinaryTreeNodeWithParent(5);
            var node7 = new BinaryTreeNodeWithParent(7);
            var node2 = new BinaryTreeNodeWithParent(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNodeWithParent(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNodeWithParent(4) { Left = node2, Right = node6 };
            node1.Parent = node2;
            node3.Parent = node2;
            node2.Parent = root;
            node5.Parent = node6;
            node7.Parent = node6;
            node6.Parent = root;

            Assert.AreEqual(P4_6_Successor.GetNext(node1), node2);
            Assert.AreEqual(P4_6_Successor.GetNext(node2), node3);
            Assert.AreEqual(P4_6_Successor.GetNext(node3), root);
            Assert.AreEqual(P4_6_Successor.GetNext(root), node5);
            Assert.AreEqual(P4_6_Successor.GetNext(node5), node6);
            Assert.AreEqual(P4_6_Successor.GetNext(node6), node7);
        }

        [TestMethod]
        public void P4_7_BuildOrder_Test()
        {
            var projectA = new Project("A");
            var projectB = new Project("B");
            var projectC = new Project("C");
            var projectD = new Project("D");
            var projectE = new Project("E");
            var projectF = new Project("F");
            var projectG = new Project("G");

            projectA.Dependencies = new List<Project>() { projectB, projectC };
            projectB.Dependencies = new List<Project>() { projectC, projectD };
            projectC.Dependencies = new List<Project>() { projectD };
            projectE.Dependencies = new List<Project>() { projectA, projectF };

            var buildOrder = P4_7_BuildOrder.GetBuildOrderFor(projectA);
            Assert.AreEqual(buildOrder[0], projectD);
            Assert.AreEqual(buildOrder[1], projectC);
            Assert.AreEqual(buildOrder[2], projectB);
            Assert.AreEqual(buildOrder[3], projectA);

            buildOrder = P4_7_BuildOrder.GetBuildOrderFor(projectE);
            Assert.AreEqual(buildOrder[0], projectD);
            Assert.AreEqual(buildOrder[1], projectC);
            Assert.AreEqual(buildOrder[2], projectB);
            Assert.AreEqual(buildOrder[3], projectA);
            Assert.AreEqual(buildOrder[4], projectF);
            Assert.AreEqual(buildOrder[5], projectE);

        }

        [TestMethod]
        public void P4_8_CommonAncestor_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  

            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node5 = new BinaryTreeNode(5);
            var node7 = new BinaryTreeNode(7);
            var node2 = new BinaryTreeNode(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNode(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNode(4) { Left = node2, Right = node6 };

            Assert.AreEqual(P4_8_CommonAncestor.FindFirstCommonAncestorForNonBSTNodes(root, node1, node5), root);
            Assert.AreEqual(P4_8_CommonAncestor.FindFirstCommonAncestorForNonBSTNodes(root, node1, node3), node2);
        }

        [TestMethod]
        public void P4_10_CheckSubtree_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  
            //           \
            //            8
            var tree1node1 = new BinaryTreeNode(1);
            var tree1node3 = new BinaryTreeNode(3);
            var tree1node5 = new BinaryTreeNode(5);
            var tree1node8 = new BinaryTreeNode(8);
            var tree1node7 = new BinaryTreeNode(7) { Right = tree1node8 };
            var tree1node2 = new BinaryTreeNode(2) { Left = tree1node1, Right = tree1node3 };
            var tree1node6 = new BinaryTreeNode(6) { Left = tree1node5, Right = tree1node7 };
            var tree1root = new BinaryTreeNode(4) { Left = tree1node2, Right = tree1node6 };

            //  6    
            // / \
            //5   7  
            //     \
            //      8
            var tree2node5 = new BinaryTreeNode(5);
            var tree2node8 = new BinaryTreeNode(8);
            var tree2node7 = new BinaryTreeNode(7) { Right = tree2node8 };
            var tree2root = new BinaryTreeNode(6) { Left = tree2node5, Right = tree2node7 };

            Assert.IsTrue(P4_10_CheckSubtree.IsSubtreeForNonBST(tree1root, tree2root));
            Assert.IsFalse(P4_10_CheckSubtree.IsSubtreeForNonBST(tree2root, tree1root));
            Assert.IsFalse(P4_10_CheckSubtree.IsSubtreeForNonBST(tree1node5, tree2root));
        }

        [TestMethod]
        public void P4_11_RandomNode_Test()
        {
            //     4       
            //   /   \
            //  2     6    
            // / \   / \
            //1   3 5   7  

            var node1 = new BinaryTreeNode(1);
            var node3 = new BinaryTreeNode(3);
            var node5 = new BinaryTreeNode(5);
            var node7 = new BinaryTreeNode(7);
            var node2 = new BinaryTreeNode(2) { Left = node1, Right = node3 };
            var node6 = new BinaryTreeNode(6) { Left = node5, Right = node7 };
            var root = new BinaryTreeNode(4) { Left = node2, Right = node6 };

            int min = 1;
            int max = 7;
            int polls = 1000;
            long sum = 0;
            for (int i = 0; i < polls; i++)
                sum += P4_11_RandomNode.PickRandomNode(root, min, max).Value;

            long expectedSum = polls * (min + max) / 2;

            Assert.IsTrue(Math.Abs(sum - expectedSum) < expectedSum / 10);
        }

        [TestMethod]
        public void P4_12_PathsWithSum_Test()
        {
            //      10       
            //     /  \
            //    5   -3    
            //   / \    \
            //  3   2    11  
            // / \   \        
            //3  -2   1        

            var node3 = new BinaryTreeNode(3);
            var nodeMinus2 = new BinaryTreeNode(-2);
            var node3x = new BinaryTreeNode(3) { Left = node3, Right = nodeMinus2 };
            var node1 = new BinaryTreeNode(1);
            var node2 = new BinaryTreeNode(2) { Right = node1 };
            var node5 = new BinaryTreeNode(5) { Left = node3, Right = node2 };
            var node11 = new BinaryTreeNode(11);
            var nodeMinus3 = new BinaryTreeNode(-3) { Right = node11 };
            var root = new BinaryTreeNode(10) { Left = node5, Right = nodeMinus3 };

            var count = P4_12_PathsWithSum.FindNumberOfPathsWithSum(root, 8);
            Assert.AreEqual(count, 3);
        }
    }
}