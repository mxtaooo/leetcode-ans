using System;
using System.Collections.Generic;

namespace CSharpConsoleApp
{
    class Program
    {
        static bool IsValidSudoku(char[][] board)
        {
            char[] cache = new char[9];

            bool IsUnique(char[] chars)
            {
                var set = new HashSet<char>(9);
                foreach (var c in chars)
                {
                    if (c != '.')
                    {
                        if (set.Contains(c))
                        {
                            return false;
                        }
                        else
                        {
                            set.Add(c);
                        }
                    }
                }
                return true;
            }
            bool CheckRow(int row)
            {
                return IsUnique(board[row]);
            }
            bool CheckColumn(int column)
            {
                for (int row = 0; row < 9; row++)
                {
                    cache[row] = board[row][column];
                }
                return IsUnique(cache);
            }
            bool CheckBox(int row, int column)
            {
                var index = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        cache[index++] = board[row + i][column + j];
                    }
                }
                return IsUnique(cache);
            }

            for (int i = 0; i < 9; i++)
            {
                if (!CheckRow(i) || !CheckColumn(i))
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    if (!CheckBox(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var chars = new char[][]
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };
            Console.WriteLine(IsValidSudoku(chars));

            var @char = new char[][]
            {
                new char[] {'8','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };
            Console.WriteLine(IsValidSudoku(@char));
        }
    }
}
