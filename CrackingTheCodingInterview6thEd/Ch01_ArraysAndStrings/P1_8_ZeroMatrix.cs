using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_8_ZeroMatrix
    {
        public static void MarkRowsAndColumnsZero(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return;

            var zeroedRowIndexSet = new HashSet<int>();
            var zeroedColumnIndexSet = new HashSet<int>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        if (!zeroedRowIndexSet.Contains(row))
                            zeroedRowIndexSet.Add(row);

                        if (!zeroedColumnIndexSet.Contains(col))
                            zeroedColumnIndexSet.Add(col);
                    }
                }
            }

            foreach(var row in zeroedRowIndexSet)
            {
                for (int c = 0; c < matrix[row].Length; c++)
                    matrix[row][c] = 0;
            }

            foreach (var col in zeroedColumnIndexSet)
            {
                for (int r = 0; r < matrix.Length; r++)
                    matrix[r][col] = 0;
            }

        }
    }
}
