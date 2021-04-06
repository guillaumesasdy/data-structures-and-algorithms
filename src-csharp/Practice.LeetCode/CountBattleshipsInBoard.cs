using System;

namespace Practice.LeetCode
{
    public class CountBattleshipsInBoard
    {
        public void Run()
        {
            throw new NotImplementedException("All tests pass on Leetcode.");
        }

        public int CountBattleships(char[][] board)
        {
            int count = 0;
            
            for (int i = 0; i < board.GetLength(0); i++)
            for (int j = 0; j < board[i].GetLength(0); j++)
            if (board[i][j] == 'X')
            {
                bool left = (i == 0) || (board[i - 1][j] == '.');
                bool up = (j == 0) || (board[i][j - 1] == '.');
                if (left & up)
                    count++;
            }

            return count;
        }
    }
}