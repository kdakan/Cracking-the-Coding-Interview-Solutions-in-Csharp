using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_11_DivingBoard
    {
        public static HashSet<int> FindAllPossibleLengths(int numberOfPlanks, int shortPlankLength, int longPlankLength)
        {
            //find all possible kengths of a board built from K number of small and large planks
            //               0       
            //           /       \
            //         /           \
            //       S               L    
            //     /   \           /   \
            //    /     \         /     \
            //   S       L       S       L
            // /   \   /   \   /   \   /   \
            //S     L S     L S     L S     L                                                             

            var boardSizeSet = new HashSet<int>();

            visit(shortPlankLength, longPlankLength, numberOfPlanks, 0, boardSizeSet, shortPlankLength);
            visit(shortPlankLength, longPlankLength, numberOfPlanks, 0, boardSizeSet, longPlankLength);

            return boardSizeSet;
        }

        private static void visit(int shortPlankLength, int longPlankLength, int numberOfPlanks, int boardSize, HashSet<int> boardSizeSet, int plankLength)
        {
            if (numberOfPlanks == 0)
            {
                boardSizeSet.Add(boardSize);
                return;
            }

            boardSize += plankLength;

            numberOfPlanks--;

            visit(shortPlankLength, longPlankLength, numberOfPlanks, boardSize, boardSizeSet, shortPlankLength);
            visit(shortPlankLength, longPlankLength, numberOfPlanks, boardSize, boardSizeSet, longPlankLength);
        }

        public static HashSet<int> FindAllPossibleLengthsOptimized(int numberOfPlanks, int shortPlankLength, int longPlankLength)
        {
            //find all possible kengths of a board built from K number of small and large planks
            //               0       
            //           /       \
            //         /           \
            //       S               L    
            //     /   \           /   \
            //    /     \         /     \
            //   S       L       S       L
            // /   \   /   \   /   \   /   \
            //S     L S     L S     L S     L                                                             

            //boardSize count is always numberOfPlanks + 1, 
            //because all size possibilities are: 0 short, 1 short, 2 shorts, .. numberOfPlanks shorts

            var boardSizeSet = new HashSet<int>();

            for (int i = 0; i <= numberOfPlanks; i++)
                boardSizeSet.Add(shortPlankLength * i + longPlankLength * (numberOfPlanks - i));

            return boardSizeSet;
        }

    }

}
