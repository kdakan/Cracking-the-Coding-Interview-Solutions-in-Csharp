using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo;

namespace AlgoTest
{
    [TestClass]
    public class AlgoTest
    {
        [TestMethod]
        public void IsPalindromePermutation()
        {
            var isPalindromePermutation1 = PalindromePermutation.IsPermutationOfAPalindrome("abecbae");//perm. of abeceba
            Assert.IsTrue(isPalindromePermutation1);
            var isPalindromePermutation2 = PalindromePermutation.IsPermutationOfAPalindrome("abecba");
            Assert.IsFalse(isPalindromePermutation2);
        }

        [TestMethod]
        public void StringCompress()
        {
            //aaaabbbcdd => compressed: a4b3c1d2 return compressed
            //aabbcd => compressed: a2b2c1d1 return original (because compressed is longer)
            var compressed1 = StringCompression.CompressString("aaaabbbcdd");
            Assert.AreEqual(compressed1, "a4b3c1d2");
            var compressed2 = StringCompression.CompressString("aabbcd");
            Assert.AreEqual(compressed2, "aabbcd");
        }

        [TestMethod]
        public void RotateMatrix()
        {
            int[][] matrix =
            {
                new int[] {11, 12, 13, 14},
                new int[] {21, 22, 23, 24},
                new int[] {31, 32, 33, 34},
                new int[] {41, 42, 43, 44}
            };

            MatrixRotation.Rotate90DegreesInPlace(matrix);

            //0. satır => 3. sütun
            //1. satır => 2. sütun
            //2. satır => 1. sütun
            //3. satır => 0. sütun

            int[][] expectedMatrix =
            {
                new int[] {41, 31, 21, 11},
                new int[] {42, 32, 22, 12},
                new int[] {43, 33, 23, 13},
                new int[] {44, 34, 24, 14}
            };

            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(matrix[i][j], expectedMatrix[i][j]);
                }
            }

        }
    }
}
