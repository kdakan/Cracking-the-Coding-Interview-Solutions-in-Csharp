using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using CrackingTheCodingInterview6thEd.Ch02_LinkedLists;

namespace Tests
{
    [TestClass]
    public class Ch02_LinkedListsTest
    {
        [TestMethod]
        public void P2_1_RemoveDups_Test()
        {
            Node node3 = new Node() { Value = 1 };
            Node node2 = new Node() { Value = 3, Next = node3 };
            Node node1 = new Node() { Value = 2, Next = node2 };
            Node head = new Node() { Value = 1, Next = node1 };

            P2_1_RemoveDups.RemoveDuplicates(head);
            Assert.AreEqual(head.Next, node1);
            Assert.AreEqual(node1.Next, node2);
            Assert.AreEqual(node2.Next, null);

            node3 = new Node() { Value = 1 };
            node2 = new Node() { Value = 3, Next = node3 };
            node1 = new Node() { Value = 2, Next = node2 };
            head = new Node() { Value = 1, Next = node1 };

            P2_1_RemoveDups.RemoveDuplicatesNoBufferAllowed(head);
            Assert.AreEqual(head.Next, node1);
            Assert.AreEqual(node1.Next, node2);
            Assert.AreEqual(node2.Next, null);

        }

        [TestMethod]
        public void P2_2_ReturnKthToLast_Test()
        {
            Node node6 = new Node() { Value = 6 };
            Node node5 = new Node() { Value = 5, Next = node6 };
            Node node4 = new Node() { Value = 4, Next = node5 };
            Node node3 = new Node() { Value = 3, Next = node4 };
            Node node2 = new Node() { Value = 2, Next = node3 };
            Node node1 = new Node() { Value = 1, Next = node2 };
            Node head = new Node() { Value = 0, Next = node1 };

            var zerothToLast = P2_2_ReturnKthToLast.FindKthToLast(head, 0);
            Assert.AreEqual(zerothToLast, node6);

            var firstToLast = P2_2_ReturnKthToLast.FindKthToLast(head, 1);
            Assert.AreEqual(firstToLast, node5);

            var secondToLast = P2_2_ReturnKthToLast.FindKthToLast(head, 2);
            Assert.AreEqual(secondToLast, node4);

            var thirdToLast = P2_2_ReturnKthToLast.FindKthToLast(head, 3);
            Assert.AreEqual(thirdToLast, node3);
        }

        [TestMethod]
        public void P2_3_DeleteMiddleNode_Test()
        {
            Node node6 = new Node() { Value = 6 };
            Node node5 = new Node() { Value = 5, Next = node6 };
            Node node4 = new Node() { Value = 4, Next = node5 };
            Node node3 = new Node() { Value = 3, Next = node4 };
            Node node2 = new Node() { Value = 2, Next = node3 };
            Node node1 = new Node() { Value = 1, Next = node2 };
            Node head = new Node() { Value = 0, Next = node1 };

            P2_3_DeleteMiddleNode.DeleteNodeNotInHeadOrTailByValue(node4);
            Assert.AreEqual(node3.Value, 3);
            Assert.AreEqual(node3.Next.Value, 5);
        }

        [TestMethod]
        public void P2_4_Partition_Test()
        {
            Node node6 = new Node() { Value = 1 };
            Node node5 = new Node() { Value = 2, Next = node6 };
            Node node4 = new Node() { Value = 10, Next = node5 };
            Node node3 = new Node() { Value = 5, Next = node4 };
            Node node2 = new Node() { Value = 8, Next = node3 };
            Node node1 = new Node() { Value = 5, Next = node2 };
            Node head = new Node() { Value = 3, Next = node1 };

            var partitionedListHead = P2_4_Partition.PartitionList(head, 5);
            Assert.AreEqual(partitionedListHead.Value, 3);
            Assert.AreEqual(partitionedListHead.Next.Value, 2);
            Assert.AreEqual(partitionedListHead.Next.Next.Value, 1);
            Assert.AreEqual(partitionedListHead.Next.Next.Next.Value, 5);
            Assert.AreEqual(partitionedListHead.Next.Next.Next.Next.Value, 8);
            Assert.AreEqual(partitionedListHead.Next.Next.Next.Next.Next.Value, 5);
            Assert.AreEqual(partitionedListHead.Next.Next.Next.Next.Next.Next.Value, 10);
        }

        [TestMethod]
        public void P2_5_SumLists_Test()
        {
            Node b2 = new Node() { Value = 6 };
            Node b1 = new Node() { Value = 1, Next = b2 };
            Node b0 = new Node() { Value = 7, Next = b1 };

            Node c2 = new Node() { Value = 2 };
            Node c1 = new Node() { Value = 9, Next = c2 };
            Node c0 = new Node() { Value = 5, Next = c1 };

            //7->1->6 means 617, 5->9->2 means 295
            //sum: 912
            var sumHead = P2_5_SumLists.SumBackwardsPatternLists(b0, c0);

            Assert.AreEqual(sumHead.Value, 2);
            Assert.AreEqual(sumHead.Next.Value, 1);
            Assert.AreEqual(sumHead.Next.Next.Value, 9);

            sumHead = P2_5_SumLists.SumBackwardsPatternLists(b0, b0);

            Assert.AreEqual(sumHead.Value, 4);
            Assert.AreEqual(sumHead.Next.Value, 3);
            Assert.AreEqual(sumHead.Next.Next.Value, 2);
            Assert.AreEqual(sumHead.Next.Next.Next.Value, 1);

            Node d4 = new Node() { Value = 9 };
            Node d3 = new Node() { Value = 8, Next = d4 };
            Node d2 = new Node() { Value = 2, Next = d3 };
            Node d1 = new Node() { Value = 9, Next = d2 };
            Node d0 = new Node() { Value = 5, Next = d1 };

            sumHead = P2_5_SumLists.SumBackwardsPatternLists(b0, d0);
            Assert.AreEqual(sumHead.Value, 2);
            Assert.AreEqual(sumHead.Next.Value, 1);
            Assert.AreEqual(sumHead.Next.Next.Value, 9);
            Assert.AreEqual(sumHead.Next.Next.Next.Value, 8);
            Assert.AreEqual(sumHead.Next.Next.Next.Next.Value, 9);
        }

        [TestMethod]
        public void P2_6_Palindrome_Test()
        {
            Node a4 = new Node() { Value = 1 };
            Node a3 = new Node() { Value = 2, Next = a4 };
            Node a2 = new Node() { Value = 3, Next = a3 };
            Node a1 = new Node() { Value = 2, Next = a2 };
            Node a0 = new Node() { Value = 1, Next = a1 };

            Assert.IsTrue(P2_6_Palindrome.IsPalindrome(a0));

            Node b3 = new Node() { Value = 1 };
            Node b2 = new Node() { Value = 2, Next = b3 };
            Node b1 = new Node() { Value = 2, Next = b2 };
            Node b0 = new Node() { Value = 1, Next = b1 };

            Assert.IsTrue(P2_6_Palindrome.IsPalindrome(b0));

            Node c4 = new Node() { Value = 4 };
            Node c3 = new Node() { Value = 2, Next = c4 };
            Node c2 = new Node() { Value = 3, Next = c3 };
            Node c1 = new Node() { Value = 2, Next = c2 };
            Node c0 = new Node() { Value = 1, Next = c1 };

            Assert.IsFalse(P2_6_Palindrome.IsPalindrome(c0));
        }

        [TestMethod]
        public void P2_7_Intersection_Test()
        {
            Node a1 = new Node() { Value = 22222 };
            Node a0 = new Node() { Value = 11111, Next = a1 };

            Node b3 = new Node() { Value = 4, Next = a0 };
            Node b2 = new Node() { Value = 3, Next = b3 };
            Node b1 = new Node() { Value = 2, Next = b2 };
            Node b0 = new Node() { Value = 1, Next = b1 };

            Node c2 = new Node() { Value = 33, Next = a0 };
            Node c1 = new Node() { Value = 22, Next = c2 };
            Node c0 = new Node() { Value = 11, Next = c1 };

            Assert.AreEqual(P2_7_Intersection.FindIntersection(b0, c0), a0);

            Node d1 = new Node() { Value = 22, Next = a0 };
            Node d0 = new Node() { Value = 11, Next = d1 };

            Assert.AreEqual(P2_7_Intersection.FindIntersection(b0, d0), a0);
        }

        [TestMethod]
        public void P2_8_LoopDetection_Test()
        {
            Node node6 = new Node() { Value = 6 };
            Node node5 = new Node() { Value = 5, Next = node6 };
            Node node4 = new Node() { Value = 4, Next = node5 };
            Node node3 = new Node() { Value = 3, Next = node4 };
            Node node2 = new Node() { Value = 2, Next = node3 };
            Node node1 = new Node() { Value = 1, Next = node2 };
            Node head = new Node() { Value = 0, Next = node1 };
            node6.Next = node3;//create a loop

            Assert.AreEqual(P2_8_LoopDetection.FindStartingNodeOfCircularLoop(head), node3);

            node6.Next = null;//no loop
            Assert.AreEqual(P2_8_LoopDetection.FindStartingNodeOfCircularLoop(head), null);
        }
    }
}