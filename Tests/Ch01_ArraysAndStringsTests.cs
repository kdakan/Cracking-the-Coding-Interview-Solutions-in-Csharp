using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings;

namespace Tests
{
    [TestClass]
    public class Ch01_ArraysAndStringsTests
    {
        [TestMethod]
        public void P1_1_IsUnique_Test()
        {
            var isAllUniqueChars1 = P1_1_IsUnique.HasAllUniqueChars("qwert");
            Assert.IsTrue(isAllUniqueChars1);

            var isAllUniqueChars2 = P1_1_IsUnique.HasAllUniqueChars("qweqrt");
            Assert.IsFalse(isAllUniqueChars2);
        }

        [TestMethod]
        public void P1_2_CheckPermutation_Test()
        {
            var isPermutation1 = P1_2_CheckPermutation.IsPermutation("qwert", "qwter");
            Assert.IsTrue(isPermutation1);

            var isPermutation2 = P1_2_CheckPermutation.IsPermutation("qwert", "qwtex");
            Assert.IsFalse(isPermutation2);
        }

        [TestMethod]
        public void P1_3_URLify_Test()
        {
            var s = "abc  d         ";
            var url = P1_3_URLify.Urlify(s);
            Assert.AreEqual(url, "abc%20%20d");
        }

        [TestMethod]
        public void P1_4_PalindromePermutation_Test()
        {
            Assert.IsTrue(P1_4_PalindromePermutation.IsPermutationOfAPalindrome("asdsa"));
            Assert.IsTrue(P1_4_PalindromePermutation.IsPermutationOfAPalindrome("asdas"));
            Assert.IsFalse(P1_4_PalindromePermutation.IsPermutationOfAPalindrome("asda"));
            Assert.IsFalse(P1_4_PalindromePermutation.IsPermutationOfAPalindrome("asd"));
        }

        [TestMethod]
        public void P1_5_OneAway_Test()
        {
            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("abcd", "abcd"));
            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("abcd", "abxcd"));
            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("abcd", "abd"));
            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("abcd", "abxd"));

            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("", ""));
            Assert.IsTrue(P1_5_OneAway.IsEditDistanceOneAway("a", ""));

            Assert.IsFalse(P1_5_OneAway.IsEditDistanceOneAway("abcd", "abxycd"));
            Assert.IsFalse(P1_5_OneAway.IsEditDistanceOneAway("abcd", "ad"));
            Assert.IsFalse(P1_5_OneAway.IsEditDistanceOneAway("abcd", "axyz"));
            Assert.IsFalse(P1_5_OneAway.IsEditDistanceOneAway("abcd", ""));
        }

        [TestMethod]
        public void P1_6_StringCompression_Test()
        {
            Assert.AreEqual(P1_6_StringCompression.CompressString("aaaabbbcdd"), "a4b3c1d2");
            Assert.AreEqual(P1_6_StringCompression.CompressString("aabbcd"), "aabbcd");
            Assert.AreEqual(P1_6_StringCompression.CompressString("a"), "a");
            Assert.AreEqual(P1_6_StringCompression.CompressString(""), "");
        }

        [TestMethod]
        public void P1_7_RotateMatrix_Test()
        {
            int[][] matrix3x3 =
            {
                new int[] {11, 12, 13},
                new int[] {21, 22, 23},
                new int[] {31, 32, 33},
            };

            P1_7_RotateMatrix.Rotate90DegreesInPlace(matrix3x3);

            int[][] expectedMatrix3x3 =
            {
                new int[] {31, 21, 11},
                new int[] {32, 22, 12},
                new int[] {33, 23, 13},

            };

            for (int i = 0; i < matrix3x3.Length; i++)
            {
                for (int j = 0; j < matrix3x3.Length; j++)
                {
                    Assert.AreEqual(matrix3x3[i][j], expectedMatrix3x3[i][j]);
                }
            }


            int[][] matrix4x4 =
            {
                new int[] {11, 12, 13, 14},
                new int[] {21, 22, 23, 24},
                new int[] {31, 32, 33, 34},
                new int[] {41, 42, 43, 44}
            };

            P1_7_RotateMatrix.Rotate90DegreesInPlace(matrix4x4);

            //0. satır => 3. sütun
            //1. satır => 2. sütun
            //2. satır => 1. sütun
            //3. satır => 0. sütun

            int[][] expectedMatrix4x4 =
            {
                new int[] {41, 31, 21, 11},
                new int[] {42, 32, 22, 12},
                new int[] {43, 33, 23, 13},
                new int[] {44, 34, 24, 14}
            };

            for (int i = 0; i < matrix4x4.Length; i++)
            {
                for (int j = 0; j < matrix4x4.Length; j++)
                {
                    Assert.AreEqual(matrix4x4[i][j], expectedMatrix4x4[i][j]);
                }
            }
        }

        [TestMethod]
        public void P1_8_ZeroMatrix_Test()
        {
            int[][] matrix =
            {
                new int[] {11, 12, 13, 14},
                new int[] {21,  0, 23, 24},
                new int[] {31, 32, 33, 34},
                new int[] {41, 42, 43, 44},
                new int[] {51, 52, 53,  0},
                new int[] {61, 62, 63, 64}
            };

            P1_8_ZeroMatrix.MarkRowsAndColumnsZero(matrix);

            int[][] expectedMatrix =
            {
                new int[] {11, 0, 13, 0},
                new int[] { 0, 0,  0, 0},
                new int[] {31, 0, 33, 0},
                new int[] {41, 0, 43, 0},
                new int[] { 0, 0,  0, 0},
                new int[] {61, 0, 63, 0}
            };

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Assert.AreEqual(matrix[i][j], expectedMatrix[i][j]);
                }
            }
        }

        [TestMethod]
        public void P1_9_StringRotation_Test()
        {
            Assert.IsTrue(P1_9_StringRotation.IsRotationOfString("dfgas", "asdfg"));
            Assert.IsFalse(P1_9_StringRotation.IsRotationOfString("dfgas", "asdf"));
            Assert.IsFalse(P1_9_StringRotation.IsRotationOfString("dfgas", "asdfx"));
        }
    }
}