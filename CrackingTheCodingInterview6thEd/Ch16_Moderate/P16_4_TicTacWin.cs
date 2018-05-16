using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_4_TicTacWin
    {
        public static bool IsWin(int[][] board)
        {
            //should be square board
            if (board.Length < 1 || board[0].Length < 1 || board.Length != board[0].Length)
                return false;
            //if any row or column or diagonal is same color, some player has won the game

            var boardLength = board[0].Length;

            if (checkDiagonal1(board, boardLength) || checkDiagonal2(board, boardLength))
                return true;

            for (int i = 0; i < boardLength; i++)
            {
                if (checkRow(i, board, boardLength) || checkColumn(i, board, boardLength))
                    return true;
            }

            return false;
        }

        private static bool checkRow(int rowIndex, int[][] board, int boardLength)
        {
            var left = board[rowIndex][0];
            if (left == 0)
                return false;

            for (int i = 1; i < boardLength; i++)
            {
                if (board[rowIndex][i] != left)
                    return false;
            }

            return true;
        }

        private static bool checkColumn(int columnIndex, int[][] board, int boardLength)
        {
            var top = board[0][columnIndex];
            if (top == 0)
                return false;

            for (int i = 1; i < boardLength; i++)
            {
                if (board[i][columnIndex] != top)
                    return false;
            }

            return true;
        }

        private static bool checkDiagonal1(int[][] board, int boardLength)
        {
            var topleft = board[0][0];
            if (topleft == 0)
                return false;

            for (int i = 1; i < boardLength; i++)
            {
                if (board[i][i] != topleft)
                    return false;
            }

            return true;
        }

        private static bool checkDiagonal2(int[][] board, int boardLength)
        {
            var topright = board[0][boardLength - 1];
            if (topright == 0)
                return false;

            for (int i = 1; i < boardLength; i++)
            {
                if (board[i][boardLength - 1] != topright)
                    return false;
            }

            return true;
        }

    }

}
